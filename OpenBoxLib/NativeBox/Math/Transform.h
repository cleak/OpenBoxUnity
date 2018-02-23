#pragma once

#include "LinearAlgebra.h"
#include "Pose.h"

#include "../Util.h"

namespace obx {

class Transform : DoNotCopy {
private:
	Transform* parent = nullptr;

public:

	Pose localPose;

	Transform();
	Transform(mat4 m);
	Transform(mat3 m);
	Transform(quat orientation, vec3 position, vec3 scale);
	Transform(const Transform &other);

	Transform& operator= (const Transform &other);

	void SetGlobalPose(const Pose &pose);
	const Pose GetGlobalPose() const;
	void SetLocalPose(const Pose& pose) { localPose = pose; }
	const Pose GetLocalPose() const { return localPose; }

	void Rotate(const quat& rot);
	void Rotate(const vec3& axis, float radians);
	void RotateX(float radians);
	void RotateY(float radians);
	void RotateZ(float radians);
	void Translate(const vec3& trans);

	void SetPosition(const vec3& position);
	vec3 GetPosition() const;

	vec3 GetForward() const;
	vec3 GetBack() const;
	vec3 GetLeft() const;
	vec3 GetRight() const;
	vec3 GetUp() const;
	vec3 GetDown() const;

	vec3 GetLocalForward() const;

	// Sets the forward direction with a vector that need not be normalized.
	void SetLocalForward(vec3 forward);

	// Sets the forward direction with a normalized vector. Faster than the unnormalized version.
	void SetLocalForwardNormal(vec3 forward);

	mat3 ToMat3() const;
	mat4 ToMat4() const;
	mat4 ToViewMat() const;
	mat3 ToNormalMat() const;

	Transform* GetParent() const { return parent; }
	void SetParent(Transform* parent) { this->parent = parent; }

	Pose Inverse();
};

} // namespace obx