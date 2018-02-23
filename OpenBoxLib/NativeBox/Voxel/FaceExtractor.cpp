#include "FaceExtractor.h"

using namespace std;

namespace obx {

OBX_FORCEINLINE bool IsTransparent(ubvec4 voxel) {
	return voxel.w > 0 && voxel.w < 255;
}

OBX_FORCEINLINE void AddFaces(const VoxelSet<ubvec4, VoxelStoragePointer<ubvec4>>& voxels,
			  std::list<PointQuad>& opaqueFaces, std::list<PointQuad>& transparentFaces, ivec3 idx) {

	constexpr int kNumNormals = 6;

	ivec3 normals[kNumNormals] = {
		ivec3(1, 0, 0),
		ivec3(-1, 0, 0),

		ivec3(0, 1, 0),
		ivec3(0, -1, 0),

		ivec3(0, 0, 1),
		ivec3(0, 0, -1)
	};

	bool transparent = IsTransparent(voxels(idx));

	for (int i = 0; i < kNumNormals; ++i) {
		ivec3 normal = normals[i];
		ivec3 neighbor = idx + normal;

		if (voxels.IsValidIndex(neighbor) && voxels.IsSolid(neighbor)) {
			if (transparent && IsTransparent(voxels(neighbor))) {
				// Two transparent voxels - face is hidden.
				continue;
			}

			if (transparent && voxels(neighbor).w == 255) {
				// Transparent self and opaque neighbor - hidden to avoid z-fighting.
				continue;
			}

			if (!transparent && voxels(neighbor).w == 255) {
				// Two opaque voxels - face is hidden.
				continue;
			}
		}

		auto c = voxels(idx);
		PointQuad q;

		q.color = ubvec4(c.x, c.y, c.z, c.w);

		ivec3 pos = idx;

		if (Max(normal) > 0) {
			pos += normal;
		}

		q.pos = pos;
		q.faceIdx = i;

		if (transparent) {
			transparentFaces.push_back(q);
			q.faceIdx ^= 1;
			transparentFaces.push_back(q);
		} else {
			opaqueFaces.push_back(q);
		}
	}
}

void FaceExtractor::FindFaces(const VoxelSet<ubvec4, VoxelStoragePointer<ubvec4>>& voxels,
							  std::list<PointQuad>& opaqueFaces, std::list<PointQuad>& transparentFaces) {
	for (int z = 0; z < voxels.Size().z; ++z) {
		for (int y = 0; y < voxels.Size().y; ++y) {
			for (int x = 0; x < voxels.Size().x; ++x) {
				if (!voxels.IsSolid(x, y, z)) {
					// Empty voxel; skip.
					continue;
				}

				AddFaces(voxels, opaqueFaces, transparentFaces, ivec3(x, y, z));
			}
		}
	}
}

} // namespace obx