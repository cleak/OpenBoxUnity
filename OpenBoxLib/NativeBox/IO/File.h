#pragma once

#include <string>
#include <vector>

#include "../Util.h"

namespace obx {

// Searches a specified paths and locates requested files.
class FileLocator : DoNotCopy {
private:

	std::vector<std::string> searchPaths;

public:

	FileLocator();
	FileLocator(FileLocator&& locator);

	// Finds the specified file. Exception if not found.
	std::string Find(const std::string& file) const;

	// Finds the specified file. If not found, a file with the given default folder path will be
	// returned.
	std::string Find(const std::string& file, const std::string defaultPath) const;

	// Returns true if the specified file is found, false otherwise.
	bool CanFind(const std::string& file) const;

	// Gets a vector of all search paths.
	const std::vector<std::string>& GetSearchPaths() const;

	// Adds the specified path to the search paths.
	void AddSearchPath(const std::string& path);
};

// Binary file container
class File : DoNotCopy {
private:
	size_t size;
	uint8_t* data;

public:

	explicit File(const std::string& filename);
	explicit File(const char* filename);

	static void Save(const std::string& filename, size_t numBytes, const void* bytes);

	static void Save(const std::string& filename, const Blob& blob);

	static Blob Load(const std::string& filename);

	static std::list<std::string> FindAll(const std::string& dir);

	// Reads in an entire text file as a string and returns it.
	std::string LoadText(std::string filename);

	~File();

	OBX_FORCEINLINE size_t Size() const { return size; }
	OBX_FORCEINLINE uint8_t* Data() const { return data; }
};

} // namespace obx
