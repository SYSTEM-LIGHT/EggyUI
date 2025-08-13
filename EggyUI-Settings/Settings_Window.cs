// Author：一只野生的蛋小绿_Minty（https://space.bilibili.com/1591761987）
// 注意：此设置程序尚未开发完成。部分代码由AI生成，但我作为“提示词仙人”，对代码生成过程进行了控制。后续会对代码进行测试并修正可能存在的错误。

using Microsoft.Win32;
using System.Diagnostics;
using System.Xml.Linq;
using System.IO;
using System;
using System.Collections.Generic;

namespace EggyUI_Settings
{
    public partial class Settings_Window : Form
    {
        private string RainmeterPath { get; set; } = string.Empty; // Rainmeter路径
        private string RainmeterSkinPath { get; set; } = string.Empty; // Rainmeter皮肤路径
        private string FolderBackgroundPath { get; set; } = string.Empty; // 文件夹背景目录
        private string StartAllBackPath { get; set; } = string.Empty; // 文件夹背景目录
        private string Start11Path { get; set; } = string.Empty; // 文件夹背景目录
        private readonly string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.xml");

        public Settings_Window()
        {
            LoadConfiguration();
            InitializeComponent();
        }

        private void LoadConfiguration()
        {
            // 从XML文件读取配置
            try
            {
                // 如果配置文件不存在，创建默认配置
                if (!File.Exists(configFilePath))
                {
                    CreateDefaultConfig();
                }

                // 加载配置文件
                XDocument doc = XDocument.Load(configFilePath);
                RainmeterPath = doc.Root?.Element("RainmeterPath")?.Value ?? @"C:\Windows\EggyCore\Rainmeter";
                RainmeterSkinPath = doc.Root?.Element("RainmeterSkinPath")?.Value?.Replace("%USERPROFILE%", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)) ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Rainmeter\\Skins");
                FolderBackgroundPath = doc.Root?.Element("FolderBackgroundPath")?.Value ?? @"C:\Windows\EggyCore\FolderBackground";
                StartAllBackPath = doc.Root?.Element("StartAllBackPath")?.Value ?? @"C:\Program Files\StartAllBack";
                Start11Path = doc.Root?.Element("Start11Path")?.Value ?? @"C:\Program Files (x86)\Stardock\Start11";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载配置时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // 使用默认值
                RainmeterPath = @"C:\Windows\EggyCore\Rainmeter";
                RainmeterSkinPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Rainmeter\\Skins");
                FolderBackgroundPath = @"C:\Windows\EggyCore\FolderBackground";
                StartAllBackPath = @"C:\Program Files\StartAllBack";
                Start11Path = @"C:\Program Files (x86)\Stardock\Start11";
            }
        }

        private void CreateDefaultConfig()
        {
            // 创建默认配置文件
            try
            {
                XDocument doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Settings",
                        new XElement("RainmeterPath", @"C:\Windows\EggyCore\Rainmeter"),
                        new XElement("RainmeterSkinPath", @"%USERPROFILE%\Documents\Rainmeter\Skins"),
                        new XElement("FolderBackgroundPath", @"C:\Windows\EggyCore\FolderBackground")
                    )
                );
                doc.Save(configFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"创建默认配置文件时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool TaskExists(string taskName)
        {
            try
            {
                // 使用schtasks命令行工具查询任务
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "schtasks.exe",
                    Arguments = $"/query /tn \"{taskName}\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (Process? process = Process.Start(startInfo))
                {
                    if (process == null) return false;

                    process.WaitForExit();

                    // 退出代码为0表示任务存在
                    return process.ExitCode == 0;
                }
            }
            catch
            {
                // 发生异常时默认为任务不存在
                return false;
            }
        }

        private void ReloadFolderBackgroundPic()
        {
            // 刷新文件夹背景预览图片
            string imageFolder = Path.Combine(FolderBackgroundPath, "image");
            if (Directory.Exists(imageFolder))
            {
                string[] imageFiles = Directory.GetFiles(imageFolder, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(file =>
                        file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        file.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    .ToArray();

                if (imageFiles.Length > 0)
                {
                    Random random = new Random();
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
                        MessageBox.Show($"加载图片时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Settings_Window_Load(object sender, EventArgs e)
        {
            ReloadFolderBackgroundPic();
            // 检测开始菜单修改软件是否存在
            OpenStartAllBackSettings.Enabled = File.Exists(Path.Combine(StartAllBackPath, "StartAllBackCfg.exe"));
            OpenStart11Settings.Enabled = File.Exists(Path.Combine(Start11Path, "Start11Config.exe"));
            // 检测Rainmeter计划任务是否存在
            checkBox1.Checked = TaskExists("EggyUIWidgets");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            try
            {
                // 设置Rainmeter开启启动
                Process.Start(new ProcessStartInfo
                {
                    FileName = "schtasks",
                    Arguments = box.Checked && !TaskExists("EggyUIWidgets") ? $"/create /tn EggyUIWidgets /sc onlogon /tr \"{Path.Combine(RainmeterPath, "Rainmeter.exe")}\" /f" : "/delete /tn EggyUIWidgets /f",
                    CreateNoWindow = true, // 无窗口创建进程
                    UseShellExecute = false
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"设置Rainmeter开机启动时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 通用按钮点击处理器
        private void ButtonClickHandler(object sender, EventArgs e, Dictionary<string, string> pathMap, Dictionary<string, string> errorMsgMap)
        {
            Button btn = (Button)sender;
            try
            {
                string fileName = pathMap.TryGetValue(btn.Name, out string? value) ? value : pathMap["default"];
                Process.Start(new ProcessStartInfo
                {
                    FileName = fileName,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                string errorMsg = errorMsgMap.TryGetValue(btn.Name, out string? msg) ? msg : errorMsgMap["default"];
                MessageBox.Show(string.Format(errorMsg, ex.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RainmeterSettingsButton_Click(object sender, EventArgs e)
        {
            var pathMap = new Dictionary<string, string>
            {
                { "OpenRainmeterFolder", RainmeterPath },
                { "OpenRainmeterSkinFolder", RainmeterSkinPath },
                { "default", Path.Combine(RainmeterPath, "ResetRainmeter.exe") }
            };

            var errorMsgMap = new Dictionary<string, string>
            {
                { "OpenRainmeterFolder", "打开Rainmeter文件夹时发生错误：{0}" },
                { "OpenRainmeterSkinFolder", "打开Rainmeter皮肤文件夹时发生错误：{0}" },
                { "default", "重置Rainmeter时发生错误：{0}" }
            };

            ButtonClickHandler(sender, e, pathMap, errorMsgMap);
        }

        private void FBGSettingsButton_Click(object sender, EventArgs e)
        {
            var pathMap = new Dictionary<string, string>
            {
                { "EnableFBG", Path.Combine(FolderBackgroundPath, "Register.cmd") },
                { "DisableFBG", Path.Combine(FolderBackgroundPath, "Uninstall.cmd") },
                { "default", Path.Combine(FolderBackgroundPath, "image") }
            };

            var errorMsgMap = new Dictionary<string, string>
            {
                { "EnableFBG", "开启文件夹背景功能时发生错误：{0}" },
                { "DisableFBG", "关闭文件夹背景功能时发生错误：{0}" },
                { "default", "打开文件夹背景图片目录时发生错误：{0}" }
            };

            ButtonClickHandler(sender, e, pathMap, errorMsgMap);
        }

        private void ReloadFolderBackgroundPicButton_Click(object sender, EventArgs e)
        {
            // 刷新文件夹背景预览图片
            ReloadFolderBackgroundPic();
        }

        private void OtherSettingsButton_Click(object sender, EventArgs e)
        {
            var pathMap = new Dictionary<string, string>
            {
                { "OpenStartAllBackSettings", Path.Combine(StartAllBackPath, "StartAllBackCfg.exe") },
                { "OpenStart11Settings", Path.Combine(Start11Path, "Start11Config.exe") },
                { "OpenPersonalizationSettings", "ms-settings:personalization" },
                { "default", "control" }
            };

            var errorMsgMap = new Dictionary<string, string>
            {
                { "OpenStartAllBackSettings", "打开StartAllBack设置时发生错误：{0}" },
                { "OpenStart11Settings", "打开Start11设置时发生错误：{0}" },
                { "OpenPersonalizationSettings", "打开系统个性化设置时发生错误：{0}" },
                { "default", "打开控制面板时发生错误：{0}" }
            };

            ButtonClickHandler(sender, e, pathMap, errorMsgMap);
        }
    }
}
