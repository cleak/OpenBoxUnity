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

	float GetAlpha() {
		if (baseType != Type::Glass) {
			return 1.0f;
		}

		return 1.0f - glass;
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

	OBX_FORCEINLINE const auto& MaterialAt(ivec3 idx) const { return materials[modelData->At(idx)]; }
	OBX_FORCEINLINE const auto& At(ivec3 idx) const { return modelData->At(idx); }

	OBX_FORCEINLINE auto& Materials() { return materials; }
	OBX_FORCEINLINE const auto& Materials() const { return materials; }

	OBX_FORCEINLINE auto& ModelData() { return *modelData; }
	OBX_FORCEINLINE const auto& ModelData() const { return *modelData; }

	UniPtr<VoxelSet<ubvec4>> ToColoredVoxels() const;

	// TODO: Direct export to quads (defer assigning colors to last step)
};

} // namespace obx
