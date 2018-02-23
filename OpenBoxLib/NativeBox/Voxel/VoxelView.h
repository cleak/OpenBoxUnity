#pragma once

#include <glm/glm.hpp>

#include "../Util.h"
#include "../Math.h"

namespace obx {

///////////////////////////////////////////////////////////////////////////////
// Voxel View Slice: Remaps indices to a sliced view of a voxel set (i.e.
//					 offset and range restriction.
class VoxelViewSlice {
private:

	glm::ivec3 Start;
	glm::ivec3 Size;

protected:

	OBX_FORCEINLINE void SetView(const glm::ivec3& startPos, const glm::ivec3& endPos) {
		Start = startPos;
		Size = endPos - startPos + glm::ivec3(1, 1, 1);
	}

	OBX_FORCEINLINE glm::ivec3 GetSize(const void* v) const { return Size; }

	OBX_FORCEINLINE bool IsValidIndex(const void* v, int x, int y, int z) const {
		return x >= 0 && x < Size.x
			&& y >= 0 && y < Size.y
			&& z >= 0 && z < Size.z;
	}

	OBX_FORCEINLINE void Transform(int& x, int& y, int& z) const {
		OBX_ASSERT(IsValidIndex(nullptr, x, y, z));
		x += Start.x;
		y += Start.y;
		z += Start.z;
	}

	OBX_FORCEINLINE void ReverseTransform(int& x, int& y, int& z) const {
		x -= Start.x;
		y -= Start.y;
		z -= Start.z;
		OBX_ASSERT(IsValidIndex(nullptr, x, y, z));
	}

	OBX_FORCEINLINE bool CanApplyAll() const {
		return false;
	}
};

///////////////////////////////////////////////////////////////////////////////
// Voxel View Passthrough: Identity transform of indices.
class VoxelViewPassthrough {
protected:

	OBX_FORCEINLINE void SetView(const glm::ivec3& startPos, const glm::ivec3& endPos) {}

	template <typename Base>
	OBX_FORCEINLINE glm::ivec3 GetSize(Base* t) const {
		return t->ContainerSize();
	}

	template <typename Base>
	OBX_FORCEINLINE bool IsValidIndex(Base* t, int x, int y, int z) const {
		return t->IsValidContainerIndex(x, y, z);
	}

	OBX_FORCEINLINE void Transform(int& x, int& y, int& z) const {}

	OBX_FORCEINLINE void ReverseTransform(int& x, int& y, int& z) const {}

	OBX_FORCEINLINE bool CanApplyAll() const {
		return true;
	}
};

} // namespace obx
