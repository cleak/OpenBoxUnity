#include "Util.h"

#include <algorithm>
#include <fstream>
#include <iostream>
#include <sstream>

using namespace std;

namespace obx {

////////////////////////////////////////////////////////////////////////////////
// Exception handling

bool HandleAssertionFailure(const char* expr, const char* file, int line, const char* message) {
	cerr << "Assertion failure @ " << file << "(" << line << "): " << expr << " " << message;
	return true;
}

Exception::Exception()
	: details("") {}

Exception::Exception(const char * message)
	: details(message) {}

Exception::Exception(std::string message)
	: details(message) {}

////////////////////////////////////////////////////////////////////////////////
// String functions

std::string ToLower(std::string str) {
	std::transform(str.begin(), str.end(), str.begin(), ::tolower);
	return str;
}

std::string ToUpper(std::string str) {
	std::transform(str.begin(), str.end(), str.begin(), ::toupper);
	return str;
}

std::list<std::string> Split(const std::string & str, const std::string & delimeters, bool ignoreEmpty) {
	size_t start = 0;
	size_t end = 0;

	list<string> strings;

	for (size_t i = 0; i < str.size(); ++i) {
		bool split = false;

		for (size_t j = 0; j < delimeters.size(); ++j) {
			if (str[i] == delimeters[j]) {
				split = true;
				end = i;
				break;
			}
		}

		if (split) {
			size_t len = end - start;
			if (len > 0 || !ignoreEmpty) {
				strings.push_back(str.substr(start, len));
			}
			start = i + 1;
		}
	}

	// Process the match at the end
	end = str.size();
	size_t len = end - start;
	if (len > 0 || !ignoreEmpty) {
		strings.push_back(str.substr(start, len));
	}

	return strings;
}

std::string Join(const std::string & delimeter, const std::vector<std::string>& strings) {
	if (strings.size() <= 0) {
		return "";
	}

	size_t totalLen = delimeter.size() * (strings.size() - 1);

	for (auto& str : strings) {
		totalLen += str.size();
	}

	string joined(totalLen, ' ');
	
	size_t nextIdx = 0;
	for (auto& str : strings) {
		// Insert delimeter
		if (nextIdx > 0) {
			for (auto& c : delimeter) {
				joined[nextIdx] = c;
				nextIdx++;
			}
		}

		// Append next string
		for (auto& c : str) {
			joined[nextIdx] = c;
			nextIdx++;
		}
	}

	return joined;
}

std::string Join(const std::string & delimeter, const std::list<std::string>& strings) {
	if (strings.size() <= 0) {
		return "";
	}

	size_t totalLen = delimeter.size() * (strings.size() - 1);

	for (auto& str : strings) {
		totalLen += str.size();
	}

	string joined(totalLen, ' ');

	size_t nextIdx = 0;
	for (auto& str : strings) {
		// Insert delimeter
		if (nextIdx > 0) {
			for (auto& c : delimeter) {
				joined[nextIdx] = c;
				nextIdx++;
			}
		}

		// Append next string
		for (auto& c : str) {
			joined[nextIdx] = c;
			nextIdx++;
		}
	}

	return joined;
}

////////////////////////////////////////////////////////////////////////////////
// Blob Class

Blob::Blob(Blob && other) {
	data = other.data;
	size = other.size;
	managed = other.managed;

	other.data = nullptr;
	other.size = 0;
	other.managed = false;
}

Blob::~Blob() {
	if (managed) {
		delete[] data;

		data = nullptr;
		size = 0;
		managed = false;
	}
}

Blob::Blob(const std::string & str) {
	managed = true;
	size = str.size();
	data = new uint8_t[size];
	memcpy(data, &str[0], size);
}

Blob::Blob(void * data, size_t byteCount) {
	this->managed = false;
	this->data = (uint8_t*)data;
	this->size = byteCount;
}

Blob::Blob(void * data, size_t byteCount, bool managed) {
	this->managed = managed;
	this->data = (uint8_t*)data;
	this->size = byteCount;
}

Blob::Blob(size_t numBytes) {
	this->size = numBytes;
	this->managed = true;
	this->data = new uint8_t[numBytes];
}

std::string Blob::ToString() const {
	return std::string((char*)data, size);
}

} // namespace obx
