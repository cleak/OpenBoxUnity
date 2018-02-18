using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace OpenBox {
    public static class VecUtil {
        ////////////////////////////////////////////////////////////////////////
        // Vector2
        ////////////////////////////////////////////////////////////////////////
        public static float MinComp(Vector2 v) {
            return Mathf.Min(v.x, v.y);
        }

        public static float MaxComp(Vector2 v) {
            return Mathf.Max(v.x, v.y);
        }

        public static float AbsMinComp(Vector2 v) {
            return Mathf.Min(Mathf.Abs(v.x), Mathf.Abs(v.y));
        }

        public static float AbsMaxComp(Vector2 v) {
            return Mathf.Max(Mathf.Abs(v.x), Mathf.Abs(v.y));
        }

        public static Vector2 Mul(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.x * v2.x, v1.y * v2.y);
        }

        public static Vector2 Div(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.x / v2.x, v1.y / v2.y);
        }

        public static Vector2 Div(float f, Vector2 v) {
            return new Vector2(f / v.x, f / v.y);
        }

        public static Vector2 Div(Vector2 v, float f) {
            return new Vector2(v.x / f, v.y / f);
        }

        public static Vector2 Abs(Vector2 v) {
            return new Vector2(Mathf.Abs(v.x), Mathf.Abs(v.y));
        }

        public static Vector2 Step(Vector2 edge, Vector2 v) {
            return new Vector2(
                v.x < edge.x ? 0 : 1,
                v.y < edge.y ? 0 : 1
            );
        }

        public static Vector2 Step(float edge, Vector2 v) {
            return new Vector2(
                v.x < edge ? 0 : 1,
                v.y < edge ? 0 : 1
            );
        }

        public static Vector2 Sign(Vector2 v) {
            return new Vector2(Math.Sign(v.x), Math.Sign(v.y));
        }

        public static Vector2 Fract(Vector2 v) {
            return new Vector2(
                v.x - (int)v.x,
                v.y - (int)v.y
            );
        }

        ////////////////////////////////////////////////////////////////////////
        // Vector3
        ////////////////////////////////////////////////////////////////////////
        public static float MinComp(Vector3 v) {
            return Mathf.Min(v.x, v.y, v.z);
        }

        public static float MaxComp(Vector3 v) {
            return Mathf.Max(v.x, v.y, v.z);
        }

        public static float AbsMinComp(Vector3 v) {
            return Mathf.Min(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
        }

        public static float AbsMaxComp(Vector3 v) {
            return Mathf.Max(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
        }

        public static Vector3 Mul(Vector3 v1, Vector3 v2) {
            return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        public static Vector3 Div(Vector3 v1, Vector3 v2) {
            return new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }

        public static Vector3 Div(float f, Vector3 v) {
            return new Vector3(f / v.x, f / v.y, f / v.z);
        }

        public static Vector3 Div(Vector3 v, float f) {
            return new Vector3(v.x / f, v.y / f, v.z / f);
        }

        public static Vector3 Abs(Vector3 v) {
            return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
        }

        public static Vector3 Step(Vector3 edge, Vector3 v) {
            return new Vector3(
                v.x < edge.x ? 0 : 1,
                v.y < edge.y ? 0 : 1,
                v.z < edge.z ? 0 : 1
            );
        }

        public static Vector3 Step(float edge, Vector3 v) {
            return new Vector3(
                v.x < edge ? 0 : 1,
                v.y < edge ? 0 : 1,
                v.z < edge ? 0 : 1
            );
        }

        public static Vector3 Sign(Vector3 v) {
            return new Vector3(Math.Sign(v.x), Math.Sign(v.y), Math.Sign(v.z));
        }

        public static Vector3 Fract(Vector3 v) {
            return new Vector3(
                v.x - (int)v.x,
                v.y - (int)v.y,
                v.z - (int)v.z
            );
        }

        ////////////////////////////////////////////////////////////////////////
        // Vector4
        ////////////////////////////////////////////////////////////////////////
        public static float MinComp(Vector4 v) {
            return Mathf.Min(v.x, v.y, v.z, v.w);
        }

        public static float MaxComp(Vector4 v) {
            return Mathf.Max(v.x, v.y, v.z, v.w);
        }

        public static float AbsMinComp(Vector4 v) {
            return Mathf.Min(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z), Mathf.Abs(v.w));
        }

        public static float AbsMaxComp(Vector4 v) {
            return Mathf.Max(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z), Mathf.Abs(v.w));
        }

        public static Vector4 Mul(Vector4 v1, Vector4 v2) {
            return new Vector4(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z, v1.w * v2.w);
        }

        public static Vector4 Div(Vector4 v1, Vector4 v2) {
            return new Vector4(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z, v1.w / v2.w);
        }

        public static Vector4 Div(float f, Vector4 v) {
            return new Vector4(f / v.x, f / v.y, f / v.z, f / v.w);
        }

        public static Vector4 Div(Vector4 v, float f) {
            return new Vector4(v.x / f, v.y / f, v.z / f, v.w / f);
        }

        public static Vector4 Abs(Vector4 v) {
            return new Vector4(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z), Mathf.Abs(v.w));
        }

        public static Vector4 Step(Vector4 edge, Vector4 v) {
            return new Vector4(
                v.x < edge.x ? 0 : 1,
                v.y < edge.y ? 0 : 1,
                v.z < edge.z ? 0 : 1,
                v.w < edge.w ? 0 : 1
            );
        }

        public static Vector4 Step(float edge, Vector4 v) {
            return new Vector4(
                v.x < edge ? 0 : 1,
                v.y < edge ? 0 : 1,
                v.z < edge ? 0 : 1,
                v.w < edge ? 0 : 1
            );
        }

        public static Vector4 Sign(Vector4 v) {
            return new Vector4(Math.Sign(v.x), Math.Sign(v.y), Math.Sign(v.z), Math.Sign(v.w));
        }

        public static Vector4 Fract(Vector4 v) {
            return new Vector4(
                v.x - (int)v.x,
                v.y - (int)v.y,
                v.z - (int)v.z,
                v.w - (int)v.w
            );
        }
    }
}

