using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

using OpenBox;
using LiteBox.LMath;

public struct VoxelHit {
    /// The index of the voxel that was hit.
    public Vec3i index;

    /// The index of the voxel immediately before the hit (possibly out of bounds).
    public Vec3i neighborIndex;

    /// World position of the hit.
    public Vector3 point;

    /// Surface normal of the hit voxel in world space.
    public Vector3 normal;

    /// Distance from the ray's origin to the hit.
    public float distance;
}

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class VoxelComponent : MonoBehaviour {
    public VoxelSet<Color32> voxels { get; set; }

    public void Clear() {
        voxels = null;

        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf.mesh) {
            Destroy(mf.mesh);
            mf.mesh = null;
        }
    }

    /// Adds indices of the specified range to the specified submesh.
    static void AddMeshIndices(int idxCount, Mesh mesh, int baseIdx, int submeshIdx) {
        int[] indices = new int[idxCount];

        for (int i = 0; i < idxCount; ++i) {
            indices[i] = i + baseIdx;
        }

        mesh.SetIndices(indices, MeshTopology.Points, submeshIdx);
    }

    /// Adds all geometry in the given quad lists to the given mesh.
    static int AddMeshGeometry(PointQuadList[] quads, Mesh mesh) {
        int geometryCount = 0;
        int subMeshCount = 0;

        foreach (var q in quads) {
            geometryCount += q.count;

            if (q.count > 0) {
                subMeshCount++;
            }
        }

        // Flatten into mesh
        Vector3[] points = new Vector3[geometryCount];
        Color32[] colors = new Color32[geometryCount];
        Vector2[] uvs = new Vector2[geometryCount];

        var pointsHandle = GCHandle.Alloc(points, GCHandleType.Pinned);
        var colorsHandle = GCHandle.Alloc(colors, GCHandleType.Pinned);
        var uvsHandle = GCHandle.Alloc(uvs, GCHandleType.Pinned);

        int facesFilled = 0;
        for (int i = 0; i < quads.Length; ++i) {
            OpenBoxNative.CopyFaceGeometry(
                quads[i].handle,
                Marshal.UnsafeAddrOfPinnedArrayElement(points, facesFilled),
                Marshal.UnsafeAddrOfPinnedArrayElement(uvs, facesFilled),
                Marshal.UnsafeAddrOfPinnedArrayElement(colors, facesFilled)
            );
        }

        pointsHandle.Free();
        colorsHandle.Free();
        uvsHandle.Free();

        mesh.vertices = points;
        mesh.colors32 = colors;
        mesh.uv = uvs;

        return subMeshCount;
    }

    void MakeMeshFromQuadLists(PointQuadList opaqueFaces, PointQuadList transparentFaces) {
        Mesh mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        int subMeshCount = AddMeshGeometry(new PointQuadList[] {
            opaqueFaces,
            transparentFaces
        }, mesh);
        mesh.subMeshCount = subMeshCount;

        Material[] materials = new Material[subMeshCount];

        int submeshIdx = 0;
        int nextPointIdx = 0;

        // Opaque quads
        if (opaqueFaces.count > 0) {
            AddMeshIndices(opaqueFaces.count, mesh, nextPointIdx, submeshIdx);
            materials[submeshIdx] = new Material(Shader.Find("Voxel/PointQuads"));

            nextPointIdx += opaqueFaces.count;
            submeshIdx++;
        }

        // Transparent quads
        if (transparentFaces.count > 0) {
            AddMeshIndices(transparentFaces.count, mesh, nextPointIdx, submeshIdx);
            materials[submeshIdx] = new Material(Shader.Find("Voxel/PointQuadsTransparent"));

            nextPointIdx += transparentFaces.count;
            submeshIdx++;
        }

        GetComponent<MeshRenderer>().materials = materials;
        GetComponent<MeshFilter>().mesh = mesh;
    }

    /// Loads a MagicaVoxel model into the current model.
    public void LoadMagicaModel(string magicaVoxelFile, bool retainVoxels) {
        Clear();

        PointQuadList opaqueFaces = new PointQuadList();
        PointQuadList transparentFaces = new PointQuadList();

        IntPtr model = OpenBoxNative.MagicaLoadModel(magicaVoxelFile);
        OpenBoxNative.MagicaExtractFaces(model, ref opaqueFaces, ref transparentFaces);

        if (retainVoxels) {
            // Copy voxels over to the C# side
            voxels = new VoxelSet<Color32>(OpenBoxNative.MagicaModelSize(model));
            OpenBoxNative.MagicaCopyVoxels(voxels.Pin(), model);
            voxels.Unpin();
        }

        OpenBoxNative.MagicaFreeModel(model);

        MakeMeshFromQuadLists(opaqueFaces, transparentFaces);

        OpenBoxNative.FreeFacesHandle(opaqueFaces.handle);
        OpenBoxNative.FreeFacesHandle(transparentFaces.handle);
    }

    /// Turns the current voxel set into a mesh, replacing any currently attached mesh.
	public void UpdateMesh() {
        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf.mesh) {
            Destroy(mf.mesh);
            mf.mesh = null;
        }

        PointQuadList opaqueFaces = new PointQuadList();
        PointQuadList transparentFaces = new PointQuadList();

        IntPtr voxelsPtr = voxels.Pin();
        OpenBoxNative.ExtractFaces(voxelsPtr, voxels.Size, ref opaqueFaces, ref transparentFaces);
        voxels.Unpin();

        MakeMeshFromQuadLists(opaqueFaces, transparentFaces);

        OpenBoxNative.FreeFacesHandle(opaqueFaces.handle);
        OpenBoxNative.FreeFacesHandle(transparentFaces.handle);
    }

    #region Layer Marching
    const float kEps = 0.00005f;

    public bool RaycastVoxel(Vector3 origin, Vector3 direction, out VoxelHit hitInfo) {
        hitInfo = new VoxelHit();

        if (voxels == null) {
            throw new InvalidOperationException("Tried to raycast on an empty voxel set");
        }

        Vector3 size = VecUtil.Mul(new Vector3(voxels.Size.x, voxels.Size.y, voxels.Size.z), transform.lossyScale);

        // TODO: Does this account for scale properly? Probably not.
        Ray ray = new Ray(
            transform.InverseTransformPoint(origin),
            transform.InverseTransformDirection(direction)
        );

        bool inside = true;

        // Check each dimension to see if origin is inside the voxel set
        for (int i = 0; i < 3; ++i) {
            if (ray.origin[i] < 0 || ray.origin[i] > size[i]) {
                inside = false;
            }
        }

        if (!inside) {
            // Find a point on the surface to start at.
            float minT = float.PositiveInfinity;

            // Find first intersection
            for (int i = 0; i < 3; ++i) {
                if (ray.direction[i] == 0) {
                    continue;
                }

                for (int j = 0; j < 2; ++j) {
                    // TODO: Use true int size instead?
                    float t = (j * size[i] - ray.origin[i]) / ray.direction[i];

                    if (t < 0) {
                        continue;
                    }

                    Vector3 probePoint = ray.origin + ray.direction * t;
                    bool validHit = true;

                    for (int k = 0; k < 3; ++k) {
                        if (k == i) {
                            // Current dimension *must* hit; don't check to avoid precision issues
                            continue;
                        }

                        if (probePoint[k] < 0 || probePoint[k] > size[k]) {
                            validHit = false;
                        }
                    }

                    if (validHit) {
                        minT = Mathf.Min(t, minT);
                    }
                }
            }

            // TODO: Be more elegant about an invalid minT (no hit)
            ray.origin += (minT + kEps) * ray.direction;
        }

        float dist;
        if (LayerMarch(ray.origin, ray.direction, out hitInfo.index, out hitInfo.neighborIndex, out dist)) {
            hitInfo.point = transform.TransformPoint(ray.GetPoint(dist));
            // TODO: Find a quicker way to do this; must account for non-uniform scale
            hitInfo.distance = (hitInfo.point - origin).magnitude;

            Vec3i delta = hitInfo.neighborIndex - hitInfo.index;
            hitInfo.normal = transform.TransformDirection(new Vector3(delta.x, delta.y, delta.z));
            return true;
        } else {
            return false;
        }
    }

    Vec3i ToIndex(Vector3 v) {
        //v += 0.5f * Vector3.one;
        //return new Vec3i((int)v.x, (int)v.y, (int)v.z);
        return new Vec3i((int)v.x, (int)v.y, (int)v.z);
    }

    bool LayerMarch(Vector3 startPoint, Vector3 dir, out Vec3i hitIdx, out Vec3i lastIdx, out float t) {
        dir = Vector3.Normalize(dir);

        Vector3 voxelGridSize = new Vector3(voxels.Size.x, voxels.Size.y, voxels.Size.z);

        Vector3 p0 = startPoint;
        float endT = VecUtil.MinComp(Vector3.Max(
            VecUtil.Div(voxelGridSize - p0, dir),
            VecUtil.Div(-p0, dir)
        ));

        Vector3 p0abs = VecUtil.Mul(Vector3.one - VecUtil.Step(0, dir), voxelGridSize)
            + VecUtil.Mul(VecUtil.Sign(dir), p0);
        Vector3 dirAbs = VecUtil.Abs(dir);

        //float t = 0;
        t = 0;
        lastIdx = ToIndex(p0 + dir * (t - kEps));
        while (t <= endT) {
            Vec3i idx = ToIndex(p0 + dir * (t + kEps));

            if (!voxels.IsValid(idx)) {
                break;
            }

            Color32 c = voxels[idx];
            if (c.a > 0) {
                hitIdx = idx;
                return true;
            }

            lastIdx = idx;

            Vector3 pAbs = p0abs + dirAbs * t;
            Vector3 deltas = VecUtil.Div(Vector3.one - VecUtil.Fract(pAbs), dirAbs);
            t += Mathf.Max(VecUtil.MinComp(deltas), float.Epsilon);
        }

        hitIdx = new Vec3i(-1);
        return false;
    }

    #endregion
}
