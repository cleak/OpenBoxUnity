#pragma once

#include <array>
#include <exception>
#include <string>

#include "VoxelSet.h"
#include "../Util.h"

namespace obx {

// Container for a single Magica material.
struct MagicaMaterial {
	enum class Type : uint32_t {
		Diffuse = 0,
		Metal = 1,
		Glass = 2,
		Emissive = 3
	};

	Type baseType;

	float diffuse;
	float metal;
	float glass;
	float emissive;

	ubvec4 color;

	// TODO: Additional properties here

	OBX_FORCEINLINE float GetAlpha() const {
		if (baseType != Type::Glass) {
			return 1.0f;
		}

		return 1.0f - glass;
	}

	OBX_FORCEINLINE ubvec4 BakedColor() const {
		ubvec4 c = color;

		if (baseType == Type::Glass) {
			c.a = (uint8_t)(255 * GetAlpha() + 0.5f);
		} else {
			c.a = 255;
		}

		return c;
	}
};

class MagicaException : public obx::Exception {
public:
	MagicaException(const std::string& message) : obx::Exception(message) {}
};

class MagicaLoader;

// Container for a single Magica model.
class MagicaModel : DoNotCopy {
private:

	UniPtr<VoxelSet<uint8_t>> modelData;
	std::array<MagicaMaterial, 0x100> materials;
	MagicaModel(ivec3 size);

	friend class ::obx::MagicaLoader;

public:

	MagicaModel(const std::string& filepath);
	void Load(const std::string& filepath);
	void Save(const std::string& filepath) const;

	// Trims empty space surrounding the filled voxels.
	void TrimEmptySpace();

	OBX_FORCEINLINE auto Size() const { return modelData->Size(); }

	OBX_FORCEINLINE const auto& MaterialAt(ivec3 idx) const { return materials[modelData->At(idx)]; }
	OBX_FORCEINLINE const auto& At(ivec3 idx) const { return modelData->At(idx); }

	OBX_FORCEINLINE auto& Materials() { return materials; }
	OBX_FORCEINLINE const auto& Materials() const { return materials; }

	OBX_FORCEINLINE auto& ModelData() { return *modelData; }
	OBX_FORCEINLINE const auto& ModelData() const { return *modelData; }

	UniPtr<VoxelSet<ubvec4>> ToColoredVoxels() const {
		UniPtr<VoxelSet<ubvec4>> voxels = std::make_unique<VoxelSet<ubvec4>>(modelData->Size());
		FillColoredVoxels(*voxels);
		return voxels;
	}

	template <typename T, typename U, typename V>
	void FillColoredVoxels(VoxelSet<ubvec4, T, U, V>& dest) const {

		modelData->ApplyIndexed([&, this](uint8_t matIdx, int x, int y, int z) {
			if (matIdx == 0) {
				dest(x, y, z) = ubvec4(0);
			} else {
				dest(x, y, z) = materials[matIdx].BakedColor();
			}
		});
	}

	// TODO: Direct export to quads (defer assigning colors to last step)
};

} // namespace obx
