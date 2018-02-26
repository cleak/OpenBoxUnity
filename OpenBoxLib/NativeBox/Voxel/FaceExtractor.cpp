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

////////////////////////////////////////////////////////////////////////////////
// MagicaModel face extractor

constexpr int kNumMaterials = 0x100;

OBX_FORCEINLINE void AddFaces(const VoxelSet<uint8_t>& voxels, const array<ubvec4, kNumMaterials>& matColor,	
							  const array<bool, kNumMaterials>& matTransparent,
							  const array<bool, kNumMaterials>& matSolid,
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

	bool transparent = matTransparent[voxels(idx)];

	for (int i = 0; i < kNumNormals; ++i) {
		ivec3 normal = normals[i];
		ivec3 neighbor = idx + normal;

		if (voxels.IsValidIndex(neighbor) && matSolid[voxels(neighbor)]) {
			if (transparent || !matTransparent[voxels(neighbor)]) {
				continue;
			}
		}

		PointQuad q;
		q.color = matColor[voxels(idx)];

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

void FaceExtractor::FindFaces(const MagicaModel& model,
							  std::list<PointQuad>& opaqueFaces, std::list<PointQuad>& transparentFaces) {
	
	// Bake materials
	array<ubvec4, kNumMaterials> matColor;
	array<bool, kNumMaterials> matTransparent;
	array<bool, kNumMaterials> matSolid;

	for (int i = 0; i < kNumMaterials; ++i) {
		matColor[i] = model.Materials()[i].BakedColor();
		matSolid[i] = IsVoxelSolid<ubvec4>::IsSolid(matColor[i]);
		matTransparent[i] = IsTransparent(matColor[i]);
	}

	// Material 0 is defined as empty
	matSolid[0] = false;

	for (int z = 0; z < model.Size().z; ++z) {
		for (int y = 0; y < model.Size().y; ++y) {
			for (int x = 0; x < model.Size().x; ++x) {
				auto matIdx = model.ModelData()(x, y, z);
				if (!matSolid[matIdx]) {
					// Empty voxel; skip.
					continue;
				}

				AddFaces(model.ModelData(), matColor, matTransparent, matSolid,
						 opaqueFaces, transparentFaces, ivec3(x, y, z));
			}
		}
	}
}

} // namespace obx