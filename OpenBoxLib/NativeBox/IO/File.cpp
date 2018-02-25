#include "File.h"

#include <fstream>
#include <sstream>

#include <experimental/filesystem>
namespace fs = std::experimental::filesystem;

using namespace std;

namespace obx {

////////////////////////////////////////////////////////////////////////////////
// File Locator Class

FileLocator::FileLocator() {}

FileLocator::FileLocator(FileLocator && locator)
	: searchPaths(std::move(locator.searchPaths)) {}

std::string FileLocator::Find(const std::string & file) const {
	for (const auto& path : searchPaths) {
		fs::path checkFile(path);
		if (fs::exists(checkFile / file)) {
			return fs::canonical(checkFile / file).generic_string();
		}
	}

	throw Exception("File " + file + " not found");
}

std::string FileLocator::Find(const std::string & file, const std::string defaultPath) const {
	if (!CanFind(file)) {
		// Return default
		return fs::canonical(fs::path(defaultPath) / file).generic_string();
	}

	return Find(file);
}

bool FileLocator::CanFind(const std::string & file) const {
	for (const auto& path : searchPaths) {
		fs::path checkFile(path);
		if (fs::exists(checkFile / file)) {
			return true;
		}
	}
	return false;
}

const std::vector<std::string>& FileLocator::GetSearchPaths() const {
	return searchPaths;
}

void FileLocator::AddSearchPath(const std::string& path) {
	searchPaths.push_back(path);
}

std::string ReadTextFile(std::string filename) {
	ifstream textStream(filename, std::ifstream::in);

	if (textStream.fail()) {
		throw Exception("Failed to open file " + filename);
	}

	string str(static_cast<stringstream const&>(stringstream() << textStream.rdbuf()).str());
	return str;
}

////////////////////////////////////////////////////////////////////////////////
// File Class

File::File(const std::string & filename) : File(filename.c_str()) {}

File::File(const char* filename) {
	OBX_ASSERT(fs::exists(filename));
	ifstream fileIn(filename, ios::in | ios::binary | ios::ate);
	size = fileIn.tellg();
	data = new uint8_t[size];
	fileIn.seekg(0, ios::beg);
	fileIn.read((char*)data, size);
	fileIn.close();
}

void File::Save(const char * filename, size_t numBytes, const void * bytes) {
	ofstream fout(filename, ios::out | ios::binary);
	fout.write((const char*)bytes, numBytes);
	fout.close();
}

void File::Save(const std::string & filename, size_t numBytes, const void * bytes) {
	Save(filename.c_str(), numBytes, bytes);
}

void File::Save(const char * filename, const Blob & blob) {
	Save(filename, blob.Size(), blob.Data());
}

void File::Save(const std::string & filename, const Blob & blob) {
	Save(filename, blob.Size(), blob.Data());
}

Blob File::Load(const char * filename) {
	OBX_ASSERT(fs::exists(filename));
	ifstream fileIn(filename, ios::in | ios::binary | ios::ate);
	size_t size = fileIn.tellg();
	Blob blob(size);
	fileIn.seekg(0, ios::beg);
	fileIn.read((char*)blob.Data(), size);
	fileIn.close();
	return blob;
}

Blob File::Load(const std::string & filename) {
	return Load(filename.c_str());
}

std::list<std::string> File::FindAll(const std::string & dir) {
	const size_t kMaxIterations = 1024 * 16;

	list<string> files;
	size_t iterations = 0;

	auto endFile = fs::recursive_directory_iterator();
	for (auto f = fs::recursive_directory_iterator(dir); f != endFile; ++f) {
		++iterations;
		if (iterations > kMaxIterations) {
			throw Exception("Max iterations reached");
		}

		if (fs::is_directory(*f)) {
			continue;
		}

		string relativePath = f->path().filename().string();
		fs::path parentDir = f->path();

		for (size_t i = 0; i < f.depth(); ++i) {
			parentDir = parentDir.parent_path();
			relativePath = parentDir.filename().string() + "/" + relativePath;
		}

		files.push_back(relativePath);
	}

	return files;
}

std::string File::LoadText(std::string filename) {
	return Load(filename.c_str()).ToString();
}

File::~File() {
	delete[] data;
}

} // namespace obx
