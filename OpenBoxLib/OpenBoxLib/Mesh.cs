using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using LiteBox.LMath;

namespace OpenBox {
    public struct HalfEdge {
        public int vertexIdx;
        public int otherHalf;
    }

    public class MeshSimplifier {
        public Vec3f[] Points { get; private set; }
        public HalfEdge[] Edges { get; private set; }

        [MethodImpl(256)]
        public Vec3f GetFromPoint(int edgeIdx) {
            return Points[Edges[Prev(edgeIdx)].vertexIdx];
        }

        [MethodImpl(256)]
        public Vec3f GetToPoint(int edgeIdx) {
            return Points[Edges[edgeIdx].vertexIdx];
        }

        [MethodImpl(256)]
        public Vec3f GetEdgeDelta(int edgeIdx) {
            return GetToPoint(edgeIdx) - GetFromPoint(edgeIdx);
        }

        [MethodImpl(256)]
        public int Next(int currEdgeIdx) {
            int next = currEdgeIdx + 1;
            return next % 3 == 0 ? next - 3 : next; 
        }

        [MethodImpl(256)]
        bool Active(int currEdgeIdx) {
            return Edges[currEdgeIdx].vertexIdx >= 0;
        }

        [MethodImpl(256)]
        public int Prev(int currEdgeIdx) {
            int prev = currEdgeIdx - 1;
            return currEdgeIdx % 3 == 0 ? prev + 3 : prev;
        }

        [MethodImpl(256)]
        public int Opp(int currEdge) {
            return Edges[currEdge].otherHalf;
        }

        [MethodImpl(256)]
        public int Base(int currEdge) {
            return currEdge - (currEdge % 3);
        }

        [MethodImpl(256)]
        public bool IsOpen(int edgeIdx) {
            return Opp(edgeIdx) < 0;
        }

        [MethodImpl(256)]
        public bool SameDirEdges(int edge1, int edge2) {
            Vec3f d1 = GetEdgeDelta(edge1);
            Vec3f d2 = GetEdgeDelta(edge2);

            if (Vec3f.Dot(d1, d2) < 0) {
                return false;
            }

            float c = Vec3f.Cross(d1, d2).MagnitudeSqrd();

            const float kEdgeThresh = 0.01f;

            if (c >= kEdgeThresh * kEdgeThresh) {
                return false;
            } else {
                return true;
            }
        }

        [MethodImpl(256)]
        public Vec3f Normal(int edgeIdx) {
            Vec3f d1 = GetEdgeDelta(edgeIdx);
            Vec3f d2 = GetEdgeDelta(Next(edgeIdx));

            Vec3f norm = Vec3f.Cross(d1, d2);
            return norm.Normalized();
        }

        [MethodImpl(256)]
        public Vec3f Normal(int vIdx1, int vIdx2, int vIdx3) {
            var v1 = Points[vIdx1];
            var v2 = Points[vIdx2];
            var v3 = Points[vIdx3];

            Vec3f d1 = v2 - v1;
            Vec3f d2 = v3 - v1;

            Vec3f norm = Vec3f.Cross(d1, d2);
            return norm.Normalized();
        }

        [MethodImpl(256)]
        public bool IsCreased(int edgeIdx) {
            if (IsOpen(edgeIdx)) {
                return false;
            }

            Vec3f n1 = Normal(edgeIdx);
            Vec3f n2 = Normal(Opp(edgeIdx));

            return Vec3f.Dot(n1, n2) < 0.99f;
        }

        public enum VertexType {
            Interior,
            PerimeterStraight,
            PerimeterCorner
        }

        [MethodImpl(256)]
        public VertexType DestType(int edgeIdx) {
            // Outgoing open edge
            int openOut = Next(edgeIdx);
            int startingEdge = openOut;
            while (!IsOpen(openOut) && !IsCreased(openOut)) {
                openOut = Next(Opp(openOut));
                if (openOut == startingEdge) {
                    // Came full circle; not on the perimeter.
                    return VertexType.Interior;
                }
            }

            // Incoming open edge
            int openIn = edgeIdx;
            while (!IsOpen(openIn) && !IsCreased(openIn)) {
                openIn = Prev(Opp(openIn));
                if (openIn == edgeIdx) {
                    throw new Exception("Malformed mesh. Vertex has an open edge out but not an open edge in");
                }
            }

            if (!SameDirEdges(openIn, openOut)) {
                return VertexType.PerimeterCorner;
            } else {
                return VertexType.PerimeterStraight;
            }
        }

        [MethodImpl(256)]
        public VertexType SrcType(int edgeIdx) {
            return DestType(Prev(edgeIdx));
        }

        [MethodImpl(256)]
        public int GetOpenOutEdgeDest(int edgeIdx) {
            // Outgoing open edge
            int openOut = Next(edgeIdx);
            int startingEdge = openOut;
            while (!IsOpen(openOut) && !IsCreased(openOut)) {
                openOut = Next(Opp(openOut));
                if (openOut == startingEdge) {
                    throw new Exception("Not a perimeter vertex");
                }
            }

            return openOut;
        }

        [MethodImpl(256)]
        public int GetOpenOutEdgeSrc(int edgeIdx) {
            return GetOpenOutEdgeDest(Prev(edgeIdx));
        }

        [MethodImpl(256)]
        public int GetOpenInEdgeDest(int edgeIdx) {
            // Incoming open edge
            int openIn = edgeIdx;
            while (!IsOpen(openIn) && !IsCreased(openIn)) {
                openIn = Prev(Opp(openIn));
                if (openIn == edgeIdx) {
                    throw new Exception("Malformed mesh. Vertex has an open edge out but not an open edge in");
                }
            }

            return openIn;
        }

        [MethodImpl(256)]
        public int GetOpenInEdgeSrc(int edgeIdx) {
            return GetOpenInEdgeDest(Prev(edgeIdx));
        }

        [MethodImpl(256)]
        public bool IsCorner(int edgeIdx) {
            return DestType(edgeIdx) == VertexType.PerimeterCorner;
        }

        [MethodImpl(256)]
        public IEnumerable<int> IncomingEdges(int incomingEdgeIdx) {
            int currEdge = incomingEdgeIdx;
            while (currEdge >= 0) {
                yield return currEdge;
                currEdge = Opp(Next(currEdge));
                if (currEdge == incomingEdgeIdx) {
                    // Came full circle; not on the perimeter.
                    yield break;
                }
            }

            currEdge = incomingEdgeIdx;
            while (!IsOpen(currEdge)) {
                currEdge = Prev(Opp(currEdge));
                yield return currEdge;
            }
        }

        // Finds all triangles
        [MethodImpl(256)]
        public IEnumerable<int> FullPolygon(int startEdge) {
            HashSet<int> foundTris = new HashSet<int>();
            Queue<int> triQueue = new Queue<int>();

            Vec3f n = Normal(startEdge);

            foundTris.Add(Base(startEdge));
            triQueue.Enqueue(Base(startEdge));

            while (triQueue.Count > 0) {
                int e = triQueue.Dequeue();

                if (Vec3f.Dot(n, Normal(e)) < 0.99f) {
                    // Creased edge; not part of the same polygon.
                    continue;
                }

                yield return e;

                foreach (int nextE in new int[] { Opp(e), Opp(Next(e)), Opp(Prev(e)) }) {
                    if (nextE < 0) {
                        // Open edge
                        continue;
                    }

                    int nextEBase = Base(nextE);

                    if (foundTris.Contains(nextEBase)) {
                        // All processed triangle
                        continue;
                    }

                    foundTris.Add(nextEBase);
                    triQueue.Enqueue(nextEBase);
                }
            }
        }

        // Finds all triangles
        [MethodImpl(256)]
        public IEnumerable<List<int>> AllPolygons() {
            HashSet<int> foundTris = new HashSet<int>();
            Queue<int> triQueue = new Queue<int>();

            for (int i = 0; i < Edges.Length; i += 3) {
                if (Edges[i].vertexIdx < 0 || foundTris.Contains(i)) {
                    continue;
                }

                List<int> currPoly = new List<int>();

                Vec3f n = Normal(i);

                triQueue.Enqueue(i);

                while (triQueue.Count > 0) {
                    int e = triQueue.Dequeue();

                    if (foundTris.Contains(e)) {
                        // Already processed
                        continue;
                    }

                    if (Vec3f.Dot(n, Normal(e)) < 0.99f) {
                        // Creased edge; not part of the same polygon.
                        continue;
                    }

                    foundTris.Add(e);
                    currPoly.Add(e);

                    foreach (int nextE in new int[] { Opp(e), Opp(Next(e)), Opp(Prev(e)) }) {
                        if (nextE < 0) {
                            // Open edge
                            continue;
                        }

                        int nextEBase = Base(nextE);

                        triQueue.Enqueue(nextEBase);
                    }
                }

                yield return currPoly;
            }
        }

        [MethodImpl(256)]
        public IEnumerable<int> OpenOrCreasedEdges(int incomingEdgeIdx) {
            foreach (var e in IncomingEdges(incomingEdgeIdx)) {
                if (IsOpen(e) || IsCreased(e)) {
                    yield return e;
                }

                if (IsOpen(Next(e))) {
                    yield return Next(e);
                }
            }
        }

        public int ignore1 = 0;
        public int ignore2 = 0;
        public int ignore3 = 0;

        public void PrintStats() {
            Console.WriteLine("Ignored edges by category: {0}, {1}, {2}", ignore1, ignore2, ignore3);
        }

        [MethodImpl(256)]
        public bool Flips(int vert1, int vert2, int vertOld, int vertNew) {
            Vec3f n1 = Normal(vert1, vert2, vertOld);
            Vec3f n2 = Normal(vert1, vert2, vertNew);

            if (float.IsNaN(n2.x)) {
                return true;
            }

            //return Vec3f.Dot(n1, n2) <= 0f;
            return Vec3f.Dot(n1, n2) <= 0.01f;
        }

        // From http://mathworld.wolfram.com/TriangleInterior.html
        public bool InsideTri(int vIdx0, int vIdx1, int vIdx2, int testPointIdx) {
            int flatAxis = -1;
            Vec3f[] rawPoints = {
                Points[vIdx0],
                Points[vIdx1],
                Points[vIdx2]
            };

            for (int i = 0; i < 3; ++i) {
                if (rawPoints[0][i] == rawPoints[1][i]
                    && rawPoints[1][i] == rawPoints[2][i]) {
                    flatAxis = i;
                    break;
                }
            }

            if (flatAxis < 0) {
                throw new Exception("No flat axis found");
            }

            if (Points[testPointIdx][flatAxis] != rawPoints[0][flatAxis]) {
                // Test point is not coplanar. Don't test.
                return false;
            }

            // Drop dimension that doesn't change
            Vec2f testPoint = new Vec2f();
            Vec2f[] v = new Vec2f[3];
            int copyToIdx = 0;
            for (int i = 0; i < 3; ++i) {
                if (i == flatAxis) {
                    continue;
                }

                for (int j = 0; j < v.Length; ++j) {
                    v[j][copyToIdx] = rawPoints[j][i];
                }

                testPoint[copyToIdx] = Points[testPointIdx][i];
                copyToIdx++;
            }

            v[1] = v[1] - v[0];
            v[2] = v[2] - v[0];

            float scale = 1.0f / Det(v[1], v[2]);
            float a =  (Det(testPoint, v[2]) - Det(v[0], v[2])) * scale;
            float b = -(Det(testPoint, v[1]) - Det(v[0], v[1])) * scale;

            return a > 0 && b > 0 && (a + b) < 1;
        }

        float Det(Vec2f u, Vec2f v) {
            return u.x * v.y - u.y * v.x;
        }

        public bool CanCollapse(int edgeIdx) {
            var srcType = SrcType(edgeIdx);
            var destType = DestType(edgeIdx);

            //return !IsCorner(edgeIdx);
            if (srcType == VertexType.PerimeterCorner) {
                ignore1++;
                return false;
            }

            if (srcType == VertexType.PerimeterStraight && destType == VertexType.Interior) {
                ignore2++;
                return false;
            }

            /*if (srcType != VertexType.Interior && destType != VertexType.Interior
                && !IsOpen(edgeIdx)) {
                // Can not connect open edges by a closed edge
                ignore3++;
                return false;
            }*/

            /*if (srcType != VertexType.Interior && destType != VertexType.Interior
                && !IsCreased(edgeIdx)) {
                // Can not connect open edges by a closed edge
                ignore3++;
                return false;
            }*/

            if (srcType != VertexType.Interior && destType != VertexType.Interior
                //&& GetOpenOutEdgeSrc(edgeIdx) != edgeIdx) {
                && (GetOpenInEdgeDest(edgeIdx) != edgeIdx || GetOpenOutEdgeSrc(edgeIdx) != edgeIdx)) {
                // Can not connect open edges by a closed edge
                ignore3++;
                return false;
            }

            if (srcType != VertexType.Interior && destType != VertexType.Interior
                && !SameDirEdges(GetOpenOutEdgeSrc(edgeIdx), GetOpenInEdgeSrc(edgeIdx))) {
                // Can not connect open edges by a closed edge
                ignore3++;
                return false;
            }

            if (srcType != VertexType.Interior && destType != VertexType.Interior
                && !SameDirEdges(edgeIdx, GetOpenInEdgeSrc(edgeIdx))) {
                // Can not connect open edges by a closed edge
                ignore3++;
                return false;
            }

            foreach (var e1 in OpenOrCreasedEdges(Prev(edgeIdx))) {
                foreach (var e2 in OpenOrCreasedEdges(Prev(edgeIdx))) {
                    //if (Math.Abs(Vec3f.Dot(GetEdgeDelta(e1), GetEdgeDelta(e2))) < 0.01f) {
                    if (Math.Abs(Vec3f.Dot(GetEdgeDelta(e1), GetEdgeDelta(e2))) < 0.01f) {
                        // Open or creased edges that are orthogonal; stop.
                        return false;
                    }
                }
            }

            int vIdxOld = Edges[Prev(edgeIdx)].vertexIdx;
            int vIdxNew = Edges[edgeIdx].vertexIdx;

            // Checks if the collapse would put points on the wrong side of line segments
            /*foreach (var e1 in IncomingEdges(Prev(edgeIdx))) {
                if (e1 == Prev(edgeIdx) || e1 == Opp(edgeIdx)) {
                    // Ignore triangles that are about to be removed
                    continue;
                }
                int from = Edges[Prev(e1)].vertexIdx;

                foreach (var e2 in IncomingEdges(Prev(edgeIdx))) {
                //foreach (var e2 in IncomingEdges(Prev(e1))) {
                    if (InsideTri(from, vIdxOld, vIdxNew, Edges[Prev(e2)].vertexIdx)) {
                        return false;
                    }
                }
            }*/

            // Check if this merge would flip any triangles
            foreach (var e in IncomingEdges(Prev(edgeIdx))) {
                if (e == Prev(edgeIdx) || e == Opp(edgeIdx)) {
                    // Ignore triangles that are about to be removed
                    continue;
                }

                if (Flips(Edges[Prev(e)].vertexIdx, Edges[Next(e)].vertexIdx, vIdxOld, vIdxNew)) {
                    return false;
                }
            }

            /*if (srcType != VertexType.Interior && destType != VertexType.Interior
                && !SameDirEdges(edgeIdx, GetOpenOutEdgeDest(edgeIdx))) {
                // Can not connect open edges by a closed edge
                ignore3++;
                return false;
            }*/

            int openCount = 0;
            foreach (var startEdge in new int[] { edgeIdx, Opp(edgeIdx)}) {
                int localOpenCount = 0;
                if (startEdge < 0) {
                    continue;
                }

                int e = startEdge;
                for (int i = 0; i < 3; ++i) {
                    if (IsOpen(e) || IsCreased(e)) {
                        openCount++;
                        localOpenCount++;
                    }

                    e = Next(e);
                }

                if (localOpenCount >= 2) {
                    //return false;
                }
            }

            /*if (openCount > 2) {
                return false;
            } else if (openCount == 2) {
                return srcType == VertexType.PerimeterStraight;
            } else {
                return true;
            }*/

            return true;
            //return false;
        }

        public void Collapse(int edgeIdx) {

            if (Edges[Prev(edgeIdx)].vertexIdx != Edges[edgeIdx].vertexIdx && !CanCollapse(edgeIdx)) {
                throw new Exception("Debug: tried to collapse edge that can not be collapsed");
            }

            int newVertexIdx = Edges[edgeIdx].vertexIdx;
            int oldVertIdx = Edges[Prev(edgeIdx)].vertexIdx;

            List<int> collapseList = new List<int>();

            // Point to the new vertex
            foreach (int e in IncomingEdges(Prev(edgeIdx))) {
                if (Edges[Prev(e)].vertexIdx == newVertexIdx) {
                    //throw new Exception("Degenerate edge created");
                    collapseList.Add(e);
                    //Collapse(e);
                }

                if (Edges[e].vertexIdx != oldVertIdx) {
                    throw new Exception();
                }
                Edges[e].vertexIdx = newVertexIdx;

                // Seems like this would just skip one step ahead in iterations; not needed
                /*if (IsOpen(e)) {
                    continue;
                }

                if (Edges[PrevEdge(OppEdge(e))].vertexIdx != oldVertIdx) {
                    throw new Exception();
                }
                Edges[PrevEdge(OppEdge(e))].vertexIdx = newVertexIdx;*/
            }

            foreach (int rootEdge in new int[]{ edgeIdx, Opp(edgeIdx) }) {
                if (rootEdge < 0) {
                    // No triangle here
                    continue;
                }

                GlueEdges(Opp(Next(rootEdge)), Opp(Prev(rootEdge)));

                // Mark the edges as deleted
                Edges[rootEdge].vertexIdx = -1;
                Edges[Next(rootEdge)].vertexIdx = -1;
                Edges[Prev(rootEdge)].vertexIdx = -1;
            }

            foreach (var e in collapseList) {
                if (Active(e)) {
                    //Collapse(e);
                }
            }
        }

        void GlueEdges(int edgeIdx1, int edgeIdx2) {
            if (edgeIdx1 == edgeIdx2 && edgeIdx1 >= 0) {
                // TODO: This shouldn't happen and will likely form a bad mesh
                throw new Exception("Can't glue an edge to itself");
            }

            if (edgeIdx1 >= 0) {
                Edges[edgeIdx1].otherHalf = edgeIdx2;
            }

            if (edgeIdx2 >= 0) {
                Edges[edgeIdx2].otherHalf = edgeIdx1;
            }
        }

        public void Simplify() {
            SaveToObj("out_raw.obj");
            int iteration = 0;
            while (true) {
                Console.WriteLine("Iteration {0}", iteration);
                int edgesDeleted = 0;

                // Check each edge if it can be deleted
                // TODO: Only check dirty edges
                for (int i = 0; i < Edges.Length; ++i) {
                    if (Edges[i].vertexIdx < 0) {
                        // Edge is already deleted
                        continue;
                    }

                    if (CanCollapse(i)) {
                        // Collapse the edge
                        Collapse(i);

                        edgesDeleted++;
                    }
                }

                Console.WriteLine("    edges deleted {0}\n", edgesDeleted);
                SaveToObj(string.Format("out_{0}.obj", iteration));
                iteration++;

                if (edgesDeleted == 0) {
                    // Stop when there are no edges left to simplify
                    break;
                }
            }
        }

        public void Compact() {
            int nextVertIdx = 0;
            int nextEdgeIdx = 0;

            int[] vertexRemap = new int[Points.Length];
            for (int i = 0; i < vertexRemap.Length; ++i) {
                vertexRemap[i] = -1;
            }

            int[] edgeRemap = new int[Edges.Length];
            for (int i = 0; i < edgeRemap.Length; ++i) {
                edgeRemap[i] = -1;
            }

            for (int i = 0; i < Edges.Length; ++i) {
                if (Edges[i].vertexIdx < 0) {
                    continue;
                }

                // Assign an index to the current edge if it doesn't have one
                if (edgeRemap[i] < 0) {
                    edgeRemap[i] = nextEdgeIdx;
                    nextEdgeIdx++;
                }

                // Assign an index to the current position if it doesn't have one
                if (vertexRemap[Edges[i].vertexIdx] < 0) {
                    vertexRemap[Edges[i].vertexIdx] = nextVertIdx;
                    nextVertIdx++;
                }
            }

            // Collapse edges
            HalfEdge[] reducedEdges = new HalfEdge[nextEdgeIdx];
            for (int i = 0; i < Edges.Length; ++i) {
                int newIdx = edgeRemap[i];
                if (newIdx < 0) {
                    continue;
                }

                reducedEdges[newIdx] = new HalfEdge();
                reducedEdges[newIdx].vertexIdx = vertexRemap[Edges[i].vertexIdx];

                if (Edges[i].otherHalf >= 0) {
                    reducedEdges[newIdx].otherHalf = edgeRemap[Edges[i].otherHalf];
                } else {
                    reducedEdges[newIdx].otherHalf = -1;
                }
            }

            // Collapse positions
            Vec3f[] reducedPositions = new Vec3f[nextVertIdx];
            for (int i = 0; i < Points.Length; ++i) {
                int newIdx = vertexRemap[i];
                if (newIdx < 0) {
                    continue;
                }

                reducedPositions[newIdx] = Points[i];
            }

            // Replace arrays
            Points = reducedPositions;
            Edges = reducedEdges;
        }

        public MeshSimplifier(Vec3f[] points, int[] triangles) {
            if (triangles.Length % 3 != 0) {
                throw new Exception("triangle indices must be a multiple of 3");
            }

            Points = new Vec3f[points.Length];
            points.CopyTo(Points, 0);

            Dictionary<Vec2i, List<int>> knownEdges = new Dictionary<Vec2i, List<int>>();
            Edges = new HalfEdge[triangles.Length];

            Console.WriteLine("Processing {0} edges", triangles.Length);
            Console.WriteLine("Finding all known edges");

            // Populate vertex indices and find all known edges
            for (int i = 0; i < Edges.Length / 3; ++i) {
                for (int j = 0; j < 3; ++j) {
                    int idx = i * 3 + j;
                    int prevIdx = Prev(idx);

                    Vec2i edge = new Vec2i(triangles[prevIdx], triangles[idx]);
                    /*if (knownEdges.ContainsKey(edge)) {
                        throw new Exception("Edge already exists");
                    }*/

                    if (!knownEdges.ContainsKey(edge)) {
                        knownEdges.Add(edge, new List<int>());
                    }

                    knownEdges[edge].Add(idx);

                    if (triangles[idx] < 0 || triangles[idx] >= Points.Length) {
                        throw new Exception(string.Format("Triangle index {0} out of bounds", triangles[idx]));
                    }

                    Edges[idx].vertexIdx = triangles[idx];
                }
            }

            Console.WriteLine("Linking up corresponding edges");
            // Link up corresponding half edges
            for (int i = 0; i < Edges.Length / 3; ++i) {
                for (int j = 0; j < 3; ++j) {
                    int idx = i * 3 + j;
                    int prevIdx = Prev(idx);

                    Vec2i otherEdge = new Vec2i(triangles[idx], triangles[prevIdx]);
                    if (!knownEdges.ContainsKey(otherEdge) || knownEdges[otherEdge].Count == 0) {
                        // Boundary edge
                        Edges[idx].otherHalf = -1;
                        continue;
                    }

                    Edges[idx].otherHalf = knownEdges[otherEdge].First();
                    knownEdges[otherEdge].RemoveAt(0);
                }
            }

            /*for (int i = 0; i < 4; ++i) {
                for (int j = 0; j < 3; ++j) {
                    int idx = i * 3 + j;
                    Console.WriteLine("{0}: {1}", idx, DestType(idx));
                }
                Console.WriteLine("*******************");
            }*/

            Console.WriteLine("Mesh created");
        }

        Vec3f Max3f(Vec3f a, Vec3f b) {
            return new Vec3f(
                Math.Max(a.x, b.x),
                Math.Max(a.y, b.y),
                Math.Max(a.z, b.z)
            );
        }

        Vec3f Min3f(Vec3f a, Vec3f b) {
            return new Vec3f(
                Math.Min(a.x, b.x),
                Math.Min(a.y, b.y),
                Math.Min(a.z, b.z)
            );
        }

        /// Single entry in a texture atlas
        struct AtlasEntry {
            public int startVertIdx;
            public int vertCount;
            public int flatDimension;
            public Vec3i min;
            public Vec3i max;
            public Vec3i normal;

            public Vec3i To3d(Vec2i p) {
                switch (flatDimension) {
                    case 0:
                        return new Vec3i(0, p.x, p.y) + min;

                    case 1:
                        return new Vec3i(p.x, 0, p.y) + min;

                    case 2:
                        return new Vec3i(p.x, p.y, 0) + min;

                    default:
                        throw new Exception("Invalid flat dimension");
                }
            }

            public Vec2i To2d(Vec3i p) {
                p -= min;

                switch (flatDimension) {
                    case 0:
                        return new Vec2i(p.y, p.z);

                    case 1:
                        return new Vec2i(p.x, p.z);

                    case 2:
                        return new Vec2i(p.x, p.y);

                    default:
                        throw new Exception("Invalid flat dimension");
                }
            }

            public Mat3b Basis() {
                switch (flatDimension) {
                    case 0:
                        return new Mat3b(
                            new Vec3b(0, 1, 0),
                            new Vec3b(0, 0, 1),
                            new Vec3b(1, 0, 0)
                        );

                    case 1:
                        return new Mat3b(
                            new Vec3b(1, 0, 0),
                            new Vec3b(0, 0, 1),
                            new Vec3b(0, 1, 0)
                        );

                    case 2:
                        return new Mat3b(
                            new Vec3b(1, 0, 0),
                            new Vec3b(0, 1, 0),
                            new Vec3b(0, 0, 1)
                        );

                    default:
                        throw new Exception("Invalid flat dimension");
                }
            }
        }

        public void GetMesh(VoxelSet<Vec4b> voxels, 
            out int[] indices, out Vec3f[] points, out Vec3f[] normals, out Vec2f[] uvs,
            out VoxelSet<Vec4b> textureAtlas) {
            List<int> indicesList = new List<int>();
            List<Vec3f> pointsList = new List<Vec3f>();
            List<Vec3f> normalsList = new List<Vec3f>();
            List<Vec2f> uvsList = new List<Vec2f>();

            Dictionary<int, int> vertIdxRemap = new Dictionary<int, int>();

            List<Bin> bins = new List<Bin>();

            foreach (var poly in AllPolygons()) {
                // For each connected polygon
                vertIdxRemap.Clear();
                Vec3f normal = Normal(poly.First());

                Vec3f maxP = new Vec3f(-1);
                Vec3f minP = new Vec3f(1024 * 1024);

                AtlasEntry atlasEntry = new AtlasEntry();
                atlasEntry.startVertIdx = pointsList.Count;
                atlasEntry.normal = new Vec3i(
                    (int)Math.Round(normal.x),
                    (int)Math.Round(normal.y),
                    (int)Math.Round(normal.z)
                );

                foreach (var baseEdge in poly) {
                    // Each triangle that makes up the polygon
                    foreach (var e in new int[] { baseEdge, Next(baseEdge), Prev(baseEdge)}) {
                        // Each vertex of each triangle
                        int vertIdx = Edges[e].vertexIdx;
                        if (!vertIdxRemap.ContainsKey(vertIdx)) {
                            vertIdxRemap.Add(vertIdx, pointsList.Count);
                            pointsList.Add(Points[vertIdx]);
                            normalsList.Add(normal);

                            maxP = Max3f(maxP, Points[vertIdx]);
                            minP = Min3f(minP, Points[vertIdx]);

                            // TODO: Add UV here
                        }

                        indicesList.Add(vertIdxRemap[vertIdx]);
                    }
                }

                atlasEntry.vertCount = pointsList.Count - atlasEntry.startVertIdx;

                // TODO: Add to texture atlas here
                Vec3f deltaP = maxP - minP;

                // Determine which dimension is flat
                int flatIdx = -1;
                for (int i = 0; i < 3; ++i) {
                    if (deltaP[i] == 0) {
                        if (flatIdx >= 0) {
                            throw new Exception("Two or more flat dimensions found");
                        }
                        flatIdx = i;
                    }
                }

                Vec2i size;
                if (flatIdx == 0) {
                    size = new Vec2i((int)Math.Round(deltaP.y), (int)Math.Round(deltaP.z));
                } else if (flatIdx == 1) {
                    size = new Vec2i((int)Math.Round(deltaP.x), (int)Math.Round(deltaP.z));
                } else {
                    size = new Vec2i((int)Math.Round(deltaP.x), (int)Math.Round(deltaP.y));
                }

                atlasEntry.flatDimension = flatIdx;
                atlasEntry.max = new Vec3i(maxP + new Vec3f(0.5f));
                atlasEntry.min = new Vec3i(minP + new Vec3f(0.5f));

                Bin b = new Bin();
                b.Size = size;
                b.UserData = atlasEntry;
                bins.Add(b);
            }

            indices = indicesList.ToArray();
            points = pointsList.ToArray();
            normals = normalsList.ToArray();

            //BinPacker bp = new BinPacker(512);
            BinPacker bp = new BinPacker(512);
            bp.BinPadding = new Vec2i(2);
            bp.Pack(bins);
            bp.MakePow2();

            textureAtlas = new VoxelSet<Vec4b>(bp.Width, bp.Height, 1);

            for (int y = 0; y < textureAtlas.Size.y; ++y) {
                for (int x = 0; x < textureAtlas.Size.x; ++x) {
                    textureAtlas[x, y, 0] = new Vec4b(0, 255, 0, 255);
                }
            }

            uvs = new Vec2f[points.Length];
            foreach (var bin in bp.Bins) {
                var atlasEntry = (AtlasEntry)bin.UserData;

                // Copy to atlas
                var toSlice = textureAtlas.Slice(new Vec3i(bin.Position, 0),
                    new Vec3i(bin.Position + bin.Size - 1, 0));

                Vec3i voxelOffset = new Vec3i(0);

                if (atlasEntry.normal.Dot(new Vec3i(1)) > 0) {
                    voxelOffset = atlasEntry.normal * -1;
                } else {
                    //voxelOffset = atlasEntry.normal * -1;
                    voxelOffset = new Vec3i(0);
                }

                var fromSlice = voxels.Slice(
                    atlasEntry.min + voxelOffset,
                    atlasEntry.max - atlasEntry.min + atlasEntry.Basis() * new Vec3i(0, 0, 1),
                    atlasEntry.Basis()
                );

                if (toSlice.Size.x != fromSlice.Size.x
                    || toSlice.Size.y != fromSlice.Size.y
                    || toSlice.Size.z != fromSlice.Size.z) {
                    throw new Exception();
                }

                /*for (int y = 0; y < toSlice.Size.y; ++y) {
                    for (int x = 0; x < toSlice.Size.x; ++x) {
                        toSlice[x, y, 0] = fromSlice[x, y, 0];
                    }
                }*/

                for (int y = 0; y < toSlice.Size.y; ++y) {
                    for (int x = 0; x < toSlice.Size.x; ++x) {
                        if (Vec4b.Dot(toSlice[x, y, 0], new Vec4b(1)) != 0) {
                            ////throw new Exception();
                        }
                        toSlice[x, y, 0] = voxels[atlasEntry.To3d(new Vec2i(x, y)) + voxelOffset];
                        //toSlice[x, y, 0] = c;
                    }
                }

                // Compute UVs
                for (int i = atlasEntry.startVertIdx; i < atlasEntry.startVertIdx + atlasEntry.vertCount; ++i) {
                    Vec2f uv = new Vec2f(atlasEntry.To2d(new Vec3i(points[i])));

                    //uv *= new Vec2f(bin.Size - 1) / new Vec2f(bin.Size);
                    //uv += 0.5f;

                    uv *= (new Vec2f(bin.Size ) - 0.01f) / new Vec2f(bin.Size);
                    uv += 0.005f;

                    /////////
                    //uv *= 0.998f;
                    //uv += 0.01f;

                    uv += new Vec2f(bin.Position);

                    ///////
                    //uv += 0.25f;

                    uv.x /= bp.Width;
                    uv.y /= bp.Height;

                    uvs[i] = uv;
                }
            }

            Console.WriteLine("Total size: {0} x {1}", bp.Width, bp.Height);
        }

        public void SaveToObj(string filename) {
            using (StreamWriter writer = File.CreateText(filename)) {
                writer.WriteLine("# Created in OpenBox");
                writer.WriteLine();
                writer.WriteLine("# Vertex positions");
                foreach (var p in Points) {
                    // Position
                    writer.Write("v {0} {1} {2}", p.x, p.y, p.z);

                    // Color
                    writer.Write(" 1 1 0 0");

                    writer.WriteLine();
                }

                writer.WriteLine();
                writer.WriteLine("# Triangles");

                for (int i = 0; i < Edges.Length; i += 3) {
                    if (Edges[i].vertexIdx < 0) {
                        continue;
                    }

                    writer.Write("f");
                    for (int j = 0; j < 3; ++j) {
                        writer.Write(" {0}", Edges[i + j].vertexIdx + 1);
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
