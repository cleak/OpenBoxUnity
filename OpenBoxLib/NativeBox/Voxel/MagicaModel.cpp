#include "MagicaModel.h"

#include "../IO.h"

#include <map>

using namespace std;

namespace obx {

static const string kHeader = "VOX ";
static const string kChunkMain = "MAIN";
static const string kChunkPack = "PACK";
static const string kChunkSize = "SIZE";
static const string kChunkXyzi = "XYZI";
static const string kChunkRgba = "RGBA";
static const string kChunkMatt = "MATT";
static const string kChunkMatl = "MATL";  // New material format from 0.99 onwards

static const uint32_t kDefaultPalette[256] = {
	0x00000000, 0xffffffff, 0xffccffff, 0xff99ffff, 0xff66ffff, 0xff33ffff, 0xff00ffff, 0xffffccff, 0xffccccff, 0xff99ccff, 0xff66ccff, 0xff33ccff, 0xff00ccff, 0xffff99ff, 0xffcc99ff, 0xff9999ff,
	0xff6699ff, 0xff3399ff, 0xff0099ff, 0xffff66ff, 0xffcc66ff, 0xff9966ff, 0xff6666ff, 0xff3366ff, 0xff0066ff, 0xffff33ff, 0xffcc33ff, 0xff9933ff, 0xff6633ff, 0xff3333ff, 0xff0033ff, 0xffff00ff,
	0xffcc00ff, 0xff9900ff, 0xff6600ff, 0xff3300ff, 0xff0000ff, 0xffffffcc, 0xffccffcc, 0xff99ffcc, 0xff66ffcc, 0xff33ffcc, 0xff00ffcc, 0xffffcccc, 0xffcccccc, 0xff99cccc, 0xff66cccc, 0xff33cccc,
	0xff00cccc, 0xffff99cc, 0xffcc99cc, 0xff9999cc, 0xff6699cc, 0xff3399cc, 0xff0099cc, 0xffff66cc, 0xffcc66cc, 0xff9966cc, 0xff6666cc, 0xff3366cc, 0xff0066cc, 0xffff33cc, 0xffcc33cc, 0xff9933cc,
	0xff6633cc, 0xff3333cc, 0xff0033cc, 0xffff00cc, 0xffcc00cc, 0xff9900cc, 0xff6600cc, 0xff3300cc, 0xff0000cc, 0xffffff99, 0xffccff99, 0xff99ff99, 0xff66ff99, 0xff33ff99, 0xff00ff99, 0xffffcc99,
	0xffcccc99, 0xff99cc99, 0xff66cc99, 0xff33cc99, 0xff00cc99, 0xffff9999, 0xffcc9999, 0xff999999, 0xff669999, 0xff339999, 0xff009999, 0xffff6699, 0xffcc6699, 0xff996699, 0xff666699, 0xff336699,
	0xff006699, 0xffff3399, 0xffcc3399, 0xff993399, 0xff663399, 0xff333399, 0xff003399, 0xffff0099, 0xffcc0099, 0xff990099, 0xff660099, 0xff330099, 0xff000099, 0xffffff66, 0xffccff66, 0xff99ff66,
	0xff66ff66, 0xff33ff66, 0xff00ff66, 0xffffcc66, 0xffcccc66, 0xff99cc66, 0xff66cc66, 0xff33cc66, 0xff00cc66, 0xffff9966, 0xffcc9966, 0xff999966, 0xff669966, 0xff339966, 0xff009966, 0xffff6666,
	0xffcc6666, 0xff996666, 0xff666666, 0xff336666, 0xff006666, 0xffff3366, 0xffcc3366, 0xff993366, 0xff663366, 0xff333366, 0xff003366, 0xffff0066, 0xffcc0066, 0xff990066, 0xff660066, 0xff330066,
	0xff000066, 0xffffff33, 0xffccff33, 0xff99ff33, 0xff66ff33, 0xff33ff33, 0xff00ff33, 0xffffcc33, 0xffcccc33, 0xff99cc33, 0xff66cc33, 0xff33cc33, 0xff00cc33, 0xffff9933, 0xffcc9933, 0xff999933,
	0xff669933, 0xff339933, 0xff009933, 0xffff6633, 0xffcc6633, 0xff996633, 0xff666633, 0xff336633, 0xff006633, 0xffff3333, 0xffcc3333, 0xff993333, 0xff663333, 0xff333333, 0xff003333, 0xffff0033,
	0xffcc0033, 0xff990033, 0xff660033, 0xff330033, 0xff000033, 0xffffff00, 0xffccff00, 0xff99ff00, 0xff66ff00, 0xff33ff00, 0xff00ff00, 0xffffcc00, 0xffcccc00, 0xff99cc00, 0xff66cc00, 0xff33cc00,
	0xff00cc00, 0xffff9900, 0xffcc9900, 0xff999900, 0xff669900, 0xff339900, 0xff009900, 0xffff6600, 0xffcc6600, 0xff996600, 0xff666600, 0xff336600, 0xff006600, 0xffff3300, 0xffcc3300, 0xff993300,
	0xff663300, 0xff333300, 0xff003300, 0xffff0000, 0xffcc0000, 0xff990000, 0xff660000, 0xff330000, 0xff0000ee, 0xff0000dd, 0xff0000bb, 0xff0000aa, 0xff000088, 0xff000077, 0xff000055, 0xff000044,
	0xff000022, 0xff000011, 0xff00ee00, 0xff00dd00, 0xff00bb00, 0xff00aa00, 0xff008800, 0xff007700, 0xff005500, 0xff004400, 0xff002200, 0xff001100, 0xffee0000, 0xffdd0000, 0xffbb0000, 0xffaa0000,
	0xff880000, 0xff770000, 0xff550000, 0xff440000, 0xff220000, 0xff110000, 0xffeeeeee, 0xffdddddd, 0xffbbbbbb, 0xffaaaaaa, 0xff888888, 0xff777777, 0xff555555, 0xff444444, 0xff222222, 0xff111111
};

static const int kVersion = 150;

class MagicaLoader : DoNotCopy {
public:

	ByteBuffer stream;
	vector<UniPtr<MagicaModel>> models;
	int modelIdx;

	struct Chunk {
		string chunkId;
		int numBytes;
		int numChildBytes;

		string ToString() {
			return chunkId + " " + to_string(numBytes) + " " + to_string(numChildBytes);
		}
	};

	// Loads a model, consistenting of the given size chunk and an index chunk.
	UniPtr<MagicaModel> LoadModel(Chunk sizeChunk) {
		if (sizeChunk.chunkId != kChunkSize) {
			throw MagicaException("Bad size chunk");
		}

		// TODO: This seems to load models rotated 180 degrees
		ivec3 size = stream.Read<ivec3>();
		std::swap(size.y, size.z);

		UniPtr<MagicaModel> model;
		model.reset(new MagicaModel(size));

		Chunk idxChunk = ReadChunk();
		if (idxChunk.chunkId != kChunkXyzi) {
			throw MagicaException("Bad index chunk");
		}

		// Read individual voxels
		int numVoxels = stream.Read<int32_t>();
		for (int j = 0; j < numVoxels; ++j) {
			ivec3 idx = stream.Read<ubvec3>();

			// Change from Z-up to Y-up
			std::swap(idx.y, idx.z);

			model->ModelData().At(idx) = stream.Read();
		}

		return model;
	}

	// Replaces the current palette with palette in the given chunk.
	void LoadPaletteChunk(Chunk palChunk) {
		if (palChunk.chunkId != kChunkRgba) {
			throw MagicaException("Bad palette chunk");
		}

		if (modelIdx < 0) {
			throw MagicaException("Unexpected palette chunk location");
		}

		for (int i = 0; i < 255; ++i) {
			models[0]->Materials()[i + 1].color = stream.Read<ubvec4>();
		}

		// Discard unused color
		stream.Read<ubvec4>();
	}

	static int CountBits(int bits) {
		int total = 0;
		while (bits > 0) {
			total += (bits & 1);
			bits >>= 1;
		}

		return total;
	}

	// Loads a material using the old material format.
	void LoadOldMaterial(Chunk matChunk) {
		if (matChunk.chunkId != kChunkMatt) {
			throw MagicaException("Bad material chunk");
		}

		if (modelIdx < 0) {
			throw MagicaException("Unexpected MATT chunk location");
		}

		int id = stream.Read<int32_t>();
		MagicaMaterial& m = models[0]->Materials()[id];
			
		m.baseType = (MagicaMaterial::Type)stream.Read<int32_t>();
		float weight = stream.Read<float>();
		int propertyBits = stream.Read<int32_t>();
		//int propValueCount = CountBits(propertyBits & 0x7);
		int propValueCount = CountBits(propertyBits);

		switch (m.baseType) {
		case MagicaMaterial::Type::Diffuse:
			m.diffuse = weight;
			break;

		case MagicaMaterial::Type::Emissive:
			m.emissive = weight;
			break;

		case MagicaMaterial::Type::Glass:
			m.glass = weight;
			break;

		case MagicaMaterial::Type::Metal:
			m.metal = weight;
			break;
		}

		// Skip property values
		for (int i = 0; i < propValueCount; ++i) {
			// Ignore property value
			stream.Read<float>();
		}
	}

	// Loads a material using the new material format.
	void LoadNewMaterial(Chunk matChunk) {
		int id = stream.Read<int32_t>();
		MagicaMaterial& m = models[0]->Materials()[id];
		
		int numProps = stream.Read<int32_t>();

		string type = "";
		map<string, float> props;
		for (int i = 0; i < numProps; ++i) {
			string propName = stream.ReadString(false);
			string valueStr = stream.ReadString(false);

			if (propName == "_type") {
				type = valueStr;
				continue;
			}

			float value = stof(valueStr);
			props[propName] = value;
		}

		if (type == "_glass") {
			m.glass = props["_weight"];
			m.baseType = MagicaMaterial::Type::Glass;
		}

		// TODO: Handle other material types
	}

	MagicaLoader(const string& filepath)
		: stream(File::Load(filepath))
	{
		/////////////////
		// TODO: Default palette

		// Read header
		if (stream.ReadFixedString(4) != kHeader) {
			throw MagicaException("Bad header");
		}

		if (stream.Read<int32_t>() != kVersion) {
			throw MagicaException("Bad version");
		}

		// Main chunk
		Chunk mainChunk = ReadChunk();
		if (mainChunk.chunkId != kChunkMain) {
			throw MagicaException("Bad main chunk ID");
		}

		// (Optional) Read pack chunk
		int numModels = 1;
		if (stream.Peek() == 'P') {
			Chunk packChunk = ReadChunk();
			if (packChunk.chunkId != kChunkPack) {
				throw MagicaException("Bad pack chunk");
			}

			numModels = stream.Read<int32_t>();
		}

		models.resize(numModels);
		modelIdx = -1;

		// Read all remaining chunks
		while (!stream.Eof()) {
			Chunk chunk = ReadChunk();

			if (chunk.chunkId == kChunkSize) {
				modelIdx++;
				if (modelIdx >= numModels) {
					throw MagicaException("Too many models in file");
				}

				models[modelIdx] = LoadModel(chunk);
                continue;
			}

			if (chunk.chunkId == kChunkRgba) {
				LoadPaletteChunk(chunk);
                continue;
            }

			if (chunk.chunkId == kChunkMatt) {
				LoadOldMaterial(chunk);
                continue;
            }

			if (chunk.chunkId == kChunkMatl) {
				LoadNewMaterial(chunk);
                continue;
            }

            stream.SetLocation(stream.GetLocation() + chunk.numBytes);
		}

		if (modelIdx + 1 != numModels || numModels == 0) {
			throw MagicaException("Too few models in file");
		}

		// TODO: Verify all models have been written to
	}

	Chunk ReadChunk() {
		Chunk chunk;
		chunk.chunkId = stream.ReadFixedString(4);
		chunk.numBytes = stream.Read<int32_t>();
		chunk.numChildBytes = stream.Read<int32_t>();

		return chunk;
	}
};

MagicaModel::MagicaModel(ivec3 size) 
	: modelData(std::make_unique<VoxelSet<uint8_t>>(size))
{
	modelData->Set(0);

	// Default palette
	for (int i = 0; i < materials.size(); ++i) {
		materials[i].baseType = MagicaMaterial::Type::Diffuse;
		
		materials[i].diffuse = 1.0f;
		materials[i].metal = 0.0f;
		materials[i].glass = 0.0f;
		materials[i].emissive = 0.0f;

		materials[i].color = *((ubvec4*)&kDefaultPalette[i]);
	}
}

MagicaModel::MagicaModel(const std::string & filepath) {
	Load(filepath);
}

void MagicaModel::Load(const std::string & filepath) {
	MagicaLoader loader(filepath);
	modelData = std::move(loader.models[0]->modelData);
	materials = std::move(loader.models[0]->materials);
}

void MagicaModel::Save(const std::string & filepath) const {
	OBX_FAIL("Not implemented yet");
}

void MagicaModel::TrimEmptySpace() {
	ivec3 minSolid = modelData->Size();
	ivec3 maxSolid(0);

	modelData->ApplyIndexed([&](uint8_t v, int x, int y, int z) {
		if (v == 0) {
			// Ignore empty voxels
			return;
		}

		minSolid = glm::min(minSolid, ivec3(x, y, z));
		maxSolid = glm::max(maxSolid, ivec3(x, y, z));
	});

	modelData = modelData->Slice(minSolid, maxSolid).Clone();
}

} // namespace obx
