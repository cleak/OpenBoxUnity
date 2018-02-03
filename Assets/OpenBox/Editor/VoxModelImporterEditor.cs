using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.AssetImporters;

[CustomEditor(typeof(VoxModelImporter))]
public class VoxModelImporterEditor : ScriptedImporterEditor {
    public override void OnInspectorGUI() {

        VoxModelImporter importer = (VoxModelImporter)target;

        DrawDefaultInspector();

        var lastColliderType = importer.colliderType;
        importer.colliderType = (VoxModelImporter.ColliderType)EditorGUILayout.EnumPopup("Colliders", importer.colliderType);

        if (lastColliderType != importer.colliderType) {
            EditorUtility.SetDirty(target);
            importer.SaveAndReimport();
        }

        ApplyRevertGUI();
    }
}
