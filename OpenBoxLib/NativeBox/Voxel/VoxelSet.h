#pragma once

#include <functional>
#include <memory>
#include <vector>

#include <omp.h>

#include <glm/glm.hpp>

#include "../Util.h"
#include "../Math.h"

#include "SolidTest.h"
#include "VoxelStorage.h"
#include "VoxelView.h"

#define OBX_SOLID_TYPE bool

namespace obx {

///////////////////////////////////////////////////////////////////////////////
// Voxel Set
// A complete interface to a set of voxels.
//template<typename T, typename ContainerType, typename ViewType, typename SolidTestType>
template<typename T, typename ContainerType = VoxelStorageVector<T>, typename ViewType = VoxelViewPassthrough, typename SolidTestType = IsVoxelSolid<T>>
class VoxelSet : public ContainerType, public ViewType {

public:

    using SliceType = typename VoxelSet<T, typename ContainerType::ProxyType, VoxelViewSlice, SolidTestType>;
    using ValRefType = typename ContainerType::ValRefType;

    template<typename BaseVoxelStorageT>
    OBX_FORCEINLINE VoxelSet(BaseVoxelStorageT* p, const glm::ivec3& start, const glm::ivec3& end)
        : ContainerType(p) {
        ViewType::SetView(start, end);
    }

    explicit OBX_FORCEINLINE VoxelSet(int width)
        : ContainerType(width, width, width) {}

    OBX_FORCEINLINE VoxelSet(int w, int h, int d)
        : ContainerType(w, h, d) {}

    explicit OBX_FORCEINLINE VoxelSet(const glm::ivec3& dimensions)
        : ContainerType(dimensions.x, dimensions.y, dimensions.z) {}

    OBX_FORCEINLINE glm::ivec3 Size() const { return ViewType::GetSize(this); }
    OBX_FORCEINLINE glm::ivec3 ContainerSize() const { return ContainerType::GetSize(); }

    OBX_FORCEINLINE ValRefType At(const glm::ivec3& idx) { return At(idx.x, idx.y, idx.z); }
    OBX_FORCEINLINE ValRefType At(int x, int y, int z) {
        OBX_ASSERT(ViewType::IsValidIndex(this, x, y, z));
        ViewType::Transform(x, y, z);
        return ContainerType::At(x, y, z);
    }

	OBX_FORCEINLINE const T At(const glm::ivec3& idx) const { return At(idx.x, idx.y, idx.z); }
	OBX_FORCEINLINE const T At(int x, int y, int z) const {
		OBX_ASSERT(ViewType::IsValidIndex(this, x, y, z));
		ViewType::Transform(x, y, z);
		return ContainerType::At(x, y, z);
	}

    OBX_FORCEINLINE bool IsValidIndex(int x, int y, int z) const {
        return ViewType::IsValidIndex(this, x, y, z);
    }

    OBX_FORCEINLINE bool IsValidContainerIndex(int x, int y, int z) const {
        return ContainerType::IsValidIndex(x, y, z);
    }

    OBX_FORCEINLINE bool IsValidIndex(const glm::ivec3& idx) const {
        return IsValidIndex(idx.x, idx.y, idx.z);
    }

    OBX_FORCEINLINE ValRefType operator()(const glm::ivec3& idx) { return At(idx.x, idx.y, idx.z); }
    OBX_FORCEINLINE ValRefType operator()(int x, int y, int z) { return At(x, y, z); }

	OBX_FORCEINLINE const T operator()(const glm::ivec3& idx) const { return At(idx.x, idx.y, idx.z); }
	OBX_FORCEINLINE const T operator()(int x, int y, int z) const { return At(x, y, z); }

    // Assigns all voxels in the set to the given value
    OBX_FORCEINLINE void Set(const T& value) {
        Apply([&](ValRefType v) { v = value; });
    }

    template <typename FuncT>
    OBX_FORCEINLINE void Apply(FuncT func) {
        if (ViewType::CanApplyAll()) {
            ContainerType::Apply(func);
        } else {
            int startX = 0;
            int startY = 0;
            int startZ = 0;

            int endX = Size().x - 1;
            int endY = Size().y - 1;
            int endZ = Size().z - 1;

            ViewType::Transform(startX, startY, startZ);
            ViewType::Transform(endX, endY, endZ);

            ContainerType::Apply(func, startX, startY, startZ, endX, endY, endZ);
        }
    }

	template <typename FuncT>
	OBX_FORCEINLINE void Apply(FuncT func) const {
		if (ViewType::CanApplyAll()) {
			ContainerType::Apply(func);
		} else {
			int startX = 0;
			int startY = 0;
			int startZ = 0;

			int endX = Size().x - 1;
			int endY = Size().y - 1;
			int endZ = Size().z - 1;

			ViewType::Transform(startX, startY, startZ);
			ViewType::Transform(endX, endY, endZ);

			ContainerType::Apply(func, startX, startY, startZ, endX, endY, endZ);
		}
	}

    template <typename FuncT>
    OBX_FORCEINLINE void ApplyIndexed(FuncT func) {
        int startX = 0;
        int startY = 0;
        int startZ = 0;

        int endX = Size().x - 1;
        int endY = Size().y - 1;
        int endZ = Size().z - 1;

        ViewType::Transform(startX, startY, startZ);
        ViewType::Transform(endX, endY, endZ);

        ContainerType::ApplyIndexed(func, startX, startY, startZ, endX, endY, endZ);
    }

	template <typename FuncT>
	OBX_FORCEINLINE void ApplyIndexed(FuncT func) const {
		int startX = 0;
		int startY = 0;
		int startZ = 0;

		int endX = Size().x - 1;
		int endY = Size().y - 1;
		int endZ = Size().z - 1;

		ViewType::Transform(startX, startY, startZ);
		ViewType::Transform(endX, endY, endZ);

		ContainerType::ApplyIndexed(func, startX, startY, startZ, endX, endY, endZ);
	}

	///////////////////////////////////////////////////////////////////////////////
	// Parallel versions of Apply methods

	template <typename FuncT>
	OBX_FORCEINLINE void ApplyIndexed(FuncT func, int threads) {
		int startX = 0;
		int startY = 0;
		int startZ = 0;

		int endX = Size().x - 1;
		int endY = Size().y - 1;
		int endZ = Size().z - 1;

		ViewType::Transform(startX, startY, startZ);
		ViewType::Transform(endX, endY, endZ);

		ivec3 kernelSize(8, 8, 8);

		ivec3 start(startX, startY, startZ);
		ivec3 end(endX, endY, endZ);

		ivec3 numKernels = ((end - start) + kernelSize) / kernelSize;

		omp_set_num_threads(threads);

#pragma omp parallel
		{
			int i = omp_get_thread_num();
			int numThreads = omp_get_num_threads();

			for (int z = 0; z < numKernels.z; ++z) {
				for (int y = 0; y < numKernels.y; ++y) {
					for (int x = (z + y + i) % numThreads; x < numKernels.x; x += numThreads) {
						ivec3 startIdx = start + ivec3(x, y, z) * kernelSize;
						ivec3 endIdx = start + ivec3(x, y, z) * kernelSize + kernelSize - ivec3(1);

						endIdx = glm::min(endIdx, end);
						ContainerType::ApplyIndexed(func, startIdx.x, startIdx.y, startIdx.z, endIdx.x, endIdx.y, endIdx.z);
					}
				}
			}
		}
	}

    OBX_FORCEINLINE SliceType Slice(const glm::ivec3& start, const glm::ivec3& end) {
        return SliceType((ContainerType*)(this), start, end);
    }

    OBX_FORCEINLINE SliceType Slice(int x0, int y0, int z0, int x1, int y1, int z1) {
        return Slice(glm::ivec3(x0, y0, z0), glm::ivec3(x1, y1, z1));
    }

	OBX_FORCEINLINE const SliceType Slice(const glm::ivec3& start, const glm::ivec3& end) const {
		return SliceType((ContainerType*)(this), start, end);
	}

	OBX_FORCEINLINE const SliceType Slice(int x0, int y0, int z0, int x1, int y1, int z1) const {
		return Slice(glm::ivec3(x0, y0, z0), glm::ivec3(x1, y1, z1));
	}

    OBX_FORCEINLINE bool IsSolid(int x, int y, int z) const {
        return IsValidIndex(x, y, z) && SolidTestType::IsSolid(At(x, y, z));
    }

    OBX_FORCEINLINE bool IsSolid(const glm::ivec3& idx) const {
        return IsSolid(idx.x, idx.y, idx.z);
    }

    OBX_FORCEINLINE std::unique_ptr<VoxelSet<OBX_SOLID_TYPE, VoxelStorageVector<OBX_SOLID_TYPE>, VoxelViewPassthrough>> ToSolidBits() const {
        VoxelSet<OBX_SOLID_TYPE, VoxelStorageVector<OBX_SOLID_TYPE>, VoxelViewPassthrough>* solidBits = new VoxelSet<OBX_SOLID_TYPE, VoxelStorageVector<OBX_SOLID_TYPE>, VoxelViewPassthrough>(Size());
		ToSolidBits(*solidBits);
        return std::unique_ptr<VoxelSet<OBX_SOLID_TYPE, VoxelStorageVector<OBX_SOLID_TYPE>, VoxelViewPassthrough>>(solidBits);
    }

	template<typename U>
	OBX_FORCEINLINE void ToSolidBits(U& otherVoxels) const {
		OBX_ASSERT(Size() == otherVoxels.Size());
		ApplyIndexed([&](const T& val, int x, int y, int z) {
			// TODO: THIS SHOULDN'T BE REQUIRED!!
			ViewType::ReverseTransform(x, y, z);
			otherVoxels.At(x, y, z) = SolidTestType::IsSolid(val);
		});
	}

    OBX_FORCEINLINE bool IsAllSolid() const {
        const auto size = Size();
        for (int z = 0; z < size.z; ++z) {
            for (int y = 0; y < size.y; ++y) {
                for (int x = 0; x < size.x; ++x) {
                    if (!IsSolid(x, y, z)) {
                        return false;
                    }
                }
            }
        }
        return true;
    }

	OBX_FORCEINLINE bool IsEmpty() const {
		const auto size = Size();
		for (int z = 0; z < size.z; ++z) {
			for (int y = 0; y < size.y; ++y) {
				for (int x = 0; x < size.x; ++x) {
					if (IsSolid(x, y, z)) {
						return false;
					}
				}
			}
		}
		return true;
	}

	OBX_FORCEINLINE std::unique_ptr<VoxelSet<T, VoxelStorageVector<T>, VoxelViewPassthrough>> Clone() const {
		VoxelSet<T, VoxelStorageVector<T>, VoxelViewPassthrough>* cloned = new VoxelSet<T, VoxelStorageVector<T>, VoxelViewPassthrough>(Size());
		
		OBX_ASSERT(Size() == cloned->Size());
		ApplyIndexed([&](const T& val, int x, int y, int z) {
			ViewType::ReverseTransform(x, y, z);
			cloned->At(x, y, z) = val;
		});

		return std::unique_ptr<VoxelSet<T, VoxelStorageVector<T>, VoxelViewPassthrough>>(cloned);
	}
};

} // namepsace obx
