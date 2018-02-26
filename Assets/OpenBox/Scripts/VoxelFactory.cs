using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

using OpenBox;
using LiteBox.LMath;

public class VoxelFactory {
    public enum ColliderType {
        None,
        Exact,
        HalfScale,
        ThirdScale,
        QuarterScale
    }

    public enum VoxelMaterial {
        Opaque,
        Transparent
        //Emissive
    }

    struct Quad {
        public Vector3 position;
        public Color32 color;
        public Vector2 uv;
    }

    static bool IsTransparent(VoxelSet<Vec4b> voxels, Vec3i idx) {
        return voxels[idx].w > 0 && voxels[idx].w < 255;
    }

    ////////////////////////////////////////////////////////////////////////////
    // Native interop

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    struct PointQuadList {
        public int count;
        public IntPtr handle;
    };

    [DllImport("NativeBox.dll")]
    static extern unsafe IntPtr obx_MagicaLoadModel([MarshalAs(UnmanagedType.LPStr)]String filepath);

    [DllImport("NativeBox.dll")]
    static extern unsafe IntPtr obx_MagicaExtractFaces(IntPtr model, ref PointQuadList opaqueFaces, ref PointQuadList transparentFaces);

    [DllImport("NativeBox.dll")]
    static extern void obx_MagicaFreeModel(IntPtr handle);

    [DllImport("NativeBox.dll")]
    static extern unsafe void obx_ExtractFaces(IntPtr colors, Vec3i size, ref PointQuadList opaqueFaces, ref PointQuadList transparentFaces);

    // void obx_CopyFaceGeometry(Faces* faces, vec3* points, vec2* faceIndices, ubvec4* colors) {
    [DllImport("NativeBox.dll")]
    static extern unsafe void obx_CopyFaceGeometry(IntPtr facesHandle, IntPtr points, IntPtr faceIndices, IntPtr colors);

    [DllImport("NativeBox.dll")]
    static extern void obx_FreeFacesHandle(IntPtr handle);

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
            obx_CopyFaceGeometry(
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

    static void MakeMeshFromQuadLists(PointQuadList opaqueFaces, PointQuadList transparentFaces, out Mesh mesh, out Material[] materials) {
        mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        int subMeshCount = AddMeshGeometry(new PointQuadList[] {
            opaqueFaces,
            transparentFaces
        }, mesh);
        mesh.subMeshCount = subMeshCount;

        materials = new Material[subMeshCount];

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
    }

    // Makes a mesh from the given voxel set.
    public static void MakeMeshNative(VoxelSet<Vec4b> voxels, out Mesh mesh, out Material[] materials) {
        PointQuadList opaqueFaces = new PointQuadList();
        PointQuadList transparentFaces = new PointQuadList();

        IntPtr voxelsPtr = voxels.Pin();
        obx_ExtractFaces(voxelsPtr, voxels.Size, ref opaqueFaces, ref transparentFaces);
        voxels.Unpin();

        MakeMeshFromQuadLists(opaqueFaces, transparentFaces, out mesh, out materials);

        obx_FreeFacesHandle(opaqueFaces.handle);
        obx_FreeFacesHandle(transparentFaces.handle);
    }


    public static void MakeMeshNative(string magicaVoxelFile, out Mesh mesh, out Material[] materials) {
        PointQuadList opaqueFaces = new PointQuadList();
        PointQuadList transparentFaces = new PointQuadList();

        IntPtr model = obx_MagicaLoadModel(magicaVoxelFile);
        obx_MagicaExtractFaces(model, ref opaqueFaces, ref transparentFaces);
        obx_MagicaFreeModel(model);

        MakeMeshFromQuadLists(opaqueFaces, transparentFaces, out mesh, out materials);

        obx_FreeFacesHandle(opaqueFaces.handle);
        obx_FreeFacesHandle(transparentFaces.handle);
    }


    ////////////////////////////////////////////////////////////////////////////



    // Adds all faces for the given index of the given voxels to the list of quads.
    static void AddFaces(VoxelSet<Vec4b> voxels, List<Quad> quads, Vec3i idx) {
        Vec3i[] normals = {
            new Vec3i(1, 0, 0),
            new Vec3i(-1, 0, 0),

            new Vec3i(0, 1, 0),
            new Vec3i(0, -1, 0),

            new Vec3i(0, 0, 1),
            new Vec3i(0, 0, -1)
        };

        bool transparent = IsTransparent(voxels, idx);

        for (int i = 0; i < normals.Length; ++i) {
            Vec3i normal = normals[i];
            Vec3i neighbor = idx + normal;
            if (voxels.IsValid(neighbor) && (voxels[neighbor].w > 0)) {
                if (transparent && IsTransparent(voxels, neighbor)) {
                    // Two transparent voxels - face is hidden.
                    continue;
                }

                if (transparent && voxels[neighbor].w == 255) {
                    // Transparent self and opaque neighbor - hidden to avoid z-fighting.
                    continue;
                }

                if (!transparent && voxels[neighbor].w == 255) {
                    // Two opaque voxels - face is hidden.
                    continue;
                }
            }

            var c = voxels[idx];
            Quad q = new Quad();

            q.color = new Color32(c.x, c.y, c.z, c.w);

            Vec3i pos = idx;

            if (Vec3i.Dot(normal, new Vec3i(1)) > 0) {
                pos += normal;
            }

            q.position = new Vector3(pos.x, pos.y, pos.z);
            q.uv = new Vector2(i, 0);

            quads.Add(q);

            if (transparent) {
                // Add back facing as well for transparent quads
                //q.uv = new Vector2((i - (i % 2)) + ((i + 1) % 2), 0);
                q.uv = new Vector2(i ^ 1, 0);
                //q.position += new Vector3(normal.x, normal.y, normal.z);
                quads.Add(q);
            }
        }
    }

    // Adds geometry for the given quads to the mesh and returns the number of submeshes.
    static int AddMeshGeometry(List<Quad>[] quads, Mesh mesh) {
        int geometryCount = 0;
        int subMeshCount = 0;

        foreach (var q in quads) {
            geometryCount += q.Count;

            if (q.Count > 0) {
                subMeshCount++;
            }
        }

        // Flatten into mesh
        Vector3[] points = new Vector3[geometryCount];
        Color32[] colors = new Color32[geometryCount];
        Vector2[] uvs = new Vector2[geometryCount];

        int idx = 0;
        foreach (var quadList in quads) {
            foreach (var quad in quadList) {
                points[idx] = quad.position;
                colors[idx] = quad.color;
                uvs[idx] = quad.uv;
                idx++;
            }
        }

        mesh.vertices = points;
        mesh.colors32 = colors;
        mesh.uv = uvs;

        return subMeshCount;
    }

    static void AddMeshIndices(int idxCount, Mesh mesh, int baseIdx, int submeshIdx) {
        int[] indices = new int[idxCount];

        for (int i = 0; i < idxCount; ++i) {
            indices[i] = i + baseIdx;
        }

        mesh.SetIndices(indices, MeshTopology.Points, submeshIdx);
    }

    // Makes a mesh from the given voxel set.
    public static void MakeMesh(VoxelSet<Vec4b> voxels, out Mesh mesh, out Material[] materials) {
        List<Quad> quads = new List<Quad>();
        List<Quad> transparentQuads = new List<Quad>();

        // Find all visible faces
        for (int z = 0; z < voxels.Size.z; ++z) {
            for (int y = 0; y < voxels.Size.y; ++y) {
                for (int x = 0; x < voxels.Size.x; ++x) {
                    if (voxels[x, y, z].w <= 0) {
                        // Empty; skip
                        continue;
                    }

                    if (voxels[x, y, z].w < 255) {
                        AddFaces(voxels, transparentQuads, new Vec3i(x, y, z));
                    } else {
                        AddFaces(voxels, quads, new Vec3i(x, y, z));
                    }
                }
            }
        }

        mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        int subMeshCount = AddMeshGeometry(new List<Quad>[] {
            quads,
            transparentQuads
        }, mesh);
        mesh.subMeshCount = subMeshCount;

        materials = new Material[subMeshCount];

        int submeshIdx = 0;
        int nextPointIdx = 0;

        // Opaque quads
        if (quads.Count > 0) {
            AddMeshIndices(quads.Count, mesh, nextPointIdx, submeshIdx);
            materials[submeshIdx] = new Material(Shader.Find("Voxel/PointQuads"));

            nextPointIdx += quads.Count;
            submeshIdx++;
        }

        // Transparent quads
        if (transparentQuads.Count > 0) {
            AddMeshIndices(transparentQuads.Count, mesh, nextPointIdx, submeshIdx);
            materials[submeshIdx] = new Material(Shader.Find("Voxel/PointQuadsTransparent"));

            nextPointIdx += transparentQuads.Count;
            submeshIdx++;
        }
    }

    // Makes a set of covers to completely cover the given shape.
    static List<BoxMaker.Box> MakeBoxes(VoxelSet<bool> shape, int scale) {
        List<BoxMaker.Box> boxes = BoxMaker.MakeBoxes(shape);

        if (scale != 1) {
            foreach (var box in boxes) {
                box.extents *= scale;
                box.origin *= scale;
            }
        }

        return boxes;
    }

    // Reduces the size of the given shape by the given factor.
    static VoxelSet<bool> ReduceShape(VoxelSet<bool> shape, int factor) {
        Vec3i size = Vec3i.Max(shape.Size / factor, new Vec3i(1));

        Debug.Log("Old size: " + shape.Size + "     New size: " + size);

        VoxelSet<bool> reducedShape = new VoxelSet<bool>(size);
        shape.Apply((v, idx) => {
            Vec3i targetIdx = Vec3i.Min(size - 1, idx / factor);
            reducedShape[targetIdx] = reducedShape[targetIdx] || v;
        });

        return reducedShape;
    }

    // Adds colliders to the given game object.
    public static void AddColliders(GameObject obj, VoxelSet<Vec4b> voxels, ColliderType colliderType) {
        if (colliderType != ColliderType.None) {
            VoxelSet<bool> shape = voxels.Project(v => v.w > 0);
            int scale = 1;
            if (colliderType == ColliderType.HalfScale) {
                //shape = ReduceShape(shape);
                shape = ReduceShape(shape, 2);
                scale = 2;
            }

            if (colliderType == ColliderType.ThirdScale) {
                shape = ReduceShape(shape, 3);
                scale = 3;
            }

            if (colliderType == ColliderType.QuarterScale) {
                //shape = ReduceShape(ReduceShape(shape));
                shape = ReduceShape(shape, 4);
                scale = 4;
            }

            List<BoxMaker.Box> boxes = MakeBoxes(shape, scale);

            // Add box colliders
            foreach (var boxDesc in boxes) {
                BoxCollider box = obj.AddComponent<BoxCollider>();
                box.size = new Vector3(boxDesc.extents.x, boxDesc.extents.y, boxDesc.extents.z);
                box.center = new Vector3(boxDesc.origin.x, boxDesc.origin.y, boxDesc.origin.z) + box.size / 2.0f;
            }
        }
    }

    public static GameObject Load(VoxelSet<Vec4b> voxels, ColliderType colliderType) {
        GameObject obj = new GameObject("VoxelModel");

        Material[] materials;
        Mesh mesh;
        //MakeMesh(voxels, out mesh, out materials);
        MakeMeshNative(voxels, out mesh, out materials);

        MeshRenderer renderer = obj.AddComponent<MeshRenderer>();
        renderer.materials = materials;

        MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        AddColliders(obj, voxels, colliderType);

        return obj;
    }

    public static GameObject Load(string filepath, ColliderType colliderType) {
        GameObject obj = new GameObject("VoxelModel");

        Material[] materials;
        Mesh mesh;
        //MakeMesh(voxels, out mesh, out materials);
        MakeMeshNative(filepath, out mesh, out materials);

        MeshRenderer renderer = obj.AddComponent<MeshRenderer>();
        renderer.materials = materials;

        MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        // TODO: Handle colliders natively
        //AddColliders(obj, voxels, colliderType);

        return obj;
    }
}
