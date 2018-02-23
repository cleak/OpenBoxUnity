#pragma once

#include "LinearAlgebra.h"

#include "../Util.h"

namespace obx {

class Pose {
public:
	quat orientation = { 1, 0, 0, 0 };
	vec3 position = { 0, 0, 0 };
	vec3 scale = { 1, 1, 1 };

	Pose();
	Pose(mat4 m);
	Pose(mat3 m);
	Pose(quat orientation, vec3 position, vec3 scale);
	Pose(const Pose &other);

	Pose& operator= (const Pose &other);

	Pose operator* (const Pose &other) const;

	void Rotate(const quat& rot);
	void Rotate(const vec3& axis, float radians);
	void RotateX(float radians);
	void RotateY(float radians);
	void RotateZ(float radians);
	void Translate(const vec3& trans);

	vec3 GetForward() const;
	vec3 GetBack() const;
	vec3 GetLeft() const;
	vec3 GetRight() const;
	vec3 GetUp() const;
	vec3 GetDown() const;

	void SetForward(vec3 forward);

	// Sets the forward direction with a normalized vector. Faster than the unnormalized version.
	void SetForwardNormal(vec3 forward);

	mat3 ToMat3() const;
	mat4 ToMat4() const;
	mat4 ToViewMat() const;

	static Pose Combine(const Pose& parent, const Pose& child);
	static Pose Inverse(const Pose& pose);
	static Pose LookAt(const vec3& eye, const vec3& at, const vec3& up);
};

} // namespace obx
