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
using System.IO;
using System.Xml.Linq;
using System.Windows.Forms;

namespace EggyUI_Settings
{
    /// <summary>
    /// 配置服务的实现类
    /// </summary>
    public class ConfigurationService
    {
        private readonly string configFilePath;

        public string RainmeterPath { get; set; } = string.Empty;
        public string RainmeterSkinPath { get; set; } = string.Empty;
        public string FolderBackgroundPath { get; set; } = string.Empty;
        public string StartAllBackPath { get; set; } = string.Empty;
        public string Start11Path { get; set; } = string.Empty;

        public ConfigurationService()
        {
            configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.xml");
        }

        public void LoadConfiguration()
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
                RainmeterSkinPath = doc.Root?.Element("RainmeterSkinPath")?.Value?.Replace("%USERPROFILE%",
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile))
                    ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                    @"Rainmeter\Skins");
                FolderBackgroundPath = doc.Root?.Element("FolderBackgroundPath")?.Value
                    ?? @"C:\Windows\EggyCore\FolderBackground";
                StartAllBackPath = doc.Root?.Element("StartAllBackPath")?.Value
                    ?? @"C:\Program Files\StartAllBack";
                Start11Path = doc.Root?.Element("Start11Path")?.Value
                    ?? @"C:\Program Files (x86)\Stardock\Start11";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载配置时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // 使用默认值
                RainmeterPath = @"C:\Windows\EggyCore\Rainmeter";
                RainmeterSkinPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                    @"Rainmeter\Skins");
                FolderBackgroundPath = @"C:\Windows\EggyCore\FolderBackground";
                StartAllBackPath = @"C:\Program Files\StartAllBack";
                Start11Path = @"C:\Program Files (x86)\Stardock\Start11";
            }
        }

        public void CreateDefaultConfig()
        {
            // 创建默认配置文件
            try
            {
                XDocument doc = new(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Settings",
                        new XElement("RainmeterPath", @"C:\Windows\EggyCore\Rainmeter"),
                        new XElement("RainmeterSkinPath", @"%USERPROFILE%\Documents\Rainmeter\Skins"),
                        new XElement("FolderBackgroundPath", @"C:\Windows\EggyCore\FolderBackground"),
                        new XElement("StartAllBackPath", @"C:\Program Files\StartAllBack"),
                        new XElement("Start11Path", @"C:\Program Files (x86)\Stardock\Start11")
                    )
                );
                doc.Save(configFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"创建默认配置文件时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 此方法暂时用不到，先注释掉
        // public void SaveConfiguration()
        // {
        //     // 保存配置到XML文件
        //     try
        //     {
        //         XDocument doc = new XDocument(
        //             new XDeclaration("1.0", "utf-8", "yes"),
        //             new XElement("Settings",
        //                 new XElement("RainmeterPath", RainmeterPath),
        //                 new XElement("RainmeterSkinPath", RainmeterSkinPath.Replace(
        //                     Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "%USERPROFILE%")),
        //                 new XElement("FolderBackgroundPath", FolderBackgroundPath),
        //                 new XElement("StartAllBackPath", StartAllBackPath),
        //                 new XElement("Start11Path", Start11Path)
        //             )
        //         );
        //         doc.Save(configFilePath);
        //     }
        //     catch (Exception ex)
        //     {
        //         System.Windows.Forms.MessageBox.Show($"保存配置文件时发生错误：{ex.Message}", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        //     }
        // }
    }
}