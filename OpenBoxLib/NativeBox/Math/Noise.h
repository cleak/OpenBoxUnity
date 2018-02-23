#pragma once

#include "LinearAlgebra.h"

#include "../Util.h"

namespace obx {

class Noise {
private:

	OBX_FORCEINLINE static float IToF(uint32_t i) {
		return (float)(i / (double)(std::numeric_limits<uint32_t>::max()));
	}

public:
	OBX_FORCEINLINE static uint32_t Squirrel3(int position, uint32_t seed) {
		constexpr uint32_t kBitNoise1 = 0xB5297A4D;
		constexpr uint32_t kBitNoise2 = 0x68E31DA4;
		constexpr uint32_t kBitNoise3 = 0x1B56C4E9;

		uint32_t mangled = position;
		mangled *= kBitNoise1;
		mangled += seed;
		mangled ^= (mangled >> 8);
		mangled += kBitNoise2;
		mangled ^= (mangled << 8);
		mangled *= kBitNoise3;
		mangled ^= (mangled >> 8);

		return mangled;
	}

	// Integer noise
	OBX_FORCEINLINE static uint32_t At(int position, uint32_t seed = 0) {
		return Squirrel3(position, seed);
	}
	
	OBX_FORCEINLINE static uint32_t At(int x, int y, uint32_t seed) {
		constexpr uint32_t kPrime = 198491317;
		return At(x + kPrime * y, seed);
	}

	OBX_FORCEINLINE static uint32_t At(ivec2 v, uint32_t seed) {
		return At(v.x, v.y, seed);
	}

	OBX_FORCEINLINE static uint32_t At(int x, int y, int z, uint32_t seed) {
		constexpr uint32_t kPrime1 = 198491317;
		constexpr uint32_t kPrime2 = 6542989;
		return At(x + kPrime1 * y + kPrime2 * z, seed);
	}

	OBX_FORCEINLINE static uint32_t At(ivec3 v, uint32_t seed) {
		return At(v.x, v.y, v.z, seed);
	}

	OBX_FORCEINLINE static uint32_t At(int x, int y, int z, int w, uint32_t seed) {
		constexpr uint32_t kPrime1 = 198491317;
		constexpr uint32_t kPrime2 = 6542989;
		constexpr uint32_t kPrime3 = 37520929;
		return At(x + kPrime1 * y + kPrime2 * z + kPrime3 * w, seed);
	}

	OBX_FORCEINLINE static uint32_t At(ivec4 v, uint32_t seed) {
		return At(v.x, v.y, v.z, v.w, seed);
	}

	// Float noise [0 - 1]
	OBX_FORCEINLINE static float AtF(int position, uint32_t seed = 0) {
		return IToF(At(position, seed));
	}

	OBX_FORCEINLINE static float AtF(int x, int y, uint32_t seed) {
		return IToF(At(x, y, seed));
	}

	OBX_FORCEINLINE static float AtF(ivec2 v, uint32_t seed) {
		return IToF(At(v, seed));
	}

	OBX_FORCEINLINE static float AtF(int x, int y, int z, uint32_t seed) {
		return IToF(At(x, y, z, seed));
	}

	OBX_FORCEINLINE static float AtF(ivec3 v, uint32_t seed) {
		return IToF(At(v, seed));
	}

	OBX_FORCEINLINE static float AtF(int x, int y, int z, int w, uint32_t seed) {
		return IToF(At(x, y, z, w, seed));
	}

	OBX_FORCEINLINE static float AtF(ivec4 v, uint32_t seed) {
		return IToF(At(v, seed));
	}

	// Converts the float from a uniform [0,1] range to an exponential [0,1] range.
	OBX_FORCEINLINE static float ExpDist(float t) {
		OBX_ASSERT(t >= 0);
		OBX_ASSERT(t <= 1);
		//constexpr float kExpBase = 1.0f / 64.0f;
		//constexpr float kExpBase = 1.0f / 4.0f;
		//constexpr float kExpBase = 1.0f / 32.0f;
		//constexpr float kExpBase = 1.0f / 16.0f;
		constexpr float kExpBase = 1.0f / 8.0f;
		constexpr float kExpComp = 1.0f - kExpBase;
		return (std::powf(kExpBase, 1.0f - t) - kExpBase) / kExpComp;
	}
};

float SCurve(float t);

float Lerp(float t, float a, float b);

class PerlinNoise {
private:

	int octaves;
	uint32_t seed;
	float amplitude;
	float maxAmp;
	float frequency;
	bool useExp;

	float Evaluate(vec2 rawPos, float frequency, int octave);
	float Evaluate2D(vec2 rawPos, int z, float frequency, int octave);
	float Evaluate3D(vec3 rawPos, float frequency, int octave);

public:

	PerlinNoise(int octaves, uint32_t seed, float amplitude, float frequency, bool useExp=true);

	float At(vec2 pos);
	float At(vec3 pos);

	uint32_t GetSeed() const { return seed; }
	int GetNumOctaves() const { return octaves; }
	float GetFrequency() const { return frequency; }
	float GetAmplitude() const { return amplitude; }
	float GetMaxAmplitude() const { return maxAmp; }
};

} // namespace obx
