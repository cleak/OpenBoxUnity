#pragma once

/*******************************************************************************
Voxel Storage

Collection of storage backings for VoxelSet. Includes:
 * VoxelStorageVector: std::vector backed voxel set.
 * VoxelStoragePointer: Raw pointer based voxel set. Does not include memory
	management; user is responsible for creating and deleting memory.
 * VoxelStorageProxy: Proxy type, for referring to the same storage in new ways
	(e.g. in slicing).

*******************************************************************************/

#include <functional>
#include <vector>

#include <glm/glm.hpp>

#include "../Util.h"
#include "../Math.h"

namespace obx {

////////////////////////////////////////////////////////////////////////////////
// VoxelStorageProxy: Proxy to another storage type.
template<typename T, typename BaseStorageType>
class VoxelStorageProxy {
private:

	BaseStorageType* BaseVoxelStorage = nullptr;

protected:

	OBX_FORCEINLINE VoxelStorageProxy(BaseStorageType* baseVoxelStorage) {
		BaseVoxelStorage = baseVoxelStorage;
	}

	OBX_FORCEINLINE VoxelStorageProxy(VoxelStorageProxy<T, BaseStorageType>* proxy) {
		BaseVoxelStorage = proxy->BaseVoxelStorage;
	}

	using ProxyType = VoxelStorageProxy<T, BaseStorageType>;
	using ValRefType = typename BaseStorageType::ValRefType;

	OBX_FORCEINLINE VoxelStorageProxy(int w, int h, int d) {}

	OBX_FORCEINLINE void SetBaseVoxelStorage(BaseStorageType* baseVoxelStorage) {
		BaseVoxelStorage = baseVoxelStorage;
	}

	OBX_FORCEINLINE glm::ivec3 GetSize() const {
		return BaseVoxelStorage->GetSize();
	}

	// Retrieves the value at the specified index, possibly for setting
	OBX_FORCEINLINE ValRefType At(int x, int y, int z) {
		return BaseVoxelStorage->At(x, y, z);
	}

	OBX_FORCEINLINE const T At(int x, int y, int z) const {
		return BaseVoxelStorage->At(x, y, z);
	}

	// Checks if the given index is valid
	OBX_FORCEINLINE bool IsValidIndex(int x, int y, int z) const {
		return BaseVoxelStorage->IsValidIndex(x, y, z);
	}

	// Assigns all voxels in the set to the given value
	OBX_FORCEINLINE void Set(ValRefType value) {
		BaseVoxelStorage->Set(value);
	}

	// Assigns all voxels in the set to the given value in the given range
	OBX_FORCEINLINE void Set(ValRefType value, int startX, int startY, int startZ, int endX, int endY, int endZ) {
		BaseVoxelStorage->Set(value, startX, startY, startZ, endX, endY, endZ);
	}

	// Assigns all voxels in the set to the given value
	template <typename FuncT>
	OBX_FORCEINLINE void Apply(FuncT func) {
		BaseVoxelStorage->Apply(func);
	}

	template <typename FuncT>
	OBX_FORCEINLINE void Apply(FuncT func) const {
		BaseVoxelStorage->Apply(func);
	}

	// Assigns all voxels in the set to the given value in the given range
	template <typename FuncT>
	OBX_FORCEINLINE void Apply(FuncT func, int startX, int startY, int startZ, int endX, int endY, int endZ) {
		BaseVoxelStorage->Apply(func, startX, startY, startZ, endX, endY, endZ);
	}

	template <typename FuncT>
	OBX_FORCEINLINE void Apply(FuncT func, int startX, int startY, int startZ, int endX, int endY, int endZ) const {
		BaseVoxelStorage->Apply(func, startX, startY, startZ, endX, endY, endZ);
	}

	// Assigns all voxels in the set to the given value in the given range
	template <typename FuncT>
	OBX_FORCEINLINE void ApplyIndexed(FuncT func, int startX, int startY, int startZ, int endX, int endY, int endZ) {
		BaseVoxelStorage->ApplyIndexed(func, startX, startY, startZ, endX, endY, endZ);
	}

	template <typename FuncT>
	OBX_FORCEINLINE void ApplyIndexed(FuncT func, int startX, int startY, int startZ, int endX, int endY, int endZ) const {
		BaseVoxelStorage->ApplyIndexed(func, startX, startY, startZ, endX, endY, endZ);
	}
};

////////////////////////////////////////////////////////////////////////////////
// VoxelStorageVector: std::vector based voxel storage.
template<typename T>
class VoxelStorageVector {
private:

	friend class VoxelStorageProxy<T, VoxelStorageVector<T>>;

	std::vector<T> Voxels;
	glm::ivec3 Size;

	int ZMul;
	int YMul;

protected:

	using ProxyType = VoxelStorageProxy<T, VoxelStorageVector<T>>;
	using ValRefType = typename std::vector<T>::reference;

	OBX_FORCEINLINE VoxelStorageVector(int w, int h, int d) {
		Voxels.resize(w * h * d);
		YMul = w;
		ZMul = w * h;
		Size.x = w;
		Size.y = h;
		Size.z = d;
	}

	OBX_FORCEINLINE glm::ivec3 GetSize() const { return Size; }

	// Retrieves the value at the specified index, possibly for setting
	OBX_FORCEINLINE ValRefType At(int x, int y, int z) {
		OBX_ASSERT(IsValidIndex(x, y, z));
		return Voxels[z * ZMul + y * YMul + x];
	}

	OBX_FORCEINLINE const T At(int x, int y, int z) const {
		OBX_ASSERT(IsValidIndex(x, y, z));
		return Voxels[z * ZMul + y * YMul + x];
	}

	// Checks if the given index is valid
	OBX_FORCEINLINE bool IsValidIndex(int x, int y, int z) const {
		return x >= 0 && x < Size.x
			&& y >= 0 && y < Size.y
			&& z >= 0 && z < Size.z;
	}

	// Assigns all voxels in the set to the given value
	OBX_FORCEINLINE void Set(ValRefType value) {
		const size_t kMaxSize = Voxels.size();
		for (size_t i = 0; i < kMaxSize; ++i) {
			Voxels[i] = value;
		}
	}

	// Assigns all voxels in the set to the given value in the given range
	OBX_FORCEINLINE void Set(ValRefType value, int startX, int startY, int startZ, int endX, int endY, int endZ) {
		OBX_ASSERT(IsValidIndex(startX, startY, startZ));
		OBX_ASSERT(IsValidIndex(endX, endY, endZ));
		OBX_ASSERT(startX <= endX);
		OBX_ASSERT(startY <= endY);
		OBX_ASSERT(startZ <= endZ);

		for (int z = startZ; z <= endZ; ++z) {
			for (int y = startY; y <= endY; ++y) {
				int baseIdx = z * ZMul + y * YMul;
				for (int x = startX; x <= endX; ++x) {
					Voxels[baseIdx + x] = value;
				}
			}
		}
	}

	template <typename FuncT>
	OBX_FORCEINLINE void Apply(FuncT func) {
		const size_t kMaxSize = Voxels.size();
		for (size_t i = 0; i < kMaxSize; ++i) {
			func(Voxels[i]);
		}
	}

	template <typename FuncT>
	OBX_FORCEINLINE void Apply(FuncT func) const {
		const size_t kMaxSize = Voxels.size();
		for (size_t i = 0; i < kMaxSize; ++i) {
			func(Voxels[i]);
		}
	}

	template <typename FuncT>
	OBX_FORCEINLINE void Apply(FuncT func, int startX, int startY, int startZ, int endX, int endY, int endZ) {
		OBX_ASSERT(IsValidIndex(startX, startY, startZ));
		OBX_ASSERT(IsValidIndex(endX, endY, endZ));
		OBX_ASSERT(startX <= endX);
		OBX_ASSERT(startY <= endY);
		OBX_ASSERT(startZ <= endZ);

		for (int z = startZ; z <= endZ; ++z) {
			for (int y = startY; y <= endY; ++y) {
				int baseIdx = z * ZMul + y * YMul;
				for (int x = startX; x <= endX; ++x) {
					func(Voxels[baseIdx + x]);
				}
			}
		}
	}

	template <typename FuncT>
	OBX_FORCEINLINE void Apply(FuncT func, int startX, int startY, int startZ, int endX, int endY, int endZ) const {
		OBX_ASSERT(IsValidIndex(startX, startY, startZ));
		OBX_ASSERT(IsValidIndex(endX, endY, endZ));
		OBX_ASSERT(startX <= endX);
		OBX_ASSERT(startY <= endY);
		OBX_ASSERT(startZ <= endZ);

		for (int z = startZ; z <= endZ; ++z) {
			for (int y = startY; y <= endY; ++y) {
				int baseIdx = z * ZMul + y * YMul;
				for (int x = startX; x <= endX; ++x) {
					func(Voxels[baseIdx + x]);
				}
			}
		}
	}

	template <typename FuncT>
	OBX_FORCEINLINE void ApplyIndexed(FuncT func, int startX, int startY, int startZ, int endX, int endY, int endZ) {
		OBX_ASSERT(IsValidIndex(startX, startY, startZ));
		OBX_ASSERT(IsValidIndex(endX, endY, endZ));
		OBX_ASSERT(startX <= endX);
		OBX_ASSERT(startY <= endY);
		OBX_ASSERT(startZ <= endZ);

		for (int z = startZ; z <= endZ; ++z) {
			for (int y = startY; y <= endY; ++y) {
				int baseIdx = z * ZMul + y * YMul;
				for (int x = startX; x <= endX; ++x) {
					func(Voxels[baseIdx + x], x, y, z);
				}
			}
		}
	}

	template <typename FuncT>
	OBX_FORCEINLINE void ApplyIndexed(FuncT func, int startX, int startY, int startZ, int endX, int endY, int endZ) const {
		OBX_ASSERT(IsValidIndex(startX, startY, startZ));
		OBX_ASSERT(IsValidIndex(endX, endY, endZ));
		OBX_ASSERT(startX <= endX);
		OBX_ASSERT(startY <= endY);
		OBX_ASSERT(startZ <= endZ);

		for (int z = startZ; z <= endZ; ++z) {
			for (int y = startY; y <= endY; ++y) {
				int baseIdx = z * ZMul + y * YMul;
				for (int x = startX; x <= endX; ++x) {
					func(Voxels[baseIdx + x], x, y, z);
				}
			}
		}
	}
};

////////////////////////////////////////////////////////////////////////////////
// VoxelStorageVector: Non-owner raw pointer backed voxel storage.
template<typename T>
class VoxelStoragePointer {
public:

	void SetView(T* voxels) { Voxels = voxels; }
	T* Voxels = nullptr;

protected:

	friend class VoxelStorageProxy<T, VoxelStoragePointer<T>>;

	glm::ivec3 Size;

	int ZMul;
	int YMul;

	using ProxyType = VoxelStorageProxy<T, VoxelStoragePointer<T>>;
	using ValRefType = T&;

	OBX_FORCEINLINE VoxelStoragePointer(int w, int h, int d) {
		YMul = w;
		ZMul = w * h;
		Size.x = w;
		Size.y = h;
		Size.z = d;
	}

	OBX_FORCEINLINE glm::ivec3 GetSize() const { return Size; }

	// Retrieves the value at the specified index, possibly for setting
	OBX_FORCEINLINE ValRefType At(int x, int y, int z) {
		OBX_ASSERT(IsValidIndex(x, y, z));
		return Voxels[z * ZMul + y * YMul + x];
	}

	OBX_FORCEINLINE const T At(int x, int y, int z) const {
		OBX_ASSERT(IsValidIndex(x, y, z));
		return Voxels[z * ZMul + y * YMul + x];
	}

	// Checks if the given index is valid
	OBX_FORCEINLINE bool IsValidIndex(int x, int y, int z) const {
		return x >= 0 && x < Size.x
			&& y >= 0 && y < Size.y
			&& z >= 0 && z < Size.z;
	}

	// Assigns all voxels in the set to the given value
	OBX_FORCEINLINE void Set(ValRefType value) {
		const size_t kMaxSize = Voxels.size();
		for (size_t i = 0; i < kMaxSize; ++i) {
			Voxels[i] = value;
		}
	}

	// Assigns all voxels in the set to the given value in the given range
	OBX_FORCEINLINE void Set(ValRefType value, int startX, int startY, int startZ, int endX, int endY, int endZ) {
		OBX_ASSERT(IsValidIndex(startX, startY, startZ));
		OBX_ASSERT(IsValidIndex(endX, endY, endZ));
		OBX_ASSERT(startX <= endX);
		OBX_ASSERT(startY <= endY);
		OBX_ASSERT(startZ <= endZ);

		for (int z = startZ; z <= endZ; ++z) {
			for (int y = startY; y <= endY; ++y) {
				int baseIdx = z * ZMul + y * YMul;
				for (int x = startX; x <= endX; ++x) {
					Voxels[baseIdx + x] = value;
				}
			}
		}
	}

	template <typename FuncT>
	OBX_FORCEINLINE void Apply(FuncT func) {
		const size_t kMaxSize = Size.x * Size.y * Size.z;
		for (size_t i = 0; i < kMaxSize; ++i) {
			func(Voxels[i]);
		}
	}

	template <typename FuncT>
	OBX_FORCEINLINE void Apply(FuncT func) const {
		const size_t kMaxSize = Size.x * Size.y * Size.z;
		for (size_t i = 0; i < kMaxSize; ++i) {
			func(Voxels[i]);
		}
	}

	template <typename FuncT>
	OBX_FORCEINLINE void Apply(FuncT func, int startX, int startY, int startZ, int endX, int endY, int endZ) {
		OBX_ASSERT(IsValidIndex(startX, startY, startZ));
		OBX_ASSERT(IsValidIndex(endX, endY, endZ));
		OBX_ASSERT(startX <= endX);
		OBX_ASSERT(startY <= endY);
		OBX_ASSERT(startZ <= endZ);

		for (int z = startZ; z <= endZ; ++z) {
			for (int y = startY; y <= endY; ++y) {
				int baseIdx = z * ZMul + y * YMul;
				for (int x = startX; x <= endX; ++x) {
					func(Voxels[baseIdx + x]);
				}
			}
		}
	}

	template <typename FuncT>
	OBX_FORCEINLINE void Apply(FuncT func, int startX, int startY, int startZ, int endX, int endY, int endZ) const {
		OBX_ASSERT(IsValidIndex(startX, startY, startZ));
		OBX_ASSERT(IsValidIndex(endX, endY, endZ));
		OBX_ASSERT(startX <= endX);
		OBX_ASSERT(startY <= endY);
		OBX_ASSERT(startZ <= endZ);

		for (int z = startZ; z <= endZ; ++z) {
			for (int y = startY; y <= endY; ++y) {
				int baseIdx = z * ZMul + y * YMul;
				for (int x = startX; x <= endX; ++x) {
					func(Voxels[baseIdx + x]);
				}
			}
		}
	}

	template <typename FuncT>
	OBX_FORCEINLINE void ApplyIndexed(FuncT func, int startX, int startY, int startZ, int endX, int endY, int endZ) {
		OBX_ASSERT(IsValidIndex(startX, startY, startZ));
		OBX_ASSERT(IsValidIndex(endX, endY, endZ));
		OBX_ASSERT(startX <= endX);
		OBX_ASSERT(startY <= endY);
		OBX_ASSERT(startZ <= endZ);

		for (int z = startZ; z <= endZ; ++z) {
			for (int y = startY; y <= endY; ++y) {
				int baseIdx = z * ZMul + y * YMul;
				for (int x = startX; x <= endX; ++x) {
					func(Voxels[baseIdx + x], x, y, z);
				}
			}
		}
	}

	template <typename FuncT>
	OBX_FORCEINLINE void ApplyIndexed(FuncT func, int startX, int startY, int startZ, int endX, int endY, int endZ) const {
		OBX_ASSERT(IsValidIndex(startX, startY, startZ));
		OBX_ASSERT(IsValidIndex(endX, endY, endZ));
		OBX_ASSERT(startX <= endX);
		OBX_ASSERT(startY <= endY);
		OBX_ASSERT(startZ <= endZ);

		for (int z = startZ; z <= endZ; ++z) {
			for (int y = startY; y <= endY; ++y) {
				int baseIdx = z * ZMul + y * YMul;
				for (int x = startX; x <= endX; ++x) {
					func(Voxels[baseIdx + x], x, y, z);
				}
			}
		}
	}
};

} // namespace obx