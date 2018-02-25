#pragma once

#include <vector>

#include "../Util.h"

namespace obx {

class ByteBuffer : DoNotCopy {
private:

	std::vector<uint8_t> bytes;
	size_t location;

public:

	ByteBuffer();
	ByteBuffer(const Blob& blob);

	std::vector<uint8_t>& ByteVector() { return bytes; }
	const std::vector<uint8_t>& ByteVector() const { return bytes; }

	uint8_t& operator[](size_t idx) { return bytes[idx]; }
	const uint8_t& operator[](size_t idx) const { return bytes[idx]; }

	void Write(uint8_t byte);
	void Write(const void* data, size_t byteCount);

	size_t GetLocation() const { return location; }
	void SetLocation(size_t location) { this->location = location; }

	size_t Size() const { return bytes.size(); }

	uint8_t Read();
	uint8_t Peek() const;

	bool Eof() const;

	void WriteString(const std::string& str, bool wordAlign = true, bool preamble = true);

	// Writes a fixed size string. Pads up to numChars.
	void WriteFixedString(const std::string& str, size_t numChars);

	bool CopyTo(void* destination, size_t count);
	
	std::string ReadString(bool wordAlign = true);

	std::string ReadFixedString(size_t numChars);

	template <typename T>
	OBX_FORCEINLINE void Write(const T& val) {
		static_assert(std::is_trivially_copyable<T>::value, "Only trivially copyable types allowed");
		Write(&val, sizeof(T));
	}

	template <typename T>
	OBX_FORCEINLINE void WriteVector(const std::vector<T>& vec) {
		static_assert(std::is_trivially_copyable<T>::value, "Only trivially copyable types allowed");
		Write(&vec[0], sizeof(T) * vec.size());
	}

	template <typename T>
	OBX_FORCEINLINE T Read() {
		static_assert(std::is_trivially_copyable<T>::value, "Only trivially copyable types allowed");
		T t;
		CopyTo(&t, sizeof(T));
		return t;
	}

	template <typename T>
	OBX_FORCEINLINE std::vector<T> ReadVector(size_t count) {
		static_assert(std::is_trivially_copyable<T>::value, "Only trivially copyable types allowed");
		std::vector<T> vec(count);
		for (size_t i = 0; i < count; ++i) {
			vec[i] = Read<T>();
		}
		return vec;
	}
};

} // namespace obx
