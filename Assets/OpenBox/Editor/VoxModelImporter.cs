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
    public bool trimEmptySpace = false;
    public bool includeRigidBody = false;

    [HideInInspector]
    public float scale = 1;

    [HideInInspector]
    public VoxelFactory.ColliderType colliderType;

    public override void OnImportAsset(AssetImportContext ctx) {
        // Main asset
        var obj = new GameObject("MainModel");
        ctx.AddObjectToAsset("MainModel", obj);
        ctx.SetMainObject(obj);

        var voxComp = obj.AddComponent<VoxelComponent>();
        MagicaFlags flags = 0;
        if (trimEmptySpace) {
            flags |= MagicaFlags.Trim;
        }

        voxComp.LoadMagicaModel(ctx.assetPath, true, colliderType, flags);

        var meshFilter = obj.GetComponent<MeshFilter>();
        var mesh = meshFilter.sharedMesh;
        ctx.AddObjectToAsset("Mesh", mesh);

        var meshRenderer = obj.GetComponent<MeshRenderer>();
        for (int i = 0; i < meshRenderer.sharedMaterials.Length; ++i) {
            ctx.AddObjectToAsset("Material_" + i, meshRenderer.sharedMaterials[i]);
        }

        if (includeRigidBody) {
            obj.AddComponent<Rigidbody>();
        }
    }
}
