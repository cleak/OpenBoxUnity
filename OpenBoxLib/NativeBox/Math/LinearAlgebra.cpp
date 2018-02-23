#include "LinearAlgebra.h"

namespace obx {

mat3 Diag3(const vec3 & v) {
    return mat3(
        v.x, 0, 0,
        0, v.y, 0,
        0, 0, v.z
    );
}

mat3 Diag3(float x1, float x2, float x3) {
    return Diag3(vec3(x1, x2, x3));
}

mat4 Diag4(const vec3 & v) {
    return Diag4(vec4(v, 1));
}

mat4 Diag4(float x1, float x2, float x3) {
    return Diag4(vec3(x1, x2, x3));
}

mat4 Diag4(const vec4 & v) {
    return mat4(
        v.x, 0, 0, 0,
        0, v.y, 0, 0,
        0, 0, v.z, 0,
        0, 0, 0, v.w
    );
}

mat4 Diag4(float x1, float x2, float x3, float x4) {
    return Diag4(vec4(x1, x2, x3, x4));
}

} // namespace obx