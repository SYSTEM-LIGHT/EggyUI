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

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace EggyUI_Settings
{
    public partial class Settings_Window : Form
    {
        #region 变量、方法

        public Settings_Window()
        {
            // 实例化配置服务
            _configurationService = new ConfigurationService();
            _configurationService.LoadConfiguration();
            InitializeComponent();
        }

        private readonly ConfigurationService _configurationService;

        private readonly object _syncObject = new(); // 用于线程同步的对象

        private bool isResetting = false;

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
        private static readonly string ArtWorkPath = Path.Combine(Application.StartupPath, "artwork");

        // 版本信息文件路径
        private static readonly string VersionInfoFile = Path.Combine(ArtWorkPath, "VersionInfo.txt");

        private static bool TaskExists(string taskName)
        {
            try
            {
                // 使用schtasks命令行工具查询任务
                ProcessStartInfo startInfo = new()
                {
                    FileName = "schtasks.exe",
                    Arguments = $"/query /tn \"{taskName}\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

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

        private void ReloadFolderBackgroundPic()
        {
            // 刷新文件夹背景预览图片
            string imageFolder = Path.Combine(FolderBackgroundPath, "image");
            if (Directory.Exists(imageFolder))
            {
                Span<string> imageFiles = Directory.GetFiles(imageFolder, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(file =>
                        file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        file.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    .ToArray();

                if (imageFiles.Length > 0)
                {
                    Random random = new();
                    string randomImagePath = imageFiles[random.Next(imageFiles.Length)];
                    try
                    {
                        if (this.FolderBackgroundPic is PictureBox picBox)
                        {
                            // 在UI线程上更新图片
                            if (picBox.InvokeRequired)
                            {
                                picBox.Invoke(new Action(() =>
                                {
                                    picBox.Image?.Dispose(); // 销毁原图像对象
                                    picBox.Image = Image.FromFile(randomImagePath);
                                }));
                            }
                            else
                            {
                                picBox.Image?.Dispose(); // 销毁原图像对象
                                picBox.Image = Image.FromFile(randomImagePath);
                            }
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
        private static void ButtonClickHandler(
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
                    Arguments = argumentsMap != null
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

        private void Settings_Window_Load(object sender, EventArgs e)
        {
            // 加载版本图片
            string VersionImage = Path.Combine(ArtWorkPath, "EggyUI_Version.png");
            if (File.Exists(VersionImage)) 
                VersionPic.Image = Image.FromFile(VersionImage);

            // 加载文件夹背景预览图
            ReloadFolderBackgroundPic();

            // 检测当前系统是否能够使用本地用户和组（一般家庭版不能用）
            string? lusrMgrMscPath = SpecialValue.GetValidToolPath("lusrmgr.msc");
            OpenLusrmgrMsc.Enabled = !SystemVersionChecker.IsHomeEdition() && lusrMgrMscPath != null;

            // 检测当前系统是否能够使用组策略编辑器
            string? gpeditMscPath = SpecialValue.GetValidToolPath("gpedit.msc");
            OpenGpeditMsc.Enabled = gpeditMscPath != null;

            // 检测开始菜单修改软件是否存在
            OpenStartAllBackSettings.Enabled =
                File.Exists(Path.Combine(StartAllBackPath, "StartAllBackCfg.exe"))
                && !((SpecialValue.NTVersion < 10) && (SpecialValue.BuildVersion < 22000)); // 检测是否为Win11
            OpenStart11Settings.Enabled =
                File.Exists(Path.Combine(Start11Path, "Start11Config.exe"))
                && !(SpecialValue.NTVersion < 10); // 检测是否为Win10/Win11

            // 检测Rainmeter计划任务是否存在
            CheckRainmeterStartup.Checked = TaskExists("EggyUIWidgets");

            // 使用线程异步读取版本信息文件
            Thread ReadVersionFileThread = new(() =>
            {
                if (File.Exists(VersionInfoFile))
                {
                    try
                    {
                        string versionInfo = File.ReadAllText(VersionInfoFile);
                        // 在UI线程上更新文本
                        if (VersionInfoText.InvokeRequired)
                        {
                            VersionInfoText.Invoke(new Action(() =>
                            {
                                VersionInfoText.Text = versionInfo;
                            }));
                        }
                        else
                        {
                            VersionInfoText.Text = versionInfo;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"读取版本信息文件时发生错误：{ex.Message}");
                    }
                }
            });
            ReadVersionFileThread.Start();
        }

        private void CheckRainmeterStartup_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            try
            {
                // 加锁以确保线程安全
                lock (_syncObject)
                {
                    // 设置Rainmeter开启启动
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "schtasks",
                        Arguments = box.Checked
                            && !TaskExists("EggyUIWidgets")
                            ? $"/create /tn EggyUIWidgets /sc onlogon /tr \"{Path.Combine(RainmeterPath, "Rainmeter.exe")}\" /f"
                            : "/delete /tn EggyUIWidgets /f",
                        CreateNoWindow = true, // 无窗口创建进程
                        UseShellExecute = false
                    });
                }
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

        private void ResetRainmeterButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "你确定要重置Rainmeter吗？",
                "提示",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                lock (_syncObject)
                {
                    if (isResetting) 
                    {
                        MessageBox.Show("重置操作正在进行中，请稍候...");
                        return;
                    }
                    isResetting = true;
                }

                ResetRainmeterConfig.Enabled = false;
                
                Thread ResetRainmeterThread = new(() =>
                {
                    try
                    {
                        ResetRainmeter reset = new(RainmeterPath, RainmeterSkinPath);
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
                    finally
                    {
                        lock (_syncObject)
                        {
                            isResetting = false;
                        }
                        ResetRainmeterConfig.Invoke((Action)(() => ResetRainmeterConfig.Enabled = true));
                    }
                });
                ResetRainmeterThread.Start();
            }
        }

        private void RainmeterSettingsButton_Click(object sender, EventArgs e)
        {
            // 路径列表
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

        private void FBGSettingsButton_Click(object sender, EventArgs e)
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

        private void ReloadFolderBackgroundPicButton_Click(object sender, EventArgs e)
        {
            // 刷新文件夹背景预览图片
            ReloadFolderBackgroundPic();
        }

        private void OtherSettingsButton_Click(object sender, EventArgs e)
        {
            // 路径列表
            Dictionary<string, string> pathMap = new()
            {
                { "OpenStartAllBackSettings", Path.Combine(StartAllBackPath, "StartAllBackCfg.exe") },
                { "OpenStart11Settings", Path.Combine(Start11Path, "Start11Config.exe") },
                { "OpenPersonalizationSettings", "ms-settings:personalization" },
                { "default", "control" },
                { "OpenGpeditMsc", SpecialValue.GetValidToolPath("gpedit.msc") ?? string.Empty },
                { "OpenLusrMgrMsc", SpecialValue.GetValidToolPath("lusrmgr.msc") ?? string.Empty }
            };

            // 错误信息列表
            Dictionary<string, string> errorMsgMap = new()
            {
                { "OpenStartAllBackSettings", "打开StartAllBack设置时发生错误：{0}" },
                { "OpenStart11Settings", "打开Start11设置时发生错误：{0}" },
                { "OpenPersonalizationSettings", "打开系统个性化设置时发生错误：{0}" },
                { "default", "打开控制面板时发生错误：{0}" },
                { "OpenGpeditMsc", "打开组策略编辑器时发生错误：{0}" },
                { "OpenLusrMgrMsc", "打开本地用户和组时发生错误：{0}" }
            };

            ButtonClickHandler(sender, pathMap, errorMsgMap);
        }

        private void EggyUILinkButtonClick(object sender, EventArgs e)
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
