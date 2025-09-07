#include "NTVersionLogoChanger.h"
#include <Windows.h>
#include <string>
#include <iostream>

// DLL全局数据
std::wstring g_customLogoPath;
HHOOK g_hHook = nullptr;
HMODULE g_hModule = nullptr;
std::wstring g_imagesFolderPath;

// 钩子过程回调函数
LRESULT CALLBACK HookProc(int nCode, WPARAM wParam, LPARAM lParam);

// 获取DLL所在目录
std::wstring GetDllDirectory()
{
    wchar_t dllPath[MAX_PATH] = { 0 };
    GetModuleFileName(g_hModule, dllPath, MAX_PATH);
    std::wstring fullPath = dllPath;
    size_t lastSlashPos = fullPath.find_last_of(L"\\/");
    if (lastSlashPos != std::wstring::npos)
    {
        return fullPath.substr(0, lastSlashPos);
    }
    return L"";
}

// 获取images文件夹路径
std::wstring GetImagesFolderPath()
{
    if (g_imagesFolderPath.empty())
    {
        std::wstring dllDir = GetDllDirectory();
        // 修改路径构建方式，确保路径正确
        // 可以根据实际部署情况调整路径
        g_imagesFolderPath = dllDir + L"\\images\\";
    }
    return g_imagesFolderPath;
}

// 确保images文件夹存在
HRESULT EnsureImagesFolderExists()
{
    std::wstring folderPath = GetImagesFolderPath();
    
    // 检查文件夹是否存在
    DWORD dwAttrib = GetFileAttributes(folderPath.c_str());
    if (dwAttrib != INVALID_FILE_ATTRIBUTES && (dwAttrib & FILE_ATTRIBUTE_DIRECTORY))
    {
        // 文件夹已存在
        return S_OK;
    }
    
    // 文件夹不存在，需要创建
    // 解析路径，确保所有父目录都存在
    std::wstring path = folderPath;
    size_t pos = 0;
    
    // 跳过UNC路径前缀（如果有）
    if (path.substr(0, 2) == L"\\\\")
    {
        pos = path.find(L'\\', 2);
        if (pos != std::wstring::npos)
        {
            pos = path.find(L'\\', pos + 1);
        }
    }
    
    // 逐步创建目录
    while ((pos = path.find(L'\\', pos + 1)) != std::wstring::npos)
    {
        std::wstring subPath = path.substr(0, pos);
        if (subPath.empty())
            continue;
            
        dwAttrib = GetFileAttributes(subPath.c_str());
        if (dwAttrib == INVALID_FILE_ATTRIBUTES)
        {
            // 创建子目录
            if (!CreateDirectory(subPath.c_str(), NULL))
            {
                return HRESULT_FROM_WIN32(GetLastError());
            }
        }
    }
    
    // 创建最终目录
    if (!CreateDirectory(folderPath.c_str(), NULL))
    {
        DWORD error = GetLastError();
        if (error != ERROR_ALREADY_EXISTS)
        {
            return HRESULT_FROM_WIN32(error);
        }
    }
    
    return S_OK;
}

// DLL入口点 - 添加extern "C"以确保正确的名称修饰
#ifdef __cplusplus
extern "C" {
#endif

    BOOL WINAPI DllMain(HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved)
    {
        switch (ul_reason_for_call)
        {
        case DLL_PROCESS_ATTACH:
            g_hModule = hModule;
            // 初始化时确保images文件夹存在
            EnsureImagesFolderExists();
            break;
        case DLL_THREAD_ATTACH:
        case DLL_THREAD_DETACH:
            break;
        case DLL_PROCESS_DETACH:
            if (g_hHook)
            {
                UnhookWindowsHookEx(g_hHook);
                g_hHook = nullptr;
            }
            break;
        }
        return TRUE;
    }

    // 注册插件
    NTVLC_API HRESULT WINAPI RegisterPlugin()
    {
        // 检查是否已经注册
        if (g_hHook)
        {
            return S_FALSE; // 已经注册
        }

        // 设置全局钩子来拦截ShellAbout函数调用
        g_hHook = SetWindowsHookEx(WH_CALLWNDPROCRET, HookProc, g_hModule, 0);
        if (!g_hHook)
        {
            return HRESULT_FROM_WIN32(GetLastError());
        }

        return S_OK;
    }

    // 注销插件
    NTVLC_API HRESULT WINAPI UnregisterPlugin()
    {
        if (g_hHook)
        {
            if (!UnhookWindowsHookEx(g_hHook))
            {
                return HRESULT_FROM_WIN32(GetLastError());
            }
            g_hHook = nullptr;
        }
        return S_OK;
    }

    // 设置自定义Logo
    NTVLC_API HRESULT WINAPI SetCustomLogo(const wchar_t* logoPath)
    {
        if (!logoPath || *logoPath == L'\0')
        {
            return E_INVALIDARG;
        }

        // 验证文件是否存在
        if (GetFileAttributes(logoPath) == INVALID_FILE_ATTRIBUTES)
        {
            return HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND);
        }

        g_customLogoPath = logoPath;
        return S_OK;
    }

    // 恢复默认Logo
    NTVLC_API HRESULT WINAPI RestoreDefaultLogo()
    {
        g_customLogoPath.clear();
        return S_OK;
    }

    // 从images文件夹加载指定尺寸的logo
    NTVLC_API HRESULT WINAPI LoadLogoFromImagesFolder(LogoSize size)
    {
        // 确保images文件夹存在
        HRESULT hr = EnsureImagesFolderExists();
        if (FAILED(hr))
        {
            return hr;
        }

        std::wstring folderPath = GetImagesFolderPath();
        std::wstring fileName;

        // 根据尺寸确定文件名
        switch (size)
        {
        case LogoSize::Large:
            fileName = L"logo_large";
            break;
        case LogoSize::Medium:
            fileName = L"logo_medium";
            break;
        case LogoSize::Small:
            fileName = L"logo_small";
            break;
        default:
            return E_INVALIDARG;
        }

        // 检查.png文件是否存在
        std::wstring pngPath = folderPath + fileName + L".png";
        if (GetFileAttributes(pngPath.c_str()) != INVALID_FILE_ATTRIBUTES)
        {
            g_customLogoPath = pngPath;
            return S_OK;
        }

        // 检查.bmp文件是否存在
        std::wstring bmpPath = folderPath + fileName + L".bmp";
        if (GetFileAttributes(bmpPath.c_str()) != INVALID_FILE_ATTRIBUTES)
        {
            g_customLogoPath = bmpPath;
            return S_OK;
        }

        // 两个格式的文件都不存在
        return HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND);
    }

// 用于regsvr32注册的标准函数实现
#ifdef __cplusplus
extern "C" {
#endif

STDAPI WINAPI DllRegisterServer(void)
{
    // 调用现有的RegisterPlugin函数来注册插件
    return RegisterPlugin();
}

STDAPI WINAPI DllUnregisterServer(void)
{
    // 调用现有的UnregisterPlugin函数来注销插件
    return UnregisterPlugin();
}

#ifdef __cplusplus
}
#endif

// 钩子过程实现
LRESULT CALLBACK HookProc(int nCode, WPARAM wParam, LPARAM lParam)
{
    // 只处理有效的钩子代码
    if (nCode >= 0) {
        // 检查是否有自定义Logo路径
        if (!g_customLogoPath.empty()) {
            // 这里应该添加实际的逻辑来拦截和修改系统Logo显示
            // 由于没有具体的系统Logo替换逻辑，这里只是一个框架
            // 实际实现需要根据目标系统（Win10 1607）的具体API和机制
        }
    }
    
    // 继续传递钩子链
    return CallNextHookEx(g_hHook, nCode, wParam, lParam);
}