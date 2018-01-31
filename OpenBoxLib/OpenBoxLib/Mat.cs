using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteBox.LMath {
    public struct Mat3f {
        public Vec3f c0;
        public Vec3f c1;
        public Vec3f c2;

        public Mat3f(Vec3f c0, Vec3f c1, Vec3f c2) {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        public Vec3f GetCol(int idx) {
            switch (idx) {
                case 0:
                    return c0;

                case 1:
                    return c1;

                case 2:
                    return c2;

                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public void SetCol(int idx, Vec3f c) {
            switch (idx) {
                case 0:
                    c0 = c;
                    break;

                case 1:
                    c1 = c;
                    break;

                case 2:
                    c2 = c;
                    break;

                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public Vec3f GetRow(int idx) {
            return new Vec3f(c0[idx], c1[idx], c2[idx]);
        }

        public void SetRow(int idx, Vec3f r) {
            c0[idx] = r[0];
            c1[idx] = r[1];
            c2[idx] = r[2];
        }

        public float this[int i, int j] {
            get { return GetRow(i)[j]; }
            set {
                switch (j) {
                    case 0:
                        c0[i] = value;
                        break;

                    case 1:
                        c1[i] = value;
                        break;

                    case 2:
                        c2[i] = value;
                        break;

                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public static Mat3f operator *(Mat3f a, Mat3f b) {
            return new Mat3f(a * b.c0, a * b.c1, a * b.c2);
        }

        public static Vec3f operator *(Mat3f m, Vec3f v) {
            return m.c0 * v[0] + m.c1 * v[1] + m.c2 * v[2];
        }
    }

    public struct Mat3b {
        public Vec3b c0;
        public Vec3b c1;
        public Vec3b c2;

        public Mat3b(Vec3b c0, Vec3b c1, Vec3b c2) {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        public Vec3b GetCol(int idx) {
            switch (idx) {
                case 0:
                    return c0;

                case 1:
                    return c1;

                case 2:
                    return c2;

                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public void SetCol(int idx, Vec3b c) {
            switch (idx) {
                case 0:
                    c0 = c;
                    break;

                case 1:
                    c1 = c;
                    break;

                case 2:
                    c2 = c;
                    break;

                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public Vec3b GetRow(int idx) {
            return new Vec3b(c0[idx], c1[idx], c2[idx]);
        }

        public void SetRow(int idx, Vec3b r) {
            c0[idx] = r[0];
            c1[idx] = r[1];
            c2[idx] = r[2];
        }

        public byte this[int i, int j] {
            get { return GetRow(i)[j]; }
            set {
                switch (j) {
                    case 0:
                        c0[i] = value;
                        break;

                    case 1:
                        c1[i] = value;
                        break;

                    case 2:
                        c2[i] = value;
                        break;

                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public static Mat3b operator *(Mat3b a, Mat3b b) {
            return new Mat3b(a * b.c0, a * b.c1, a * b.c2);
        }

        public static Vec3b operator *(Mat3b m, Vec3b v) {
            return m.c0 * v[0] + m.c1 * v[1] + m.c2 * v[2];
        }

        public static Vec3i operator *(Mat3b m, Vec3i v) {
            return new Vec3i(m.c0) * v[0] + new Vec3i(m.c1) * v[1] + new Vec3i(m.c2) * v[2];
        }

        public Mat3b Transpose() {
            return new Mat3b(
                GetRow(0),
                GetRow(1),
                GetRow(2)
            );
        }
    }
}
