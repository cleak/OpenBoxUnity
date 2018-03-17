using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.AssetImporters;

[CustomEditor(typeof(VoxModelImporter))]
public class VoxModelImporterEditor : ScriptedImporterEditor {
    public override void OnInspectorGUI() {

        VoxModelImporter importer = (VoxModelImporter)target;

        var lastTrim = importer.trimEmptySpace;
        var lastIncludeRigidBody = importer.includeRigidBody;
        DrawDefaultInspector();

        var lastColliderType = importer.colliderType;
        importer.colliderType = (VoxelFactory.ColliderType)EditorGUILayout.EnumPopup("Colliders", importer.colliderType);

        // Display scale
        List<float> scalesList = new List<float>();
        for (float s = 4; s >= 0.125; s /= 2) {
            scalesList.Add(s);
        }

        int idx = 0;
        int currScaleIdx = scalesList.Count;
        string[] scaleStrs = new string[scalesList.Count + 1];
        foreach (float s in scalesList) {
            if (s == importer.scale) {
                currScaleIdx = idx;
            }
            scaleStrs[idx++] = s.ToString();
        }

        scaleStrs[scaleStrs.Length - 1] = "Other";
        int newScaleIdx = EditorGUILayout.Popup("Voxel Scale", currScaleIdx, scaleStrs);

        float oldScale = importer.scale;
        if (newScaleIdx < scalesList.Count) {
            importer.scale = scalesList[newScaleIdx];
        } else {
            importer.scale = EditorGUILayout.FloatField("Custom Scale", 0);
        }


        if (lastColliderType != importer.colliderType
            || lastTrim != importer.trimEmptySpace
            || oldScale != importer.scale
            || lastIncludeRigidBody != importer.includeRigidBody) {
            EditorUtility.SetDirty(target);
            importer.SaveAndReimport();
        }

        ApplyRevertGUI();
    }
}
