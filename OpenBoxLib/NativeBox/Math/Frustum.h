#pragma once

#include <vector>

#include "LinearAlgebra.h"

namespace obx {

struct Frustum {
	std::vector<vec4> planes;
};

} // namespace obx
