using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

using OpenBox;
using LiteBox.LMath;

[ScriptedImporter(1, "vox")]
public class VoxModelImporter : ScriptedImporter {

    public enum ColliderType {
        None,
        Exact,
        HalfScale,
        ThirdScale,
        QuarterScale
    }

    [HideInInspector]
    public ColliderType colliderType;

    public struct Quad {
        public Vector3 position;
        public Color32 color;
        public Vector2 uv;
    }

    void AddFaces(VoxelSet<Vec4b> voxels, List<Quad> quads, Vec3i idx) {
        Vec3i[] normals = {
            new Vec3i(1, 0, 0),
            new Vec3i(-1, 0, 0),

            new Vec3i(0, 1, 0),
            new Vec3i(0, -1, 0),

            new Vec3i(0, 0, 1),
            new Vec3i(0, 0, -1)
        };

        for (int i = 0; i < normals.Length; ++i) {
            Vec3i normal = normals[i];
            Vec3i neighbor = idx + normals[i];
            if (voxels.IsValid(neighbor) && voxels[neighbor].w > 0) {
                // Face is hidden
                continue;
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
        }
    }

    Mesh MakeMesh(VoxelSet<Vec4b> voxels) {
        List<Quad> quads = new List<Quad>();

        // Find all visible faces
        for (int z = 0; z < voxels.Size.z; ++z) {
            for (int y = 0; y < voxels.Size.y; ++y) {
                for (int x = 0; x < voxels.Size.x; ++x) {
                    if (voxels[x, y, z].w <= 0) {
                        // Empty; skip
                        continue;
                    }

                    AddFaces(voxels, quads, new Vec3i(x, y, z));
                }
            }
        }

        // Flatten into mesh
        Vector3[] points = new Vector3[quads.Count];
        Color32[] colors = new Color32[quads.Count];
        Vector2[] uvs = new Vector2[quads.Count];
        int[] indices = new int[quads.Count];

        int idx = 0;
        foreach (var quad in quads) {
            points[idx] = quad.position;
            colors[idx] = quad.color;
            uvs[idx] = quad.uv;
            indices[idx] = idx;
            idx++;
        }

        Mesh mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        mesh.vertices = points;
        mesh.colors32 = colors;
        mesh.uv = uvs;

        mesh.SetIndices(indices, MeshTopology.Points, 0);
        return mesh;
    }

    List<BoxMaker.Box> MakeBoxes(VoxelSet<bool> shape, int scale) {
        List<BoxMaker.Box> boxes = BoxMaker.MakeBoxes(shape);

        if (scale != 1) {
            foreach (var box in boxes) {
                box.extents *= scale;
                box.origin *= scale;
            }
        }

        return boxes;
    }

    // Reduces the size of the shape by a factor of 2 in each dimension
    VoxelSet<bool> ReduceShape(VoxelSet<bool> shape) {

        VoxelSet<bool> reducedShape = new VoxelSet<bool>(shape.Size / 2);
        reducedShape.Apply((v, idx) => {
            reducedShape[idx] = false;

            for (int dz = 0; dz < 2; ++dz) {
                for (int dy = 0; dy < 2; ++dy) {
                    for (int dx = 0; dx < 2; ++dx) {
                        reducedShape[idx] = reducedShape[idx] || shape[idx * 2 + new Vec3i(dx, dy, dz)];
                    }
                }
            }
        });

        return reducedShape;
    }

    VoxelSet<bool> ReduceShape(VoxelSet<bool> shape, int factor) {
        Vec3i size = Vec3i.Max(shape.Size / factor, new Vec3i(1));

        Debug.Log("Old size: " + shape.Size + "     New size: " + size);

        VoxelSet<bool> reducedShape = new VoxelSet<bool>(size);
        shape.Apply((v, idx) => {
            Vec3i targetIdx = Vec3i.Min(size - 1, idx / factor);
            reducedShape[targetIdx] = reducedShape[targetIdx] || v;
        });

        return reducedShape;
    }

    public override void OnImportAsset(AssetImportContext ctx) {
        // Main asset
        var obj = new GameObject("MainModel");
        ctx.AddObjectToAsset("MainModel", obj);
        ctx.SetMainObject(obj);

        var material = new Material(Shader.Find("Voxel/PointQuads"));
        ctx.AddObjectToAsset("Material", material);

        var voxels = MagicaFile.Load(ctx.assetPath)[0];

        Mesh mesh = MakeMesh(voxels);

        var renderer = obj.AddComponent<MeshRenderer>();

        renderer.material = material;

        var meshFilter = obj.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        ctx.AddObjectToAsset("Mesh", mesh);

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
}
