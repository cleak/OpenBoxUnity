using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using OpenBox;
using LiteBox.LMath;

public class VoxelsOnLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //var voxels = MagicaFile.Load(@"C:\Projects\Unity\OpenBoxUnity\Assets\VoxModels\cathedral-2.vox")[0];
        //VoxelSet<Vec4b> voxels = new VoxelSet<Vec4b>(32);

        /*voxels.Apply((ref Vec4b v, Vec3i idx) => {
            v = new Vec4b((idx * 255) / voxels.Size, 255);
        });*/

        //GameObject obj = VoxelFactory.Load(voxels, VoxelFactory.ColliderType.None);
        GameObject obj = VoxelFactory.Load(@"C:\Projects\Unity\OpenBoxUnity\Assets\VoxModels\cathedral-2.vox", VoxelFactory.ColliderType.None);
        obj.transform.parent = transform;
        //obj.transform.Translate(-new Vector3(voxels.Size.x, voxels.Size.y, voxels.Size.z) / 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
