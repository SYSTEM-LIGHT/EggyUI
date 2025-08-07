using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace ResetRainmeter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rainmeter 重置工具");
            Console.WriteLine("by 一只野生的蛋小绿_Minty");
            Console.WriteLine("==================================");

            // 1. 结束Rainmeter进程
            Console.WriteLine("[1/4] 正在结束Rainmeter进程...");
            KillProcess("Rainmeter");
            Thread.Sleep(2000); // 等待进程完全退出

            // 2. 删除AppData/Roaming中的配置目录
            Console.WriteLine("\n[2/4] 正在删除配置目录...");
            DeleteRainmeterFolder(Environment.SpecialFolder.ApplicationData);

            // 3. 删除文档目录中的Rainmeter文件夹
            Console.WriteLine("\n[3/4] 正在删除皮肤目录...");
            DeleteRainmeterFolder(Environment.SpecialFolder.MyDocuments);

            // 4. 重新启动Rainmeter（从当前目录启动）
            Console.WriteLine("\n[4/4] 正在启动Rainmeter...");
            StartRainmeter();

            Console.WriteLine("\n操作完成！按任意键退出...");
            Console.ReadKey();
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
                    Console.WriteLine($"已结束进程: {process.Id}");
                    found = true;
                }

                if (!found)
                {
                    Console.WriteLine("未找到运行的Rainmeter进程");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"结束进程错误: {ex.Message}");
            }
        }

        static void DeleteRainmeterFolder(Environment.SpecialFolder folderType)
        {
            try
            {
                string folderPath = Environment.GetFolderPath(folderType);
                string rainmeterPath = Path.Combine(folderPath, "Rainmeter");

                if (Directory.Exists(rainmeterPath))
                {
                    Directory.Delete(rainmeterPath, true);
                    Console.WriteLine($"已删除目录: {rainmeterPath}");
                }
                else
                {
                    Console.WriteLine($"目录不存在: {rainmeterPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"删除目录错误: {ex.Message}");
            }
        }

        static void StartRainmeter()
        {
            try
            {
                // 获取当前程序所在目录
                string currentDir = AppDomain.CurrentDomain.BaseDirectory;
                string rainmeterPath = Path.Combine(currentDir, "Rainmeter.exe");

                if (File.Exists(rainmeterPath))
                {
                    Console.WriteLine($"从目录启动: {currentDir}");
                    Process.Start(rainmeterPath);
                    Console.WriteLine("Rainmeter 已成功启动");
                }
                else
                {
                    Console.WriteLine($"未在当前目录找到Rainmeter.exe: {currentDir}");
                    Console.WriteLine("尝试默认安装路径...");

                    // 回退到默认安装路径
                    string defaultPath = @"C:\Program Files\Rainmeter\Rainmeter.exe";
                    if (File.Exists(defaultPath))
                    {
                        Process.Start(defaultPath);
                        Console.WriteLine("从默认路径启动成功");
                    }
                    else
                    {
                        Console.WriteLine("无法找到Rainmeter.exe，请手动启动");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"启动错误: {ex.Message}");
            }
        }
    }
}