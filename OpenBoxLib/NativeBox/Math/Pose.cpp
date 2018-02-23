#include "Pose.h"

#include <iostream>

namespace obx {

Pose::Pose() {}

Pose::Pose(mat4 m) {
	// This assuming no scale
	//orientation = glm::inverse(glm::quat_cast(m));
	orientation = glm::quat_cast(m);
	position = m[3];
}

Pose::Pose(mat3 m) {
	// This assuming no scale
	orientation = glm::quat_cast(m);
}

Pose::Pose(quat orientation, vec3 position, vec3 scale) : Pose(*this) {
	this->orientation = orientation;
	this->position = position;
	this->scale = scale;
}

Pose::Pose(const Pose &other) {
	this->orientation = other.orientation;
	this->position = other.position;
	this->scale = other.scale;
}

Pose& Pose::operator= (const Pose &other) {
	this->orientation = other.orientation;
	this->position = other.position;
	this->scale = other.scale;
	return *this;
}

Pose Pose::operator* (const Pose &other) const{
	return Combine(*this, other);
}

void Pose::Rotate(const quat & rot) {
	OBX_EXPORT_FN_OVERLOAD(Q);
	orientation = rot * orientation;
	// TODO: changed();
}

void Pose::Rotate(const vec3 & axis, float radians) {
	OBX_EXPORT_FN();
	Rotate(quat(glm::cos(radians / 2.0f), axis * glm::sin(radians / 2.0f)));
}

void Pose::RotateX(float radians) {
	OBX_EXPORT_FN();
	Rotate(vec3(1, 0, 0), radians);
}

void Pose::RotateY(float radians) {
	OBX_EXPORT_FN();
	Rotate(vec3(0, 1, 0), radians);
}

void Pose::RotateZ(float radians) {
	OBX_EXPORT_FN();
	Rotate(vec3(0, 0, 1), radians);
}

void Pose::Translate(const vec3 & trans) {
	OBX_EXPORT_FN();
//#pragma comment(linker, "/EXPORT:" __FUNCTION__ "=" __FUNCDNAME__ )
//#pragma comment(linker, "/EXPORT:" __FUNCTION__"=" __FUNCDNAME__)
#pragma message( "Compiling " __FILE__ )   
#pragma message( "Last modified on " __FUNCSIG__ )  
	position += trans;
	// TODO: changed();
}

#define OPENGL_FORWARD vec3( 0,  0, -1)
#define OPENGL_BACK    vec3( 0,  0,  1)
#define OPENGL_LEFT    vec3(-1,  0,  0)
#define OPENGL_RIGHT   vec3( 1,  0,  0)
#define OPENGL_UP      vec3( 0,  1,  0)
#define OPENGL_DOWN    vec3( 0, -1,  0)

vec3 Pose::GetForward() const {
	OBX_EXPORT_FN();
	return orientation * OPENGL_FORWARD;
}

vec3 Pose::GetBack() const {
	OBX_EXPORT_FN();
	return orientation * OPENGL_BACK;
}

vec3 Pose::GetLeft() const {
	OBX_EXPORT_FN();
	return orientation * OPENGL_LEFT;
}

vec3 Pose::GetRight() const {
	OBX_EXPORT_FN();
	return orientation * OPENGL_RIGHT;
}

vec3 Pose::GetUp() const {
	OBX_EXPORT_FN();
	return orientation * OPENGL_UP;
}

vec3 Pose::GetDown() const {
	OBX_EXPORT_FN();
	return orientation * OPENGL_DOWN;
}

void Pose::SetForward(vec3 forward) {
	OBX_EXPORT_FN();
	/*vec3 xyz = glm::cross(OPENGL_FORWARD, forward);
	float w = glm::length(forward) + glm::dot(OPENGL_FORWARD, forward);
	orientation = quat(w, xyz);*/
	SetForwardNormal(glm::normalize(forward));
}

void Pose::SetForwardNormal(vec3 forward) {
	OBX_EXPORT_FN();
	/*vec3 xyz = glm::cross(OPENGL_FORWARD, forward);
	float w = glm::dot(OPENGL_FORWARD, forward);
	orientation = quat(w, xyz);*/

	vec3 A = OPENGL_FORWARD;
	vec3 B = forward;
	vec3 C = glm::normalize(glm::cross(A, B));

	float c = glm::dot(A, B);
	float s = glm::length(glm::cross(A, B));

	//float theta = acos(glm::dot(A, B));
	float theta = atan2(s, c);

	orientation = quat(glm::cos(theta / 2.0f), C * glm::sin(theta / 2.0f));
}

mat3 Pose::ToMat3() const {
	OBX_EXPORT_FN();
	return glm::mat3_cast(orientation) * Diag3(scale);
}

mat4 Pose::ToMat4() const {
	OBX_EXPORT_FN();
	mat4 mat = glm::mat4_cast(orientation) * Diag4(scale);
	mat[3] = vec4(position, 1);
	return mat;
}

mat4 Pose::ToViewMat() const {
	OBX_EXPORT_FN();
	return glm::inverse(ToMat4());
}

Pose Pose::Combine(const Pose & parent, const Pose & child) {
	OBX_EXPORT_FN();
	Pose pose(
		parent.orientation * child.orientation,
		parent.orientation * (parent.scale * child.position) + parent.position,
		child.scale * parent.scale
	);

	return pose;
}

Pose Pose::Inverse(const Pose & pose) {
	OBX_EXPORT_FN();
	quat orientInv = glm::inverse(pose.orientation);
	Pose inv(
		orientInv, 
		orientInv * (1.0f / pose.scale * -pose.position),
		1.0f / pose.scale
	);

	return inv;
}

Pose Pose::LookAt(const vec3 & eye, const vec3 & at, const vec3 & up) {
	OBX_EXPORT_FN();
	/*vec3 zaxis = glm::normalize(at - eye);
	vec3 xaxis = glm::normalize(glm::cross(up, zaxis));
	vec3 yaxis = glm::cross(zaxis, xaxis);*/

	return Pose(glm::inverse(glm::lookAt(eye, at, up)));
}

} // namespace obx