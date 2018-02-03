using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LiteBox.LMath;

namespace OpenBox {
    // Converts a given voxel set into a box cover set that can be used for a rigid body.
    public class BoxMaker {
        public struct Box {
            public Vec3i origin;
            public Vec3i extents;
        }

        static bool ToSolid(Vec4b voxel) {
            return voxel.w > 0;
        }

        public static List<Box> MakeBoxes(VoxelSet<Vec4b> voxels) {
            var shape = voxels.Project(ToSolid);
            List<Box> boxes = new List<Box>();

            //////return boxes;

            // Directions to explore
            Vec3i[] dirs = new[] {
                new Vec3i(1, 0, 0),
                new Vec3i(0, 1, 0),
                new Vec3i(0, 0, 1)
            };

            // TODO: Iteration order may need to be reversed
            for (int z = 0; z < voxels.Size.z; z++) {
                for (int y = 0; y < voxels.Size.y; y++) {
                    for (int x = 0; x < voxels.Size.x; x++) {
                        if (!shape[x, y, z])
                            continue;

                        Vec3i idx = new Vec3i(x, y, z);
                        Vec3i endIdx = new Vec3i(x, y, z);

                        // Expand box in each cardinal direction as much as possible
                        foreach (var dir in dirs) {
                            Vec3i checkFromIdx = idx;

                            // Expand as much as possible in the current direction
                            while (shape.IsValid(endIdx + dir)) {
                                checkFromIdx += dir;

                                // Create a slice for the next layer in the current dir and make sure it's solid
                                var slice = shape.Slice(checkFromIdx, endIdx + dir);
                                if (!slice.IsAllSolid(b => b)) {
                                    break;
                                }
                                slice.Set(false);

                                endIdx += dir;
                            }
                        }

                        Box box;
                        box.origin = new Vec3i(x, y, z);
                        box.extents = new Vec3i(endIdx.x + 1 - idx.x, endIdx.y + 1 - idx.y, endIdx.z + 1 - idx.z);
                        boxes.Add(box);
                    }
                }
            }

            return boxes;
        }
    }
}
