#include "Transform.h"

#include <glm/gtc/quaternion.hpp>

namespace obx {

Transform::Transform() {}
Transform::Transform(mat4 m) : localPose(m) {}
Transform::Transform(mat3 m) : localPose(m) {}

Transform::Transform(quat orientation, vec3 position, vec3 scale)
	: localPose(orientation, position, scale)
{}

Transform::Transform(const Transform &other) {
	if (!other.parent) {
		localPose = other.localPose;
	} else {
		SetGlobalPose(other.GetGlobalPose());
	}
}

Transform& Transform::operator= (const Transform &other) {
	SetGlobalPose(other.GetGlobalPose());
	return *this;
}

void Transform::SetGlobalPose(const Pose & pose) {
	if (!parent) {
		localPose = pose;
	} else {
		Pose parentFrameInv = Pose::Inverse(parent->GetGlobalPose());
		localPose = Pose::Combine(pose, parentFrameInv);
	}
}

const Pose Transform::GetGlobalPose() const {
	if (!parent) {
		return localPose;
	}

	Pose globalTrans = localPose;
	Transform* p = parent;
	while (p) {
		globalTrans = Pose::Combine(p->localPose, globalTrans);
		p = p->parent;
	}

	return globalTrans;
}

void Transform::Rotate(const quat & rot) {
	// TODO: Should be global
	localPose.Rotate(rot);
	// TODO: changed();
}

void Transform::Rotate(const vec3 & axis, float radians) {
	Rotate(quat(glm::cos(radians / 2.0f), axis * glm::sin(radians / 2.0f)));
}

void Transform::RotateX(float radians) {
	Rotate(vec3(1, 0, 0), radians);
}

void Transform::RotateY(float radians) {
	Rotate(vec3(0, 1, 0), radians);
}

void Transform::RotateZ(float radians) {
	Rotate(vec3(0, 0, 1), radians);
}

void Transform::Translate(const vec3 & trans) {
	// TODO: Should be global
	localPose.Translate(trans);
	// TODO: changed();
}

void Transform::SetPosition(const vec3 & position) {
	Pose pose = GetGlobalPose();
	pose.position = position;
	SetGlobalPose(pose);
}

vec3 Transform::GetPosition() const {
	return GetGlobalPose().position;
}

vec3 Transform::GetForward() const {
	if (!parent) {
		return localPose.GetForward();
	} else {
		return parent->GetGlobalPose().orientation * localPose.GetForward();
	}
}

vec3 Transform::GetBack() const {
	if (!parent) {
		return localPose.GetBack();
	} else {
		return parent->GetGlobalPose().orientation * localPose.GetBack();
	}
}

vec3 Transform::GetLeft() const {
	if (!parent) {
		return localPose.GetLeft();
	} else {
		return parent->GetGlobalPose().orientation * localPose.GetLeft();
	}
}

vec3 Transform::GetRight() const {
	if (!parent) {
		return localPose.GetRight();
	} else {
		return parent->GetGlobalPose().orientation * localPose.GetRight();
	}
}

vec3 Transform::GetUp() const {
	if (!parent) {
		return localPose.GetUp();
	} else {
		return parent->GetGlobalPose().orientation * localPose.GetUp();
	}
}

vec3 Transform::GetDown() const {
	if (!parent) {
		return localPose.GetDown();
	} else {
		return parent->GetGlobalPose().orientation * localPose.GetDown();
	}
}

vec3 Transform::GetLocalForward() const {
	return localPose.GetForward();
}

void Transform::SetLocalForward(vec3 forward) {
	localPose.SetForward(forward);
}

void Transform::SetLocalForwardNormal(vec3 forward) {
	localPose.SetForwardNormal(forward);
}

mat3 Transform::ToMat3() const {
	return GetGlobalPose().ToMat3();
}

mat4 Transform::ToMat4() const {
	return GetGlobalPose().ToMat4();
}

mat4 Transform::ToViewMat() const {
	return Pose::Inverse(GetGlobalPose()).ToMat4();
}

mat3 Transform::ToNormalMat() const {
	auto pose = GetGlobalPose();
	pose.scale = vec3(1);
	pose.position = vec3(0);

	//return Pose::Inverse(pose).ToMat3();
	return glm::transpose(Pose::Inverse(pose).ToMat3());
}

Pose Transform::Inverse() {
	return Pose::Inverse(GetGlobalPose());
}

} // namespace obx