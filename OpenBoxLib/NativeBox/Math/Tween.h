#pragma once

#include "../core/World.h"
#include "LinearAlgebra.h"

namespace obx {

enum class TweenType : uint32_t {
	Linear,
	Cosine,
	SmoothStep
};

template <typename T>
class Tween {
private:

	T startVal;
	T endVal;

	double startTime;
	double endTime;

	TweenType tweenType = TweenType::Linear;

public:

	TweenType GetType() const {
		return tweenType;
	}

	void SetType(TweenType type) {
		tweenType = type;
	}

	void Set(const T& startVal, const T& endVal, double startTime, double endTime) {
		this->startVal = startVal;
		this->endVal = endVal;
		this->startTime = startTime;
		this->endTime = endTime;
	}

	T Current() const {
		return At((World::TotalTime() - startTime) / (endTime - startTime));
	}

	T At(float t) const {
		float clamped = glm::clamp(t, 0.0f, 1.0f);
		
		switch (tweenType) {
		case TweenType::Linear:
			break;

		case TweenType::Cosine:
			clamped = cosf(clamped * glm::pi<float>()) * (-0.5f) + 0.5f;
			break;

		case TweenType::SmoothStep:
			clamped = SCurve(clamped);
			break;

		default:
			OBX_FAIL("Unknown tween type");
		}

		return glm::mix(startVal, endVal, clamped);
	}

	T GetStart() const {
		return startVal;
	}

	void SetStart(const T& val) {
		startVal = val;
	}

	T GetEnd() const {
		return endVal;
	}

	void SetEnd(const T& val) {
		endVal = val;
	}
	
	double GetStartTime() const {
		return startTime;
	}

	void SetStartTime(double time) {
		startTime = time;
	}

	double GetEndTime() const {
		return endTime;
	}

	void SetEndTime(double time) {
		endTime = time;
	}
};

} // namespace obx
