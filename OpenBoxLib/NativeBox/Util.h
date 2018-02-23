#pragma once

#include <exception>
#include <intrin.h>
#include <list>
#include <memory>
#include <string>
#include <vector>

#define OBX_FORCEINLINE __forceinline

#define OBX_STRINGIFY(expr) #expr

#ifndef OBX_CLANG
	#define OBX_EXPORT_FN_OVERLOAD(fnSuffix) \
		__pragma(comment(linker, "/EXPORT:" __FUNCTION__#fnSuffix"=" __FUNCDNAME__))

	#define OBX_EXPORT_FN() \
		OBX_EXPORT_FN_OVERLOAD("")
#else
	void lbx_ForClang_ExportFn(char* suffix);
	#define OBX_EXPORT_FN_OVERLOAD(fnSuffix) \
			lbx_ForClang_ExportFn(#fnSuffix)

	#define OBX_EXPORT_FN() \
			lbx_ForClang_ExportFn("")

#define lbx_interop __attribute__((annotate("obx interop")))
#define lbx_interop_as(name) __attribute__((annotate("obx interop_as " #name)))
#define lbx_pod __attribute__((annotate("obx pod")))
#define lbx_ignore __attribute__((annotate("obx ignore")))
#endif

namespace obx {

template<typename T>using UniPtr = std::unique_ptr<T>;
template<typename T>using ShrPtr = std::shared_ptr<T>;
template<typename T>using WkPtr = std::weak_ptr<T>;

// Class to disallow copy and assignment. Inherit from this to disable for a particular class.
class DoNotCopy {
public:
	DoNotCopy(const DoNotCopy&) = delete;
	DoNotCopy& operator=(const DoNotCopy&) = delete;

protected:

	DoNotCopy() {}
};

// Determines if the given value is in the given set
template<typename T, typename S = std::vector<T>>
bool IsIn(const T& val, const S& checkSet) {
	return std::find(std::begin(checkSet), std::end(checkSet), val) != std::end(checkSet);
}

////////////////////////////////////////////////////////////////////////////////
// Exception handling

class Exception : std::exception {
private:

	std::string details;

public:

	Exception();
	Exception(const char* message);
	Exception(std::string message);

	virtual const char* what() const { 
		return details.c_str();
	}
};

bool HandleAssertionFailure(const char* expr, const char* file, int line, const char* message);

////////////////////////////////////////////////////////////////////////////////
// String helpers

std::list<std::string> Split(const std::string& str, const std::string& delimeters, bool ignoreEmpty = true);
std::string Join(const std::string& delimeter, const std::vector<std::string>& strings);
std::string Join(const std::string& delimeter, const std::list<std::string>& strings);

// Converts a stirng to lowercase
std::string ToLower(std::string str);

// Converts a stirng to uppercase
std::string ToUpper(std::string str);

////////////////////////////////////////////////////////////////////////////////
// Blob

// Container of raw bytes; can be managed or unmanaged.
class Blob : DoNotCopy {
private:

	size_t size;
	uint8_t* data;
	bool managed;

public:

	Blob(Blob&& other);
	virtual ~Blob();

	// Constructs a managed blob, copying in the contets of the given string.
	explicit Blob(const std::string& str);

	// Constructs a blob that's unmanaged.
	explicit Blob(void* data, size_t byteCount);

	// Constructs a managed or unmanaged blob.
	explicit Blob(void* data, size_t byteCount, bool managed);

	// Constructs a blob with the specified number of bytes.
	explicit Blob(size_t numBytes);
	
	OBX_FORCEINLINE size_t Size() const { return size; }
	OBX_FORCEINLINE uint8_t* Data() const { return data; }
	OBX_FORCEINLINE bool IsManaged() const { return managed; }

	std::string ToString() const;
};

} // namespace obx

////////////////////////////////////////////////////////////////////////////////
// Assertion macros

#ifndef OBX_RELEASE
#define OBX_ASSERT(cond)\
    do {\
        if (!(cond)) {\
            if (::obx::HandleAssertionFailure(#cond, __FILE__, __LINE__, "")) {\
                __debugbreak();\
            }\
        }\
    } while (0)

#define OBX_ASSERT_MSG(cond, msg)\
    do {\
        if (!(cond)) {\
            if (::obx::HandleAssertionFailure(#cond, __FILE__, __LINE__, (msg))) {\
                __debugbreak();\
            }\
        }\
    } while (0)

#define OBX_FAIL(msg)\
    do {\
            if (::obx::HandleAssertionFailure("FAIL", __FILE__, __LINE__, (msg))) {\
                __debugbreak();\
            }\
    } while (0)

#else
#define OBX_ASSERT(cond) \  
do { (void)0; } while (0)
#define OBX_ASSERT_MSG(cond, msg) \  
do { (void)0; } while (0)
#define OBX_FAIL(msg) \  
do { (void)0; } while (0)
#endif