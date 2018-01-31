using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LiteBox.LMath
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2l : IEquatable<Vec2l>
    {
        public long x;
        public long y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2l(Vec2l other)
        {
            x = (long)other.x;
            y = (long)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2l(Vec2ul other)
        {
            x = (long)other.x;
            y = (long)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2l(Vec2i other)
        {
            x = (long)other.x;
            y = (long)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2l(Vec2ui other)
        {
            x = (long)other.x;
            y = (long)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2l(Vec2s other)
        {
            x = (long)other.x;
            y = (long)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2l(Vec2us other)
        {
            x = (long)other.x;
            y = (long)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2l(Vec2b other)
        {
            x = (long)other.x;
            y = (long)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2l(Vec2d other)
        {
            x = (long)other.x;
            y = (long)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2l(Vec2f other)
        {
            x = (long)other.x;
            y = (long)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2l(long x, long y)
        {
            this.x = x;
            this.y = y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2l(long fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2l operator +(Vec2l l, Vec2l r)
        {
            Vec2l ret;
            ret.x = (long)(l.x + r.x);
            ret.y = (long)(l.y + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2l operator -(Vec2l l, Vec2l r)
        {
            Vec2l ret;
            ret.x = (long)(l.x - r.x);
            ret.y = (long)(l.y - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2l operator *(Vec2l l, Vec2l r)
        {
            Vec2l ret;
            ret.x = (long)(l.x * r.x);
            ret.y = (long)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2l operator /(Vec2l l, Vec2l r)
        {
            Vec2l ret;
            ret.x = (long)(l.x / r.x);
            ret.y = (long)(l.y / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2l operator +(Vec2l l, long r)
        {
            Vec2l ret;
            ret.x = (long)(l.x + r);
            ret.y = (long)(l.y + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2l operator +(long l, Vec2l r)
        {
            Vec2l ret;
            ret.x = (long)(l + r.x);
            ret.y = (long)(l + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2l operator -(Vec2l l, long r)
        {
            Vec2l ret;
            ret.x = (long)(l.x - r);
            ret.y = (long)(l.y - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2l operator -(long l, Vec2l r)
        {
            Vec2l ret;
            ret.x = (long)(l - r.x);
            ret.y = (long)(l - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2l operator *(Vec2l l, long r)
        {
            Vec2l ret;
            ret.x = (long)(l.x * r);
            ret.y = (long)(l.y * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2l operator *(long l, Vec2l r)
        {
            Vec2l ret;
            ret.x = (long)(l * r.x);
            ret.y = (long)(l * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2l operator /(Vec2l l, long r)
        {
            Vec2l ret;
            ret.x = (long)(l.x / r);
            ret.y = (long)(l.y / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2l operator /(long l, Vec2l r)
        {
            Vec2l ret;
            ret.x = (long)(l / r.x);
            ret.y = (long)(l / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2l operator %(Vec2l l, Vec2l r)
        {
            Vec2l ret;
            ret.x = (long)(l.x % r.x);
            ret.y = (long)(l.y % r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2l operator %(Vec2l l, long r)
        {
            Vec2l ret;
            ret.x = (long)(l.x % r);
            ret.y = (long)(l.y % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2l operator %(long l, Vec2l r)
        {
            Vec2l ret;
            ret.x = (long)(l % r.x);
            ret.y = (long)(l % r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Dot(Vec2l l, Vec2l r)
        {
            long ret = 0;
            ret += (long)(l.x * r.x);
            ret += (long)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long Dot(Vec2l r)
        {
            long ret = 0;
            ret += (long)(x * r.x);
            ret += (long)(y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec2l l, Vec2l r)
        {
            return l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec2l l, Vec2l r)
        {
            return l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec2l l, Vec2l r)
        {
            return l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec2l l, Vec2l r)
        {
            return l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec2l other)
        {
            return x == other.x && x == other.x;
        }

        public long this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    default: return y;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    default: y = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3l : IEquatable<Vec3l>
    {
        public long x;
        public long y;
        public long z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2l other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec3l other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2l other, long z)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2ul other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec3ul other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2ul other, long z)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2i other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec3i other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2i other, long z)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2ui other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec3ui other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2ui other, long z)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2s other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec3s other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2s other, long z)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2us other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec3us other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2us other, long z)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2b other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec3b other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2b other, long z)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2d other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec3d other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2d other, long z)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2f other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec3f other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(Vec2f other, long z)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(long x, long y, long z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l(long fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l operator +(Vec3l l, Vec3l r)
        {
            Vec3l ret;
            ret.x = (long)(l.x + r.x);
            ret.y = (long)(l.y + r.y);
            ret.z = (long)(l.z + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l operator -(Vec3l l, Vec3l r)
        {
            Vec3l ret;
            ret.x = (long)(l.x - r.x);
            ret.y = (long)(l.y - r.y);
            ret.z = (long)(l.z - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l operator *(Vec3l l, Vec3l r)
        {
            Vec3l ret;
            ret.x = (long)(l.x * r.x);
            ret.y = (long)(l.y * r.y);
            ret.z = (long)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l operator /(Vec3l l, Vec3l r)
        {
            Vec3l ret;
            ret.x = (long)(l.x / r.x);
            ret.y = (long)(l.y / r.y);
            ret.z = (long)(l.z / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l operator +(Vec3l l, long r)
        {
            Vec3l ret;
            ret.x = (long)(l.x + r);
            ret.y = (long)(l.y + r);
            ret.z = (long)(l.z + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l operator +(long l, Vec3l r)
        {
            Vec3l ret;
            ret.x = (long)(l + r.x);
            ret.y = (long)(l + r.y);
            ret.z = (long)(l + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l operator -(Vec3l l, long r)
        {
            Vec3l ret;
            ret.x = (long)(l.x - r);
            ret.y = (long)(l.y - r);
            ret.z = (long)(l.z - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l operator -(long l, Vec3l r)
        {
            Vec3l ret;
            ret.x = (long)(l - r.x);
            ret.y = (long)(l - r.y);
            ret.z = (long)(l - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l operator *(Vec3l l, long r)
        {
            Vec3l ret;
            ret.x = (long)(l.x * r);
            ret.y = (long)(l.y * r);
            ret.z = (long)(l.z * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l operator *(long l, Vec3l r)
        {
            Vec3l ret;
            ret.x = (long)(l * r.x);
            ret.y = (long)(l * r.y);
            ret.z = (long)(l * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l operator /(Vec3l l, long r)
        {
            Vec3l ret;
            ret.x = (long)(l.x / r);
            ret.y = (long)(l.y / r);
            ret.z = (long)(l.z / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l operator /(long l, Vec3l r)
        {
            Vec3l ret;
            ret.x = (long)(l / r.x);
            ret.y = (long)(l / r.y);
            ret.z = (long)(l / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l operator %(Vec3l l, Vec3l r)
        {
            Vec3l ret;
            ret.x = (long)(l.x % r.x);
            ret.y = (long)(l.y % r.y);
            ret.z = (long)(l.z % r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l operator %(Vec3l l, long r)
        {
            Vec3l ret;
            ret.x = (long)(l.x % r);
            ret.y = (long)(l.y % r);
            ret.z = (long)(l.z % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l operator %(long l, Vec3l r)
        {
            Vec3l ret;
            ret.x = (long)(l % r.x);
            ret.y = (long)(l % r.y);
            ret.z = (long)(l % r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Dot(Vec3l l, Vec3l r)
        {
            long ret = 0;
            ret += (long)(l.x * r.x);
            ret += (long)(l.y * r.y);
            ret += (long)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long Dot(Vec3l r)
        {
            long ret = 0;
            ret += (long)(x * r.x);
            ret += (long)(y * r.y);
            ret += (long)(z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3l Cross(Vec3l u, Vec3l v)
        {
            Vec3l ret;
            ret.x = (long)(u.y * v.z - u.z * v.y);
            ret.y = (long)(u.z * v.x - u.x * v.z);
            ret.z = (long)(u.x * v.y - u.y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3l Cross(Vec3l v)
        {
            Vec3l ret;
            ret.x = (long)(y * v.z - z * v.y);
            ret.y = (long)(z * v.x - x * v.z);
            ret.z = (long)(x * v.y - y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec3l l, Vec3l r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec3l l, Vec3l r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec3l l, Vec3l r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec3l l, Vec3l r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec3l other)
        {
            return x == other.x && x == other.x && x == other.x;
        }

        public long this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    default: return z;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default: z = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4l : IEquatable<Vec4l>
    {
        public long x;
        public long y;
        public long z;
        public long w;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2l other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3l other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec4l other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = (long)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2l other, long z, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3l other, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2ul other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3ul other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec4ul other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = (long)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2ul other, long z, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3ul other, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2i other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3i other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec4i other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = (long)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2i other, long z, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3i other, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2ui other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3ui other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec4ui other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = (long)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2ui other, long z, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3ui other, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2s other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3s other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec4s other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = (long)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2s other, long z, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3s other, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2us other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3us other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec4us other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = (long)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2us other, long z, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3us other, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2b other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3b other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec4b other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = (long)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2b other, long z, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3b other, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2d other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3d other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec4d other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = (long)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2d other, long z, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3d other, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2f other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3f other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec4f other)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            w = (long)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec2f other, long z, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(Vec3f other, long w)
        {
            x = (long)other.x;
            y = (long)other.y;
            z = (long)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(long x, long y, long z, long w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4l(long fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
            this.w = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4l operator +(Vec4l l, Vec4l r)
        {
            Vec4l ret;
            ret.x = (long)(l.x + r.x);
            ret.y = (long)(l.y + r.y);
            ret.z = (long)(l.z + r.z);
            ret.w = (long)(l.w + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4l operator -(Vec4l l, Vec4l r)
        {
            Vec4l ret;
            ret.x = (long)(l.x - r.x);
            ret.y = (long)(l.y - r.y);
            ret.z = (long)(l.z - r.z);
            ret.w = (long)(l.w - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4l operator *(Vec4l l, Vec4l r)
        {
            Vec4l ret;
            ret.x = (long)(l.x * r.x);
            ret.y = (long)(l.y * r.y);
            ret.z = (long)(l.z * r.z);
            ret.w = (long)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4l operator /(Vec4l l, Vec4l r)
        {
            Vec4l ret;
            ret.x = (long)(l.x / r.x);
            ret.y = (long)(l.y / r.y);
            ret.z = (long)(l.z / r.z);
            ret.w = (long)(l.w / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4l operator +(Vec4l l, long r)
        {
            Vec4l ret;
            ret.x = (long)(l.x + r);
            ret.y = (long)(l.y + r);
            ret.z = (long)(l.z + r);
            ret.w = (long)(l.w + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4l operator +(long l, Vec4l r)
        {
            Vec4l ret;
            ret.x = (long)(l + r.x);
            ret.y = (long)(l + r.y);
            ret.z = (long)(l + r.z);
            ret.w = (long)(l + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4l operator -(Vec4l l, long r)
        {
            Vec4l ret;
            ret.x = (long)(l.x - r);
            ret.y = (long)(l.y - r);
            ret.z = (long)(l.z - r);
            ret.w = (long)(l.w - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4l operator -(long l, Vec4l r)
        {
            Vec4l ret;
            ret.x = (long)(l - r.x);
            ret.y = (long)(l - r.y);
            ret.z = (long)(l - r.z);
            ret.w = (long)(l - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4l operator *(Vec4l l, long r)
        {
            Vec4l ret;
            ret.x = (long)(l.x * r);
            ret.y = (long)(l.y * r);
            ret.z = (long)(l.z * r);
            ret.w = (long)(l.w * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4l operator *(long l, Vec4l r)
        {
            Vec4l ret;
            ret.x = (long)(l * r.x);
            ret.y = (long)(l * r.y);
            ret.z = (long)(l * r.z);
            ret.w = (long)(l * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4l operator /(Vec4l l, long r)
        {
            Vec4l ret;
            ret.x = (long)(l.x / r);
            ret.y = (long)(l.y / r);
            ret.z = (long)(l.z / r);
            ret.w = (long)(l.w / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4l operator /(long l, Vec4l r)
        {
            Vec4l ret;
            ret.x = (long)(l / r.x);
            ret.y = (long)(l / r.y);
            ret.z = (long)(l / r.z);
            ret.w = (long)(l / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4l operator %(Vec4l l, Vec4l r)
        {
            Vec4l ret;
            ret.x = (long)(l.x % r.x);
            ret.y = (long)(l.y % r.y);
            ret.z = (long)(l.z % r.z);
            ret.w = (long)(l.w % r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4l operator %(Vec4l l, long r)
        {
            Vec4l ret;
            ret.x = (long)(l.x % r);
            ret.y = (long)(l.y % r);
            ret.z = (long)(l.z % r);
            ret.w = (long)(l.w % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4l operator %(long l, Vec4l r)
        {
            Vec4l ret;
            ret.x = (long)(l % r.x);
            ret.y = (long)(l % r.y);
            ret.z = (long)(l % r.z);
            ret.w = (long)(l % r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Dot(Vec4l l, Vec4l r)
        {
            long ret = 0;
            ret += (long)(l.x * r.x);
            ret += (long)(l.y * r.y);
            ret += (long)(l.z * r.z);
            ret += (long)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long Dot(Vec4l r)
        {
            long ret = 0;
            ret += (long)(x * r.x);
            ret += (long)(y * r.y);
            ret += (long)(z * r.z);
            ret += (long)(w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec4l l, Vec4l r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec4l l, Vec4l r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec4l l, Vec4l r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec4l l, Vec4l r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec4l other)
        {
            return x == other.x && x == other.x && x == other.x && x == other.x;
        }

        public long this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: return w;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: w = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2ul : IEquatable<Vec2ul>
    {
        public ulong x;
        public ulong y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ul(Vec2l other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ul(Vec2ul other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ul(Vec2i other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ul(Vec2ui other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ul(Vec2s other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ul(Vec2us other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ul(Vec2b other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ul(Vec2d other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ul(Vec2f other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ul(ulong x, ulong y)
        {
            this.x = x;
            this.y = y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ul(ulong fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ul operator +(Vec2ul l, Vec2ul r)
        {
            Vec2ul ret;
            ret.x = (ulong)(l.x + r.x);
            ret.y = (ulong)(l.y + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ul operator -(Vec2ul l, Vec2ul r)
        {
            Vec2ul ret;
            ret.x = (ulong)(l.x - r.x);
            ret.y = (ulong)(l.y - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ul operator *(Vec2ul l, Vec2ul r)
        {
            Vec2ul ret;
            ret.x = (ulong)(l.x * r.x);
            ret.y = (ulong)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ul operator /(Vec2ul l, Vec2ul r)
        {
            Vec2ul ret;
            ret.x = (ulong)(l.x / r.x);
            ret.y = (ulong)(l.y / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ul operator +(Vec2ul l, ulong r)
        {
            Vec2ul ret;
            ret.x = (ulong)(l.x + r);
            ret.y = (ulong)(l.y + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ul operator +(ulong l, Vec2ul r)
        {
            Vec2ul ret;
            ret.x = (ulong)(l + r.x);
            ret.y = (ulong)(l + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ul operator -(Vec2ul l, ulong r)
        {
            Vec2ul ret;
            ret.x = (ulong)(l.x - r);
            ret.y = (ulong)(l.y - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ul operator -(ulong l, Vec2ul r)
        {
            Vec2ul ret;
            ret.x = (ulong)(l - r.x);
            ret.y = (ulong)(l - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ul operator *(Vec2ul l, ulong r)
        {
            Vec2ul ret;
            ret.x = (ulong)(l.x * r);
            ret.y = (ulong)(l.y * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ul operator *(ulong l, Vec2ul r)
        {
            Vec2ul ret;
            ret.x = (ulong)(l * r.x);
            ret.y = (ulong)(l * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ul operator /(Vec2ul l, ulong r)
        {
            Vec2ul ret;
            ret.x = (ulong)(l.x / r);
            ret.y = (ulong)(l.y / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ul operator /(ulong l, Vec2ul r)
        {
            Vec2ul ret;
            ret.x = (ulong)(l / r.x);
            ret.y = (ulong)(l / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ul operator %(Vec2ul l, Vec2ul r)
        {
            Vec2ul ret;
            ret.x = (ulong)(l.x % r.x);
            ret.y = (ulong)(l.y % r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ul operator %(Vec2ul l, ulong r)
        {
            Vec2ul ret;
            ret.x = (ulong)(l.x % r);
            ret.y = (ulong)(l.y % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ul operator %(ulong l, Vec2ul r)
        {
            Vec2ul ret;
            ret.x = (ulong)(l % r.x);
            ret.y = (ulong)(l % r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Dot(Vec2ul l, Vec2ul r)
        {
            ulong ret = 0;
            ret += (ulong)(l.x * r.x);
            ret += (ulong)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong Dot(Vec2ul r)
        {
            ulong ret = 0;
            ret += (ulong)(x * r.x);
            ret += (ulong)(y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec2ul l, Vec2ul r)
        {
            return l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec2ul l, Vec2ul r)
        {
            return l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec2ul l, Vec2ul r)
        {
            return l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec2ul l, Vec2ul r)
        {
            return l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec2ul other)
        {
            return x == other.x && x == other.x;
        }

        public ulong this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    default: return y;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    default: y = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3ul : IEquatable<Vec3ul>
    {
        public ulong x;
        public ulong y;
        public ulong z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2l other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec3l other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2l other, ulong z)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2ul other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec3ul other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2ul other, ulong z)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2i other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec3i other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2i other, ulong z)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2ui other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec3ui other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2ui other, ulong z)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2s other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec3s other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2s other, ulong z)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2us other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec3us other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2us other, ulong z)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2b other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec3b other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2b other, ulong z)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2d other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec3d other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2d other, ulong z)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2f other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec3f other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(Vec2f other, ulong z)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(ulong x, ulong y, ulong z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul(ulong fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul operator +(Vec3ul l, Vec3ul r)
        {
            Vec3ul ret;
            ret.x = (ulong)(l.x + r.x);
            ret.y = (ulong)(l.y + r.y);
            ret.z = (ulong)(l.z + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul operator -(Vec3ul l, Vec3ul r)
        {
            Vec3ul ret;
            ret.x = (ulong)(l.x - r.x);
            ret.y = (ulong)(l.y - r.y);
            ret.z = (ulong)(l.z - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul operator *(Vec3ul l, Vec3ul r)
        {
            Vec3ul ret;
            ret.x = (ulong)(l.x * r.x);
            ret.y = (ulong)(l.y * r.y);
            ret.z = (ulong)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul operator /(Vec3ul l, Vec3ul r)
        {
            Vec3ul ret;
            ret.x = (ulong)(l.x / r.x);
            ret.y = (ulong)(l.y / r.y);
            ret.z = (ulong)(l.z / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul operator +(Vec3ul l, ulong r)
        {
            Vec3ul ret;
            ret.x = (ulong)(l.x + r);
            ret.y = (ulong)(l.y + r);
            ret.z = (ulong)(l.z + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul operator +(ulong l, Vec3ul r)
        {
            Vec3ul ret;
            ret.x = (ulong)(l + r.x);
            ret.y = (ulong)(l + r.y);
            ret.z = (ulong)(l + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul operator -(Vec3ul l, ulong r)
        {
            Vec3ul ret;
            ret.x = (ulong)(l.x - r);
            ret.y = (ulong)(l.y - r);
            ret.z = (ulong)(l.z - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul operator -(ulong l, Vec3ul r)
        {
            Vec3ul ret;
            ret.x = (ulong)(l - r.x);
            ret.y = (ulong)(l - r.y);
            ret.z = (ulong)(l - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul operator *(Vec3ul l, ulong r)
        {
            Vec3ul ret;
            ret.x = (ulong)(l.x * r);
            ret.y = (ulong)(l.y * r);
            ret.z = (ulong)(l.z * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul operator *(ulong l, Vec3ul r)
        {
            Vec3ul ret;
            ret.x = (ulong)(l * r.x);
            ret.y = (ulong)(l * r.y);
            ret.z = (ulong)(l * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul operator /(Vec3ul l, ulong r)
        {
            Vec3ul ret;
            ret.x = (ulong)(l.x / r);
            ret.y = (ulong)(l.y / r);
            ret.z = (ulong)(l.z / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul operator /(ulong l, Vec3ul r)
        {
            Vec3ul ret;
            ret.x = (ulong)(l / r.x);
            ret.y = (ulong)(l / r.y);
            ret.z = (ulong)(l / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul operator %(Vec3ul l, Vec3ul r)
        {
            Vec3ul ret;
            ret.x = (ulong)(l.x % r.x);
            ret.y = (ulong)(l.y % r.y);
            ret.z = (ulong)(l.z % r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul operator %(Vec3ul l, ulong r)
        {
            Vec3ul ret;
            ret.x = (ulong)(l.x % r);
            ret.y = (ulong)(l.y % r);
            ret.z = (ulong)(l.z % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul operator %(ulong l, Vec3ul r)
        {
            Vec3ul ret;
            ret.x = (ulong)(l % r.x);
            ret.y = (ulong)(l % r.y);
            ret.z = (ulong)(l % r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Dot(Vec3ul l, Vec3ul r)
        {
            ulong ret = 0;
            ret += (ulong)(l.x * r.x);
            ret += (ulong)(l.y * r.y);
            ret += (ulong)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong Dot(Vec3ul r)
        {
            ulong ret = 0;
            ret += (ulong)(x * r.x);
            ret += (ulong)(y * r.y);
            ret += (ulong)(z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ul Cross(Vec3ul u, Vec3ul v)
        {
            Vec3ul ret;
            ret.x = (ulong)(u.y * v.z - u.z * v.y);
            ret.y = (ulong)(u.z * v.x - u.x * v.z);
            ret.z = (ulong)(u.x * v.y - u.y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ul Cross(Vec3ul v)
        {
            Vec3ul ret;
            ret.x = (ulong)(y * v.z - z * v.y);
            ret.y = (ulong)(z * v.x - x * v.z);
            ret.z = (ulong)(x * v.y - y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec3ul l, Vec3ul r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec3ul l, Vec3ul r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec3ul l, Vec3ul r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec3ul l, Vec3ul r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec3ul other)
        {
            return x == other.x && x == other.x && x == other.x;
        }

        public ulong this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    default: return z;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default: z = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4ul : IEquatable<Vec4ul>
    {
        public ulong x;
        public ulong y;
        public ulong z;
        public ulong w;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2l other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3l other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec4l other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = (ulong)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2l other, ulong z, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3l other, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2ul other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3ul other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec4ul other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = (ulong)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2ul other, ulong z, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3ul other, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2i other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3i other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec4i other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = (ulong)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2i other, ulong z, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3i other, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2ui other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3ui other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec4ui other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = (ulong)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2ui other, ulong z, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3ui other, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2s other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3s other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec4s other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = (ulong)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2s other, ulong z, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3s other, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2us other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3us other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec4us other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = (ulong)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2us other, ulong z, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3us other, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2b other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3b other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec4b other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = (ulong)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2b other, ulong z, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3b other, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2d other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3d other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec4d other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = (ulong)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2d other, ulong z, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3d other, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2f other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3f other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec4f other)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            w = (ulong)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec2f other, ulong z, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(Vec3f other, ulong w)
        {
            x = (ulong)other.x;
            y = (ulong)other.y;
            z = (ulong)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(ulong x, ulong y, ulong z, ulong w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ul(ulong fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
            this.w = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ul operator +(Vec4ul l, Vec4ul r)
        {
            Vec4ul ret;
            ret.x = (ulong)(l.x + r.x);
            ret.y = (ulong)(l.y + r.y);
            ret.z = (ulong)(l.z + r.z);
            ret.w = (ulong)(l.w + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ul operator -(Vec4ul l, Vec4ul r)
        {
            Vec4ul ret;
            ret.x = (ulong)(l.x - r.x);
            ret.y = (ulong)(l.y - r.y);
            ret.z = (ulong)(l.z - r.z);
            ret.w = (ulong)(l.w - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ul operator *(Vec4ul l, Vec4ul r)
        {
            Vec4ul ret;
            ret.x = (ulong)(l.x * r.x);
            ret.y = (ulong)(l.y * r.y);
            ret.z = (ulong)(l.z * r.z);
            ret.w = (ulong)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ul operator /(Vec4ul l, Vec4ul r)
        {
            Vec4ul ret;
            ret.x = (ulong)(l.x / r.x);
            ret.y = (ulong)(l.y / r.y);
            ret.z = (ulong)(l.z / r.z);
            ret.w = (ulong)(l.w / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ul operator +(Vec4ul l, ulong r)
        {
            Vec4ul ret;
            ret.x = (ulong)(l.x + r);
            ret.y = (ulong)(l.y + r);
            ret.z = (ulong)(l.z + r);
            ret.w = (ulong)(l.w + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ul operator +(ulong l, Vec4ul r)
        {
            Vec4ul ret;
            ret.x = (ulong)(l + r.x);
            ret.y = (ulong)(l + r.y);
            ret.z = (ulong)(l + r.z);
            ret.w = (ulong)(l + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ul operator -(Vec4ul l, ulong r)
        {
            Vec4ul ret;
            ret.x = (ulong)(l.x - r);
            ret.y = (ulong)(l.y - r);
            ret.z = (ulong)(l.z - r);
            ret.w = (ulong)(l.w - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ul operator -(ulong l, Vec4ul r)
        {
            Vec4ul ret;
            ret.x = (ulong)(l - r.x);
            ret.y = (ulong)(l - r.y);
            ret.z = (ulong)(l - r.z);
            ret.w = (ulong)(l - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ul operator *(Vec4ul l, ulong r)
        {
            Vec4ul ret;
            ret.x = (ulong)(l.x * r);
            ret.y = (ulong)(l.y * r);
            ret.z = (ulong)(l.z * r);
            ret.w = (ulong)(l.w * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ul operator *(ulong l, Vec4ul r)
        {
            Vec4ul ret;
            ret.x = (ulong)(l * r.x);
            ret.y = (ulong)(l * r.y);
            ret.z = (ulong)(l * r.z);
            ret.w = (ulong)(l * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ul operator /(Vec4ul l, ulong r)
        {
            Vec4ul ret;
            ret.x = (ulong)(l.x / r);
            ret.y = (ulong)(l.y / r);
            ret.z = (ulong)(l.z / r);
            ret.w = (ulong)(l.w / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ul operator /(ulong l, Vec4ul r)
        {
            Vec4ul ret;
            ret.x = (ulong)(l / r.x);
            ret.y = (ulong)(l / r.y);
            ret.z = (ulong)(l / r.z);
            ret.w = (ulong)(l / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ul operator %(Vec4ul l, Vec4ul r)
        {
            Vec4ul ret;
            ret.x = (ulong)(l.x % r.x);
            ret.y = (ulong)(l.y % r.y);
            ret.z = (ulong)(l.z % r.z);
            ret.w = (ulong)(l.w % r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ul operator %(Vec4ul l, ulong r)
        {
            Vec4ul ret;
            ret.x = (ulong)(l.x % r);
            ret.y = (ulong)(l.y % r);
            ret.z = (ulong)(l.z % r);
            ret.w = (ulong)(l.w % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ul operator %(ulong l, Vec4ul r)
        {
            Vec4ul ret;
            ret.x = (ulong)(l % r.x);
            ret.y = (ulong)(l % r.y);
            ret.z = (ulong)(l % r.z);
            ret.w = (ulong)(l % r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Dot(Vec4ul l, Vec4ul r)
        {
            ulong ret = 0;
            ret += (ulong)(l.x * r.x);
            ret += (ulong)(l.y * r.y);
            ret += (ulong)(l.z * r.z);
            ret += (ulong)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong Dot(Vec4ul r)
        {
            ulong ret = 0;
            ret += (ulong)(x * r.x);
            ret += (ulong)(y * r.y);
            ret += (ulong)(z * r.z);
            ret += (ulong)(w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec4ul l, Vec4ul r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec4ul l, Vec4ul r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec4ul l, Vec4ul r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec4ul l, Vec4ul r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec4ul other)
        {
            return x == other.x && x == other.x && x == other.x && x == other.x;
        }

        public ulong this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: return w;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: w = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2i : IEquatable<Vec2i>
    {
        public int x;
        public int y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2i(Vec2l other)
        {
            x = (int)other.x;
            y = (int)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2i(Vec2ul other)
        {
            x = (int)other.x;
            y = (int)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2i(Vec2i other)
        {
            x = (int)other.x;
            y = (int)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2i(Vec2ui other)
        {
            x = (int)other.x;
            y = (int)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2i(Vec2s other)
        {
            x = (int)other.x;
            y = (int)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2i(Vec2us other)
        {
            x = (int)other.x;
            y = (int)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2i(Vec2b other)
        {
            x = (int)other.x;
            y = (int)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2i(Vec2d other)
        {
            x = (int)other.x;
            y = (int)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2i(Vec2f other)
        {
            x = (int)other.x;
            y = (int)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2i(int x, int y)
        {
            this.x = x;
            this.y = y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2i(int fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2i operator +(Vec2i l, Vec2i r)
        {
            Vec2i ret;
            ret.x = (int)(l.x + r.x);
            ret.y = (int)(l.y + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2i operator -(Vec2i l, Vec2i r)
        {
            Vec2i ret;
            ret.x = (int)(l.x - r.x);
            ret.y = (int)(l.y - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2i operator *(Vec2i l, Vec2i r)
        {
            Vec2i ret;
            ret.x = (int)(l.x * r.x);
            ret.y = (int)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2i operator /(Vec2i l, Vec2i r)
        {
            Vec2i ret;
            ret.x = (int)(l.x / r.x);
            ret.y = (int)(l.y / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2i operator +(Vec2i l, int r)
        {
            Vec2i ret;
            ret.x = (int)(l.x + r);
            ret.y = (int)(l.y + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2i operator +(int l, Vec2i r)
        {
            Vec2i ret;
            ret.x = (int)(l + r.x);
            ret.y = (int)(l + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2i operator -(Vec2i l, int r)
        {
            Vec2i ret;
            ret.x = (int)(l.x - r);
            ret.y = (int)(l.y - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2i operator -(int l, Vec2i r)
        {
            Vec2i ret;
            ret.x = (int)(l - r.x);
            ret.y = (int)(l - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2i operator *(Vec2i l, int r)
        {
            Vec2i ret;
            ret.x = (int)(l.x * r);
            ret.y = (int)(l.y * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2i operator *(int l, Vec2i r)
        {
            Vec2i ret;
            ret.x = (int)(l * r.x);
            ret.y = (int)(l * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2i operator /(Vec2i l, int r)
        {
            Vec2i ret;
            ret.x = (int)(l.x / r);
            ret.y = (int)(l.y / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2i operator /(int l, Vec2i r)
        {
            Vec2i ret;
            ret.x = (int)(l / r.x);
            ret.y = (int)(l / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2i operator %(Vec2i l, Vec2i r)
        {
            Vec2i ret;
            ret.x = (int)(l.x % r.x);
            ret.y = (int)(l.y % r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2i operator %(Vec2i l, int r)
        {
            Vec2i ret;
            ret.x = (int)(l.x % r);
            ret.y = (int)(l.y % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2i operator %(int l, Vec2i r)
        {
            Vec2i ret;
            ret.x = (int)(l % r.x);
            ret.y = (int)(l % r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Dot(Vec2i l, Vec2i r)
        {
            int ret = 0;
            ret += (int)(l.x * r.x);
            ret += (int)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Dot(Vec2i r)
        {
            int ret = 0;
            ret += (int)(x * r.x);
            ret += (int)(y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec2i l, Vec2i r)
        {
            return l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec2i l, Vec2i r)
        {
            return l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec2i l, Vec2i r)
        {
            return l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec2i l, Vec2i r)
        {
            return l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec2i other)
        {
            return x == other.x && x == other.x;
        }

        public int this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    default: return y;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    default: y = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3i : IEquatable<Vec3i>
    {
        public int x;
        public int y;
        public int z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2l other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec3l other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2l other, int z)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2ul other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec3ul other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2ul other, int z)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2i other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec3i other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2i other, int z)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2ui other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec3ui other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2ui other, int z)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2s other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec3s other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2s other, int z)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2us other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec3us other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2us other, int z)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2b other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec3b other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2b other, int z)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2d other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec3d other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2d other, int z)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2f other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec3f other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(Vec2f other, int z)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i(int fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i operator +(Vec3i l, Vec3i r)
        {
            Vec3i ret;
            ret.x = (int)(l.x + r.x);
            ret.y = (int)(l.y + r.y);
            ret.z = (int)(l.z + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i operator -(Vec3i l, Vec3i r)
        {
            Vec3i ret;
            ret.x = (int)(l.x - r.x);
            ret.y = (int)(l.y - r.y);
            ret.z = (int)(l.z - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i operator *(Vec3i l, Vec3i r)
        {
            Vec3i ret;
            ret.x = (int)(l.x * r.x);
            ret.y = (int)(l.y * r.y);
            ret.z = (int)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i operator /(Vec3i l, Vec3i r)
        {
            Vec3i ret;
            ret.x = (int)(l.x / r.x);
            ret.y = (int)(l.y / r.y);
            ret.z = (int)(l.z / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i operator +(Vec3i l, int r)
        {
            Vec3i ret;
            ret.x = (int)(l.x + r);
            ret.y = (int)(l.y + r);
            ret.z = (int)(l.z + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i operator +(int l, Vec3i r)
        {
            Vec3i ret;
            ret.x = (int)(l + r.x);
            ret.y = (int)(l + r.y);
            ret.z = (int)(l + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i operator -(Vec3i l, int r)
        {
            Vec3i ret;
            ret.x = (int)(l.x - r);
            ret.y = (int)(l.y - r);
            ret.z = (int)(l.z - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i operator -(int l, Vec3i r)
        {
            Vec3i ret;
            ret.x = (int)(l - r.x);
            ret.y = (int)(l - r.y);
            ret.z = (int)(l - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i operator *(Vec3i l, int r)
        {
            Vec3i ret;
            ret.x = (int)(l.x * r);
            ret.y = (int)(l.y * r);
            ret.z = (int)(l.z * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i operator *(int l, Vec3i r)
        {
            Vec3i ret;
            ret.x = (int)(l * r.x);
            ret.y = (int)(l * r.y);
            ret.z = (int)(l * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i operator /(Vec3i l, int r)
        {
            Vec3i ret;
            ret.x = (int)(l.x / r);
            ret.y = (int)(l.y / r);
            ret.z = (int)(l.z / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i operator /(int l, Vec3i r)
        {
            Vec3i ret;
            ret.x = (int)(l / r.x);
            ret.y = (int)(l / r.y);
            ret.z = (int)(l / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i operator %(Vec3i l, Vec3i r)
        {
            Vec3i ret;
            ret.x = (int)(l.x % r.x);
            ret.y = (int)(l.y % r.y);
            ret.z = (int)(l.z % r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i operator %(Vec3i l, int r)
        {
            Vec3i ret;
            ret.x = (int)(l.x % r);
            ret.y = (int)(l.y % r);
            ret.z = (int)(l.z % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i operator %(int l, Vec3i r)
        {
            Vec3i ret;
            ret.x = (int)(l % r.x);
            ret.y = (int)(l % r.y);
            ret.z = (int)(l % r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Dot(Vec3i l, Vec3i r)
        {
            int ret = 0;
            ret += (int)(l.x * r.x);
            ret += (int)(l.y * r.y);
            ret += (int)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Dot(Vec3i r)
        {
            int ret = 0;
            ret += (int)(x * r.x);
            ret += (int)(y * r.y);
            ret += (int)(z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3i Cross(Vec3i u, Vec3i v)
        {
            Vec3i ret;
            ret.x = (int)(u.y * v.z - u.z * v.y);
            ret.y = (int)(u.z * v.x - u.x * v.z);
            ret.z = (int)(u.x * v.y - u.y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3i Cross(Vec3i v)
        {
            Vec3i ret;
            ret.x = (int)(y * v.z - z * v.y);
            ret.y = (int)(z * v.x - x * v.z);
            ret.z = (int)(x * v.y - y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec3i l, Vec3i r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec3i l, Vec3i r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec3i l, Vec3i r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec3i l, Vec3i r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec3i other)
        {
            return x == other.x && x == other.x && x == other.x;
        }

        public int this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    default: return z;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default: z = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4i : IEquatable<Vec4i>
    {
        public int x;
        public int y;
        public int z;
        public int w;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2l other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3l other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec4l other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = (int)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2l other, int z, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3l other, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2ul other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3ul other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec4ul other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = (int)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2ul other, int z, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3ul other, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2i other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3i other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec4i other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = (int)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2i other, int z, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3i other, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2ui other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3ui other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec4ui other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = (int)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2ui other, int z, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3ui other, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2s other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3s other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec4s other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = (int)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2s other, int z, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3s other, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2us other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3us other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec4us other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = (int)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2us other, int z, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3us other, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2b other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3b other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec4b other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = (int)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2b other, int z, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3b other, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2d other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3d other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec4d other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = (int)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2d other, int z, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3d other, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2f other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3f other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec4f other)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            w = (int)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec2f other, int z, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(Vec3f other, int w)
        {
            x = (int)other.x;
            y = (int)other.y;
            z = (int)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(int x, int y, int z, int w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4i(int fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
            this.w = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4i operator +(Vec4i l, Vec4i r)
        {
            Vec4i ret;
            ret.x = (int)(l.x + r.x);
            ret.y = (int)(l.y + r.y);
            ret.z = (int)(l.z + r.z);
            ret.w = (int)(l.w + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4i operator -(Vec4i l, Vec4i r)
        {
            Vec4i ret;
            ret.x = (int)(l.x - r.x);
            ret.y = (int)(l.y - r.y);
            ret.z = (int)(l.z - r.z);
            ret.w = (int)(l.w - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4i operator *(Vec4i l, Vec4i r)
        {
            Vec4i ret;
            ret.x = (int)(l.x * r.x);
            ret.y = (int)(l.y * r.y);
            ret.z = (int)(l.z * r.z);
            ret.w = (int)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4i operator /(Vec4i l, Vec4i r)
        {
            Vec4i ret;
            ret.x = (int)(l.x / r.x);
            ret.y = (int)(l.y / r.y);
            ret.z = (int)(l.z / r.z);
            ret.w = (int)(l.w / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4i operator +(Vec4i l, int r)
        {
            Vec4i ret;
            ret.x = (int)(l.x + r);
            ret.y = (int)(l.y + r);
            ret.z = (int)(l.z + r);
            ret.w = (int)(l.w + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4i operator +(int l, Vec4i r)
        {
            Vec4i ret;
            ret.x = (int)(l + r.x);
            ret.y = (int)(l + r.y);
            ret.z = (int)(l + r.z);
            ret.w = (int)(l + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4i operator -(Vec4i l, int r)
        {
            Vec4i ret;
            ret.x = (int)(l.x - r);
            ret.y = (int)(l.y - r);
            ret.z = (int)(l.z - r);
            ret.w = (int)(l.w - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4i operator -(int l, Vec4i r)
        {
            Vec4i ret;
            ret.x = (int)(l - r.x);
            ret.y = (int)(l - r.y);
            ret.z = (int)(l - r.z);
            ret.w = (int)(l - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4i operator *(Vec4i l, int r)
        {
            Vec4i ret;
            ret.x = (int)(l.x * r);
            ret.y = (int)(l.y * r);
            ret.z = (int)(l.z * r);
            ret.w = (int)(l.w * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4i operator *(int l, Vec4i r)
        {
            Vec4i ret;
            ret.x = (int)(l * r.x);
            ret.y = (int)(l * r.y);
            ret.z = (int)(l * r.z);
            ret.w = (int)(l * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4i operator /(Vec4i l, int r)
        {
            Vec4i ret;
            ret.x = (int)(l.x / r);
            ret.y = (int)(l.y / r);
            ret.z = (int)(l.z / r);
            ret.w = (int)(l.w / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4i operator /(int l, Vec4i r)
        {
            Vec4i ret;
            ret.x = (int)(l / r.x);
            ret.y = (int)(l / r.y);
            ret.z = (int)(l / r.z);
            ret.w = (int)(l / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4i operator %(Vec4i l, Vec4i r)
        {
            Vec4i ret;
            ret.x = (int)(l.x % r.x);
            ret.y = (int)(l.y % r.y);
            ret.z = (int)(l.z % r.z);
            ret.w = (int)(l.w % r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4i operator %(Vec4i l, int r)
        {
            Vec4i ret;
            ret.x = (int)(l.x % r);
            ret.y = (int)(l.y % r);
            ret.z = (int)(l.z % r);
            ret.w = (int)(l.w % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4i operator %(int l, Vec4i r)
        {
            Vec4i ret;
            ret.x = (int)(l % r.x);
            ret.y = (int)(l % r.y);
            ret.z = (int)(l % r.z);
            ret.w = (int)(l % r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Dot(Vec4i l, Vec4i r)
        {
            int ret = 0;
            ret += (int)(l.x * r.x);
            ret += (int)(l.y * r.y);
            ret += (int)(l.z * r.z);
            ret += (int)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Dot(Vec4i r)
        {
            int ret = 0;
            ret += (int)(x * r.x);
            ret += (int)(y * r.y);
            ret += (int)(z * r.z);
            ret += (int)(w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec4i l, Vec4i r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec4i l, Vec4i r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec4i l, Vec4i r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec4i l, Vec4i r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec4i other)
        {
            return x == other.x && x == other.x && x == other.x && x == other.x;
        }

        public int this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: return w;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: w = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2ui : IEquatable<Vec2ui>
    {
        public uint x;
        public uint y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ui(Vec2l other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ui(Vec2ul other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ui(Vec2i other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ui(Vec2ui other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ui(Vec2s other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ui(Vec2us other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ui(Vec2b other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ui(Vec2d other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ui(Vec2f other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ui(uint x, uint y)
        {
            this.x = x;
            this.y = y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2ui(uint fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ui operator +(Vec2ui l, Vec2ui r)
        {
            Vec2ui ret;
            ret.x = (uint)(l.x + r.x);
            ret.y = (uint)(l.y + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ui operator -(Vec2ui l, Vec2ui r)
        {
            Vec2ui ret;
            ret.x = (uint)(l.x - r.x);
            ret.y = (uint)(l.y - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ui operator *(Vec2ui l, Vec2ui r)
        {
            Vec2ui ret;
            ret.x = (uint)(l.x * r.x);
            ret.y = (uint)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ui operator /(Vec2ui l, Vec2ui r)
        {
            Vec2ui ret;
            ret.x = (uint)(l.x / r.x);
            ret.y = (uint)(l.y / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ui operator +(Vec2ui l, uint r)
        {
            Vec2ui ret;
            ret.x = (uint)(l.x + r);
            ret.y = (uint)(l.y + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ui operator +(uint l, Vec2ui r)
        {
            Vec2ui ret;
            ret.x = (uint)(l + r.x);
            ret.y = (uint)(l + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ui operator -(Vec2ui l, uint r)
        {
            Vec2ui ret;
            ret.x = (uint)(l.x - r);
            ret.y = (uint)(l.y - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ui operator -(uint l, Vec2ui r)
        {
            Vec2ui ret;
            ret.x = (uint)(l - r.x);
            ret.y = (uint)(l - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ui operator *(Vec2ui l, uint r)
        {
            Vec2ui ret;
            ret.x = (uint)(l.x * r);
            ret.y = (uint)(l.y * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ui operator *(uint l, Vec2ui r)
        {
            Vec2ui ret;
            ret.x = (uint)(l * r.x);
            ret.y = (uint)(l * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ui operator /(Vec2ui l, uint r)
        {
            Vec2ui ret;
            ret.x = (uint)(l.x / r);
            ret.y = (uint)(l.y / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ui operator /(uint l, Vec2ui r)
        {
            Vec2ui ret;
            ret.x = (uint)(l / r.x);
            ret.y = (uint)(l / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ui operator %(Vec2ui l, Vec2ui r)
        {
            Vec2ui ret;
            ret.x = (uint)(l.x % r.x);
            ret.y = (uint)(l.y % r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ui operator %(Vec2ui l, uint r)
        {
            Vec2ui ret;
            ret.x = (uint)(l.x % r);
            ret.y = (uint)(l.y % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2ui operator %(uint l, Vec2ui r)
        {
            Vec2ui ret;
            ret.x = (uint)(l % r.x);
            ret.y = (uint)(l % r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Dot(Vec2ui l, Vec2ui r)
        {
            uint ret = 0;
            ret += (uint)(l.x * r.x);
            ret += (uint)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint Dot(Vec2ui r)
        {
            uint ret = 0;
            ret += (uint)(x * r.x);
            ret += (uint)(y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec2ui l, Vec2ui r)
        {
            return l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec2ui l, Vec2ui r)
        {
            return l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec2ui l, Vec2ui r)
        {
            return l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec2ui l, Vec2ui r)
        {
            return l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec2ui other)
        {
            return x == other.x && x == other.x;
        }

        public uint this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    default: return y;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    default: y = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3ui : IEquatable<Vec3ui>
    {
        public uint x;
        public uint y;
        public uint z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2l other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec3l other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2l other, uint z)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2ul other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec3ul other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2ul other, uint z)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2i other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec3i other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2i other, uint z)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2ui other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec3ui other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2ui other, uint z)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2s other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec3s other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2s other, uint z)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2us other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec3us other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2us other, uint z)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2b other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec3b other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2b other, uint z)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2d other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec3d other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2d other, uint z)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2f other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec3f other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(Vec2f other, uint z)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(uint x, uint y, uint z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui(uint fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui operator +(Vec3ui l, Vec3ui r)
        {
            Vec3ui ret;
            ret.x = (uint)(l.x + r.x);
            ret.y = (uint)(l.y + r.y);
            ret.z = (uint)(l.z + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui operator -(Vec3ui l, Vec3ui r)
        {
            Vec3ui ret;
            ret.x = (uint)(l.x - r.x);
            ret.y = (uint)(l.y - r.y);
            ret.z = (uint)(l.z - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui operator *(Vec3ui l, Vec3ui r)
        {
            Vec3ui ret;
            ret.x = (uint)(l.x * r.x);
            ret.y = (uint)(l.y * r.y);
            ret.z = (uint)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui operator /(Vec3ui l, Vec3ui r)
        {
            Vec3ui ret;
            ret.x = (uint)(l.x / r.x);
            ret.y = (uint)(l.y / r.y);
            ret.z = (uint)(l.z / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui operator +(Vec3ui l, uint r)
        {
            Vec3ui ret;
            ret.x = (uint)(l.x + r);
            ret.y = (uint)(l.y + r);
            ret.z = (uint)(l.z + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui operator +(uint l, Vec3ui r)
        {
            Vec3ui ret;
            ret.x = (uint)(l + r.x);
            ret.y = (uint)(l + r.y);
            ret.z = (uint)(l + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui operator -(Vec3ui l, uint r)
        {
            Vec3ui ret;
            ret.x = (uint)(l.x - r);
            ret.y = (uint)(l.y - r);
            ret.z = (uint)(l.z - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui operator -(uint l, Vec3ui r)
        {
            Vec3ui ret;
            ret.x = (uint)(l - r.x);
            ret.y = (uint)(l - r.y);
            ret.z = (uint)(l - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui operator *(Vec3ui l, uint r)
        {
            Vec3ui ret;
            ret.x = (uint)(l.x * r);
            ret.y = (uint)(l.y * r);
            ret.z = (uint)(l.z * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui operator *(uint l, Vec3ui r)
        {
            Vec3ui ret;
            ret.x = (uint)(l * r.x);
            ret.y = (uint)(l * r.y);
            ret.z = (uint)(l * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui operator /(Vec3ui l, uint r)
        {
            Vec3ui ret;
            ret.x = (uint)(l.x / r);
            ret.y = (uint)(l.y / r);
            ret.z = (uint)(l.z / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui operator /(uint l, Vec3ui r)
        {
            Vec3ui ret;
            ret.x = (uint)(l / r.x);
            ret.y = (uint)(l / r.y);
            ret.z = (uint)(l / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui operator %(Vec3ui l, Vec3ui r)
        {
            Vec3ui ret;
            ret.x = (uint)(l.x % r.x);
            ret.y = (uint)(l.y % r.y);
            ret.z = (uint)(l.z % r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui operator %(Vec3ui l, uint r)
        {
            Vec3ui ret;
            ret.x = (uint)(l.x % r);
            ret.y = (uint)(l.y % r);
            ret.z = (uint)(l.z % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui operator %(uint l, Vec3ui r)
        {
            Vec3ui ret;
            ret.x = (uint)(l % r.x);
            ret.y = (uint)(l % r.y);
            ret.z = (uint)(l % r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Dot(Vec3ui l, Vec3ui r)
        {
            uint ret = 0;
            ret += (uint)(l.x * r.x);
            ret += (uint)(l.y * r.y);
            ret += (uint)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint Dot(Vec3ui r)
        {
            uint ret = 0;
            ret += (uint)(x * r.x);
            ret += (uint)(y * r.y);
            ret += (uint)(z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3ui Cross(Vec3ui u, Vec3ui v)
        {
            Vec3ui ret;
            ret.x = (uint)(u.y * v.z - u.z * v.y);
            ret.y = (uint)(u.z * v.x - u.x * v.z);
            ret.z = (uint)(u.x * v.y - u.y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3ui Cross(Vec3ui v)
        {
            Vec3ui ret;
            ret.x = (uint)(y * v.z - z * v.y);
            ret.y = (uint)(z * v.x - x * v.z);
            ret.z = (uint)(x * v.y - y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec3ui l, Vec3ui r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec3ui l, Vec3ui r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec3ui l, Vec3ui r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec3ui l, Vec3ui r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec3ui other)
        {
            return x == other.x && x == other.x && x == other.x;
        }

        public uint this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    default: return z;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default: z = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4ui : IEquatable<Vec4ui>
    {
        public uint x;
        public uint y;
        public uint z;
        public uint w;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2l other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3l other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec4l other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = (uint)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2l other, uint z, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3l other, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2ul other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3ul other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec4ul other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = (uint)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2ul other, uint z, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3ul other, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2i other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3i other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec4i other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = (uint)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2i other, uint z, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3i other, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2ui other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3ui other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec4ui other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = (uint)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2ui other, uint z, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3ui other, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2s other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3s other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec4s other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = (uint)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2s other, uint z, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3s other, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2us other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3us other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec4us other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = (uint)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2us other, uint z, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3us other, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2b other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3b other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec4b other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = (uint)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2b other, uint z, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3b other, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2d other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3d other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec4d other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = (uint)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2d other, uint z, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3d other, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2f other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3f other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec4f other)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            w = (uint)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec2f other, uint z, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(Vec3f other, uint w)
        {
            x = (uint)other.x;
            y = (uint)other.y;
            z = (uint)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(uint x, uint y, uint z, uint w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4ui(uint fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
            this.w = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ui operator +(Vec4ui l, Vec4ui r)
        {
            Vec4ui ret;
            ret.x = (uint)(l.x + r.x);
            ret.y = (uint)(l.y + r.y);
            ret.z = (uint)(l.z + r.z);
            ret.w = (uint)(l.w + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ui operator -(Vec4ui l, Vec4ui r)
        {
            Vec4ui ret;
            ret.x = (uint)(l.x - r.x);
            ret.y = (uint)(l.y - r.y);
            ret.z = (uint)(l.z - r.z);
            ret.w = (uint)(l.w - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ui operator *(Vec4ui l, Vec4ui r)
        {
            Vec4ui ret;
            ret.x = (uint)(l.x * r.x);
            ret.y = (uint)(l.y * r.y);
            ret.z = (uint)(l.z * r.z);
            ret.w = (uint)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ui operator /(Vec4ui l, Vec4ui r)
        {
            Vec4ui ret;
            ret.x = (uint)(l.x / r.x);
            ret.y = (uint)(l.y / r.y);
            ret.z = (uint)(l.z / r.z);
            ret.w = (uint)(l.w / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ui operator +(Vec4ui l, uint r)
        {
            Vec4ui ret;
            ret.x = (uint)(l.x + r);
            ret.y = (uint)(l.y + r);
            ret.z = (uint)(l.z + r);
            ret.w = (uint)(l.w + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ui operator +(uint l, Vec4ui r)
        {
            Vec4ui ret;
            ret.x = (uint)(l + r.x);
            ret.y = (uint)(l + r.y);
            ret.z = (uint)(l + r.z);
            ret.w = (uint)(l + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ui operator -(Vec4ui l, uint r)
        {
            Vec4ui ret;
            ret.x = (uint)(l.x - r);
            ret.y = (uint)(l.y - r);
            ret.z = (uint)(l.z - r);
            ret.w = (uint)(l.w - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ui operator -(uint l, Vec4ui r)
        {
            Vec4ui ret;
            ret.x = (uint)(l - r.x);
            ret.y = (uint)(l - r.y);
            ret.z = (uint)(l - r.z);
            ret.w = (uint)(l - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ui operator *(Vec4ui l, uint r)
        {
            Vec4ui ret;
            ret.x = (uint)(l.x * r);
            ret.y = (uint)(l.y * r);
            ret.z = (uint)(l.z * r);
            ret.w = (uint)(l.w * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ui operator *(uint l, Vec4ui r)
        {
            Vec4ui ret;
            ret.x = (uint)(l * r.x);
            ret.y = (uint)(l * r.y);
            ret.z = (uint)(l * r.z);
            ret.w = (uint)(l * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ui operator /(Vec4ui l, uint r)
        {
            Vec4ui ret;
            ret.x = (uint)(l.x / r);
            ret.y = (uint)(l.y / r);
            ret.z = (uint)(l.z / r);
            ret.w = (uint)(l.w / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ui operator /(uint l, Vec4ui r)
        {
            Vec4ui ret;
            ret.x = (uint)(l / r.x);
            ret.y = (uint)(l / r.y);
            ret.z = (uint)(l / r.z);
            ret.w = (uint)(l / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ui operator %(Vec4ui l, Vec4ui r)
        {
            Vec4ui ret;
            ret.x = (uint)(l.x % r.x);
            ret.y = (uint)(l.y % r.y);
            ret.z = (uint)(l.z % r.z);
            ret.w = (uint)(l.w % r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ui operator %(Vec4ui l, uint r)
        {
            Vec4ui ret;
            ret.x = (uint)(l.x % r);
            ret.y = (uint)(l.y % r);
            ret.z = (uint)(l.z % r);
            ret.w = (uint)(l.w % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4ui operator %(uint l, Vec4ui r)
        {
            Vec4ui ret;
            ret.x = (uint)(l % r.x);
            ret.y = (uint)(l % r.y);
            ret.z = (uint)(l % r.z);
            ret.w = (uint)(l % r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Dot(Vec4ui l, Vec4ui r)
        {
            uint ret = 0;
            ret += (uint)(l.x * r.x);
            ret += (uint)(l.y * r.y);
            ret += (uint)(l.z * r.z);
            ret += (uint)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint Dot(Vec4ui r)
        {
            uint ret = 0;
            ret += (uint)(x * r.x);
            ret += (uint)(y * r.y);
            ret += (uint)(z * r.z);
            ret += (uint)(w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec4ui l, Vec4ui r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec4ui l, Vec4ui r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec4ui l, Vec4ui r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec4ui l, Vec4ui r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec4ui other)
        {
            return x == other.x && x == other.x && x == other.x && x == other.x;
        }

        public uint this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: return w;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: w = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2s : IEquatable<Vec2s>
    {
        public short x;
        public short y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2s(Vec2l other)
        {
            x = (short)other.x;
            y = (short)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2s(Vec2ul other)
        {
            x = (short)other.x;
            y = (short)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2s(Vec2i other)
        {
            x = (short)other.x;
            y = (short)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2s(Vec2ui other)
        {
            x = (short)other.x;
            y = (short)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2s(Vec2s other)
        {
            x = (short)other.x;
            y = (short)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2s(Vec2us other)
        {
            x = (short)other.x;
            y = (short)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2s(Vec2b other)
        {
            x = (short)other.x;
            y = (short)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2s(Vec2d other)
        {
            x = (short)other.x;
            y = (short)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2s(Vec2f other)
        {
            x = (short)other.x;
            y = (short)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2s(short x, short y)
        {
            this.x = x;
            this.y = y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2s(short fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2s operator +(Vec2s l, Vec2s r)
        {
            Vec2s ret;
            ret.x = (short)(l.x + r.x);
            ret.y = (short)(l.y + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2s operator -(Vec2s l, Vec2s r)
        {
            Vec2s ret;
            ret.x = (short)(l.x - r.x);
            ret.y = (short)(l.y - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2s operator *(Vec2s l, Vec2s r)
        {
            Vec2s ret;
            ret.x = (short)(l.x * r.x);
            ret.y = (short)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2s operator /(Vec2s l, Vec2s r)
        {
            Vec2s ret;
            ret.x = (short)(l.x / r.x);
            ret.y = (short)(l.y / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2s operator +(Vec2s l, short r)
        {
            Vec2s ret;
            ret.x = (short)(l.x + r);
            ret.y = (short)(l.y + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2s operator +(short l, Vec2s r)
        {
            Vec2s ret;
            ret.x = (short)(l + r.x);
            ret.y = (short)(l + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2s operator -(Vec2s l, short r)
        {
            Vec2s ret;
            ret.x = (short)(l.x - r);
            ret.y = (short)(l.y - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2s operator -(short l, Vec2s r)
        {
            Vec2s ret;
            ret.x = (short)(l - r.x);
            ret.y = (short)(l - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2s operator *(Vec2s l, short r)
        {
            Vec2s ret;
            ret.x = (short)(l.x * r);
            ret.y = (short)(l.y * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2s operator *(short l, Vec2s r)
        {
            Vec2s ret;
            ret.x = (short)(l * r.x);
            ret.y = (short)(l * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2s operator /(Vec2s l, short r)
        {
            Vec2s ret;
            ret.x = (short)(l.x / r);
            ret.y = (short)(l.y / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2s operator /(short l, Vec2s r)
        {
            Vec2s ret;
            ret.x = (short)(l / r.x);
            ret.y = (short)(l / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2s operator %(Vec2s l, Vec2s r)
        {
            Vec2s ret;
            ret.x = (short)(l.x % r.x);
            ret.y = (short)(l.y % r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2s operator %(Vec2s l, short r)
        {
            Vec2s ret;
            ret.x = (short)(l.x % r);
            ret.y = (short)(l.y % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2s operator %(short l, Vec2s r)
        {
            Vec2s ret;
            ret.x = (short)(l % r.x);
            ret.y = (short)(l % r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Dot(Vec2s l, Vec2s r)
        {
            short ret = 0;
            ret += (short)(l.x * r.x);
            ret += (short)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short Dot(Vec2s r)
        {
            short ret = 0;
            ret += (short)(x * r.x);
            ret += (short)(y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec2s l, Vec2s r)
        {
            return l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec2s l, Vec2s r)
        {
            return l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec2s l, Vec2s r)
        {
            return l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec2s l, Vec2s r)
        {
            return l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec2s other)
        {
            return x == other.x && x == other.x;
        }

        public short this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    default: return y;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    default: y = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3s : IEquatable<Vec3s>
    {
        public short x;
        public short y;
        public short z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2l other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec3l other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2l other, short z)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2ul other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec3ul other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2ul other, short z)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2i other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec3i other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2i other, short z)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2ui other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec3ui other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2ui other, short z)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2s other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec3s other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2s other, short z)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2us other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec3us other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2us other, short z)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2b other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec3b other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2b other, short z)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2d other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec3d other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2d other, short z)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2f other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec3f other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(Vec2f other, short z)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(short x, short y, short z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s(short fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s operator +(Vec3s l, Vec3s r)
        {
            Vec3s ret;
            ret.x = (short)(l.x + r.x);
            ret.y = (short)(l.y + r.y);
            ret.z = (short)(l.z + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s operator -(Vec3s l, Vec3s r)
        {
            Vec3s ret;
            ret.x = (short)(l.x - r.x);
            ret.y = (short)(l.y - r.y);
            ret.z = (short)(l.z - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s operator *(Vec3s l, Vec3s r)
        {
            Vec3s ret;
            ret.x = (short)(l.x * r.x);
            ret.y = (short)(l.y * r.y);
            ret.z = (short)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s operator /(Vec3s l, Vec3s r)
        {
            Vec3s ret;
            ret.x = (short)(l.x / r.x);
            ret.y = (short)(l.y / r.y);
            ret.z = (short)(l.z / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s operator +(Vec3s l, short r)
        {
            Vec3s ret;
            ret.x = (short)(l.x + r);
            ret.y = (short)(l.y + r);
            ret.z = (short)(l.z + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s operator +(short l, Vec3s r)
        {
            Vec3s ret;
            ret.x = (short)(l + r.x);
            ret.y = (short)(l + r.y);
            ret.z = (short)(l + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s operator -(Vec3s l, short r)
        {
            Vec3s ret;
            ret.x = (short)(l.x - r);
            ret.y = (short)(l.y - r);
            ret.z = (short)(l.z - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s operator -(short l, Vec3s r)
        {
            Vec3s ret;
            ret.x = (short)(l - r.x);
            ret.y = (short)(l - r.y);
            ret.z = (short)(l - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s operator *(Vec3s l, short r)
        {
            Vec3s ret;
            ret.x = (short)(l.x * r);
            ret.y = (short)(l.y * r);
            ret.z = (short)(l.z * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s operator *(short l, Vec3s r)
        {
            Vec3s ret;
            ret.x = (short)(l * r.x);
            ret.y = (short)(l * r.y);
            ret.z = (short)(l * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s operator /(Vec3s l, short r)
        {
            Vec3s ret;
            ret.x = (short)(l.x / r);
            ret.y = (short)(l.y / r);
            ret.z = (short)(l.z / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s operator /(short l, Vec3s r)
        {
            Vec3s ret;
            ret.x = (short)(l / r.x);
            ret.y = (short)(l / r.y);
            ret.z = (short)(l / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s operator %(Vec3s l, Vec3s r)
        {
            Vec3s ret;
            ret.x = (short)(l.x % r.x);
            ret.y = (short)(l.y % r.y);
            ret.z = (short)(l.z % r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s operator %(Vec3s l, short r)
        {
            Vec3s ret;
            ret.x = (short)(l.x % r);
            ret.y = (short)(l.y % r);
            ret.z = (short)(l.z % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s operator %(short l, Vec3s r)
        {
            Vec3s ret;
            ret.x = (short)(l % r.x);
            ret.y = (short)(l % r.y);
            ret.z = (short)(l % r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Dot(Vec3s l, Vec3s r)
        {
            short ret = 0;
            ret += (short)(l.x * r.x);
            ret += (short)(l.y * r.y);
            ret += (short)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short Dot(Vec3s r)
        {
            short ret = 0;
            ret += (short)(x * r.x);
            ret += (short)(y * r.y);
            ret += (short)(z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3s Cross(Vec3s u, Vec3s v)
        {
            Vec3s ret;
            ret.x = (short)(u.y * v.z - u.z * v.y);
            ret.y = (short)(u.z * v.x - u.x * v.z);
            ret.z = (short)(u.x * v.y - u.y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3s Cross(Vec3s v)
        {
            Vec3s ret;
            ret.x = (short)(y * v.z - z * v.y);
            ret.y = (short)(z * v.x - x * v.z);
            ret.z = (short)(x * v.y - y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec3s l, Vec3s r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec3s l, Vec3s r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec3s l, Vec3s r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec3s l, Vec3s r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec3s other)
        {
            return x == other.x && x == other.x && x == other.x;
        }

        public short this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    default: return z;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default: z = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4s : IEquatable<Vec4s>
    {
        public short x;
        public short y;
        public short z;
        public short w;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2l other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3l other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec4l other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = (short)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2l other, short z, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3l other, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2ul other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3ul other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec4ul other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = (short)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2ul other, short z, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3ul other, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2i other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3i other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec4i other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = (short)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2i other, short z, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3i other, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2ui other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3ui other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec4ui other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = (short)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2ui other, short z, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3ui other, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2s other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3s other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec4s other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = (short)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2s other, short z, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3s other, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2us other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3us other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec4us other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = (short)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2us other, short z, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3us other, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2b other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3b other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec4b other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = (short)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2b other, short z, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3b other, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2d other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3d other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec4d other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = (short)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2d other, short z, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3d other, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2f other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3f other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec4f other)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            w = (short)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec2f other, short z, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(Vec3f other, short w)
        {
            x = (short)other.x;
            y = (short)other.y;
            z = (short)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(short x, short y, short z, short w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4s(short fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
            this.w = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4s operator +(Vec4s l, Vec4s r)
        {
            Vec4s ret;
            ret.x = (short)(l.x + r.x);
            ret.y = (short)(l.y + r.y);
            ret.z = (short)(l.z + r.z);
            ret.w = (short)(l.w + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4s operator -(Vec4s l, Vec4s r)
        {
            Vec4s ret;
            ret.x = (short)(l.x - r.x);
            ret.y = (short)(l.y - r.y);
            ret.z = (short)(l.z - r.z);
            ret.w = (short)(l.w - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4s operator *(Vec4s l, Vec4s r)
        {
            Vec4s ret;
            ret.x = (short)(l.x * r.x);
            ret.y = (short)(l.y * r.y);
            ret.z = (short)(l.z * r.z);
            ret.w = (short)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4s operator /(Vec4s l, Vec4s r)
        {
            Vec4s ret;
            ret.x = (short)(l.x / r.x);
            ret.y = (short)(l.y / r.y);
            ret.z = (short)(l.z / r.z);
            ret.w = (short)(l.w / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4s operator +(Vec4s l, short r)
        {
            Vec4s ret;
            ret.x = (short)(l.x + r);
            ret.y = (short)(l.y + r);
            ret.z = (short)(l.z + r);
            ret.w = (short)(l.w + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4s operator +(short l, Vec4s r)
        {
            Vec4s ret;
            ret.x = (short)(l + r.x);
            ret.y = (short)(l + r.y);
            ret.z = (short)(l + r.z);
            ret.w = (short)(l + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4s operator -(Vec4s l, short r)
        {
            Vec4s ret;
            ret.x = (short)(l.x - r);
            ret.y = (short)(l.y - r);
            ret.z = (short)(l.z - r);
            ret.w = (short)(l.w - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4s operator -(short l, Vec4s r)
        {
            Vec4s ret;
            ret.x = (short)(l - r.x);
            ret.y = (short)(l - r.y);
            ret.z = (short)(l - r.z);
            ret.w = (short)(l - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4s operator *(Vec4s l, short r)
        {
            Vec4s ret;
            ret.x = (short)(l.x * r);
            ret.y = (short)(l.y * r);
            ret.z = (short)(l.z * r);
            ret.w = (short)(l.w * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4s operator *(short l, Vec4s r)
        {
            Vec4s ret;
            ret.x = (short)(l * r.x);
            ret.y = (short)(l * r.y);
            ret.z = (short)(l * r.z);
            ret.w = (short)(l * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4s operator /(Vec4s l, short r)
        {
            Vec4s ret;
            ret.x = (short)(l.x / r);
            ret.y = (short)(l.y / r);
            ret.z = (short)(l.z / r);
            ret.w = (short)(l.w / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4s operator /(short l, Vec4s r)
        {
            Vec4s ret;
            ret.x = (short)(l / r.x);
            ret.y = (short)(l / r.y);
            ret.z = (short)(l / r.z);
            ret.w = (short)(l / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4s operator %(Vec4s l, Vec4s r)
        {
            Vec4s ret;
            ret.x = (short)(l.x % r.x);
            ret.y = (short)(l.y % r.y);
            ret.z = (short)(l.z % r.z);
            ret.w = (short)(l.w % r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4s operator %(Vec4s l, short r)
        {
            Vec4s ret;
            ret.x = (short)(l.x % r);
            ret.y = (short)(l.y % r);
            ret.z = (short)(l.z % r);
            ret.w = (short)(l.w % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4s operator %(short l, Vec4s r)
        {
            Vec4s ret;
            ret.x = (short)(l % r.x);
            ret.y = (short)(l % r.y);
            ret.z = (short)(l % r.z);
            ret.w = (short)(l % r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Dot(Vec4s l, Vec4s r)
        {
            short ret = 0;
            ret += (short)(l.x * r.x);
            ret += (short)(l.y * r.y);
            ret += (short)(l.z * r.z);
            ret += (short)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short Dot(Vec4s r)
        {
            short ret = 0;
            ret += (short)(x * r.x);
            ret += (short)(y * r.y);
            ret += (short)(z * r.z);
            ret += (short)(w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec4s l, Vec4s r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec4s l, Vec4s r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec4s l, Vec4s r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec4s l, Vec4s r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec4s other)
        {
            return x == other.x && x == other.x && x == other.x && x == other.x;
        }

        public short this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: return w;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: w = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2us : IEquatable<Vec2us>
    {
        public ushort x;
        public ushort y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2us(Vec2l other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2us(Vec2ul other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2us(Vec2i other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2us(Vec2ui other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2us(Vec2s other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2us(Vec2us other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2us(Vec2b other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2us(Vec2d other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2us(Vec2f other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2us(ushort x, ushort y)
        {
            this.x = x;
            this.y = y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2us(ushort fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2us operator +(Vec2us l, Vec2us r)
        {
            Vec2us ret;
            ret.x = (ushort)(l.x + r.x);
            ret.y = (ushort)(l.y + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2us operator -(Vec2us l, Vec2us r)
        {
            Vec2us ret;
            ret.x = (ushort)(l.x - r.x);
            ret.y = (ushort)(l.y - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2us operator *(Vec2us l, Vec2us r)
        {
            Vec2us ret;
            ret.x = (ushort)(l.x * r.x);
            ret.y = (ushort)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2us operator /(Vec2us l, Vec2us r)
        {
            Vec2us ret;
            ret.x = (ushort)(l.x / r.x);
            ret.y = (ushort)(l.y / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2us operator +(Vec2us l, ushort r)
        {
            Vec2us ret;
            ret.x = (ushort)(l.x + r);
            ret.y = (ushort)(l.y + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2us operator +(ushort l, Vec2us r)
        {
            Vec2us ret;
            ret.x = (ushort)(l + r.x);
            ret.y = (ushort)(l + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2us operator -(Vec2us l, ushort r)
        {
            Vec2us ret;
            ret.x = (ushort)(l.x - r);
            ret.y = (ushort)(l.y - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2us operator -(ushort l, Vec2us r)
        {
            Vec2us ret;
            ret.x = (ushort)(l - r.x);
            ret.y = (ushort)(l - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2us operator *(Vec2us l, ushort r)
        {
            Vec2us ret;
            ret.x = (ushort)(l.x * r);
            ret.y = (ushort)(l.y * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2us operator *(ushort l, Vec2us r)
        {
            Vec2us ret;
            ret.x = (ushort)(l * r.x);
            ret.y = (ushort)(l * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2us operator /(Vec2us l, ushort r)
        {
            Vec2us ret;
            ret.x = (ushort)(l.x / r);
            ret.y = (ushort)(l.y / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2us operator /(ushort l, Vec2us r)
        {
            Vec2us ret;
            ret.x = (ushort)(l / r.x);
            ret.y = (ushort)(l / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2us operator %(Vec2us l, Vec2us r)
        {
            Vec2us ret;
            ret.x = (ushort)(l.x % r.x);
            ret.y = (ushort)(l.y % r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2us operator %(Vec2us l, ushort r)
        {
            Vec2us ret;
            ret.x = (ushort)(l.x % r);
            ret.y = (ushort)(l.y % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2us operator %(ushort l, Vec2us r)
        {
            Vec2us ret;
            ret.x = (ushort)(l % r.x);
            ret.y = (ushort)(l % r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Dot(Vec2us l, Vec2us r)
        {
            ushort ret = 0;
            ret += (ushort)(l.x * r.x);
            ret += (ushort)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort Dot(Vec2us r)
        {
            ushort ret = 0;
            ret += (ushort)(x * r.x);
            ret += (ushort)(y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec2us l, Vec2us r)
        {
            return l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec2us l, Vec2us r)
        {
            return l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec2us l, Vec2us r)
        {
            return l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec2us l, Vec2us r)
        {
            return l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec2us other)
        {
            return x == other.x && x == other.x;
        }

        public ushort this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    default: return y;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    default: y = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3us : IEquatable<Vec3us>
    {
        public ushort x;
        public ushort y;
        public ushort z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2l other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec3l other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2l other, ushort z)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2ul other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec3ul other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2ul other, ushort z)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2i other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec3i other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2i other, ushort z)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2ui other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec3ui other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2ui other, ushort z)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2s other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec3s other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2s other, ushort z)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2us other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec3us other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2us other, ushort z)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2b other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec3b other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2b other, ushort z)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2d other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec3d other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2d other, ushort z)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2f other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec3f other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(Vec2f other, ushort z)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(ushort x, ushort y, ushort z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us(ushort fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us operator +(Vec3us l, Vec3us r)
        {
            Vec3us ret;
            ret.x = (ushort)(l.x + r.x);
            ret.y = (ushort)(l.y + r.y);
            ret.z = (ushort)(l.z + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us operator -(Vec3us l, Vec3us r)
        {
            Vec3us ret;
            ret.x = (ushort)(l.x - r.x);
            ret.y = (ushort)(l.y - r.y);
            ret.z = (ushort)(l.z - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us operator *(Vec3us l, Vec3us r)
        {
            Vec3us ret;
            ret.x = (ushort)(l.x * r.x);
            ret.y = (ushort)(l.y * r.y);
            ret.z = (ushort)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us operator /(Vec3us l, Vec3us r)
        {
            Vec3us ret;
            ret.x = (ushort)(l.x / r.x);
            ret.y = (ushort)(l.y / r.y);
            ret.z = (ushort)(l.z / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us operator +(Vec3us l, ushort r)
        {
            Vec3us ret;
            ret.x = (ushort)(l.x + r);
            ret.y = (ushort)(l.y + r);
            ret.z = (ushort)(l.z + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us operator +(ushort l, Vec3us r)
        {
            Vec3us ret;
            ret.x = (ushort)(l + r.x);
            ret.y = (ushort)(l + r.y);
            ret.z = (ushort)(l + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us operator -(Vec3us l, ushort r)
        {
            Vec3us ret;
            ret.x = (ushort)(l.x - r);
            ret.y = (ushort)(l.y - r);
            ret.z = (ushort)(l.z - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us operator -(ushort l, Vec3us r)
        {
            Vec3us ret;
            ret.x = (ushort)(l - r.x);
            ret.y = (ushort)(l - r.y);
            ret.z = (ushort)(l - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us operator *(Vec3us l, ushort r)
        {
            Vec3us ret;
            ret.x = (ushort)(l.x * r);
            ret.y = (ushort)(l.y * r);
            ret.z = (ushort)(l.z * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us operator *(ushort l, Vec3us r)
        {
            Vec3us ret;
            ret.x = (ushort)(l * r.x);
            ret.y = (ushort)(l * r.y);
            ret.z = (ushort)(l * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us operator /(Vec3us l, ushort r)
        {
            Vec3us ret;
            ret.x = (ushort)(l.x / r);
            ret.y = (ushort)(l.y / r);
            ret.z = (ushort)(l.z / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us operator /(ushort l, Vec3us r)
        {
            Vec3us ret;
            ret.x = (ushort)(l / r.x);
            ret.y = (ushort)(l / r.y);
            ret.z = (ushort)(l / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us operator %(Vec3us l, Vec3us r)
        {
            Vec3us ret;
            ret.x = (ushort)(l.x % r.x);
            ret.y = (ushort)(l.y % r.y);
            ret.z = (ushort)(l.z % r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us operator %(Vec3us l, ushort r)
        {
            Vec3us ret;
            ret.x = (ushort)(l.x % r);
            ret.y = (ushort)(l.y % r);
            ret.z = (ushort)(l.z % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us operator %(ushort l, Vec3us r)
        {
            Vec3us ret;
            ret.x = (ushort)(l % r.x);
            ret.y = (ushort)(l % r.y);
            ret.z = (ushort)(l % r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Dot(Vec3us l, Vec3us r)
        {
            ushort ret = 0;
            ret += (ushort)(l.x * r.x);
            ret += (ushort)(l.y * r.y);
            ret += (ushort)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort Dot(Vec3us r)
        {
            ushort ret = 0;
            ret += (ushort)(x * r.x);
            ret += (ushort)(y * r.y);
            ret += (ushort)(z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3us Cross(Vec3us u, Vec3us v)
        {
            Vec3us ret;
            ret.x = (ushort)(u.y * v.z - u.z * v.y);
            ret.y = (ushort)(u.z * v.x - u.x * v.z);
            ret.z = (ushort)(u.x * v.y - u.y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3us Cross(Vec3us v)
        {
            Vec3us ret;
            ret.x = (ushort)(y * v.z - z * v.y);
            ret.y = (ushort)(z * v.x - x * v.z);
            ret.z = (ushort)(x * v.y - y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec3us l, Vec3us r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec3us l, Vec3us r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec3us l, Vec3us r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec3us l, Vec3us r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec3us other)
        {
            return x == other.x && x == other.x && x == other.x;
        }

        public ushort this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    default: return z;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default: z = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4us : IEquatable<Vec4us>
    {
        public ushort x;
        public ushort y;
        public ushort z;
        public ushort w;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2l other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3l other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec4l other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = (ushort)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2l other, ushort z, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3l other, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2ul other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3ul other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec4ul other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = (ushort)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2ul other, ushort z, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3ul other, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2i other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3i other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec4i other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = (ushort)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2i other, ushort z, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3i other, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2ui other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3ui other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec4ui other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = (ushort)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2ui other, ushort z, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3ui other, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2s other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3s other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec4s other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = (ushort)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2s other, ushort z, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3s other, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2us other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3us other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec4us other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = (ushort)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2us other, ushort z, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3us other, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2b other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3b other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec4b other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = (ushort)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2b other, ushort z, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3b other, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2d other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3d other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec4d other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = (ushort)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2d other, ushort z, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3d other, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2f other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3f other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec4f other)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            w = (ushort)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec2f other, ushort z, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(Vec3f other, ushort w)
        {
            x = (ushort)other.x;
            y = (ushort)other.y;
            z = (ushort)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(ushort x, ushort y, ushort z, ushort w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4us(ushort fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
            this.w = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4us operator +(Vec4us l, Vec4us r)
        {
            Vec4us ret;
            ret.x = (ushort)(l.x + r.x);
            ret.y = (ushort)(l.y + r.y);
            ret.z = (ushort)(l.z + r.z);
            ret.w = (ushort)(l.w + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4us operator -(Vec4us l, Vec4us r)
        {
            Vec4us ret;
            ret.x = (ushort)(l.x - r.x);
            ret.y = (ushort)(l.y - r.y);
            ret.z = (ushort)(l.z - r.z);
            ret.w = (ushort)(l.w - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4us operator *(Vec4us l, Vec4us r)
        {
            Vec4us ret;
            ret.x = (ushort)(l.x * r.x);
            ret.y = (ushort)(l.y * r.y);
            ret.z = (ushort)(l.z * r.z);
            ret.w = (ushort)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4us operator /(Vec4us l, Vec4us r)
        {
            Vec4us ret;
            ret.x = (ushort)(l.x / r.x);
            ret.y = (ushort)(l.y / r.y);
            ret.z = (ushort)(l.z / r.z);
            ret.w = (ushort)(l.w / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4us operator +(Vec4us l, ushort r)
        {
            Vec4us ret;
            ret.x = (ushort)(l.x + r);
            ret.y = (ushort)(l.y + r);
            ret.z = (ushort)(l.z + r);
            ret.w = (ushort)(l.w + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4us operator +(ushort l, Vec4us r)
        {
            Vec4us ret;
            ret.x = (ushort)(l + r.x);
            ret.y = (ushort)(l + r.y);
            ret.z = (ushort)(l + r.z);
            ret.w = (ushort)(l + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4us operator -(Vec4us l, ushort r)
        {
            Vec4us ret;
            ret.x = (ushort)(l.x - r);
            ret.y = (ushort)(l.y - r);
            ret.z = (ushort)(l.z - r);
            ret.w = (ushort)(l.w - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4us operator -(ushort l, Vec4us r)
        {
            Vec4us ret;
            ret.x = (ushort)(l - r.x);
            ret.y = (ushort)(l - r.y);
            ret.z = (ushort)(l - r.z);
            ret.w = (ushort)(l - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4us operator *(Vec4us l, ushort r)
        {
            Vec4us ret;
            ret.x = (ushort)(l.x * r);
            ret.y = (ushort)(l.y * r);
            ret.z = (ushort)(l.z * r);
            ret.w = (ushort)(l.w * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4us operator *(ushort l, Vec4us r)
        {
            Vec4us ret;
            ret.x = (ushort)(l * r.x);
            ret.y = (ushort)(l * r.y);
            ret.z = (ushort)(l * r.z);
            ret.w = (ushort)(l * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4us operator /(Vec4us l, ushort r)
        {
            Vec4us ret;
            ret.x = (ushort)(l.x / r);
            ret.y = (ushort)(l.y / r);
            ret.z = (ushort)(l.z / r);
            ret.w = (ushort)(l.w / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4us operator /(ushort l, Vec4us r)
        {
            Vec4us ret;
            ret.x = (ushort)(l / r.x);
            ret.y = (ushort)(l / r.y);
            ret.z = (ushort)(l / r.z);
            ret.w = (ushort)(l / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4us operator %(Vec4us l, Vec4us r)
        {
            Vec4us ret;
            ret.x = (ushort)(l.x % r.x);
            ret.y = (ushort)(l.y % r.y);
            ret.z = (ushort)(l.z % r.z);
            ret.w = (ushort)(l.w % r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4us operator %(Vec4us l, ushort r)
        {
            Vec4us ret;
            ret.x = (ushort)(l.x % r);
            ret.y = (ushort)(l.y % r);
            ret.z = (ushort)(l.z % r);
            ret.w = (ushort)(l.w % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4us operator %(ushort l, Vec4us r)
        {
            Vec4us ret;
            ret.x = (ushort)(l % r.x);
            ret.y = (ushort)(l % r.y);
            ret.z = (ushort)(l % r.z);
            ret.w = (ushort)(l % r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Dot(Vec4us l, Vec4us r)
        {
            ushort ret = 0;
            ret += (ushort)(l.x * r.x);
            ret += (ushort)(l.y * r.y);
            ret += (ushort)(l.z * r.z);
            ret += (ushort)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort Dot(Vec4us r)
        {
            ushort ret = 0;
            ret += (ushort)(x * r.x);
            ret += (ushort)(y * r.y);
            ret += (ushort)(z * r.z);
            ret += (ushort)(w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec4us l, Vec4us r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec4us l, Vec4us r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec4us l, Vec4us r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec4us l, Vec4us r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec4us other)
        {
            return x == other.x && x == other.x && x == other.x && x == other.x;
        }

        public ushort this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: return w;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: w = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2b : IEquatable<Vec2b>
    {
        public byte x;
        public byte y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2b(Vec2l other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2b(Vec2ul other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2b(Vec2i other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2b(Vec2ui other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2b(Vec2s other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2b(Vec2us other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2b(Vec2b other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2b(Vec2d other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2b(Vec2f other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2b(byte x, byte y)
        {
            this.x = x;
            this.y = y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2b(byte fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2b operator +(Vec2b l, Vec2b r)
        {
            Vec2b ret;
            ret.x = (byte)(l.x + r.x);
            ret.y = (byte)(l.y + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2b operator -(Vec2b l, Vec2b r)
        {
            Vec2b ret;
            ret.x = (byte)(l.x - r.x);
            ret.y = (byte)(l.y - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2b operator *(Vec2b l, Vec2b r)
        {
            Vec2b ret;
            ret.x = (byte)(l.x * r.x);
            ret.y = (byte)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2b operator /(Vec2b l, Vec2b r)
        {
            Vec2b ret;
            ret.x = (byte)(l.x / r.x);
            ret.y = (byte)(l.y / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2b operator +(Vec2b l, byte r)
        {
            Vec2b ret;
            ret.x = (byte)(l.x + r);
            ret.y = (byte)(l.y + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2b operator +(byte l, Vec2b r)
        {
            Vec2b ret;
            ret.x = (byte)(l + r.x);
            ret.y = (byte)(l + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2b operator -(Vec2b l, byte r)
        {
            Vec2b ret;
            ret.x = (byte)(l.x - r);
            ret.y = (byte)(l.y - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2b operator -(byte l, Vec2b r)
        {
            Vec2b ret;
            ret.x = (byte)(l - r.x);
            ret.y = (byte)(l - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2b operator *(Vec2b l, byte r)
        {
            Vec2b ret;
            ret.x = (byte)(l.x * r);
            ret.y = (byte)(l.y * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2b operator *(byte l, Vec2b r)
        {
            Vec2b ret;
            ret.x = (byte)(l * r.x);
            ret.y = (byte)(l * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2b operator /(Vec2b l, byte r)
        {
            Vec2b ret;
            ret.x = (byte)(l.x / r);
            ret.y = (byte)(l.y / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2b operator /(byte l, Vec2b r)
        {
            Vec2b ret;
            ret.x = (byte)(l / r.x);
            ret.y = (byte)(l / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2b operator %(Vec2b l, Vec2b r)
        {
            Vec2b ret;
            ret.x = (byte)(l.x % r.x);
            ret.y = (byte)(l.y % r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2b operator %(Vec2b l, byte r)
        {
            Vec2b ret;
            ret.x = (byte)(l.x % r);
            ret.y = (byte)(l.y % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2b operator %(byte l, Vec2b r)
        {
            Vec2b ret;
            ret.x = (byte)(l % r.x);
            ret.y = (byte)(l % r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Dot(Vec2b l, Vec2b r)
        {
            byte ret = 0;
            ret += (byte)(l.x * r.x);
            ret += (byte)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte Dot(Vec2b r)
        {
            byte ret = 0;
            ret += (byte)(x * r.x);
            ret += (byte)(y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec2b l, Vec2b r)
        {
            return l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec2b l, Vec2b r)
        {
            return l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec2b l, Vec2b r)
        {
            return l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec2b l, Vec2b r)
        {
            return l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec2b other)
        {
            return x == other.x && x == other.x;
        }

        public byte this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    default: return y;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    default: y = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3b : IEquatable<Vec3b>
    {
        public byte x;
        public byte y;
        public byte z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2l other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec3l other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2l other, byte z)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2ul other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec3ul other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2ul other, byte z)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2i other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec3i other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2i other, byte z)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2ui other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec3ui other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2ui other, byte z)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2s other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec3s other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2s other, byte z)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2us other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec3us other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2us other, byte z)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2b other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec3b other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2b other, byte z)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2d other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec3d other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2d other, byte z)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2f other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec3f other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(Vec2f other, byte z)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(byte x, byte y, byte z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b(byte fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b operator +(Vec3b l, Vec3b r)
        {
            Vec3b ret;
            ret.x = (byte)(l.x + r.x);
            ret.y = (byte)(l.y + r.y);
            ret.z = (byte)(l.z + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b operator -(Vec3b l, Vec3b r)
        {
            Vec3b ret;
            ret.x = (byte)(l.x - r.x);
            ret.y = (byte)(l.y - r.y);
            ret.z = (byte)(l.z - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b operator *(Vec3b l, Vec3b r)
        {
            Vec3b ret;
            ret.x = (byte)(l.x * r.x);
            ret.y = (byte)(l.y * r.y);
            ret.z = (byte)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b operator /(Vec3b l, Vec3b r)
        {
            Vec3b ret;
            ret.x = (byte)(l.x / r.x);
            ret.y = (byte)(l.y / r.y);
            ret.z = (byte)(l.z / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b operator +(Vec3b l, byte r)
        {
            Vec3b ret;
            ret.x = (byte)(l.x + r);
            ret.y = (byte)(l.y + r);
            ret.z = (byte)(l.z + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b operator +(byte l, Vec3b r)
        {
            Vec3b ret;
            ret.x = (byte)(l + r.x);
            ret.y = (byte)(l + r.y);
            ret.z = (byte)(l + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b operator -(Vec3b l, byte r)
        {
            Vec3b ret;
            ret.x = (byte)(l.x - r);
            ret.y = (byte)(l.y - r);
            ret.z = (byte)(l.z - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b operator -(byte l, Vec3b r)
        {
            Vec3b ret;
            ret.x = (byte)(l - r.x);
            ret.y = (byte)(l - r.y);
            ret.z = (byte)(l - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b operator *(Vec3b l, byte r)
        {
            Vec3b ret;
            ret.x = (byte)(l.x * r);
            ret.y = (byte)(l.y * r);
            ret.z = (byte)(l.z * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b operator *(byte l, Vec3b r)
        {
            Vec3b ret;
            ret.x = (byte)(l * r.x);
            ret.y = (byte)(l * r.y);
            ret.z = (byte)(l * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b operator /(Vec3b l, byte r)
        {
            Vec3b ret;
            ret.x = (byte)(l.x / r);
            ret.y = (byte)(l.y / r);
            ret.z = (byte)(l.z / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b operator /(byte l, Vec3b r)
        {
            Vec3b ret;
            ret.x = (byte)(l / r.x);
            ret.y = (byte)(l / r.y);
            ret.z = (byte)(l / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b operator %(Vec3b l, Vec3b r)
        {
            Vec3b ret;
            ret.x = (byte)(l.x % r.x);
            ret.y = (byte)(l.y % r.y);
            ret.z = (byte)(l.z % r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b operator %(Vec3b l, byte r)
        {
            Vec3b ret;
            ret.x = (byte)(l.x % r);
            ret.y = (byte)(l.y % r);
            ret.z = (byte)(l.z % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b operator %(byte l, Vec3b r)
        {
            Vec3b ret;
            ret.x = (byte)(l % r.x);
            ret.y = (byte)(l % r.y);
            ret.z = (byte)(l % r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Dot(Vec3b l, Vec3b r)
        {
            byte ret = 0;
            ret += (byte)(l.x * r.x);
            ret += (byte)(l.y * r.y);
            ret += (byte)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte Dot(Vec3b r)
        {
            byte ret = 0;
            ret += (byte)(x * r.x);
            ret += (byte)(y * r.y);
            ret += (byte)(z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3b Cross(Vec3b u, Vec3b v)
        {
            Vec3b ret;
            ret.x = (byte)(u.y * v.z - u.z * v.y);
            ret.y = (byte)(u.z * v.x - u.x * v.z);
            ret.z = (byte)(u.x * v.y - u.y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3b Cross(Vec3b v)
        {
            Vec3b ret;
            ret.x = (byte)(y * v.z - z * v.y);
            ret.y = (byte)(z * v.x - x * v.z);
            ret.z = (byte)(x * v.y - y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec3b l, Vec3b r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec3b l, Vec3b r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec3b l, Vec3b r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec3b l, Vec3b r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec3b other)
        {
            return x == other.x && x == other.x && x == other.x;
        }

        public byte this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    default: return z;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default: z = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4b : IEquatable<Vec4b>
    {
        public byte x;
        public byte y;
        public byte z;
        public byte w;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2l other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3l other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec4l other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = (byte)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2l other, byte z, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3l other, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2ul other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3ul other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec4ul other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = (byte)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2ul other, byte z, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3ul other, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2i other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3i other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec4i other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = (byte)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2i other, byte z, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3i other, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2ui other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3ui other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec4ui other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = (byte)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2ui other, byte z, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3ui other, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2s other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3s other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec4s other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = (byte)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2s other, byte z, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3s other, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2us other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3us other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec4us other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = (byte)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2us other, byte z, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3us other, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2b other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3b other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec4b other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = (byte)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2b other, byte z, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3b other, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2d other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3d other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec4d other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = (byte)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2d other, byte z, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3d other, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2f other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3f other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec4f other)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            w = (byte)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec2f other, byte z, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(Vec3f other, byte w)
        {
            x = (byte)other.x;
            y = (byte)other.y;
            z = (byte)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(byte x, byte y, byte z, byte w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4b(byte fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
            this.w = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4b operator +(Vec4b l, Vec4b r)
        {
            Vec4b ret;
            ret.x = (byte)(l.x + r.x);
            ret.y = (byte)(l.y + r.y);
            ret.z = (byte)(l.z + r.z);
            ret.w = (byte)(l.w + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4b operator -(Vec4b l, Vec4b r)
        {
            Vec4b ret;
            ret.x = (byte)(l.x - r.x);
            ret.y = (byte)(l.y - r.y);
            ret.z = (byte)(l.z - r.z);
            ret.w = (byte)(l.w - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4b operator *(Vec4b l, Vec4b r)
        {
            Vec4b ret;
            ret.x = (byte)(l.x * r.x);
            ret.y = (byte)(l.y * r.y);
            ret.z = (byte)(l.z * r.z);
            ret.w = (byte)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4b operator /(Vec4b l, Vec4b r)
        {
            Vec4b ret;
            ret.x = (byte)(l.x / r.x);
            ret.y = (byte)(l.y / r.y);
            ret.z = (byte)(l.z / r.z);
            ret.w = (byte)(l.w / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4b operator +(Vec4b l, byte r)
        {
            Vec4b ret;
            ret.x = (byte)(l.x + r);
            ret.y = (byte)(l.y + r);
            ret.z = (byte)(l.z + r);
            ret.w = (byte)(l.w + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4b operator +(byte l, Vec4b r)
        {
            Vec4b ret;
            ret.x = (byte)(l + r.x);
            ret.y = (byte)(l + r.y);
            ret.z = (byte)(l + r.z);
            ret.w = (byte)(l + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4b operator -(Vec4b l, byte r)
        {
            Vec4b ret;
            ret.x = (byte)(l.x - r);
            ret.y = (byte)(l.y - r);
            ret.z = (byte)(l.z - r);
            ret.w = (byte)(l.w - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4b operator -(byte l, Vec4b r)
        {
            Vec4b ret;
            ret.x = (byte)(l - r.x);
            ret.y = (byte)(l - r.y);
            ret.z = (byte)(l - r.z);
            ret.w = (byte)(l - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4b operator *(Vec4b l, byte r)
        {
            Vec4b ret;
            ret.x = (byte)(l.x * r);
            ret.y = (byte)(l.y * r);
            ret.z = (byte)(l.z * r);
            ret.w = (byte)(l.w * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4b operator *(byte l, Vec4b r)
        {
            Vec4b ret;
            ret.x = (byte)(l * r.x);
            ret.y = (byte)(l * r.y);
            ret.z = (byte)(l * r.z);
            ret.w = (byte)(l * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4b operator /(Vec4b l, byte r)
        {
            Vec4b ret;
            ret.x = (byte)(l.x / r);
            ret.y = (byte)(l.y / r);
            ret.z = (byte)(l.z / r);
            ret.w = (byte)(l.w / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4b operator /(byte l, Vec4b r)
        {
            Vec4b ret;
            ret.x = (byte)(l / r.x);
            ret.y = (byte)(l / r.y);
            ret.z = (byte)(l / r.z);
            ret.w = (byte)(l / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4b operator %(Vec4b l, Vec4b r)
        {
            Vec4b ret;
            ret.x = (byte)(l.x % r.x);
            ret.y = (byte)(l.y % r.y);
            ret.z = (byte)(l.z % r.z);
            ret.w = (byte)(l.w % r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4b operator %(Vec4b l, byte r)
        {
            Vec4b ret;
            ret.x = (byte)(l.x % r);
            ret.y = (byte)(l.y % r);
            ret.z = (byte)(l.z % r);
            ret.w = (byte)(l.w % r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4b operator %(byte l, Vec4b r)
        {
            Vec4b ret;
            ret.x = (byte)(l % r.x);
            ret.y = (byte)(l % r.y);
            ret.z = (byte)(l % r.z);
            ret.w = (byte)(l % r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Dot(Vec4b l, Vec4b r)
        {
            byte ret = 0;
            ret += (byte)(l.x * r.x);
            ret += (byte)(l.y * r.y);
            ret += (byte)(l.z * r.z);
            ret += (byte)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte Dot(Vec4b r)
        {
            byte ret = 0;
            ret += (byte)(x * r.x);
            ret += (byte)(y * r.y);
            ret += (byte)(z * r.z);
            ret += (byte)(w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec4b l, Vec4b r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec4b l, Vec4b r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec4b l, Vec4b r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec4b l, Vec4b r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec4b other)
        {
            return x == other.x && x == other.x && x == other.x && x == other.x;
        }

        public byte this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: return w;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: w = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2d : IEquatable<Vec2d>
    {
        public double x;
        public double y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2d(Vec2l other)
        {
            x = (double)other.x;
            y = (double)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2d(Vec2ul other)
        {
            x = (double)other.x;
            y = (double)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2d(Vec2i other)
        {
            x = (double)other.x;
            y = (double)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2d(Vec2ui other)
        {
            x = (double)other.x;
            y = (double)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2d(Vec2s other)
        {
            x = (double)other.x;
            y = (double)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2d(Vec2us other)
        {
            x = (double)other.x;
            y = (double)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2d(Vec2b other)
        {
            x = (double)other.x;
            y = (double)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2d(Vec2d other)
        {
            x = (double)other.x;
            y = (double)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2d(Vec2f other)
        {
            x = (double)other.x;
            y = (double)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2d(double x, double y)
        {
            this.x = x;
            this.y = y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2d(double fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2d operator +(Vec2d l, Vec2d r)
        {
            Vec2d ret;
            ret.x = (double)(l.x + r.x);
            ret.y = (double)(l.y + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2d operator -(Vec2d l, Vec2d r)
        {
            Vec2d ret;
            ret.x = (double)(l.x - r.x);
            ret.y = (double)(l.y - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2d operator *(Vec2d l, Vec2d r)
        {
            Vec2d ret;
            ret.x = (double)(l.x * r.x);
            ret.y = (double)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2d operator /(Vec2d l, Vec2d r)
        {
            Vec2d ret;
            ret.x = (double)(l.x / r.x);
            ret.y = (double)(l.y / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2d operator +(Vec2d l, double r)
        {
            Vec2d ret;
            ret.x = (double)(l.x + r);
            ret.y = (double)(l.y + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2d operator +(double l, Vec2d r)
        {
            Vec2d ret;
            ret.x = (double)(l + r.x);
            ret.y = (double)(l + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2d operator -(Vec2d l, double r)
        {
            Vec2d ret;
            ret.x = (double)(l.x - r);
            ret.y = (double)(l.y - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2d operator -(double l, Vec2d r)
        {
            Vec2d ret;
            ret.x = (double)(l - r.x);
            ret.y = (double)(l - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2d operator *(Vec2d l, double r)
        {
            Vec2d ret;
            ret.x = (double)(l.x * r);
            ret.y = (double)(l.y * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2d operator *(double l, Vec2d r)
        {
            Vec2d ret;
            ret.x = (double)(l * r.x);
            ret.y = (double)(l * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2d operator /(Vec2d l, double r)
        {
            Vec2d ret;
            ret.x = (double)(l.x / r);
            ret.y = (double)(l.y / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2d operator /(double l, Vec2d r)
        {
            Vec2d ret;
            ret.x = (double)(l / r.x);
            ret.y = (double)(l / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Magnitude()
        {
            return (double)Math.Sqrt(Dot(this, this));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double MagnitudeSqrd()
        {
            return Dot(this, this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2d Normalize(Vec2d vec)
        {
            double oneOverSqrt = 1.0d / vec.Magnitude();
            return vec * oneOverSqrt;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2d Normalized()
        {
            return Normalize(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Dot(Vec2d l, Vec2d r)
        {
            double ret = 0;
            ret += (double)(l.x * r.x);
            ret += (double)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Dot(Vec2d r)
        {
            double ret = 0;
            ret += (double)(x * r.x);
            ret += (double)(y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec2d l, Vec2d r)
        {
            return l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec2d l, Vec2d r)
        {
            return l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec2d l, Vec2d r)
        {
            return l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec2d l, Vec2d r)
        {
            return l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec2d other)
        {
            return x == other.x && x == other.x;
        }

        public double this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    default: return y;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    default: y = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3d : IEquatable<Vec3d>
    {
        public double x;
        public double y;
        public double z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2l other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec3l other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2l other, double z)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2ul other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec3ul other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2ul other, double z)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2i other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec3i other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2i other, double z)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2ui other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec3ui other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2ui other, double z)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2s other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec3s other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2s other, double z)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2us other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec3us other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2us other, double z)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2b other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec3b other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2b other, double z)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2d other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec3d other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2d other, double z)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2f other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec3f other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(Vec2f other, double z)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d(double fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3d operator +(Vec3d l, Vec3d r)
        {
            Vec3d ret;
            ret.x = (double)(l.x + r.x);
            ret.y = (double)(l.y + r.y);
            ret.z = (double)(l.z + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3d operator -(Vec3d l, Vec3d r)
        {
            Vec3d ret;
            ret.x = (double)(l.x - r.x);
            ret.y = (double)(l.y - r.y);
            ret.z = (double)(l.z - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3d operator *(Vec3d l, Vec3d r)
        {
            Vec3d ret;
            ret.x = (double)(l.x * r.x);
            ret.y = (double)(l.y * r.y);
            ret.z = (double)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3d operator /(Vec3d l, Vec3d r)
        {
            Vec3d ret;
            ret.x = (double)(l.x / r.x);
            ret.y = (double)(l.y / r.y);
            ret.z = (double)(l.z / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3d operator +(Vec3d l, double r)
        {
            Vec3d ret;
            ret.x = (double)(l.x + r);
            ret.y = (double)(l.y + r);
            ret.z = (double)(l.z + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3d operator +(double l, Vec3d r)
        {
            Vec3d ret;
            ret.x = (double)(l + r.x);
            ret.y = (double)(l + r.y);
            ret.z = (double)(l + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3d operator -(Vec3d l, double r)
        {
            Vec3d ret;
            ret.x = (double)(l.x - r);
            ret.y = (double)(l.y - r);
            ret.z = (double)(l.z - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3d operator -(double l, Vec3d r)
        {
            Vec3d ret;
            ret.x = (double)(l - r.x);
            ret.y = (double)(l - r.y);
            ret.z = (double)(l - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3d operator *(Vec3d l, double r)
        {
            Vec3d ret;
            ret.x = (double)(l.x * r);
            ret.y = (double)(l.y * r);
            ret.z = (double)(l.z * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3d operator *(double l, Vec3d r)
        {
            Vec3d ret;
            ret.x = (double)(l * r.x);
            ret.y = (double)(l * r.y);
            ret.z = (double)(l * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3d operator /(Vec3d l, double r)
        {
            Vec3d ret;
            ret.x = (double)(l.x / r);
            ret.y = (double)(l.y / r);
            ret.z = (double)(l.z / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3d operator /(double l, Vec3d r)
        {
            Vec3d ret;
            ret.x = (double)(l / r.x);
            ret.y = (double)(l / r.y);
            ret.z = (double)(l / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Magnitude()
        {
            return (double)Math.Sqrt(Dot(this, this));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double MagnitudeSqrd()
        {
            return Dot(this, this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3d Normalize(Vec3d vec)
        {
            double oneOverSqrt = 1.0d / vec.Magnitude();
            return vec * oneOverSqrt;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d Normalized()
        {
            return Normalize(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Dot(Vec3d l, Vec3d r)
        {
            double ret = 0;
            ret += (double)(l.x * r.x);
            ret += (double)(l.y * r.y);
            ret += (double)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Dot(Vec3d r)
        {
            double ret = 0;
            ret += (double)(x * r.x);
            ret += (double)(y * r.y);
            ret += (double)(z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3d Cross(Vec3d u, Vec3d v)
        {
            Vec3d ret;
            ret.x = (double)(u.y * v.z - u.z * v.y);
            ret.y = (double)(u.z * v.x - u.x * v.z);
            ret.z = (double)(u.x * v.y - u.y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3d Cross(Vec3d v)
        {
            Vec3d ret;
            ret.x = (double)(y * v.z - z * v.y);
            ret.y = (double)(z * v.x - x * v.z);
            ret.z = (double)(x * v.y - y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec3d l, Vec3d r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec3d l, Vec3d r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec3d l, Vec3d r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec3d l, Vec3d r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec3d other)
        {
            return x == other.x && x == other.x && x == other.x;
        }

        public double this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    default: return z;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default: z = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4d : IEquatable<Vec4d>
    {
        public double x;
        public double y;
        public double z;
        public double w;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2l other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3l other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec4l other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = (double)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2l other, double z, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3l other, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2ul other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3ul other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec4ul other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = (double)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2ul other, double z, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3ul other, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2i other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3i other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec4i other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = (double)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2i other, double z, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3i other, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2ui other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3ui other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec4ui other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = (double)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2ui other, double z, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3ui other, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2s other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3s other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec4s other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = (double)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2s other, double z, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3s other, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2us other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3us other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec4us other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = (double)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2us other, double z, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3us other, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2b other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3b other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec4b other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = (double)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2b other, double z, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3b other, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2d other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3d other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec4d other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = (double)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2d other, double z, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3d other, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2f other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3f other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec4f other)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            w = (double)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec2f other, double z, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(Vec3f other, double w)
        {
            x = (double)other.x;
            y = (double)other.y;
            z = (double)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d(double fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
            this.w = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4d operator +(Vec4d l, Vec4d r)
        {
            Vec4d ret;
            ret.x = (double)(l.x + r.x);
            ret.y = (double)(l.y + r.y);
            ret.z = (double)(l.z + r.z);
            ret.w = (double)(l.w + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4d operator -(Vec4d l, Vec4d r)
        {
            Vec4d ret;
            ret.x = (double)(l.x - r.x);
            ret.y = (double)(l.y - r.y);
            ret.z = (double)(l.z - r.z);
            ret.w = (double)(l.w - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4d operator *(Vec4d l, Vec4d r)
        {
            Vec4d ret;
            ret.x = (double)(l.x * r.x);
            ret.y = (double)(l.y * r.y);
            ret.z = (double)(l.z * r.z);
            ret.w = (double)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4d operator /(Vec4d l, Vec4d r)
        {
            Vec4d ret;
            ret.x = (double)(l.x / r.x);
            ret.y = (double)(l.y / r.y);
            ret.z = (double)(l.z / r.z);
            ret.w = (double)(l.w / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4d operator +(Vec4d l, double r)
        {
            Vec4d ret;
            ret.x = (double)(l.x + r);
            ret.y = (double)(l.y + r);
            ret.z = (double)(l.z + r);
            ret.w = (double)(l.w + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4d operator +(double l, Vec4d r)
        {
            Vec4d ret;
            ret.x = (double)(l + r.x);
            ret.y = (double)(l + r.y);
            ret.z = (double)(l + r.z);
            ret.w = (double)(l + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4d operator -(Vec4d l, double r)
        {
            Vec4d ret;
            ret.x = (double)(l.x - r);
            ret.y = (double)(l.y - r);
            ret.z = (double)(l.z - r);
            ret.w = (double)(l.w - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4d operator -(double l, Vec4d r)
        {
            Vec4d ret;
            ret.x = (double)(l - r.x);
            ret.y = (double)(l - r.y);
            ret.z = (double)(l - r.z);
            ret.w = (double)(l - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4d operator *(Vec4d l, double r)
        {
            Vec4d ret;
            ret.x = (double)(l.x * r);
            ret.y = (double)(l.y * r);
            ret.z = (double)(l.z * r);
            ret.w = (double)(l.w * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4d operator *(double l, Vec4d r)
        {
            Vec4d ret;
            ret.x = (double)(l * r.x);
            ret.y = (double)(l * r.y);
            ret.z = (double)(l * r.z);
            ret.w = (double)(l * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4d operator /(Vec4d l, double r)
        {
            Vec4d ret;
            ret.x = (double)(l.x / r);
            ret.y = (double)(l.y / r);
            ret.z = (double)(l.z / r);
            ret.w = (double)(l.w / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4d operator /(double l, Vec4d r)
        {
            Vec4d ret;
            ret.x = (double)(l / r.x);
            ret.y = (double)(l / r.y);
            ret.z = (double)(l / r.z);
            ret.w = (double)(l / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Magnitude()
        {
            return (double)Math.Sqrt(Dot(this, this));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double MagnitudeSqrd()
        {
            return Dot(this, this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4d Normalize(Vec4d vec)
        {
            double oneOverSqrt = 1.0d / vec.Magnitude();
            return vec * oneOverSqrt;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4d Normalized()
        {
            return Normalize(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Dot(Vec4d l, Vec4d r)
        {
            double ret = 0;
            ret += (double)(l.x * r.x);
            ret += (double)(l.y * r.y);
            ret += (double)(l.z * r.z);
            ret += (double)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Dot(Vec4d r)
        {
            double ret = 0;
            ret += (double)(x * r.x);
            ret += (double)(y * r.y);
            ret += (double)(z * r.z);
            ret += (double)(w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec4d l, Vec4d r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec4d l, Vec4d r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec4d l, Vec4d r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec4d l, Vec4d r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec4d other)
        {
            return x == other.x && x == other.x && x == other.x && x == other.x;
        }

        public double this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: return w;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: w = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2f : IEquatable<Vec2f>
    {
        public float x;
        public float y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2f(Vec2l other)
        {
            x = (float)other.x;
            y = (float)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2f(Vec2ul other)
        {
            x = (float)other.x;
            y = (float)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2f(Vec2i other)
        {
            x = (float)other.x;
            y = (float)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2f(Vec2ui other)
        {
            x = (float)other.x;
            y = (float)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2f(Vec2s other)
        {
            x = (float)other.x;
            y = (float)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2f(Vec2us other)
        {
            x = (float)other.x;
            y = (float)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2f(Vec2b other)
        {
            x = (float)other.x;
            y = (float)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2f(Vec2d other)
        {
            x = (float)other.x;
            y = (float)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2f(Vec2f other)
        {
            x = (float)other.x;
            y = (float)other.y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2f(float x, float y)
        {
            this.x = x;
            this.y = y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2f(float fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2f operator +(Vec2f l, Vec2f r)
        {
            Vec2f ret;
            ret.x = (float)(l.x + r.x);
            ret.y = (float)(l.y + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2f operator -(Vec2f l, Vec2f r)
        {
            Vec2f ret;
            ret.x = (float)(l.x - r.x);
            ret.y = (float)(l.y - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2f operator *(Vec2f l, Vec2f r)
        {
            Vec2f ret;
            ret.x = (float)(l.x * r.x);
            ret.y = (float)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2f operator /(Vec2f l, Vec2f r)
        {
            Vec2f ret;
            ret.x = (float)(l.x / r.x);
            ret.y = (float)(l.y / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2f operator +(Vec2f l, float r)
        {
            Vec2f ret;
            ret.x = (float)(l.x + r);
            ret.y = (float)(l.y + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2f operator +(float l, Vec2f r)
        {
            Vec2f ret;
            ret.x = (float)(l + r.x);
            ret.y = (float)(l + r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2f operator -(Vec2f l, float r)
        {
            Vec2f ret;
            ret.x = (float)(l.x - r);
            ret.y = (float)(l.y - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2f operator -(float l, Vec2f r)
        {
            Vec2f ret;
            ret.x = (float)(l - r.x);
            ret.y = (float)(l - r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2f operator *(Vec2f l, float r)
        {
            Vec2f ret;
            ret.x = (float)(l.x * r);
            ret.y = (float)(l.y * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2f operator *(float l, Vec2f r)
        {
            Vec2f ret;
            ret.x = (float)(l * r.x);
            ret.y = (float)(l * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2f operator /(Vec2f l, float r)
        {
            Vec2f ret;
            ret.x = (float)(l.x / r);
            ret.y = (float)(l.y / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2f operator /(float l, Vec2f r)
        {
            Vec2f ret;
            ret.x = (float)(l / r.x);
            ret.y = (float)(l / r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Magnitude()
        {
            return (float)Math.Sqrt(Dot(this, this));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float MagnitudeSqrd()
        {
            return Dot(this, this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2f Normalize(Vec2f vec)
        {
            float oneOverSqrt = 1.0f / vec.Magnitude();
            return vec * oneOverSqrt;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec2f Normalized()
        {
            return Normalize(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(Vec2f l, Vec2f r)
        {
            float ret = 0;
            ret += (float)(l.x * r.x);
            ret += (float)(l.y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Dot(Vec2f r)
        {
            float ret = 0;
            ret += (float)(x * r.x);
            ret += (float)(y * r.y);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec2f l, Vec2f r)
        {
            return l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec2f l, Vec2f r)
        {
            return l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec2f l, Vec2f r)
        {
            return l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec2f l, Vec2f r)
        {
            return l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec2f other)
        {
            return x == other.x && x == other.x;
        }

        public float this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    default: return y;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    default: y = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3f : IEquatable<Vec3f>
    {
        public float x;
        public float y;
        public float z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2l other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec3l other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2l other, float z)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2ul other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec3ul other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2ul other, float z)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2i other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec3i other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2i other, float z)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2ui other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec3ui other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2ui other, float z)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2s other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec3s other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2s other, float z)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2us other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec3us other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2us other, float z)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2b other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec3b other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2b other, float z)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2d other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec3d other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2d other, float z)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2f other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec3f other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(Vec2f other, float z)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f(float fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3f operator +(Vec3f l, Vec3f r)
        {
            Vec3f ret;
            ret.x = (float)(l.x + r.x);
            ret.y = (float)(l.y + r.y);
            ret.z = (float)(l.z + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3f operator -(Vec3f l, Vec3f r)
        {
            Vec3f ret;
            ret.x = (float)(l.x - r.x);
            ret.y = (float)(l.y - r.y);
            ret.z = (float)(l.z - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3f operator *(Vec3f l, Vec3f r)
        {
            Vec3f ret;
            ret.x = (float)(l.x * r.x);
            ret.y = (float)(l.y * r.y);
            ret.z = (float)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3f operator /(Vec3f l, Vec3f r)
        {
            Vec3f ret;
            ret.x = (float)(l.x / r.x);
            ret.y = (float)(l.y / r.y);
            ret.z = (float)(l.z / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3f operator +(Vec3f l, float r)
        {
            Vec3f ret;
            ret.x = (float)(l.x + r);
            ret.y = (float)(l.y + r);
            ret.z = (float)(l.z + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3f operator +(float l, Vec3f r)
        {
            Vec3f ret;
            ret.x = (float)(l + r.x);
            ret.y = (float)(l + r.y);
            ret.z = (float)(l + r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3f operator -(Vec3f l, float r)
        {
            Vec3f ret;
            ret.x = (float)(l.x - r);
            ret.y = (float)(l.y - r);
            ret.z = (float)(l.z - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3f operator -(float l, Vec3f r)
        {
            Vec3f ret;
            ret.x = (float)(l - r.x);
            ret.y = (float)(l - r.y);
            ret.z = (float)(l - r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3f operator *(Vec3f l, float r)
        {
            Vec3f ret;
            ret.x = (float)(l.x * r);
            ret.y = (float)(l.y * r);
            ret.z = (float)(l.z * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3f operator *(float l, Vec3f r)
        {
            Vec3f ret;
            ret.x = (float)(l * r.x);
            ret.y = (float)(l * r.y);
            ret.z = (float)(l * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3f operator /(Vec3f l, float r)
        {
            Vec3f ret;
            ret.x = (float)(l.x / r);
            ret.y = (float)(l.y / r);
            ret.z = (float)(l.z / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3f operator /(float l, Vec3f r)
        {
            Vec3f ret;
            ret.x = (float)(l / r.x);
            ret.y = (float)(l / r.y);
            ret.z = (float)(l / r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Magnitude()
        {
            return (float)Math.Sqrt(Dot(this, this));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float MagnitudeSqrd()
        {
            return Dot(this, this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3f Normalize(Vec3f vec)
        {
            float oneOverSqrt = 1.0f / vec.Magnitude();
            return vec * oneOverSqrt;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f Normalized()
        {
            return Normalize(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(Vec3f l, Vec3f r)
        {
            float ret = 0;
            ret += (float)(l.x * r.x);
            ret += (float)(l.y * r.y);
            ret += (float)(l.z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Dot(Vec3f r)
        {
            float ret = 0;
            ret += (float)(x * r.x);
            ret += (float)(y * r.y);
            ret += (float)(z * r.z);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec3f Cross(Vec3f u, Vec3f v)
        {
            Vec3f ret;
            ret.x = (float)(u.y * v.z - u.z * v.y);
            ret.y = (float)(u.z * v.x - u.x * v.z);
            ret.z = (float)(u.x * v.y - u.y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec3f Cross(Vec3f v)
        {
            Vec3f ret;
            ret.x = (float)(y * v.z - z * v.y);
            ret.y = (float)(z * v.x - x * v.z);
            ret.z = (float)(x * v.y - y * v.x);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec3f l, Vec3f r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec3f l, Vec3f r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec3f l, Vec3f r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec3f l, Vec3f r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec3f other)
        {
            return x == other.x && x == other.x && x == other.x;
        }

        public float this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    default: return z;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default: z = value; break;
                }
            }

        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4f : IEquatable<Vec4f>
    {
        public float x;
        public float y;
        public float z;
        public float w;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2l other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3l other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec4l other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = (float)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2l other, float z, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3l other, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2ul other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3ul other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec4ul other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = (float)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2ul other, float z, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3ul other, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2i other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3i other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec4i other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = (float)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2i other, float z, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3i other, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2ui other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3ui other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec4ui other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = (float)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2ui other, float z, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3ui other, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2s other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3s other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec4s other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = (float)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2s other, float z, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3s other, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2us other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3us other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec4us other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = (float)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2us other, float z, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3us other, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2b other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3b other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec4b other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = (float)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2b other, float z, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3b other, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2d other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3d other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec4d other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = (float)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2d other, float z, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3d other, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2f other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = 0;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3f other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec4f other)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            w = (float)other.w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec2f other, float z, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(Vec3f other, float w)
        {
            x = (float)other.x;
            y = (float)other.y;
            z = (float)other.z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f(float fillValue)
        {
            this.x = fillValue;
            this.y = fillValue;
            this.z = fillValue;
            this.w = fillValue;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4f operator +(Vec4f l, Vec4f r)
        {
            Vec4f ret;
            ret.x = (float)(l.x + r.x);
            ret.y = (float)(l.y + r.y);
            ret.z = (float)(l.z + r.z);
            ret.w = (float)(l.w + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4f operator -(Vec4f l, Vec4f r)
        {
            Vec4f ret;
            ret.x = (float)(l.x - r.x);
            ret.y = (float)(l.y - r.y);
            ret.z = (float)(l.z - r.z);
            ret.w = (float)(l.w - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4f operator *(Vec4f l, Vec4f r)
        {
            Vec4f ret;
            ret.x = (float)(l.x * r.x);
            ret.y = (float)(l.y * r.y);
            ret.z = (float)(l.z * r.z);
            ret.w = (float)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4f operator /(Vec4f l, Vec4f r)
        {
            Vec4f ret;
            ret.x = (float)(l.x / r.x);
            ret.y = (float)(l.y / r.y);
            ret.z = (float)(l.z / r.z);
            ret.w = (float)(l.w / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4f operator +(Vec4f l, float r)
        {
            Vec4f ret;
            ret.x = (float)(l.x + r);
            ret.y = (float)(l.y + r);
            ret.z = (float)(l.z + r);
            ret.w = (float)(l.w + r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4f operator +(float l, Vec4f r)
        {
            Vec4f ret;
            ret.x = (float)(l + r.x);
            ret.y = (float)(l + r.y);
            ret.z = (float)(l + r.z);
            ret.w = (float)(l + r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4f operator -(Vec4f l, float r)
        {
            Vec4f ret;
            ret.x = (float)(l.x - r);
            ret.y = (float)(l.y - r);
            ret.z = (float)(l.z - r);
            ret.w = (float)(l.w - r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4f operator -(float l, Vec4f r)
        {
            Vec4f ret;
            ret.x = (float)(l - r.x);
            ret.y = (float)(l - r.y);
            ret.z = (float)(l - r.z);
            ret.w = (float)(l - r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4f operator *(Vec4f l, float r)
        {
            Vec4f ret;
            ret.x = (float)(l.x * r);
            ret.y = (float)(l.y * r);
            ret.z = (float)(l.z * r);
            ret.w = (float)(l.w * r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4f operator *(float l, Vec4f r)
        {
            Vec4f ret;
            ret.x = (float)(l * r.x);
            ret.y = (float)(l * r.y);
            ret.z = (float)(l * r.z);
            ret.w = (float)(l * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4f operator /(Vec4f l, float r)
        {
            Vec4f ret;
            ret.x = (float)(l.x / r);
            ret.y = (float)(l.y / r);
            ret.z = (float)(l.z / r);
            ret.w = (float)(l.w / r);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4f operator /(float l, Vec4f r)
        {
            Vec4f ret;
            ret.x = (float)(l / r.x);
            ret.y = (float)(l / r.y);
            ret.z = (float)(l / r.z);
            ret.w = (float)(l / r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Magnitude()
        {
            return (float)Math.Sqrt(Dot(this, this));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float MagnitudeSqrd()
        {
            return Dot(this, this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec4f Normalize(Vec4f vec)
        {
            float oneOverSqrt = 1.0f / vec.Magnitude();
            return vec * oneOverSqrt;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vec4f Normalized()
        {
            return Normalize(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(Vec4f l, Vec4f r)
        {
            float ret = 0;
            ret += (float)(l.x * r.x);
            ret += (float)(l.y * r.y);
            ret += (float)(l.z * r.z);
            ret += (float)(l.w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Dot(Vec4f r)
        {
            float ret = 0;
            ret += (float)(x * r.x);
            ret += (float)(y * r.y);
            ret += (float)(z * r.z);
            ret += (float)(w * r.w);
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Vec4f l, Vec4f r)
        {
            return l.x <= r.x && l.x <= r.x && l.x <= r.x && l.x <= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Vec4f l, Vec4f r)
        {
            return l.x < r.x && l.x < r.x && l.x < r.x && l.x < r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Vec4f l, Vec4f r)
        {
            return l.x >= r.x && l.x >= r.x && l.x >= r.x && l.x >= r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Vec4f l, Vec4f r)
        {
            return l.x > r.x && l.x > r.x && l.x > r.x && l.x > r.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vec4f other)
        {
            return x == other.x && x == other.x && x == other.x && x == other.x;
        }

        public float this[int elmentIndex] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                switch (elmentIndex)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: return w;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (elmentIndex)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: w = value; break;
                }
            }

        }

    }

};
