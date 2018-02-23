#pragma once

#include "../Util.h"
#include "../Math.h"

namespace obx {

///////////////////////////////////////////////////////////////////////////////
// Solid test methods
template <typename V>
struct IsVoxelSolid {
	OBX_FORCEINLINE static bool IsSolid(const V& v) {
		return false;
	}
};

template <>
struct IsVoxelSolid<std::uint8_t> {
	OBX_FORCEINLINE static bool IsSolid(const uint8_t& v) {
		return v > 0;
	}
};

template <>
struct IsVoxelSolid<bool> {
	OBX_FORCEINLINE static bool IsSolid(const bool& v) {
		return v;
	}
};

template <>
struct IsVoxelSolid<glm::vec4> {
	OBX_FORCEINLINE static bool IsSolid(const glm::vec4& v) {
		return v.a > OBX_EPSILON;
	}
};

template <>
struct IsVoxelSolid<ubvec4> {
	OBX_FORCEINLINE static bool IsSolid(const ubvec4& v) {
		return v.a > OBX_EPSILON;
	}
};

} // namespace obx