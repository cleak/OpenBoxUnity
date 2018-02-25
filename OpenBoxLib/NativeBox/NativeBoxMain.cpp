#include <iostream>
#include <string>

#include "Math.h"
#include "Voxel.h"

using namespace std;
using namespace obx;

#define OBX_EXPORT_DLL extern "C" __declspec(dllexport)

OBX_EXPORT_DLL void __stdcall HandleStr(char* str) {
	cout << str << endl;
}

struct Faces {
	list<PointQuad> faces;
};

#pragma pack(push, 1)
struct PointQuadList {
	int count;
	Faces* handle;
};
#pragma pack(pop)

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
