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
    [HideInInspector]
    public VoxelFactory.ColliderType colliderType;

    public override void OnImportAsset(AssetImportContext ctx) {
        // Main asset
        var obj = new GameObject("MainModel");
        ctx.AddObjectToAsset("MainModel", obj);
        ctx.SetMainObject(obj);

        var material = new Material(Shader.Find("Voxel/PointQuads"));
        ctx.AddObjectToAsset("Material", material);

        var voxels = MagicaFile.Load(ctx.assetPath)[0];

        Mesh mesh = VoxelFactory.MakeMesh(voxels);

        var renderer = obj.AddComponent<MeshRenderer>();

        renderer.material = material;

        var meshFilter = obj.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        ctx.AddObjectToAsset("Mesh", mesh);


        if (colliderType != VoxelFactory.ColliderType.None) {
            VoxelFactory.AddColliders(obj, voxels, colliderType);
        }
    }
}
