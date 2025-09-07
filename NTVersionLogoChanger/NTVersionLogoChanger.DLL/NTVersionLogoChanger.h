#pragma once

#ifdef __cplusplus
extern "C" {
#endif

#ifdef NTVersionLogoChanger_EXPORTS
#define NTVLC_API __declspec(dllexport)
#else
#define NTVLC_API __declspec(dllimport)
#endif

#include <Windows.h> // 确保HRESULT类型定义

// 定义Logo尺寸枚举
enum class LogoSize
{
    Large = 0,    // 687x108
    Medium = 1,   // 528x90
    Small = 2     // 458x72
};

// 插件API接口
NTVLC_API HRESULT WINAPI RegisterPlugin();
NTVLC_API HRESULT WINAPI UnregisterPlugin();
NTVLC_API HRESULT WINAPI SetCustomLogo(const wchar_t* logoPath);
NTVLC_API HRESULT WINAPI RestoreDefaultLogo();
NTVLC_API HRESULT WINAPI LoadLogoFromImagesFolder(LogoSize size);

// 用于regsvr32注册的标准函数
STDAPI WINAPI DllRegisterServer(void);
STDAPI WINAPI DllUnregisterServer(void);

#ifdef __cplusplus
}
#endif

// DllMain是DLL的入口点，不需要在此处声明