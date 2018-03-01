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

    [HideInInspector]
    public VoxelFactory.VoxelMaterial materialType;

    public override void OnImportAsset(AssetImportContext ctx) {
        // Main asset
        var obj = new GameObject("MainModel");
        ctx.AddObjectToAsset("MainModel", obj);
        ctx.SetMainObject(obj);

        var voxComp = obj.AddComponent<VoxelComponent>();
        voxComp.LoadMagicaModel(ctx.assetPath, true);

        //var voxels = MagicaFile.Load(ctx.assetPath)[0];

        //Mesh mesh;
        //VoxelFactory.MakeMesh(voxels, out mesh, out materials);

        var meshFilter = obj.GetComponent<MeshFilter>();
        var mesh = meshFilter.sharedMesh;
        ctx.AddObjectToAsset("Mesh", mesh);

        var meshRenderer = obj.GetComponent<MeshRenderer>();
        for (int i = 0; i < meshRenderer.sharedMaterials.Length; ++i) {
            ctx.AddObjectToAsset("Material_" + i, meshRenderer.sharedMaterials[i]);
        }

        /*var renderer = obj.AddComponent<MeshRenderer>();
        renderer.materials = materials;

        var meshFilter = obj.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        ctx.AddObjectToAsset("Mesh", mesh);


        if (colliderType != VoxelFactory.ColliderType.None) {
            VoxelFactory.AddColliders(obj, voxels, colliderType);
        }*/
    }
}
