﻿using System;

using OpenBox;
using LiteBox.LMath;
using System.Collections.Generic;
using System.Drawing;

namespace SandBox {
    class Program {
        static void TestMagicaFile() {
            var m = MagicaFile.Load(@"..\..\..\..\Assets\VoxModels\Twist.vox");

            Console.WriteLine("Loaded {0} models", m.Length);

            for (int z = 0; z < 126; z++) {
                for (int y = 0; y < 126; y++) {
                    for (int x = 0; x < 126; x++) {
                        if (m[0].IsValid(x, y, z) && m[0][x, y, z].w > 0) {
                            Console.Write("#");
                        } else {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.Write("\nPress any key to continue ... ");
                Console.ReadKey();
                Console.WriteLine();
            }

            Console.WriteLine("Size: <{0}, {1}, {2}>", m[0].Size.x, m[0].Size.y, m[0].Size.z);
            Console.WriteLine("Valid: {0}", m[0].IsValid(new Vec3i(64, 64, 64)));

            Console.Write("\nPress any key to continue ... ");
            Console.ReadKey();
        }

        static void TestSlices() {
            Console.WriteLine("Hello World!");

            VoxelSet<Vec4b> colors = new VoxelSet<Vec4b>(32);
            colors.Set(new Vec4b(0));
            colors.Slice(new Vec3i(1), new Vec3i(30)).Set(new Vec4b(255));
            colors.Slice(new Vec3i(3), new Vec3i(28)).Set(new Vec4b(0));
            colors.Slice(new Vec3i(5), new Vec3i(26)).Set(new Vec4b(255));

            for (int i = 0; i < 32; ++i) {
                if (colors[16, i, 16].x == 0) {
                    Console.Write(".");
                } else {
                    Console.Write("#");
                }
            }
            Console.Write("\nPress any key to continue ... ");
            Console.ReadKey();
        }

        static void TestMesh() {
            int width = 16;
            int verticesPerRow = width + 1;

            Func<int, int, int> VertIdx = (x, y) => verticesPerRow * y + x;

            List<Vec3f> vertices = new List<Vec3f>();
            List<int> indices = new List<int>();

            for (int y = 0; y < verticesPerRow; ++y) {
                for (int x = 0; x < verticesPerRow; ++x) {
                    Vec3f v = new Vec3f();
                    v.x = x;
                    v.y = y;
                    v.z = 0;
                    vertices.Add(v);
                }
            }

            for (int y = 0; y < width; ++y) {
                for (int x = 0; x < width; ++x) {
                    indices.Add(VertIdx(x, y));
                    indices.Add(VertIdx(x + 1, y));
                    indices.Add(VertIdx(x + 1, y + 1));

                    indices.Add(VertIdx(x, y));
                    indices.Add(VertIdx(x + 1, y + 1));
                    indices.Add(VertIdx(x, y + 1));
                }
            }

            MeshSimplifier m = new MeshSimplifier(vertices.ToArray(), indices.ToArray());
            m.SaveToObj("out_full.obj");
            int triangleCount = 0;

            for (int i = 0; i < m.Edges.Length; i += 3) {
                if (m.Edges[i].vertexIdx >= 0) {
                    triangleCount++;
                } else {
                    Console.WriteLine("Bad edge at index: {0}", i);
                }
            }

            m.Compact();

            Console.WriteLine("Triangle count: {0}", triangleCount);

            m.Simplify();

            triangleCount = 0;
            for (int i = 0; i < m.Edges.Length; i += 3) {
                if (m.Edges[i].vertexIdx >= 0) {
                    triangleCount++;

                    for (int j = 0; j < 3; ++j) {
                        Vec3f p = m.Points[m.Edges[i + j].vertexIdx];
                        Console.WriteLine("<{0}, {1}, {2}>", p.x, p.y, p.z);
                    }
                    Console.WriteLine();
                }
            }
            m.SaveToObj("out_simple.obj");
            m.Compact();

            Console.WriteLine("Triangle count: {0}", triangleCount);
            Console.Write("\nPress any key to continue ... ");
            Console.ReadKey();
        }

        static void TestMeshWithHole() {
            int width = 3;
            int verticesPerRow = width + 1;

            Func<int, int, int> VertIdx = (x, y) => verticesPerRow * y + x;

            List<Vec3f> vertices = new List<Vec3f>();
            List<int> indices = new List<int>();

            for (int y = 0; y < verticesPerRow; ++y) {
                for (int x = 0; x < verticesPerRow; ++x) {
                    Vec3f v = new Vec3f();
                    v.x = x;
                    v.y = y;
                    v.z = 0;
                    vertices.Add(v);
                }
            }

            for (int y = 0; y < width; ++y) {
                for (int x = 0; x < width; ++x) {
                    if (x == 1 && y == 1) {
                        // Make a hole
                        continue;
                    }

                    indices.Add(VertIdx(x, y));
                    indices.Add(VertIdx(x + 1, y));
                    indices.Add(VertIdx(x + 1, y + 1));

                    indices.Add(VertIdx(x, y));
                    indices.Add(VertIdx(x + 1, y + 1));
                    indices.Add(VertIdx(x, y + 1));
                }
            }

            MeshSimplifier m = new MeshSimplifier(vertices.ToArray(), indices.ToArray());
            m.SaveToObj("out_full.obj");
            Console.WriteLine("Triangle count: {0}", m.Edges.Length / 3);

            m.Simplify();
            m.SaveToObj("out_simple.obj");
            m.Compact();

            Console.WriteLine("Triangle count: {0}", m.Edges.Length / 3);
            Console.Write("\nPress any key to continue ... ");
            Console.ReadKey();
        }

        static void TestVoxelSimplify() {
            var m = MagicaFile.Load(@"..\..\..\..\Assets\VoxModels\cathedral-2.vox");

            var ms = Mesher.VoxelsToMesh(m[0]);
            ms.PrintStats();
            ms.SaveToObj("voxels_simplified.obj");
        }

        static void TestVoxelSimplify2() {
            var m = MagicaFile.Load(@"..\..\..\..\Assets\VoxModels\Wall_07.vox");
            var ms = Mesher.VoxelsToMeshFull(m[0]);
            ms.SaveToObj("voxels_pre_91.obj");
            ms.Collapse(43);
            ms.Collapse(54);
            ms.Collapse(61);
            ms.Collapse(91);
            ms.Compact();
            ms.PrintStats();
            ms.SaveToObj("voxels_post_91.obj");
        }

        static void TestBinPack() {
            List<Bin> bins = new List<Bin>();

            for (int i = 0; i < 10; ++i) {
                Bin b = new Bin();
                b.Size = new Vec2i(100, 100);
                bins.Add(b);
            }

            Bin b2 = new Bin();
            b2.Size = new Vec2i(12, 200);
            bins.Add(b2);

            Bin b3 = new Bin();
            b3.Size = new Vec2i(1, 90);
            bins.Add(b3);

            BinPacker bp = new BinPacker(512);
            bp.Pack(bins);

            Console.WriteLine("Total size: {0} x {1}", bp.Width, bp.Height);
        }

        static void TestSimplify3() {
            //var voxels = MagicaFile.Load(@"C:\Projects\FloofBox\uRogue\Assets\VoxModels\cathedral-2.vox");
            var voxels = MagicaFile.Load(@"..\..\..\..\Assets\VoxModels\cathedral-2.vox");

            var boxes = BoxMaker.MakeBoxes(voxels[0]);

            Console.WriteLine("{0} boxes made", boxes.Count);

            MeshSimplifier ms = Mesher.VoxelsToMeshFull(voxels[0]);
            Console.WriteLine("Triangles before reduction: " + (ms.Edges.Length / 3));
            ms.Simplify();
            ms.Compact();
            Console.WriteLine("Triangles after reduction: " + (ms.Edges.Length / 3));
            int[] tris;
            Vec3f[] rawPos;
            Vec3f[] rawNormals;
            Vec2f[] rawUvs;

            VoxelSet<Vec4b> atlas;

            ms.GetMesh(voxels[0], out tris, out rawPos, out rawNormals, out rawUvs, out atlas);

            Bitmap bmp = new Bitmap(atlas.Size.x, atlas.Size.y);

            for (int y = 0; y < atlas.Size.y; ++y) {
                for (int x = 0; x < atlas.Size.x; ++x) {
                    bmp.SetPixel(x, y, Color.FromArgb(
                        atlas[x, y, 0].x,
                        atlas[x, y, 0].y,
                        atlas[x, y, 0].z
                    ));
                }
            }

            bmp.Save("Atlas.png");
        }

        static void Main(string[] args) {
            //TestMesh();
            //TestMagicaFile();
            //TestMeshWithHole();
            //TestVoxelSimplify();
            //TestVoxelSimplify2();

            //TestVoxelSimplify();
            TestSimplify3();
            //TestBinPack();

            Console.Write("\nPress any key to continue ... ");
            Console.ReadKey();
        }
    }
}
