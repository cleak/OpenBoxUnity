#pragma once

#include "LinearAlgebra.h"
#include "Transform.h"

#include "../Util.h"

namespace obx {

// Proxy to make accessing transforms associated with a class simpler
class TransformProxy {
private:
	Transform* transform = nullptr;

protected:

	OBX_FORCEINLINE void SetTransform(Transform* transform) { this->transform = transform; }

public:

	OBX_FORCEINLINE TransformProxy() : transform(nullptr) {}
	OBX_FORCEINLINE virtual ~TransformProxy() {}

	OBX_FORCEINLINE void Rotate(const quat& rot) { transform->Rotate(rot); }
	OBX_FORCEINLINE void Rotate(const vec3& axis, float radians) { transform->Rotate(axis, radians); }
	OBX_FORCEINLINE void RotateX(float radians) { transform->RotateX(radians); }
	OBX_FORCEINLINE void RotateY(float radians) { transform->RotateY(radians); }
	OBX_FORCEINLINE void RotateZ(float radians) { transform->RotateZ(radians); }
	OBX_FORCEINLINE void Translate(const vec3& trans) { transform->Translate(trans); }

	OBX_FORCEINLINE vec3 GetForward() const { return transform->GetForward(); }
	OBX_FORCEINLINE vec3 GetLocalForward() const { return transform->GetLocalForward(); }
	OBX_FORCEINLINE void SetLocalForward(vec3 forward) { return transform->SetLocalForward(forward); }
	OBX_FORCEINLINE void SetLocalForwardNormal(vec3 forward) { return transform->SetLocalForwardNormal(forward); }

	OBX_FORCEINLINE vec3 GetBack() const { return transform->GetBack(); }
	OBX_FORCEINLINE vec3 GetLeft() const { return transform->GetLeft(); }
	OBX_FORCEINLINE vec3 GetRight() const { return transform->GetRight(); }
	OBX_FORCEINLINE vec3 GetUp() const { return transform->GetUp(); }
	OBX_FORCEINLINE vec3 GetDown() const { return transform->GetDown(); }

	OBX_FORCEINLINE mat3 ToMat3() const { return transform->ToMat3(); }
	OBX_FORCEINLINE mat4 ToMat4() const { return transform->ToMat4(); }
	OBX_FORCEINLINE mat4 ToViewMat() const { return transform->ToViewMat(); }

	OBX_FORCEINLINE Transform* GetTransform() const { return transform; }

	OBX_FORCEINLINE void SetGlobalPose(const Pose& pose) { transform->SetGlobalPose(pose); }
	OBX_FORCEINLINE Pose GetGlobalPose() const { return transform->GetGlobalPose(); }

	OBX_FORCEINLINE void SetPosition(const vec3& position) { transform->SetPosition(position); }
	OBX_FORCEINLINE vec3 GetPosition() const { return transform->GetPosition(); }

	OBX_FORCEINLINE void SetLocalPose(const Pose& pose) { transform->localPose = pose; }
	OBX_FORCEINLINE Pose GetLocalPose() const { return transform->localPose; }
};

} // namespace obx