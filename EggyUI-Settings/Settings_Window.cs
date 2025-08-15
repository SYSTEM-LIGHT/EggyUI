// Author：一只野生的蛋小绿_Minty（https://space.bilibili.com/1591761987）

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
        private readonly ConfigurationService _configurationService;

        public Settings_Window()
        {
            // 实例化配置服务
            _configurationService = new ConfigurationService();
            _configurationService.LoadConfiguration();
            InitializeComponent();
        }

        // 获取Rainmeter路径
        private string RainmeterPath => _configurationService.RainmeterPath;

        // 获取Rainmeter皮肤路径
        private string RainmeterSkinPath => _configurationService.RainmeterSkinPath;

        // 获取文件夹背景目录
        private string FolderBackgroundPath => _configurationService.FolderBackgroundPath;

        // 获取StartAllBack路径
        private string StartAllBackPath => _configurationService.StartAllBackPath;

        // 获取Start11路径
        private string Start11Path => _configurationService.Start11Path;

        // 贴图路径
        private string ArtWorkPath = Path.Combine(Application.StartupPath, "artwork");

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
            string VersionImage = Path.Combine(ArtWorkPath, "EggyUI_Version.png");
            if (File.Exists(VersionImage)) VersionPic.Image = Image.FromFile(VersionImage);
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
        private void ButtonClickHandler(
            object sender, 
            EventArgs e, 
            Dictionary<string, string> pathMap, 
            Dictionary<string, string> errorMsgMap,
            Dictionary<string, string>? argumentsMap = null
            )
        {
            Button btn = (Button)sender;
            try
            {
                string fileName = pathMap.TryGetValue(btn.Name, out string? value) ? value : pathMap["default"];
                Process.Start(new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = argumentsMap is not null ? (argumentsMap.TryGetValue(btn.Name, out string? value1) ? value1 : argumentsMap["default"]) : "",
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
            // 路径列表
            var pathMap = new Dictionary<string, string>
            {
                { "OpenRainmeterFolder", RainmeterPath },
                { "OpenRainmeterSkinFolder", RainmeterSkinPath },
                { "InstallRainmeterSkin", Path.Combine(RainmeterPath, "SkinInstaller.exe") },
                { "default", Path.Combine(RainmeterPath, "ResetRainmeter.exe") }
            };

            // 错误信息列表
            var errorMsgMap = new Dictionary<string, string>
            {
                { "OpenRainmeterFolder", "打开Rainmeter文件夹时发生错误：{0}" },
                { "OpenRainmeterSkinFolder", "打开Rainmeter皮肤文件夹时发生错误：{0}" },
                { "InstallRainmeterSkin", "安装Rainmeter皮肤时发生错误：{0}" },
                { "default", "重置Rainmeter时发生错误：{0}" }
            };

            ButtonClickHandler(sender, e, pathMap, errorMsgMap);
        }

        private void FBGSettingsButton_Click(object sender, EventArgs e)
        {
            // 路径列表
            var pathMap = new Dictionary<string, string>
            {
                { "EnableFBG", Path.Combine(FolderBackgroundPath, "Register.cmd") },
                { "DisableFBG", Path.Combine(FolderBackgroundPath, "Uninstall.cmd") },
                { "default", Path.Combine(FolderBackgroundPath, "image") }
            };

            // 错误信息列表
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
            // 路径列表
            var pathMap = new Dictionary<string, string>
            {
                { "OpenStartAllBackSettings", Path.Combine(StartAllBackPath, "StartAllBackCfg.exe") },
                { "OpenStart11Settings", Path.Combine(Start11Path, "Start11Config.exe") },
                { "OpenPersonalizationSettings", "ms-settings:personalization" },
                { "default", "control" }
            };

            // 错误信息列表
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
