#include "Noise.h"

namespace obx {

float SCurve(float t) {
	if (t < 0) {
		return 0;
	}

	if (t > 1) {
		return 1;
	}

	return t * t * (3 - 2 * t);
}

float Lerp(float t, float a, float b) {
	OBX_ASSERT(t >= 0);
	OBX_ASSERT(t <= 1);
	return a + t * (b - a);
}

PerlinNoise::PerlinNoise(int octaves, uint32_t seed, float amplitude, float frequency, bool useExp)
	: octaves(octaves), seed(seed), amplitude(amplitude), frequency(frequency), useExp(useExp)
{
	// Find max amplitude
	float a = amplitude;
	maxAmp = 0;
	for (int i = 0; i < octaves; ++i) {
		maxAmp += a;
		a /= 2;
	}
}

float ExpRandI(ivec2 pos, uint32_t seed) {
	return Noise::ExpDist(Noise::AtF(pos, seed));
}

float ExpRandF(vec2 rawPos, uint32_t seed) {
	ivec2 p = glm::floor(rawPos);
	vec2 tPos = rawPos- vec2(p);

	vec2 sPos = vec2(SCurve(tPos.x), SCurve(tPos.y));
	vec2 ab;

	for (int y = 0; y < 2; ++y) {
		vec2 uv;
		for (int x = 0; x < 2; ++x) {
			ivec2 corner = p + ivec2(x, y);
			float h1 = ExpRandI(corner, seed);
			uv[x] = h1;
			OBX_ASSERT(uv[x] >= 0);
		}

		ab[y] = Lerp(sPos.x, uv[0], uv[1]);
	}

	return Lerp(sPos.y, ab[0], ab[1]);
}

float PerlinNoise::At(vec2 pos) {
	float f = frequency;
	float a = 1.0f;

	float total = 0;
	for (int i = 0; i < octaves; ++i) {
		total += Evaluate(pos, f, i) * a;
		f *= 2;
		a /= 2;
	}

	ivec2 expPos = ivec2(glm::floor(pos * frequency));
	return (total / maxAmp) * amplitude;
}

float PerlinNoise::At(vec3 pos) {
	float f = frequency;
	float a = 1.0f;

	float total = 0;
	for (int i = 0; i < octaves; ++i) {
		total += Evaluate3D(pos, f, i) * a;
		f *= 2;
		a /= 2;
	}

	ivec2 expPos = ivec2(glm::floor(pos * frequency));
	return (total / maxAmp) * amplitude;
}

float PerlinNoise::Evaluate(vec2 rawPos, float frequency, int octave) {
	return Evaluate2D(rawPos, 0, frequency, octave);
}

float PerlinNoise::Evaluate2D(vec2 rawPos, int z, float frequency, int octave) {
	ivec2 p = glm::floor(rawPos * frequency);
	vec2 tPos = rawPos * frequency - vec2(p);

	vec2 sPos = vec2(SCurve(tPos.x), SCurve(tPos.y));

	vec2 ab;
	for (int y = 0; y < 2; ++y) {
		vec2 uv;
		for (int x = 0; x < 2; ++x) {
			ivec2 corner = p + ivec2(x, y);
			float h1 = Noise::AtF(corner.x, corner.y, z, octave * 2, seed);
			float hExp;
			if (useExp) {
				hExp = Noise::ExpDist(Noise::AtF(corner.x, corner.y, z, octave * 2 + 1, seed));
			} else {
				hExp = 1.0f;
			}

			uv[x] = h1 * hExp;
		}

		ab[y] = Lerp(sPos.x, uv[0], uv[1]);
	}

	return Lerp(sPos.y, ab[0], ab[1]);
}

float PerlinNoise::Evaluate3D(vec3 rawPos, float frequency, int octave) {
	int pZ = (int)glm::floor(rawPos.z * frequency);
	float tPosZ = rawPos.z * frequency - pZ;

	float sPosZ = SCurve(tPosZ);

	return Lerp(
		sPosZ,
		Evaluate2D(vec2(rawPos), pZ, frequency, octave),
		Evaluate2D(vec2(rawPos), pZ + 1, frequency, octave)
	);
}

} // namespace obx
