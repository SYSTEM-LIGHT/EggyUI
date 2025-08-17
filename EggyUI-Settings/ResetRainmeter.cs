// 这些代码源自独立控制台程序（ResetRainmeter），
// 为适配EggyUI设置程序进行了轻量化重构：
// 1. 移除控制台交互逻辑，改为异常传递错误
// 2. 增加路径注入构造（_RainmeterPath）
// 3. 优化进程检测与目录删除的健壮性
// 注：核心三步重置策略（结束→删除→重启）保持不变
//     原控制台的进度提示转为调试日志输出

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggyUI_Settings
{
    internal class ResetRainmeter(string _RainmeterPath)
    {
        readonly string RainmeterPath = _RainmeterPath;

        public void Start()
        {
            // 1. 结束Rainmeter进程
            KillProcess("Rainmeter");
            Thread.Sleep(2000); // 等待进程完全退出

            // 2. 删除AppData/Roaming中的配置目录
            DeleteRainmeterFolder(Environment.SpecialFolder.ApplicationData);

            // 3. 删除文档目录中的Rainmeter文件夹
            DeleteRainmeterFolder(Environment.SpecialFolder.MyDocuments);

            // 4. 重新启动Rainmeter（从当前目录启动）
            StartRainmeter();
        }

        static void KillProcess(string processName)
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

        static void DeleteRainmeterFolder(Environment.SpecialFolder folderType)
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

        void StartRainmeter()
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
