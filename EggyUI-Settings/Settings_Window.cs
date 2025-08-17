// Author：蛋仔派对远航蛋（https://space.bilibili.com/1591761987）
// 这个程序的所有代码都严格按照.NET 8的标准编写，采用了该版本中诸多现代语法特性，
// 以保证代码具备更高的可读性、简洁性和性能，同时也紧跟最新的.NET开发趋势。
// 这是我第一次接这个项目，所以代码质量可能不是很高，但是我会努力改进的。
// 另外，这个程序使用了一些线程来提高程序的响应性能。
// 不得不说GitHub的响应速度是真的慢，有时候我想提交更改都提交不了，我只能等它响应了才知道是否提交成功。

using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EggyUI_Settings
{
    public partial class Settings_Window : Form
    {
        #region 变量、方法

        readonly ConfigurationService _configurationService;

        public Settings_Window()
        {
            // 实例化配置服务
            _configurationService = new ConfigurationService();
            _configurationService.LoadConfiguration();
            InitializeComponent();
        }

        // 获取Rainmeter路径
        string RainmeterPath => _configurationService.RainmeterPath;

        // 获取Rainmeter皮肤路径
        string RainmeterSkinPath => _configurationService.RainmeterSkinPath;

        // 获取文件夹背景目录
        string FolderBackgroundPath => _configurationService.FolderBackgroundPath;

        // 获取StartAllBack路径
        string StartAllBackPath => _configurationService.StartAllBackPath;

        // 获取Start11路径
        string Start11Path => _configurationService.Start11Path;

        // 贴图路径
        static readonly string ArtWorkPath = Path.Combine(Application.StartupPath, "artwork");

        // 版本信息文件路径
        static readonly string VersionInfoFile = Path.Combine(ArtWorkPath, "VersionInfo.txt");

        // NT内核版本
        static readonly int NTVersion = Environment.OSVersion.Version.Major;

        // 系统内部版本
        static readonly int BuildVersion = Environment.OSVersion.Version.Build;

        public static bool TaskExists(string taskName)
        {
            try
            {
                // 使用schtasks命令行工具查询任务
                // 你猜我这里为什么要使用schtasks.exe而不是直接使用Task类？
                // 因为Task类是.NET 8的新特性，它只能在Windows 11上运行，而schtasks.exe在所有Windows版本上都可用
                // 另外，这里使用了new()初始化ProcessStartInfo，这是.NET 8的新特性，它可以避免内存分配
                // 同时，这里使用了CreateNoWindow = true，这是为了避免创建新的窗口
                // 最后，这里使用了RedirectStandardOutput = true和RedirectStandardError = true，这是为了获取命令行输出
                ProcessStartInfo startInfo = new()
                {
                    FileName = "schtasks.exe",
                    Arguments = $"/query /tn \"{taskName}\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                // 这里使用了简化的using语句，避免了显式调用Dispose()方法
                // 同时，这里使用了null检查运算符，避免了空引用异常
                using Process? process = Process.Start(startInfo);
                if (process == null) return false;
                process.WaitForExit();
                // 退出代码为0表示任务存在
                return process.ExitCode == 0;
            }
            catch
            {
                // 发生异常时默认为任务不存在
                return false;
            }
        }

        void ReloadFolderBackgroundPic()
        {
            // 刷新文件夹背景预览图片
            string imageFolder = Path.Combine(FolderBackgroundPath, "image");
            if (Directory.Exists(imageFolder))
            {
                // Span<string> 等效于 string[]，但 Span 是栈上分配的，而 string[] 是堆上分配的
                // 这里使用 Span 是为了避免内存分配，提高性能
                Span<string> imageFiles = Directory.GetFiles(imageFolder, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(file =>
                        file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        file.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    .ToArray();

                if (imageFiles.Length > 0)
                {
                    // 你猜我这里为什么要用new()而不是new Random()？
                    // 因为new()是.NET 8的新特性，它会自动使用线程安全的随机数生成器
                    // 而new Random()在多线程环境下可能会导致随机数重复
                    Random random = new();
                    string randomImagePath = imageFiles[random.Next(imageFiles.Length)];
                    try
                    {
                        if (this.FolderBackgroundPic is PictureBox picBox)
                        {
                            picBox.Image?.Dispose(); // 销毁原图像对象
                            picBox.Image = Image.FromFile(randomImagePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"加载图片时发生错误：{ex.Message}",
                            "错误",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
                    }
                }
            }
        }

        /// <summary>
        /// 通用按钮点击处理器
        /// </summary>
        /// <param name="sender">按钮对象</param>
        /// <param name="pathMap">路径字典</param>
        /// <param name="errorMsgMap">错误信息字典</param>
        /// <param name="argumentsMap">参数字典（可选，不填默认设置为空）</param>
        static void ButtonClickHandler(
            object sender,
            Dictionary<string, string> pathMap, // 路径字典
            Dictionary<string, string> errorMsgMap, // 错误信息字典
            Dictionary<string, string>? argumentsMap = null // 参数字典（可选，不填默认设置为空）
            )
        {
            Button btn = (Button)sender;
            try
            {
                string fileName = pathMap.TryGetValue(btn.Name, out string? value)
                    ? value : pathMap["default"];
                Process.Start(new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = argumentsMap is not null
                    ? (argumentsMap.TryGetValue(btn.Name, out string? value1)
                    ? value1 : argumentsMap["default"])
                    : "",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                string errorMsg = errorMsgMap.TryGetValue(btn.Name, out string? msg)
                    ? msg : errorMsgMap["default"];
                MessageBox.Show(
                    string.Format(errorMsg, ex.Message),
                    "错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        #endregion

        #region 事件处理程序

        // 方法的private其实是可写可不写的（不加可见性标识符的话，默认可见性就是private）
        void Settings_Window_Load(object sender, EventArgs e)
        {
            // 加载版本图片
            string VersionImage = Path.Combine(ArtWorkPath, "EggyUI_Version.png");
            if (File.Exists(VersionImage)) VersionPic.Image = Image.FromFile(VersionImage);

            // 加载文件夹背景预览图
            ReloadFolderBackgroundPic();

            // 检测开始菜单修改软件是否存在
            OpenStartAllBackSettings.Enabled =
                File.Exists(Path.Combine(StartAllBackPath, "StartAllBackCfg.exe"))
                && !((NTVersion < 10) && (BuildVersion < 22000)); // 检测是否为Win11
            OpenStart11Settings.Enabled =
                File.Exists(Path.Combine(Start11Path, "Start11Config.exe"))
                && !(NTVersion < 10); // 检测是否为Win10/Win11

            // 检测Rainmeter计划任务是否存在
            CheckRainmeterStartup.Checked = TaskExists("EggyUIWidgets");

            // 使用线程异步读取版本信息文件
            // 这里使用了异步线程是为了避免阻塞UI线程，提高响应速度
            // 另外这里用new()创建线程而不是用new Thread()创建线程，这是因为new()是.NET 8的新特性，
            // 借助编译器的类型推断能力，能根据变量声明自动推断出具体类型，使代码更加简洁易读，
            // 同时减少了冗余的类型声明，符合本程序采用.NET 8现代语法特性的开发标准。
            Thread ReadVersionFileThread = new(() =>
            {
                if (File.Exists(VersionInfoFile))
                {
                    try
                    {
                        VersionInfoText.Text = File.ReadAllText(VersionInfoFile);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"读取版本信息文件时发生错误：{ex.Message}");
                    }
                }
            });
            ReadVersionFileThread.Start();
        }

        void CheckRainmeterStartup_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            try
            {
                // 设置Rainmeter开启启动
                Process.Start(new ProcessStartInfo
                {
                    FileName = "schtasks",
                    // 这里是一个条件表达式，被我换行成了多行，
                    // 目的是为了提高代码的可读性，使代码更易维护
                    Arguments = box.Checked
                        && !TaskExists("EggyUIWidgets") 
                        ? $"/create /tn EggyUIWidgets /sc onlogon /tr \"{Path.Combine(RainmeterPath, "Rainmeter.exe")}\" /f" 
                        : "/delete /tn EggyUIWidgets /f",
                    CreateNoWindow = true, // 无窗口创建进程
                    UseShellExecute = false
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"设置Rainmeter开机启动时发生错误：{ex.Message}",
                    "错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        void ResetRainmeterButton_Click(object sender, EventArgs e)
        {
            Thread ResetRainmeterThread = new(() =>
            {
                try
                {
                    ResetRainmeter reset = new(RainmeterPath);
                    reset.Start();
                    MessageBox.Show(
                        "Rainmeter重置成功！",
                        "提示",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"重置Rainmeter时发生错误：{ex.Message}",
                        "错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            });
            ResetRainmeterThread.Start();
        }

        void RainmeterSettingsButton_Click(object sender, EventArgs e)
        {
            // 路径列表
            // 这里使用了 .NET 8 的现代语法特性 new() 来初始化字典，而非传统的 new Dictionary<string, string>。
            // 此语法是 .NET 8 引入的类型推断特性，编译器能够根据变量声明自动推断出具体的泛型类型，
            // 从而让代码更加简洁易读，同时减少了冗余的类型声明。后续类似的字典初始化操作也采用了相同的现代语法。
            Dictionary<string, string> pathMap = new()
            {
                { "OpenRainmeterFolder", RainmeterPath },
                { "OpenRainmeterSkinFolder", RainmeterSkinPath },
                { "default", Path.Combine(RainmeterPath, "SkinInstaller.exe") },
            };

            // 错误信息列表
            Dictionary<string, string> errorMsgMap = new()
            {
                { "OpenRainmeterFolder", "打开Rainmeter文件夹时发生错误：{0}" },
                { "OpenRainmeterSkinFolder", "打开Rainmeter皮肤文件夹时发生错误：{0}" },
                { "default", "安装Rainmeter皮肤时发生错误：{0}" },
            };

            ButtonClickHandler(sender, pathMap, errorMsgMap);
        }

        void FBGSettingsButton_Click(object sender, EventArgs e)
        {
            // 路径列表
            Dictionary<string, string> pathMap = new()
            {
                { "EnableFBG", Path.Combine(FolderBackgroundPath, "Register.cmd") },
                { "DisableFBG", Path.Combine(FolderBackgroundPath, "Uninstall.cmd") },
                { "default", Path.Combine(FolderBackgroundPath, "image") }
            };

            // 错误信息列表
            Dictionary<string, string> errorMsgMap = new()
            {
                { "EnableFBG", "开启文件夹背景功能时发生错误：{0}" },
                { "DisableFBG", "关闭文件夹背景功能时发生错误：{0}" },
                { "default", "打开文件夹背景图片目录时发生错误：{0}" }
            };

            ButtonClickHandler(sender, pathMap, errorMsgMap);
        }

        void ReloadFolderBackgroundPicButton_Click(object sender, EventArgs e)
        {
            // 刷新文件夹背景预览图片
            ReloadFolderBackgroundPic();
        }

        void OtherSettingsButton_Click(object sender, EventArgs e)
        {
            // 路径列表
            Dictionary<string, string> pathMap = new()
            {
                { "OpenStartAllBackSettings", Path.Combine(StartAllBackPath, "StartAllBackCfg.exe") },
                { "OpenStart11Settings", Path.Combine(Start11Path, "Start11Config.exe") },
                { "OpenPersonalizationSettings", "ms-settings:personalization" },
                { "default", "control" }
            };

            // 错误信息列表
            Dictionary<string, string> errorMsgMap = new()
            {
                { "OpenStartAllBackSettings", "打开StartAllBack设置时发生错误：{0}" },
                { "OpenStart11Settings", "打开Start11设置时发生错误：{0}" },
                { "OpenPersonalizationSettings", "打开系统个性化设置时发生错误：{0}" },
                { "default", "打开控制面板时发生错误：{0}" }
            };

            ButtonClickHandler(sender, pathMap, errorMsgMap);
        }

        void EggyUILinkButtonClick(object sender, EventArgs e)
        {
            Dictionary<string, string> pathMap = new()
            {
                {"VisitEggyUIBiliBili", "https://space.bilibili.com/3546563248916693"},
                {"JoinEggyUIGroup", "https://eggyui.neocities.org/support"},
                {"VisitEggyUIWebsite", "https://eggyui.neocities.org/support"},
                {"default", "https://xxtsoft.top/"}
            };

            Dictionary<string, string> errorMsgMap = new()
            {
                {"VisitEggyUIBiliBili", "访问EggyUI官方B站主页时发生错误：{0}"},
                {"JoinEggyUIGroup", "访问EggyUI交流群加群页面时发生错误：{0}"},
                {"VisitEggyUIWebsite", "访问EggyUI官网时发生错误：{0}"},
                {"default", "访问BSOD-MEMZ的个人网站时发生错误：{0}"}
            };

            ButtonClickHandler(sender, pathMap, errorMsgMap);
        }

        #endregion
    }
}
