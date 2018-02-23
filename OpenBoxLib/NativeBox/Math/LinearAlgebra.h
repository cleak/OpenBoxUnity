#pragma once

#include <algorithm>
#include <cstdint>
#include <cmath>
#include <cfloat>

#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/quaternion.hpp>

#include "Constants.h"

namespace obx {
	// Returns a random number in the range [0, 1]
	float randf();

	using glm::quat;

	// Float types
	using glm::vec2;
	using glm::vec3;
	using glm::vec4;

	using glm::mat2;
	using glm::mat3;
	using glm::mat4;

	using glm::mat2x2;
	using glm::mat2x3;
	using glm::mat2x4;

	using glm::mat3x2;
	using glm::mat3x3;
	using glm::mat3x4;

	using glm::mat4x2;
	using glm::mat4x3;
	using glm::mat4x4;

	// Double types
	using glm::dvec2;
	using glm::dvec3;
	using glm::dvec4;

	// Integer types
	using glm::ivec2;
	using glm::ivec3;
	using glm::ivec4;

	using glm::uvec2;
	using glm::uvec3;
	using glm::uvec4;

	// 16-bit ints
	typedef glm::tvec2<uint16_t, glm::mediump> usvec2;
	typedef glm::tvec3<uint16_t, glm::lowp> usvec3;

	static_assert(sizeof(usvec2) == sizeof(uint16_t) * 2, "glm changed uvec2 size");
	static_assert(sizeof(usvec3) == sizeof(uint16_t) * 3, "glm changed uvec3 size");

	// 8-bit ints
	typedef glm::tvec2<uint8_t> ubvec2;
	typedef glm::tvec3<uint8_t> ubvec3;
	typedef glm::tvec4<uint8_t> ubvec4;

	static_assert(sizeof(ubvec2) == 2, "glm changed ubvec2 size");
	static_assert(sizeof(ubvec3) == 3, "glm changed ubvec3 size");
	static_assert(sizeof(ubvec4) == 4, "glm changed ubvec4 size");

	///////////////////////////////////////////////////////////////////////////////
	// Helper functions.

	// Diagonal matrix
	mat3 Diag3(const vec3& v);
	mat3 Diag3(float x1, float x2, float x3);
	mat4 Diag4(const vec3& v);
	mat4 Diag4(float x1, float x2, float x3);
	mat4 Diag4(const vec4& v);
	mat4 Diag4(float x1, float x2, float x3, float x4);

	// Abs
	template <typename V>
	inline V Abs(const V& v) {
		V vOut;

		return glm::abs(v);

		for (int i = 0; i < v.length(); i++) {
			vOut[i] = std::abs(v[i]);
		}

		return vOut;
	}

	// Max
	template <typename V>
	inline typename V::value_type Max(const V& v) {
		typename V::value_type m = v[0];

		for (int i = 1; i < v.length(); i++) {
			m = std::max<typename V::value_type>(v[i], m);
		}

		return m;
	}

	// Min
	template <typename V>
	inline typename V::value_type Min(const V& v) {
		typename V::value_type m = v[0];

		for (int i = 1; i < v.length(); i++) {
			m = std::min<typename V::value_type>(v[i], m);
		}

		return m;
	}

	// AbsMax
	template <typename V>
	inline typename V::value_type AbsMax(const V& v) {
		typename V::value_type m = std::abs(v[0]);

		for (int i = 1; i < v.length(); i++) {
			m = std::max<typename V::value_type>(std::abs(v[i]), m);
		}

		return m;
	}

	// AbsMin
	template <typename V>
	inline typename V::value_type AbsMin(const V& v) {
		typename V::value_type m = std::abs(v[0]);

		for (int i = 1; i < v.length(); i++) {
			m = std::min<typename V::value_type>(std::abs(v[i]), m);
		}

		return m;
	}
}

