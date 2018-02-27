using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

using OpenBox;
using LiteBox.LMath;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class VoxelComponent : MonoBehaviour {
    public VoxelSet<Color32> Voxels { get; set; }

    public void Clear() {
        Voxels = null;

        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf.mesh) {
            Destroy(mf.mesh);
            mf.mesh = null;
        }
    }

    /// Adds indices of the specified range to the specified submesh.
    static void AddMeshIndices(int idxCount, Mesh mesh, int baseIdx, int submeshIdx) {
        int[] indices = new int[idxCount];

        for (int i = 0; i < idxCount; ++i) {
            indices[i] = i + baseIdx;
        }

        mesh.SetIndices(indices, MeshTopology.Points, submeshIdx);
    }

    /// Adds all geometry in the given quad lists to the given mesh.
    static int AddMeshGeometry(PointQuadList[] quads, Mesh mesh) {
        int geometryCount = 0;
        int subMeshCount = 0;

        foreach (var q in quads) {
            geometryCount += q.count;

            if (q.count > 0) {
                subMeshCount++;
            }
        }

        // Flatten into mesh
        Vector3[] points = new Vector3[geometryCount];
        Color32[] colors = new Color32[geometryCount];
        Vector2[] uvs = new Vector2[geometryCount];

        var pointsHandle = GCHandle.Alloc(points, GCHandleType.Pinned);
        var colorsHandle = GCHandle.Alloc(colors, GCHandleType.Pinned);
        var uvsHandle = GCHandle.Alloc(uvs, GCHandleType.Pinned);

        int facesFilled = 0;
        for (int i = 0; i < quads.Length; ++i) {
            OpenBoxNative.CopyFaceGeometry(
                quads[i].handle,
                Marshal.UnsafeAddrOfPinnedArrayElement(points, facesFilled),
                Marshal.UnsafeAddrOfPinnedArrayElement(uvs, facesFilled),
                Marshal.UnsafeAddrOfPinnedArrayElement(colors, facesFilled)
            );
        }

        pointsHandle.Free();
        colorsHandle.Free();
        uvsHandle.Free();

        mesh.vertices = points;
        mesh.colors32 = colors;
        mesh.uv = uvs;

        return subMeshCount;
    }

    void MakeMeshFromQuadLists(PointQuadList opaqueFaces, PointQuadList transparentFaces) {
        Mesh mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        int subMeshCount = AddMeshGeometry(new PointQuadList[] {
            opaqueFaces,
            transparentFaces
        }, mesh);
        mesh.subMeshCount = subMeshCount;

        Material[] materials = new Material[subMeshCount];

        int submeshIdx = 0;
        int nextPointIdx = 0;

        // Opaque quads
        if (opaqueFaces.count > 0) {
            AddMeshIndices(opaqueFaces.count, mesh, nextPointIdx, submeshIdx);
            materials[submeshIdx] = new Material(Shader.Find("Voxel/PointQuads"));

            nextPointIdx += opaqueFaces.count;
            submeshIdx++;
        }

        // Transparent quads
        if (transparentFaces.count > 0) {
            AddMeshIndices(transparentFaces.count, mesh, nextPointIdx, submeshIdx);
            materials[submeshIdx] = new Material(Shader.Find("Voxel/PointQuadsTransparent"));

            nextPointIdx += transparentFaces.count;
            submeshIdx++;
        }

        GetComponent<MeshRenderer>().materials = materials;
        GetComponent<MeshFilter>().mesh = mesh;
    }

    /// Loads a MagicaVoxel model into the current model.
    public void LoadMagicaModel(string magicaVoxelFile, bool retainVoxels) {
        Clear();

        PointQuadList opaqueFaces = new PointQuadList();
        PointQuadList transparentFaces = new PointQuadList();

        IntPtr model = OpenBoxNative.MagicaLoadModel(magicaVoxelFile);
        OpenBoxNative.MagicaExtractFaces(model, ref opaqueFaces, ref transparentFaces);

        if (retainVoxels) {
            // Copy voxels over to the C# side
            Voxels = new VoxelSet<Color32>(OpenBoxNative.MagicaModelSize(model));
            OpenBoxNative.MagicaCopyVoxels(Voxels.Pin(), model);
            Voxels.Unpin();
        }

        OpenBoxNative.MagicaFreeModel(model);

        MakeMeshFromQuadLists(opaqueFaces, transparentFaces);

        OpenBoxNative.FreeFacesHandle(opaqueFaces.handle);
        OpenBoxNative.FreeFacesHandle(transparentFaces.handle);
    }

    /// Turns the current voxel set into a mesh, replacing any currently attached mesh.
	public void UpdateMesh() {
        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf.mesh) {
            Destroy(mf.mesh);
            mf.mesh = null;
        }

        PointQuadList opaqueFaces = new PointQuadList();
        PointQuadList transparentFaces = new PointQuadList();

        IntPtr voxelsPtr = Voxels.Pin();
        OpenBoxNative.ExtractFaces(voxelsPtr, Voxels.Size, ref opaqueFaces, ref transparentFaces);
        Voxels.Unpin();

        MakeMeshFromQuadLists(opaqueFaces, transparentFaces);

        OpenBoxNative.FreeFacesHandle(opaqueFaces.handle);
        OpenBoxNative.FreeFacesHandle(transparentFaces.handle);
    }
}
