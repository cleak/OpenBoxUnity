#include "ByteBuffer.h"

#include <algorithm>

namespace obx {

ByteBuffer::ByteBuffer() {
	location = 0;
}

ByteBuffer::ByteBuffer(const Blob & blob) {
	location = 0;
	bytes.resize(blob.Size());
	memcpy(&bytes[0], blob.Data(), blob.Size());
}

void ByteBuffer::Write(uint8_t byte) {
	if (location < bytes.size()) {
		bytes[location] = byte;
	} else {
		bytes.push_back(byte);
	}

	++location;
}

void ByteBuffer::Write(const void* data, size_t byteCount) {

	if (bytes.size() < location + byteCount) {
		bytes.resize(location + byteCount);
	}

	memcpy(&bytes[location], data, byteCount);
	location += byteCount;
}

uint8_t ByteBuffer::Read() {
	OBX_ASSERT(!Eof());
	return bytes[location++];
}

uint8_t ByteBuffer::Peek() const {
	OBX_ASSERT(!Eof());
	return bytes[location];
}

bool ByteBuffer::Eof() const {
	return location >= bytes.size();
}

void ByteBuffer::WriteString(const std::string & str, bool wordAlign, bool preamble) {
	if (preamble) {
		Write((uint32_t)str.size());
	}

	Write(str.c_str(), str.size());

	if (wordAlign && location % 4 != 0) {
		int padSize = 4 - location % 4;
		for (int i = 0; i < padSize; ++i) {
			Write(uint8_t(0));
		}
	}
}

void ByteBuffer::WriteFixedString(const std::string & str, size_t numChars) {
	OBX_ASSERT(bytes.size() - location >= numChars);
	// Truncate given string if necessary
	Write(str.c_str(), std::min(str.size(), numChars));

	// Pad up to specified length
	for (int i = 0; i < numChars - str.size(); ++i) {
		bytes[location] = 0;
		++location;
	}
}

bool ByteBuffer::CopyTo(void * destination, size_t count) {
	OBX_ASSERT(!Eof());
	if (location + count > bytes.size()) {
		OBX_FAIL("Copy past end of buffer");
		return false;
	}

	memcpy(destination, &bytes[location], count);
	location += count;
	return true;
}

std::string ByteBuffer::ReadString(bool wordAlign) {
	uint32_t strSize = Read<uint32_t>();
	std::string str;
	str.resize(strSize);

	for (uint32_t i = 0; i < strSize; ++i) {
		str[i] = Read<char>();
	}

	if (wordAlign && location % 4 != 0) {
		location += 4 - location % 4;
	}

	return str;
}

std::string ByteBuffer::ReadFixedString(size_t numChars) {
	OBX_ASSERT(bytes.size() - location >= numChars);
	char* rawStr = (char*)&bytes[location];
	location += numChars;
	return std::string(rawStr, numChars);
}

} // namespace obx
