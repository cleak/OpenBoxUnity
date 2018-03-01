using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using OpenBox;
using LiteBox.LMath;

public class PickAndDestroy : MonoBehaviour {

    //const float kEps = 0.0005f;
    const float kEps = 0.00005f;
    //VoxelSet<Vec4b> voxels;

    GameObject voxelModel;
    VoxelComponent voxelComp;

    // Use this for initialization
    void Start () {
        voxelModel = new GameObject("VoxelModel");
        voxelComp = voxelModel.AddComponent<VoxelComponent>();
        voxelComp.LoadMagicaModel(@"C:\Projects\Unity\OpenBoxUnity\Assets\VoxModels\cathedral-2.vox", true);

        //voxelModel = VoxelFactory.Load(@"C:\Projects\Unity\OpenBoxUnity\Assets\VoxModels\cathedral-2.vox", VoxelFactory.ColliderType.None);
        voxelModel.transform.parent = transform;
    }

    void Update() {
        Resolution r = Screen.currentResolution;
        int w = Screen.width;
        int h = Screen.height;
        var cam = Camera.main;

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            VoxelHit hitInfo;
            if (voxelComp.RaycastVoxel(ray.origin, ray.direction, out hitInfo)) {
                voxelComp.voxels[hitInfo.index] = new Color32(0, 0, 0, 0);
                voxelComp.UpdateMesh();

                Debug.DrawRay(ray.origin, hitInfo.point, Color.yellow);
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            VoxelHit hitInfo;
            if (voxelComp.RaycastVoxel(ray.origin, ray.direction, out hitInfo)
                    && voxelComp.voxels.IsValid(hitInfo.neighborIndex)) {
                voxelComp.voxels[hitInfo.neighborIndex] = new Color32(255, 0, 0, 255);
                voxelComp.UpdateMesh();
            }
        }
    }
}
