/*
 * ============================================================================
 * EggyUI - Windows 桌面美化主题包
 * 基于网易《蛋仔派对》UI风格的粉丝二次创作，非官方、非商业项目
 * ============================================================================
 *  
 * 作者: 冷落的小情绪 (SYSTEM-LIGHT)
 * 贡献者: EggyUI 开发团队 (https://github.com/SYSTEM-LIGHT/EggyUI)
 * 
 * 版权所有 (c) 2024-2025 EggyUI 开发团队
 * 
 * 许可协议:
 * 本项目为粉丝创作，严禁用于任何商业用途。
 * 所有素材均为合法获取或自主重绘，未使用任何游戏解包内容。
 * 
 * 免责声明:
 * 1. 本软件与微软、网易无关，Windows 和《蛋仔派对》分别为其所属公司的注册商标。
 * 2. 使用者需自行承担因使用本软件可能带来的风险。
 * 3. 禁止对本软件进行商业性使用、分发或集成至商业产品中。
 * 
 * ============================================================================
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace EggyUI_Settings
{
    internal class ResetRainmeter(string _RainmeterPath, string? _RainmeterSkinPath = null)
    {
        readonly string RainmeterPath = _RainmeterPath;
        readonly string? SkinPath = _RainmeterSkinPath;

        public void Start(CancellationToken cancellationToken = default)
        {
            // 1. 结束Rainmeter进程
            KillProcess("Rainmeter");
            Thread.Sleep(2000); // 等待进程完全退出

            // 2. 删除配置目录（新增皮肤路径处理）
            DeleteRainmeterFolder(Environment.SpecialFolder.ApplicationData);
            DeleteRainmeterFolder(Environment.SpecialFolder.MyDocuments);
            
            // 新增皮肤目录删除逻辑
            if (!string.IsNullOrWhiteSpace(SkinPath))
            {
                DeleteCustomSkinFolder();
            }

            // 3. 重新启动Rainmeter
            StartRainmeter();
        }

        // 新增皮肤目录删除方法
        private void DeleteCustomSkinFolder()
        {
            try
            {
                if (Directory.Exists(SkinPath))
                {
                    Directory.Delete(SkinPath, true);
                    Debug.WriteLine($"[重置 Rainmeter] 已删除自定义皮肤目录: {SkinPath}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"删除自定义皮肤目录错误: {ex.Message}");
            }
        }

        // 修改后的构造函数组
        public ResetRainmeter(string _RainmeterPath) : this(_RainmeterPath, null) { }

        private static void KillProcess(string processName)
        {
            try
            {
                bool found = false;
                foreach (Process process in Process.GetProcessesByName(processName))
                {
                    process.Kill();
                    process.WaitForExit(1000);
                    Debug.WriteLine($"[重置 Rainmeter] 已结束进程: {process.Id}");
                    found = true;
                }

                if (!found)
                {
                    Debug.WriteLine("[重置 Rainmeter] 未找到运行的Rainmeter进程");
                }
            }
            catch (Exception ex)
            {
                // 这里抛出异常是为了在调用ResetRainmeter.Start()时能够捕获到异常，
                // 并在调用方进行处理，避免程序崩溃。
                throw new Exception($"结束Rainmeter进程错误: {ex.Message}");
            }
        }

        private static void DeleteRainmeterFolder(Environment.SpecialFolder folderType)
        {
            try
            {
                string folderPath = Environment.GetFolderPath(folderType);
                string rainmeterConfigPath = Path.Combine(folderPath, "Rainmeter");

                if (Directory.Exists(rainmeterConfigPath))
                {
                    Directory.Delete(rainmeterConfigPath, true);
                    Debug.WriteLine($"[重置 Rainmeter] 已删除目录: {rainmeterConfigPath}");
                }
                else
                {
                    Debug.WriteLine($"[重置 Rainmeter] 目录不存在: {rainmeterConfigPath}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"删除Rainmeter皮肤目录错误: {ex.Message}");
            }
        }

        private void StartRainmeter()
        {
            try
            {
                string rainmeterPath = Path.Combine(RainmeterPath, "Rainmeter.exe");

                if (File.Exists(rainmeterPath))
                {
                    Debug.WriteLine($"[重置 Rainmeter] 从配置路径启动: {RainmeterPath}");
                    Process.Start(rainmeterPath);
                    Debug.WriteLine("[重置 Rainmeter] Rainmeter 已成功启动");
                }
                else
                {
                    Debug.WriteLine($"[重置 Rainmeter] 未在配置路径找到Rainmeter.exe: {RainmeterPath}");
                    Debug.WriteLine("[重置 Rainmeter] 尝试默认安装路径...");

                    // 回退到默认安装路径
                    string defaultPath = @"C:\Program Files\Rainmeter\Rainmeter.exe";
                    if (File.Exists(defaultPath))
                    {
                        Process.Start(defaultPath);
                        Debug.WriteLine("[重置 Rainmeter] 从默认路径启动成功");
                    }
                    else
                    {
                        Debug.WriteLine("[重置 Rainmeter] 无法找到Rainmeter.exe，请手动启动");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"启动Rainmeter错误: {ex.Message}");
            }
        }
    }
}
