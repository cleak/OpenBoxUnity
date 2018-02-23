#pragma once

#include "../Util.h"

#define OBX_COMPWISE(fnName, numType) \
OBX_FORCEINLINE auto fnName(const glm::tvec2<numType>& vec) { \
	return glm::tvec2<numType>(\
		fnName(vec.x), \
		fnName(vec.y)  \
	);\
}\
\
OBX_FORCEINLINE auto fnName(const glm::tvec3<numType>& vec) { \
	return glm::tvec3<numType>(\
		fnName(vec.x), \
		fnName(vec.y), \
		fnName(vec.z)  \
	);\
}\
\
OBX_FORCEINLINE auto fnName(const glm::tvec4<numType>& vec) { \
	return glm::tvec4<numType>(\
		fnName(vec.x), \
		fnName(vec.y), \
		fnName(vec.z), \
		fnName(vec.w)  \
	);\
}\
\

#define OBX_COMPWISE_ALLINT(fnName) \
OBX_COMPWISE(fnName, int) \
OBX_COMPWISE(fnName, unsigned int) \
OBX_COMPWISE(fnName, size_t) \

#define OBX_COMPWISE_2

namespace obx {

OBX_FORCEINLINE bool IsPow2(size_t x) {
	return (x != 0) && ((x & (x - 1)) == 0);
}

OBX_FORCEINLINE bool IsPow2(unsigned int x) {
	return (x != 0) && ((x & (x - 1)) == 0);
}

OBX_FORCEINLINE bool IsPow2(int x) {
	return (x != 0) && ((x & (x - 1)) == 0);
}

OBX_FORCEINLINE unsigned int Log2(unsigned int x) {
	unsigned int logVal = 0;
	while (x > 1) {
		x >>= 1;
		logVal++;
	}
	return logVal;
}

OBX_FORCEINLINE int Log2(int x) {
	int logVal = 0;
	while (x > 1) {
		x >>= 1;
		logVal++;
	}
	return logVal;
}

OBX_FORCEINLINE size_t Log2(size_t x) {
	size_t logVal = 0;
	while (x > 1) {
		x >>= 1;
		logVal++;
	}
	return logVal;
}

/*OBX_COMPWISE(Log2, int);
OBX_COMPWISE(Log2, unsigned int);
OBX_COMPWISE(Log2, size_t);*/

OBX_COMPWISE_ALLINT(Log2);

};