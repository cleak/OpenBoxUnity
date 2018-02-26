#pragma once

#include <list>

#include "VoxelSet.h"
#include "MagicaModel.h"

namespace obx {

#pragma pack(push, 1)
struct PointQuad {
	uint8_t faceIdx;

	ubvec3 pos;

	ubvec4 color;
};
#pragma pack(pop)

class FaceExtractor {
public:

	static void FindFaces(const VoxelSet<ubvec4, VoxelStoragePointer<ubvec4>>& voxels,
						  std::list<PointQuad>& opaqueFaces, std::list<PointQuad>& transparentFaces);

	static void FindFaces(const MagicaModel& model,
						  std::list<PointQuad>& opaqueFaces, std::list<PointQuad>& transparentFaces);
};

} // namespace obx