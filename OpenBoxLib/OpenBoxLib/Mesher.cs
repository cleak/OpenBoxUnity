using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LiteBox.LMath;

namespace OpenBox {
    public class Mesher {
        public struct Quad {
            public Vec3f offset;
            public Vec3f normal;
            public Vec3f dx;
            public Vec3f dy;
            public Vec4b color;
        }

        public static List<Quad> VoxelsToQuads(VoxelSet<Vec4b> voxels) {
            List<Quad> quads = new List<Quad>();

            Vec3f[] normals = {
                new Vec3f( 1,  0,  0),
                new Vec3f(-1,  0,  0),
                new Vec3f( 0,  1,  0),
                new Vec3f( 0, -1,  0),
                new Vec3f( 0,  0,  1),
                new Vec3f( 0,  0, -1)
            };

            Vec3f[] dxs = {
                new Vec3f(0, 1, 0),
                new Vec3f(0, 0, 1),
                new Vec3f(0, 0, 1),
                new Vec3f(1, 0, 0),
                new Vec3f(1, 0, 0),
                new Vec3f(0, 1, 0)
            };

            Vec3f[] dys = {
                new Vec3f(0, 0, 1),
                new Vec3f(0, 1, 0),
                new Vec3f(1, 0, 0),
                new Vec3f(0, 0, 1),
                new Vec3f(0, 1, 0),
                new Vec3f(1, 0, 0)
            };

            voxels.Apply((Vec4b c, Vec3i idx) => {
                if (c.w == 0) {
                    // Voxel is empty
                    //return;
                }

                // Check each face
                for (int i = 0; i < 6; ++i) {

                    Quad quad = new Quad();
                    quad.normal = normals[i];
                    quad.dx = dxs[i];
                    quad.dy = dys[i];
                    quad.offset = new Vec3f(idx.x, idx.y, idx.z);
                    quad.color = c;

                    Vec3i neighbor = idx + new Vec3i(new Vec3f(quad.normal.x, quad.normal.y, quad.normal.z));
                    if (c.w == 0 || voxels.IsValid(neighbor) && voxels[neighbor].w > 0) {
                        // Voxel face is covered
                        continue;
                    }

                    if (quad.normal.x > 0 || quad.normal.y > 0 || quad.normal.z > 0) {
                        quad.offset += quad.normal;
                    }

                    quads.Add(quad);
                }
            });

            return quads;
        }

        public static MeshSimplifier VoxelsToMesh(VoxelSet<Vec4b> voxels) {
            MeshSimplifier ms = VoxelsToMeshFull(voxels);
            Console.WriteLine("Triangles before reduction: " + (ms.Edges.Length / 3));
            ms.Simplify();
            ms.Compact();
            Console.WriteLine("Triangles after reduction: " + (ms.Edges.Length / 3));

            return ms;
        }

        public static MeshSimplifier VoxelsToMeshFull(VoxelSet<Vec4b> voxels) {
            var quads = VoxelsToQuads(voxels);

            Vec3f[] positions = new Vec3f[quads.Count * 4];
            Vec3f[] normals = new Vec3f[quads.Count * 4];

            int[] tris = new int[quads.Count * 6];

            Dictionary<Vec3b, int> posRemap = new Dictionary<Vec3b, int>();

            int idx = 0;
            foreach (var q in quads) {
                for (int i = 0; i < 4; ++i) {
                    normals[idx * 4 + i] = q.normal;
                }

                positions[idx * 4 + 0] = q.offset;
                positions[idx * 4 + 1] = q.offset + q.dx;
                positions[idx * 4 + 2] = q.offset + q.dx + q.dy;
                positions[idx * 4 + 3] = q.offset + q.dy;

                int[] posIndices = new int[4];
                for (int i = 0; i < 4; ++i) {
                    Vec3b posKey = new Vec3b(positions[idx * 4 + i]);

                    if (!posRemap.ContainsKey(posKey)) {
                        posRemap[posKey] = idx * 4 + i;
                    }

                    posIndices[i] = posRemap[posKey];
                }

                tris[idx * 6 + 0] = posIndices[0];
                tris[idx * 6 + 1] = posIndices[1];
                tris[idx * 6 + 2] = posIndices[2];

                tris[idx * 6 + 3] = posIndices[0];
                tris[idx * 6 + 4] = posIndices[2];
                tris[idx * 6 + 5] = posIndices[3];
                idx++;
            }

            MeshSimplifier ms = new MeshSimplifier(positions, tris);
            return ms;
        }
    }
}
