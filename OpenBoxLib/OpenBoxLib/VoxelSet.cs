using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using LiteBox.LMath;

namespace OpenBox {
    /// Voxel Storage interface
    public interface IVoxelStorage<T> where T : struct {
        T this[int x, int y, int z] { get; set; }
        T this[Vec3i idx] { get; set; }
        Vec3i Size { get; }
    }

    /// Voxel View interface
    public interface IVoxelView {
        void Transform(ref Vec3i idx);
        Vec3i Size { get; }
    }

    /// Standard array storage for voxels.
    public class VoxelStorageArray<T> : IVoxelStorage<T> where T : struct {
        public T[,,] voxels;

        public VoxelStorageArray(int x, int y, int z) {
            voxels = new T[x, y, z];
        }

        public T this[int x, int y, int z] {
            [MethodImpl(256)]
            get => voxels[x, y, z];

            [MethodImpl(256)]
            set => voxels[x, y, z] = value;
        }

        public T this[Vec3i idx] {
            [MethodImpl(256)]
            get => voxels[idx.x, idx.y, idx.z];

            [MethodImpl(256)]
            set => voxels[idx.x, idx.y, idx.z] = value;
        }

        public Vec3i Size {
            [MethodImpl(256)]
            get => new Vec3i(voxels.GetLength(0), voxels.GetLength(1), voxels.GetLength(2));
        }
    }

    /// Pass through view for voxels.
    public struct VoxelViewPassThrough<T, Storage> : IVoxelView
        where T : struct
        where Storage : IVoxelStorage<T> {
        internal Storage storage;

        VoxelViewPassThrough(Storage storage) {
            this.storage = storage;
        }

        [MethodImpl(256)]
        public void Transform(ref Vec3i idx) { }

        public Vec3i Size {
            [MethodImpl(256)]
            get => storage.Size;
        }
    }

    /// Sliced view of a voxel set.
    public class VoxelViewSlice<T> : IVoxelView
        where T : struct {
        public VoxelViewSlice(Vec3i offset, Vec3i size) {
            Size = size;
            Offset = offset;
        }

        [MethodImpl(256)]
        public void Transform(ref Vec3i idx) {
            if (idx.x < 0 || idx.y < 0 || idx.z < 0
                || idx.x >= Size.x || idx.y >= Size.y || idx.z >= Size.z) {
                throw new IndexOutOfRangeException();
            }
            idx += Offset;
        }

        public Vec3i Size { get; private set; }
        public Vec3i Offset { get; private set; }
    }

    /// Sliced view of a voxel set that supports a change of basis.
    public class VoxelViewSliceBasis<T> : IVoxelView
     where T : struct {
        public VoxelViewSliceBasis(Vec3i offset, Vec3i size,
            Mat3b basis) {
            Size = size;
            Offset = offset;

            Basis = basis;
        }

        [MethodImpl(256)]
        public void Transform(ref Vec3i idx) {
            if (idx.x < 0 || idx.y < 0 || idx.z < 0
                || idx.x >= Size.x || idx.y >= Size.y || idx.z >= Size.z) {
                throw new IndexOutOfRangeException();
            }
            idx = Offset + Basis * idx;
        }

        public Vec3i Size { get; private set; }
        public Vec3i Offset { get; private set; }

        public Mat3b Basis { get; private set; }
    }

    /// Flexible interface to a set of voxels. Instantiate VoxelSet<T> instead.
    public class BaseVoxelSet<T, Storage, View>
        where T : struct
        where Storage : IVoxelStorage<T>
        where View : IVoxelView {
        protected View view;
        protected Storage storage;

        public delegate void ValueDelegate(T t);
        public delegate void RefDelegate(ref T t);

        public delegate void ValueIndexedDelegate(T t, Vec3i idx);
        public delegate void RefIndexedDelegate(ref T t, Vec3i idx);
        public delegate void IndexedDelegate(Vec3i idx);

        public T this[int x, int y, int z] {
            [MethodImpl(256)]
            get => this[new Vec3i(x, y, z)];

            [MethodImpl(256)]
            set => this[new Vec3i(x, y, z)] = value;
        }

        public T this[Vec3i idx] {
            [MethodImpl(256)]
            get {
                view.Transform(ref idx);
                return storage[idx];
            }

            [MethodImpl(256)]
            set {
                view.Transform(ref idx);
                storage[idx] = value;
            }
        }

        public Vec3i Size {
            [MethodImpl(256)]
            get => view.Size;
        }

        public BaseVoxelSet(View view, Storage storage) {
            this.view = view;
            this.storage = storage;
        }

        public BaseVoxelSet<T, Storage, VoxelViewSlice<T>> Slice(Vec3i start, Vec3i end) {
            if (!IsValid(start) || !IsValid(end)) {
                throw new IndexOutOfRangeException();
            }

            Vec3i offset = start;
            view.Transform(ref offset);
            return new BaseVoxelSet<T, Storage, VoxelViewSlice<T>>(
                new VoxelViewSlice<T>(
                    offset,
                    end - start + new Vec3i(1)
                ),
                storage
            );
        }

        public BaseVoxelSet<T, Storage, VoxelViewSliceBasis<T>> Slice(Vec3i offset, Vec3i size,
            Vec3b basis0, Vec3b basis1, Vec3b basis2) {
            return Slice(offset, size, new Mat3b(basis0, basis1, basis2));
        }

        public BaseVoxelSet<T, Storage, VoxelViewSliceBasis<T>> Slice(Vec3i offset, Vec3i size,
            Mat3b basis) {
            //if (!IsValid(offset) || !IsValid(offset + basis * (size - 1))) {
            if (!IsValid(offset) || !IsValid(offset + size - 1)) {
                throw new IndexOutOfRangeException();
            }

            Vec3i absOffset = offset;
            this.view.Transform(ref absOffset);

            Mat3b absBasis;
            var currBasis = this.view as VoxelViewSliceBasis<T>;

            if (currBasis != null) {
                absBasis = currBasis.Basis * basis;
            } else {
                absBasis = basis;
            }

            var view = new VoxelViewSliceBasis<T>(absOffset, basis.Transpose() * size, absBasis);

            return new BaseVoxelSet<T, Storage, VoxelViewSliceBasis<T>>(
                view,
                storage
            );
        }

        [MethodImpl(256)]
        public void Apply(RefIndexedDelegate del) {
            for (int z = 0; z < Size.z; ++z) {
                for (int y = 0; y < Size.y; ++y) {
                    for (int x = 0; x < Size.x; ++x) {
                        Vec3i idx = new Vec3i(x, y, z);
                        T val = this[idx];
                        del(ref val, idx);
                        this[idx] = val;
                    }
                }
            }
        }

        [MethodImpl(256)]
        public void Apply(ValueIndexedDelegate del) {
            for (int z = 0; z < Size.z; ++z) {
                for (int y = 0; y < Size.y; ++y) {
                    for (int x = 0; x < Size.x; ++x) {
                        Vec3i idx = new Vec3i(x, y, z);
                        del(this[idx], idx);
                    }
                }
            }
        }

        [MethodImpl(256)]
        public void Apply(ValueDelegate del) {
            Apply((T t, Vec3i idx) => del(t));
        }

        [MethodImpl(256)]
        public void Apply(RefDelegate del) {
            Apply((ref T t, Vec3i idx) => del(ref t));
        }

        [MethodImpl(256)]
        public void Set(T val) {
            for (int z = 0; z < Size.z; ++z) {
                for (int y = 0; y < Size.y; ++y) {
                    for (int x = 0; x < Size.x; ++x) {
                        this[x, y, z] = val;
                    }
                }
            }
        }

        [MethodImpl(256)]
        public bool IsValid(Vec3i idx) {
            return IsValid(idx.x, idx.y, idx.z);
        }

        [MethodImpl(256)]
        public bool IsValid(int x, int y, int z) {
            return x >= 0 && y >= 0 && z >= 0
                && x < Size.x && y < Size.y && z < Size.z;
        }

        [MethodImpl(256)]
        public VoxelSet<P> Project<P>(Func<T, P> coversionFunc) where P : struct {
            VoxelSet<P> projected = new VoxelSet<P>(Size);
            for (int z = 0; z < Size.z; z++) {
                for (int y = 0; y < Size.y; y++) {
                    for (int x = 0; x < Size.x; x++) {
                        projected[x, y, z] = coversionFunc(this[x, y, z]);
                    }
                }
            }

            return projected;
        }

        [MethodImpl(256)]
        public bool IsAllSolid(Func<T, bool> solidCheck) {
            for (int z = 0; z < Size.z; z++) {
                for (int y = 0; y < Size.y; y++) {
                    for (int x = 0; x < Size.x; x++) {
                        if (!solidCheck(this[x, y, z])) {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        [MethodImpl(256)]
        public bool IsAllEmpty(Func<T, bool> solidCheck) {
            for (int z = 0; z < Size.z; z++) {
                for (int y = 0; y < Size.y; y++) {
                    for (int x = 0; x < Size.x; x++) {
                        if (solidCheck(this[x, y, z])) {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }

    public class VoxelSet<T> : BaseVoxelSet<T, VoxelStorageArray<T>, VoxelViewPassThrough<T, VoxelStorageArray<T>>>
        where T : struct {

        public VoxelSet(int size) : base(
            new VoxelViewPassThrough<T, VoxelStorageArray<T>>(),
            new VoxelStorageArray<T>(size, size, size)
        ) {
            view.storage = storage;
        }

        public VoxelSet(int x, int y, int z) : base(
            new VoxelViewPassThrough<T, VoxelStorageArray<T>>(),
            new VoxelStorageArray<T>(x, y, z)
        ) {
            view.storage = storage;
        }

        public VoxelSet(Vec3i size) : base(
            new VoxelViewPassThrough<T, VoxelStorageArray<T>>(),
            new VoxelStorageArray<T>(size.x, size.y, size.z)
        ) {
            view.storage = storage;
        }

        GCHandle? handle;

        public unsafe IntPtr Pin() {
            if (handle != null) {
                throw new InvalidOperationException("VoxelSet is already pinned");
            }

            handle = GCHandle.Alloc(storage.voxels, GCHandleType.Pinned);
            return handle.Value.AddrOfPinnedObject();
        }

        public void Unpin() {
            if (handle == null) {
                throw new InvalidOperationException("VoxelSet is not pinned");
            }

            handle.Value.Free();
            handle = null;
        }
    }
}
