// Author��һֻҰ���ĵ�С��_Minty��https://space.bilibili.com/1591761987��

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
            // ʵ�������÷���
            _configurationService = new ConfigurationService();
            _configurationService.LoadConfiguration();
            InitializeComponent();
        }

        // ��ȡRainmeter·��
        private string RainmeterPath => _configurationService.RainmeterPath;

        // ��ȡRainmeterƤ��·��
        private string RainmeterSkinPath => _configurationService.RainmeterSkinPath;

        // ��ȡ�ļ��б���Ŀ¼
        private string FolderBackgroundPath => _configurationService.FolderBackgroundPath;

        // ��ȡStartAllBack·��
        private string StartAllBackPath => _configurationService.StartAllBackPath;

        // ��ȡStart11·��
        private string Start11Path => _configurationService.Start11Path;

        // ��ͼ·��
        private string ArtWorkPath = Path.Combine(Application.StartupPath, "artwork");

        public static bool TaskExists(string taskName)
        {
            try
            {
                // ʹ��schtasks�����й��߲�ѯ����
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

                    // �˳�����Ϊ0��ʾ�������
                    return process.ExitCode == 0;
                }
            }
            catch
            {
                // �����쳣ʱĬ��Ϊ���񲻴���
                return false;
            }
        }

        private void ReloadFolderBackgroundPic()
        {
            // ˢ���ļ��б���Ԥ��ͼƬ
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
                            picBox.Image?.Dispose(); // ����ԭͼ�����
                            picBox.Image = Image.FromFile(randomImagePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"����ͼƬʱ��������{ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Settings_Window_Load(object sender, EventArgs e)
        {
            string VersionImage = Path.Combine(ArtWorkPath, "EggyUI_Version.png");
            if (File.Exists(VersionImage)) VersionPic.Image = Image.FromFile(VersionImage);
            ReloadFolderBackgroundPic();
            // ��⿪ʼ�˵��޸�����Ƿ����
            OpenStartAllBackSettings.Enabled = File.Exists(Path.Combine(StartAllBackPath, "StartAllBackCfg.exe"));
            OpenStart11Settings.Enabled = File.Exists(Path.Combine(Start11Path, "Start11Config.exe"));
            // ���Rainmeter�ƻ������Ƿ����
            checkBox1.Checked = TaskExists("EggyUIWidgets");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            try
            {
                // ����Rainmeter��������
                Process.Start(new ProcessStartInfo
                {
                    FileName = "schtasks",
                    Arguments = box.Checked && !TaskExists("EggyUIWidgets") ? $"/create /tn EggyUIWidgets /sc onlogon /tr \"{Path.Combine(RainmeterPath, "Rainmeter.exe")}\" /f" : "/delete /tn EggyUIWidgets /f",
                    CreateNoWindow = true, // �޴��ڴ�������
                    UseShellExecute = false
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"����Rainmeter��������ʱ��������{ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ͨ�ð�ť���������
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
                MessageBox.Show(string.Format(errorMsg, ex.Message), "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RainmeterSettingsButton_Click(object sender, EventArgs e)
        {
            // ·���б�
            var pathMap = new Dictionary<string, string>
            {
                { "OpenRainmeterFolder", RainmeterPath },
                { "OpenRainmeterSkinFolder", RainmeterSkinPath },
                { "InstallRainmeterSkin", Path.Combine(RainmeterPath, "SkinInstaller.exe") },
                { "default", Path.Combine(RainmeterPath, "ResetRainmeter.exe") }
            };

            // ������Ϣ�б�
            var errorMsgMap = new Dictionary<string, string>
            {
                { "OpenRainmeterFolder", "��Rainmeter�ļ���ʱ��������{0}" },
                { "OpenRainmeterSkinFolder", "��RainmeterƤ���ļ���ʱ��������{0}" },
                { "InstallRainmeterSkin", "��װRainmeterƤ��ʱ��������{0}" },
                { "default", "����Rainmeterʱ��������{0}" }
            };

            ButtonClickHandler(sender, e, pathMap, errorMsgMap);
        }

        private void FBGSettingsButton_Click(object sender, EventArgs e)
        {
            // ·���б�
            var pathMap = new Dictionary<string, string>
            {
                { "EnableFBG", Path.Combine(FolderBackgroundPath, "Register.cmd") },
                { "DisableFBG", Path.Combine(FolderBackgroundPath, "Uninstall.cmd") },
                { "default", Path.Combine(FolderBackgroundPath, "image") }
            };

            // ������Ϣ�б�
            var errorMsgMap = new Dictionary<string, string>
            {
                { "EnableFBG", "�����ļ��б�������ʱ��������{0}" },
                { "DisableFBG", "�ر��ļ��б�������ʱ��������{0}" },
                { "default", "���ļ��б���ͼƬĿ¼ʱ��������{0}" }
            };

            ButtonClickHandler(sender, e, pathMap, errorMsgMap);
        }

        private void ReloadFolderBackgroundPicButton_Click(object sender, EventArgs e)
        {
            // ˢ���ļ��б���Ԥ��ͼƬ
            ReloadFolderBackgroundPic();
        }

        private void OtherSettingsButton_Click(object sender, EventArgs e)
        {
            // ·���б�
            var pathMap = new Dictionary<string, string>
            {
                { "OpenStartAllBackSettings", Path.Combine(StartAllBackPath, "StartAllBackCfg.exe") },
                { "OpenStart11Settings", Path.Combine(Start11Path, "Start11Config.exe") },
                { "OpenPersonalizationSettings", "ms-settings:personalization" },
                { "default", "control" }
            };

            // ������Ϣ�б�
            var errorMsgMap = new Dictionary<string, string>
            {
                { "OpenStartAllBackSettings", "��StartAllBack����ʱ��������{0}" },
                { "OpenStart11Settings", "��Start11����ʱ��������{0}" },
                { "OpenPersonalizationSettings", "��ϵͳ���Ի�����ʱ��������{0}" },
                { "default", "�򿪿������ʱ��������{0}" }
            };

            ButtonClickHandler(sender, e, pathMap, errorMsgMap);
        }
    }
}
