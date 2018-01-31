using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenBox;
using LiteBox.LMath;

namespace BoxTest {
    [TestClass]
    public class MeshTest {
        MeshSimplifier EasySquares(int w) {
            int verticesPerRow = w + 1;

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

            for (int y = 0; y < w; ++y) {
                for (int x = 0; x < w; ++x) {
                    indices.Add(VertIdx(x, y));
                    indices.Add(VertIdx(x + 1, y));
                    indices.Add(VertIdx(x + 1, y + 1));

                    indices.Add(VertIdx(x, y));
                    indices.Add(VertIdx(x + 1, y + 1));
                    indices.Add(VertIdx(x, y + 1));
                }
            }

            MeshSimplifier m = new MeshSimplifier(vertices.ToArray(), indices.ToArray());
            return m;
        }

        [TestMethod]
        public void TestNormals() {
            var m = EasySquares(1);

            var n1 = m.Normal(0, 1, 2);
            var n2 = m.Normal(2, 1, 0);

            Assert.AreEqual(Vec3f.Dot(n1, n2), -1.0f);
        }

        [TestMethod]
        public void TestFlip() {
            var m = EasySquares(2);

            Assert.IsTrue(m.Flips(3, 2, 0, 4));
            Assert.IsTrue(m.Flips(2, 3, 0, 4));
            Assert.IsTrue(m.Flips(2, 3, 4, 0));

            Assert.IsFalse(m.Flips(0, 1, 3, 5));
            Assert.IsFalse(m.Flips(1, 0, 3, 5));
            Assert.IsFalse(m.Flips(1, 0, 5, 3));
        }

        [TestMethod]
        public void TestEasyReduce() {
            var m = EasySquares(2);
            //m.Compact();
            Assert.AreEqual(8 * 3, m.Edges.Length);

            m.Simplify();
            m.Compact();
            Assert.AreEqual(2 * 3, m.Edges.Length);
        }

        [TestMethod]
        public void TestTJunctionReduce() {
            int w = 3;
            int verticesPerRow = w + 1;

            Func<int, int, int> VertIdx = (x, y) => verticesPerRow * y + x;

            List<Vec3f> vertices = new List<Vec3f>();

            for (int y = 0; y < verticesPerRow; ++y) {
                for (int x = 0; x < verticesPerRow; ++x) {
                    Vec3f v = new Vec3f();
                    v.x = x;
                    v.y = y;
                    v.z = 0;
                    vertices.Add(v);
                }
            }

            int[] indices = {
                1, 2, 10,
                2, 3, 10,
                3, 11, 10,

                // Becomes degenerate
                1, 10, 5,

                // Edge to collapse is 10 to 9
                5, 10, 9,

                4, 5, 9,
                4, 9, 8
            };

            MeshSimplifier m = new MeshSimplifier(vertices.ToArray(), indices);

            Assert.IsFalse(m.CanCollapse(12));
            Assert.IsFalse(m.CanCollapse(13));
            Assert.IsFalse(m.CanCollapse(14));
        }
    }
}
