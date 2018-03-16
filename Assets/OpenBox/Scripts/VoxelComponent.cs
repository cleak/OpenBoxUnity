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
public class VoxelComponent : MonoBehaviour, ISerializationCallbackReceiver {
    public VoxelSet<Color32> voxels;
    public VoxelFactory.ColliderType colliderType;
    public GameObject colliders;

    public void Clear() {
        voxels = null;

#if !UNITY_EDITOR
        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf.sharedMesh != null) {
            Destroy(mf.sharedMesh);
            mf.sharedMesh = null;
        }
#endif

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

        GetComponent<MeshRenderer>().sharedMaterials = materials;
        GetComponent<MeshFilter>().sharedMesh = mesh;
    }

    /// Loads a MagicaVoxel model into the current model.
    public void LoadMagicaModel(string magicaVoxelFile, bool retainVoxels, VoxelFactory.ColliderType colliderType, MagicaFlags flags) {
        Clear();

        this.colliderType = colliderType;

        PointQuadList opaqueFaces = new PointQuadList();
        PointQuadList transparentFaces = new PointQuadList();

        IntPtr model = OpenBoxNative.MagicaLoadModel(magicaVoxelFile, flags);
        OpenBoxNative.MagicaExtractFaces(model, ref opaqueFaces, ref transparentFaces);

        if (retainVoxels || colliderType != VoxelFactory.ColliderType.None) {
            // Copy voxels over to the C# side
            voxels = new VoxelSet<Color32>(OpenBoxNative.MagicaModelSize(model));
            OpenBoxNative.MagicaCopyVoxels(voxels.Pin(), model);
            voxels.Unpin();

            // TODO: Calculate colliders natively
            UpdateColliders();
        }

        OpenBoxNative.MagicaFreeModel(model);

        MakeMeshFromQuadLists(opaqueFaces, transparentFaces);

        OpenBoxNative.FreeFacesHandle(opaqueFaces.handle);
        OpenBoxNative.FreeFacesHandle(transparentFaces.handle);
    }

    /// Turns the current voxel set into a mesh, replacing any currently attached mesh.
	public void UpdateMesh() {
        MeshFilter mf = GetComponent<MeshFilter>();

        // TODO: Remove old mesh?

        PointQuadList opaqueFaces = new PointQuadList();
        PointQuadList transparentFaces = new PointQuadList();

        IntPtr voxelsPtr = voxels.Pin();
        OpenBoxNative.ExtractFaces(voxelsPtr, voxels.Size, ref opaqueFaces, ref transparentFaces);
        voxels.Unpin();

        MakeMeshFromQuadLists(opaqueFaces, transparentFaces);

        OpenBoxNative.FreeFacesHandle(opaqueFaces.handle);
        OpenBoxNative.FreeFacesHandle(transparentFaces.handle);
    }

    public void UpdateColliders() {
        if (colliders) {
#if UNITY_EDITOR
            DestroyImmediate(colliders);
            colliders = null;
#else
            Destroy(colliders);
            colliders = null;
#endif
        }

        if (colliderType != VoxelFactory.ColliderType.None) {
            colliders = new GameObject("Colliders");
            colliders.transform.SetParent(transform, false);
            VoxelFactory.AddColliders(colliders, voxels, colliderType);
        }
    }

    #region Layer Marching
    //const float kEps = 0.00005f;
    const float kEps = 0.005f;
    //const float kEps = float.Epsilon * 16;
    //const float kEps = float.Epsilon;
    //const float kEps = float.Epsilon;
    //const float kEps = 0;

    public bool RaycastVoxel(Vector3 origin, Vector3 direction, out VoxelHit hitInfo) {
        hitInfo = new VoxelHit();

        direction = Vector3.Normalize(direction);

        if (voxels == null) {
            throw new InvalidOperationException("Tried to raycast on an empty voxel set");
        }

        //Vector3 size = VecUtil.Mul(new Vector3(voxels.Size.x, voxels.Size.y, voxels.Size.z), transform.lossyScale);
        Vector3 size = new Vector3(voxels.Size.x, voxels.Size.y, voxels.Size.z);

        // TODO: Does this account for scale properly? Probably not.
        Ray ray = new Ray(
            transform.InverseTransformPoint(origin),
            transform.InverseTransformVector(direction)
        );

        bool inside = true;

        // Check each dimension to see if origin is inside the voxel set
        for (int i = 0; i < 3; ++i) {
            if (ray.origin[i] < 0 || ray.origin[i] > size[i]) {
                inside = false;
            }
        }

        float dist = 0;
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
            //ray.origin += (minT + kEps) * ray.direction;
            //ray.origin += (minT + 0.00005f) * ray.direction;
            dist = minT + 0.00005f;
        }

        if (LayerMarch(ray.origin, ray.direction, out hitInfo.index, out hitInfo.neighborIndex, ref dist)) {
            hitInfo.point = transform.TransformPoint(ray.GetPoint(dist));
            // TODO: Find a quicker way to do this; must account for non-uniform scale
            hitInfo.distance = (hitInfo.point - origin).magnitude;

            Vec3i finalIdx = ToIndex(transform.InverseTransformPoint(origin + direction * (hitInfo.distance + kEps)));
            if (finalIdx.x != hitInfo.index.x ||
                finalIdx.y != hitInfo.index.y ||
                finalIdx.z != hitInfo.index.z) {
                Debug.LogError("Final hit mismatch. Expected " + finalIdx + " but was " + hitInfo.index);
            }

            Vec3i delta = hitInfo.neighborIndex - hitInfo.index;
            hitInfo.normal = transform.TransformDirection(new Vector3(delta.x, delta.y, delta.z));
            return true;
        } else {
            return false;
        }
    }

    Vec3i ToIndex(Vector3 v) {
        return new Vec3i((int)v.x, (int)v.y, (int)v.z);
    }

    bool LayerMarch(Vector3 startPoint, Vector3 dir, out Vec3i hitIdx, out Vec3i lastIdx, ref float t) {
        dir = Vector3.Normalize(dir);

        Vector3 voxelGridSize = new Vector3(voxels.Size.x, voxels.Size.y, voxels.Size.z);

        Vector3 p0 = startPoint;
        float endT = VecUtil.MinComp(Vector3.Max(
            VecUtil.Div(voxelGridSize - p0, dir),
            VecUtil.Div(-p0, dir)
        ));

        Vector3 dirAbs = VecUtil.Abs(dir);

        // TODO: This is making invalid assumptions about p0
        //Vector3 p0abs = VecUtil.Mul(Vector3.one - VecUtil.Step(0, dir), voxelGridSize)
        //    + VecUtil.Mul(VecUtil.Sign(dir), p0);

        //Vector3 negativeDimensions = Vector3.one - VecUtil.Step(0, dir);
        //Vector3 p0abs = VecUtil.Mul(negativeDimensions, voxelGridSize) - VecUtil.Mul(negativeDimensions, p0)
        //+ VecUtil.Mul(VecUtil.Step(0, dir), p0);

        Vector3 p0abs = p0;

        for (int i = 0; i < 3; ++i) {
            if (dir[i] < 0) {
                p0abs[i] = voxelGridSize[i] - p0[i];
            }
        }

        //float t = 0;
        //t = 0;
        lastIdx = ToIndex(p0 + dir * (t - kEps));
        int iterationCount = 0;
        List<Vector3> debugPos = new List<Vector3>();
        List<Vector3> debugPosAbs = new List<Vector3>();

        t += kEps;

        while (t <= endT) {
            Vec3i idx = ToIndex(p0 + dir * (t + kEps));
            debugPos.Add(p0 + dir * (t + kEps));
            //Vec3i idx = ToIndex(p0 + dir * t);

            debugPosAbs.Add(p0abs + dirAbs * (t + kEps));
            Vector3 pAbs = p0abs + dirAbs * (t + kEps);

            ////////////////
            // DEBUG CODE
            Vec3i delta = idx - lastIdx;
            if (Vec3i.Dot(delta, delta) > 1) {
                Debug.LogWarning("Skipped a voxel");
            }

            if (!voxels.IsValid(idx)) {
                break;
            }

            Color32 c = voxels[idx];
            if (c.a > 0) {
                hitIdx = idx;
                return true;
            }

            lastIdx = idx;

            // Pretend we came in from a positive direction
            
            //Vector3 pAbs = p0abs + dirAbs * (t);
            Vector3 deltas = VecUtil.Div(Vector3.one - VecUtil.Fract(pAbs), dirAbs);
            //t += Mathf.Max(VecUtil.MinComp(deltas), float.Epsilon);
            //t += Mathf.Max(VecUtil.MinComp(deltas), 0.0005f);
            t += Mathf.Max(VecUtil.MinComp(deltas), kEps) + kEps;

            //Vector3 pAbs = p0abs + dirAbs * t;
            //Vector3 deltas = VecUtil.Div(Vector3.one - VecUtil.Fract(pAbs), dirAbs);
            //t += Mathf.Max(VecUtil.MinComp(deltas), float.Epsilon);

            //Vector3 pAbs = p0abs + dirAbs * t;
            //Vector3 p = p0 + dir * t;
            //Vector3 deltas = VecUtil.Div(VecUtil.Step(0, dir) - VecUtil.Fract(p), dir);
            //t += Mathf.Max(VecUtil.MinComp(deltas), 0.0005f);
            //t += Mathf.Max(VecUtil.MinComp(deltas), float.Epsilon);
            iterationCount++;
        }

        hitIdx = new Vec3i(-1);
        return false;
    }

    [SerializeField]
    [HideInInspector]
    private Color32[] serializeVoxelColors;

    [SerializeField]
    [HideInInspector]
    private Vector3Int serializeVoxelDimension;

    public void OnBeforeSerialize() {
        if (voxels == null) {
            return;
        }

        serializeVoxelDimension = new Vector3Int(
            voxels.Size.x,
            voxels.Size.y,
            voxels.Size.z
        );

        // TODO: MemCopy would be better
        serializeVoxelColors = new Color32[serializeVoxelDimension.x * serializeVoxelDimension.y * serializeVoxelDimension.z];
        for (int z = 0; z < serializeVoxelDimension.z; ++z) {
            for (int y = 0; y < serializeVoxelDimension.y; ++y) {
                int offset = y * serializeVoxelDimension.x
                    + z * serializeVoxelDimension.y * serializeVoxelDimension.x;
                for (int x = 0; x < serializeVoxelDimension.x; ++x) {
                    serializeVoxelColors[offset + x] = voxels[x, y, z];
                }
            }
        }
    }

    public void OnAfterDeserialize() {
        if (serializeVoxelColors == null) {
            return;
        }

        voxels = new VoxelSet<Color32>(
            serializeVoxelDimension.x,
            serializeVoxelDimension.y,
            serializeVoxelDimension.z
        );

        // TODO: MemCopy would be better
        for (int z = 0; z < serializeVoxelDimension.z; ++z) {
            for (int y = 0; y < serializeVoxelDimension.y; ++y) {
                int offset = y * serializeVoxelDimension.x
                    + z * serializeVoxelDimension.y * serializeVoxelDimension.x;
                for (int x = 0; x < serializeVoxelDimension.x; ++x) {
                    voxels[x, y, z] = serializeVoxelColors[offset + x];
                }
            }
        }

        serializeVoxelColors = null;
    }

    #endregion
}
