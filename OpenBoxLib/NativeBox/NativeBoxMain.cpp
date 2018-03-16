#include <iostream>
#include <string>

#include "Math.h"
#include "Voxel.h"

using namespace std;
using namespace obx;

#define OBX_EXPORT_DLL __declspec(dllexport)

OBX_EXPORT_DLL void __stdcall HandleStr(char* str) {
	cout << str << endl;
}

struct Faces {
	list<PointQuad> faces;
};

enum MagicaLoadFlags : uint32_t {
	Trim = 0x01
};

#pragma pack(push, 1)
struct PointQuadList {
	int32_t count;
	Faces* handle;
};
#pragma pack(pop)

// Disable warnings about returning non-C types

extern "C" {
#pragma warning(push)
#pragma warning(disable: 4190)

////////////////////////////////////////////////////////////////////////////////
// MagicaVoxel functions

OBX_EXPORT_DLL MagicaModel* __stdcall obx_MagicaLoadModel(char* filename, MagicaLoadFlags flags) {
	auto model = new MagicaModel(filename);
	if (flags & MagicaLoadFlags::Trim) {
		model->TrimEmptySpace();
	}
	return model;
}

OBX_EXPORT_DLL ivec3 __stdcall obx_MagicaModelSize(MagicaModel* model) {
	return model->Size();
}

OBX_EXPORT_DLL void __stdcall obx_MagicaCopyVoxels(ubvec4* destVoxels, MagicaModel* srcModel) {
	auto wrappedVoxels = WrapVoxelSet<ubvec4>(srcModel->Size(), destVoxels);
	srcModel->FillColoredVoxels(wrappedVoxels);
}

OBX_EXPORT_DLL void __stdcall obx_MagicaFreeModel(MagicaModel* model) {
	delete model;
}

OBX_EXPORT_DLL void __stdcall obx_MagicaExtractFaces(MagicaModel* model, PointQuadList* opaqueFaces,
													 PointQuadList* transparentFaces) {
	opaqueFaces->handle = new Faces;
	transparentFaces->handle = new Faces;

	FaceExtractor::FindFaces(*model, opaqueFaces->handle->faces, transparentFaces->handle->faces);
	opaqueFaces->count = (int)opaqueFaces->handle->faces.size();
	transparentFaces->count = (int)transparentFaces->handle->faces.size();
}

////////////////////////////////////////////////////////////////////////////////
// Misc functions

OBX_EXPORT_DLL void __stdcall obx_ExtractFaces(ubvec4* colors, ivec3 size, PointQuadList* opaqueFaces, PointQuadList* transparentFaces) {
	VoxelSet<ubvec4, VoxelStoragePointer<ubvec4>> voxels(size);
	voxels.Voxels = colors;

	opaqueFaces->handle = new Faces;
	transparentFaces->handle = new Faces;

	FaceExtractor::FindFaces(voxels, opaqueFaces->handle->faces, transparentFaces->handle->faces);
	opaqueFaces->count = (int)opaqueFaces->handle->faces.size();
	transparentFaces->count = (int)transparentFaces->handle->faces.size();
}

OBX_EXPORT_DLL void __stdcall obx_CopyFaceGeometry(Faces* faces, vec3* points, vec2* faceIndices, ubvec4* colors) {
	int idx = 0;
	for (auto f : faces->faces) {
		points[idx] = f.pos;
		faceIndices[idx] = vec2(f.faceIdx, 0);
		colors[idx] = f.color;

		++idx;
	}
}

OBX_EXPORT_DLL void __stdcall obx_FreeFacesHandle(Faces* faces) {
	delete faces;
}

#pragma warning(pop)
} // extern "C"