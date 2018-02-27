using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

using OpenBox;
using LiteBox.LMath;

namespace OpenBox {

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PointQuadList {
        public int count;
        public IntPtr handle;
    };

    public static class OpenBoxNative {
        [DllImport("NativeBox.dll", EntryPoint = "obx_ExtractFaces")]
        public static extern unsafe void ExtractFaces(IntPtr colors, Vec3i size, ref PointQuadList opaqueFaces, ref PointQuadList transparentFaces);

        // void obx_CopyFaceGeometry(Faces* faces, vec3* points, vec2* faceIndices, ubvec4* colors) {
        [DllImport("NativeBox.dll", EntryPoint = "obx_CopyFaceGeometry")]
        public static extern unsafe void CopyFaceGeometry(IntPtr facesHandle, IntPtr points, IntPtr faceIndices, IntPtr colors);

        [DllImport("NativeBox.dll", EntryPoint = "obx_FreeFacesHandle")]
        public static extern void FreeFacesHandle(IntPtr handle);

        ////////////////////////////////////////////////////////////////////////////
        // MagicaVoxel related functions
        [DllImport("NativeBox.dll", EntryPoint = "obx_MagicaLoadModel")]
        public static extern unsafe IntPtr MagicaLoadModel([MarshalAs(UnmanagedType.LPStr)]String filepath);

        [DllImport("NativeBox.dll", EntryPoint = "obx_MagicaExtractFaces")]
        public static extern unsafe IntPtr MagicaExtractFaces(IntPtr model, ref PointQuadList opaqueFaces, ref PointQuadList transparentFaces);

        [DllImport("NativeBox.dll", EntryPoint = "obx_MagicaFreeModel")]
        public static extern void MagicaFreeModel(IntPtr handle);

        [DllImport("NativeBox.dll", EntryPoint = "obx_MagicaModelSize")]
        public static extern Vec3i MagicaModelSize(IntPtr handle);

        [DllImport("NativeBox.dll", EntryPoint = "obx_MagicaCopyVoxels")]
        public static extern void MagicaCopyVoxels(IntPtr dest, IntPtr handle);
    }

}
