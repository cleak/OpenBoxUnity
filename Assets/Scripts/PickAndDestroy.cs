using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using OpenBox;
using LiteBox.LMath;

public class PickAndDestroy : MonoBehaviour {

    const float kEps = 0.0005f;
    VoxelSet<Vec4b> voxels;

    GameObject voxelModel;

    // Use this for initialization
    void Start () {
        voxels = new VoxelSet<Vec4b>(32);

        voxels.Apply((ref Vec4b v, Vec3i idx) => {
            v = new Vec4b((idx * 255) / voxels.Size, 255);
        });

        voxelModel = VoxelFactory.Load(voxels, VoxelFactory.ColliderType.None);
        voxelModel.transform.parent = transform;
    }

    Vec3i LayerMarch(Vector3 startPoint, Vector3 dir) {
        dir = Vector3.Normalize(dir);

        //Vector3 voxelSize = transform.lossyScale;
        Vector3 voxelGridSize = new Vector3(voxels.Size.x, voxels.Size.y, voxels.Size.z);

        //Vector3 p0 = VecUtil.Div(startPoint, voxelSize);
        Vector3 p0 = startPoint;
        float endT = VecUtil.MinComp(Vector3.Max(
            VecUtil.Div(voxelGridSize - p0, dir),
            VecUtil.Div(-p0, dir)
        ));

        Vector3 p0abs = VecUtil.Mul(Vector3.one - VecUtil.Step(0, dir), voxelGridSize)
            + VecUtil.Mul(VecUtil.Sign(dir), p0);
        Vector3 dirAbs = VecUtil.Abs(dir);

        float t = 0;
        while (t <= endT) {
            Vector3 idxUnity = p0 + dir * t;
            Vec3i idx = new Vec3i((int)idxUnity.x, (int)idxUnity.y, (int)idxUnity.z);

            if (!voxels.IsValid(idx)) {
                break;
            }

            Vec4b c = voxels[idx];
            if (c.w > 0) {
                return idx;
            }

            Vector3 pAbs = p0abs + dirAbs * t;
            Vector3 deltas = VecUtil.Div(Vector3.one - VecUtil.Fract(pAbs), dirAbs);
            t += Mathf.Max(VecUtil.MinComp(deltas), kEps);
        }

        return new Vec3i(-1);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 size = VecUtil.Mul(new Vector3(voxels.Size.x, voxels.Size.y, voxels.Size.z), transform.lossyScale);

            // TODO: Does this account for scale properly? Probably not.
            ray.direction = transform.InverseTransformDirection(ray.direction);
            ray.origin = transform.InverseTransformPoint(ray.origin);

            bool inside = true;
            for (int i = 0; i < 3; ++i) {
                if (ray.origin[i] < 0 || ray.origin[i] > size[i]) {
                    inside = false;
                }
            }

            if (!inside) {
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

                            if (probePoint[k]< 0 || probePoint[k] > size[k]) {
                                validHit = false;
                            }
                        }

                        if (validHit) {
                            minT = Mathf.Min(t, minT);
                        }
                    }
                }

                // TODO: Be more elegant about an invalid minT (no hit)
                ray.origin += (minT + kEps) * ray.direction;
            }

            Vec3i idx = LayerMarch(ray.origin, ray.direction);
            if (idx.x >= 0) {
                Debug.Log("Layer march hit: " + idx);
                voxels[idx] = new Vec4b(0);

                Destroy(voxelModel);
                voxelModel = VoxelFactory.Load(voxels, VoxelFactory.ColliderType.None);
                voxelModel.transform.parent = transform;
            }
        }
	}
}
