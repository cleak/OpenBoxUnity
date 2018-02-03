using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LiteBox.LMath;

namespace OpenBox {
    // Converts a given voxel set into a box cover set that can be used for a rigid body.
    public class BoxMaker {
        public class Box {
            public Vec3i origin;
            public Vec3i extents;
        }

        static bool ToSolid(Vec4b voxel) {
            return voxel.w > 0;
        }

        static bool ToSolid(float voxel) {
            return voxel >= 0.01f;
        }

        static float ToFloat(Vec4b voxel) {
            return voxel.w / 255.0f;
        }

        static void SmearLine(VoxelSet<float> voxels, float transference, Vec3i dir, Vec3i start) {
            Vec3i idx = start + dir;
            while (voxels.IsValid(idx)) {
                voxels[idx] += voxels[idx - dir] * transference;
                idx += dir;
            }
        }

        static void SmearDirection(VoxelSet<float> voxels, float transference, Vec3i dir) {
            Vec3i dx = new Vec3i(Math.Abs(dir.y), Math.Abs(dir.z), Math.Abs(dir.x));
            Vec3i dy = new Vec3i(Math.Abs(dir.z), Math.Abs(dir.x), Math.Abs(dir.y));

            Vec3i start = new Vec3i(0);

            if (Vec3i.Dot(dir, new Vec3i(1)) < 0) {
                start = voxels.Size.Dot(dir) * dir + dir;
            }

            int y = 0;
            while (voxels.IsValid(start + y * dy)) {
                int x = 0;
                while (voxels.IsValid(start + y * dy + x * dx)) {
                    SmearLine(voxels, transference, dir, start + y * dy + x * dx);
                    x++;
                }
                y++;
            }
        }

        public static VoxelSet<bool> LowPassFilter(VoxelSet<Vec4b> voxels, float transference, float threshold) {
            VoxelSet<float> fVoxels = voxels.Project(ToFloat);

            Vec3i[] dirs = {
                new Vec3i( 1,  0,  0),
                new Vec3i(-1,  0,  0),
                new Vec3i( 0,  1,  0),
                new Vec3i( 0, -1,  0),
                new Vec3i( 0,  0,  1),
                new Vec3i( 0,  0, -1),
            };

            foreach (var dir in dirs) {
                SmearDirection(fVoxels, transference, dir);
            }

            return fVoxels.Project(v => v >= threshold);
        }

        public static List<Box> MakeBoxes(VoxelSet<Vec4b> voxels) {
            return MakeBoxes(voxels.Project(ToSolid));
        }

        public static List<Box> MakeBoxes(VoxelSet<bool> shape) {
            List<Box> boxes = new List<Box>();

            // Directions to explore
            Vec3i[] dirs = new[] {
                new Vec3i(1, 0, 0),
                new Vec3i(0, 1, 0),
                new Vec3i(0, 0, 1)
            };

            // TODO: Iteration order may need to be reversed
            for (int z = 0; z < shape.Size.z; z++) {
                for (int y = 0; y < shape.Size.y; y++) {
                    for (int x = 0; x < shape.Size.x; x++) {
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

                        Box box = new Box();
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
