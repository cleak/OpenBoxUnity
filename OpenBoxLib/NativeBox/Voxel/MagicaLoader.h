#pragma once

#include "../Util.h"
#include "../Math.h"
#include "../Voxel.h"

#include <array>
#include <deque>
#include <string>

namespace obx {

class MagicaLoader {
private:

	size_t dataSize;
	size_t idx;
	uint8_t* data;

	uint32_t GetInt();
	uint32_t GetChunkId();
	uint8_t GetByte();
	bool HasMore();

	void ParseMain();
	void ParseRgba();
	void ParseMatt();

	std::string ToPrettyName(uint32_t v);

	std::array<ubvec4, 256> colors;

	std::deque<UniPtr<VoxelSet<ubvec4>>> models;

	void FillColor(VoxelSet<int> modelIndexed);

public:

	MagicaLoader(const std::string& filename);

	static const uint32_t kHeader = 'VOX ';

	static const uint32_t kChunkMain = 'MAIN';
	static const uint32_t kChunkPack = 'PACK';
	static const uint32_t kChunkSize = 'SIZE';
	static const uint32_t kChunkXyzi = 'XYZI';
	static const uint32_t kChunkRgba = 'RGBA';
	static const uint32_t kChunkMatt = 'MATT';

#pragma pack(push, 1)
	struct Chunk {
		uint32_t chunkId;
		uint32_t numContentBytes;
		uint32_t numChildBytes;

		uint8_t* contentBytes;
		uint8_t* childBytes;
	};

	struct Pack {
		uint32_t numModels;
	};

	struct Size {
		uint32_t sizeX;
		uint32_t sizeY;
		uint32_t sizeZ; // up direction
	};

	struct Xyzi {
		uint8_t x;
		uint8_t y;
		uint8_t z;
		uint8_t i;
	};

	struct XyziChunk {
		uint32_t numVoxels;
		Xyzi* xyzis;
	};

	struct Rgba {
		uint8_t r;
		uint8_t g;
		uint8_t b;
		uint8_t a;
	};

	struct RgbaChunk {
		Rgba* colors;
	};
#pragma pack(pop)

	VoxelSet<ubvec4>* GetModel(size_t idx) const { return models[idx].get(); }
	size_t GetNumModels() const { return models.size(); }

private:

	Chunk GetChunk();
	void ParseXyzi(VoxelSet<int>& voxels, Chunk& chunk);

};

} // namespace obx