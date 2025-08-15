// Author�������ɶ�Զ������https://space.bilibili.com/1591761987��
// �����������д��붼�ϸ���.NET 8�ı�׼��д�������˸ð汾������ִ��﷨���ԣ�
// �Ա�֤����߱����ߵĿɶ��ԡ�����Ժ����ܣ�ͬʱҲ�������µ�.NET�������ơ�
// �����ҵ�һ�ν������Ŀ�����Դ����������ܲ��Ǻܸߣ������һ�Ŭ���Ľ��ġ�
// ���⣬�������ʹ����һЩ�첽�������е����ࣩ������߳������Ӧ���ܡ�
// ���ò�˵GitHub����Ӧ�ٶ������������ʱ�������ύ���Ķ��ύ���ˣ���ֻ�ܵ�����Ӧ�˲�֪���Ƿ��ύ�ɹ���

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
        private static readonly string ArtWorkPath = Path.Combine(Application.StartupPath, "artwork");

        // �汾��Ϣ�ļ�·��
        private static readonly string VersionInfoFile = Path.Combine(ArtWorkPath, "VersionInfo.txt");

        public static bool TaskExists(string taskName)
        {
            try
            {
                // ʹ��schtasks�����й��߲�ѯ����
                // ���������ΪʲôҪʹ��schtasks.exe������ֱ��ʹ��Task�ࣿ
                // ��ΪTask����.NET 8�������ԣ���ֻ����Windows 11�����У���schtasks.exe������Windows�汾�϶�����
                // ���⣬����ʹ����new()��ʼ��ProcessStartInfo������.NET 8�������ԣ������Ա����ڴ����
                // ͬʱ������ʹ����CreateNoWindow = true������Ϊ�˱��ⴴ���µĴ���
                // �������ʹ����RedirectStandardOutput = true��RedirectStandardError = true������Ϊ�˻�ȡ���������
                ProcessStartInfo startInfo = new()
                {
                    FileName = "schtasks.exe",
                    Arguments = $"/query /tn \"{taskName}\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                // ����ʹ���˼򻯵�using��䣬��������ʽ����Dispose()����
                // ͬʱ������ʹ����null���������������˿������쳣
                using Process? process = Process.Start(startInfo);
                if (process == null) return false;
                process.WaitForExit();
                // �˳�����Ϊ0��ʾ�������
                return process.ExitCode == 0;
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
                // Span<string> ��Ч�� string[]���� Span ��ջ�Ϸ���ģ��� string[] �Ƕ��Ϸ����
                // ����ʹ�� Span ��Ϊ�˱����ڴ���䣬�������
                Span<string> imageFiles = Directory.GetFiles(imageFolder, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(file =>
                        file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        file.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    .ToArray();

                if (imageFiles.Length > 0)
                {
                    // ���������ΪʲôҪ��new()������new Random()��
                    // ��Ϊnew()��.NET 8�������ԣ������Զ�ʹ���̰߳�ȫ�������������
                    // ��new Random()�ڶ��̻߳����¿��ܻᵼ��������ظ�
                    Random random = new();
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

        private static async Task<string> VersionInfo() // ���ذ汾��Ϣ
        {
            if (File.Exists(VersionInfoFile))
            {
                try
                {
                    return await File.ReadAllTextAsync(VersionInfoFile);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"��ȡ�汾��Ϣ�ļ�ʱ��������{ex.Message}");
                    return string.Empty;
                }
            }
            return string.Empty;
        }

        // ���ڼ����¼������Ҹĳ����첽������߳������Ӧ����
        private async void Settings_Window_Load(object sender, EventArgs e)
        {
            // ���ذ汾ͼƬ
            string VersionImage = Path.Combine(ArtWorkPath, "EggyUI_Version.png");
            if (File.Exists(VersionImage)) VersionPic.Image = Image.FromFile(VersionImage);
            // �����ļ��б���Ԥ��ͼ
            ReloadFolderBackgroundPic();
            // ��⿪ʼ�˵��޸�����Ƿ����
            OpenStartAllBackSettings.Enabled = File.Exists(Path.Combine(StartAllBackPath, "StartAllBackCfg.exe"));
            OpenStart11Settings.Enabled = File.Exists(Path.Combine(Start11Path, "Start11Config.exe"));
            // ���Rainmeter�ƻ������Ƿ����
            CheckRainmeterStartup.Checked = TaskExists("EggyUIWidgets");
            // �����첽������ȡ�汾��Ϣ�������ı���
            if (File.Exists(VersionInfoFile))
            {
                VersionInfoText.Text = await VersionInfo();
            }
        }

        private void CheckRainmeterStartup_CheckedChanged(object sender, EventArgs e)
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
        /// <summary>
        /// ͨ�ð�ť���������
        /// </summary>
        /// <param name="sender">��ť����</param>
        /// <param name="pathMap">·���ֵ�</param>
        /// <param name="errorMsgMap">������Ϣ�ֵ�</param>
        /// <param name="argumentsMap">�����ֵ䣨��ѡ������Ĭ������Ϊ�գ�</param>
        private static void ButtonClickHandler(
            object sender,
            Dictionary<string, string> pathMap, // ·���ֵ�
            Dictionary<string, string> errorMsgMap, // ������Ϣ�ֵ�
            Dictionary<string, string>? argumentsMap = null // �����ֵ䣨��ѡ������Ĭ������Ϊ�գ�
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
            // ����ʹ���� .NET 8 ���ִ��﷨���� new() ����ʼ���ֵ䣬���Ǵ�ͳ�� new Dictionary<string, string>��
            // ���﷨�� .NET 8 ����������ƶ����ԣ��������ܹ����ݱ��������Զ��ƶϳ�����ķ������ͣ�
            // �Ӷ��ô�����Ӽ���׶���ͬʱ����������������������������Ƶ��ֵ��ʼ������Ҳ��������ͬ���ִ��﷨��
            Dictionary<string, string> pathMap = new()
            {
                { "OpenRainmeterFolder", RainmeterPath },
                { "OpenRainmeterSkinFolder", RainmeterSkinPath },
                { "InstallRainmeterSkin", Path.Combine(RainmeterPath, "SkinInstaller.exe") },
                { "default", Path.Combine(RainmeterPath, "ResetRainmeter.exe") }
            };

            // ������Ϣ�б�
            Dictionary<string, string> errorMsgMap = new()
            {
                { "OpenRainmeterFolder", "��Rainmeter�ļ���ʱ��������{0}" },
                { "OpenRainmeterSkinFolder", "��RainmeterƤ���ļ���ʱ��������{0}" },
                { "InstallRainmeterSkin", "��װRainmeterƤ��ʱ��������{0}" },
                { "default", "����Rainmeterʱ��������{0}" }
            };

            ButtonClickHandler(sender, pathMap, errorMsgMap);
        }

        private void FBGSettingsButton_Click(object sender, EventArgs e)
        {
            // ·���б�
            Dictionary<string, string> pathMap = new()
            {
                { "EnableFBG", Path.Combine(FolderBackgroundPath, "Register.cmd") },
                { "DisableFBG", Path.Combine(FolderBackgroundPath, "Uninstall.cmd") },
                { "default", Path.Combine(FolderBackgroundPath, "image") }
            };

            // ������Ϣ�б�
            Dictionary<string, string> errorMsgMap = new()
            {
                { "EnableFBG", "�����ļ��б�������ʱ��������{0}" },
                { "DisableFBG", "�ر��ļ��б�������ʱ��������{0}" },
                { "default", "���ļ��б���ͼƬĿ¼ʱ��������{0}" }
            };

            ButtonClickHandler(sender, pathMap, errorMsgMap);
        }

        private void ReloadFolderBackgroundPicButton_Click(object sender, EventArgs e)
        {
            // ˢ���ļ��б���Ԥ��ͼƬ
            ReloadFolderBackgroundPic();
        }

        private void OtherSettingsButton_Click(object sender, EventArgs e)
        {
            // ·���б�
            Dictionary<string, string> pathMap = new()
            {
                { "OpenStartAllBackSettings", Path.Combine(StartAllBackPath, "StartAllBackCfg.exe") },
                { "OpenStart11Settings", Path.Combine(Start11Path, "Start11Config.exe") },
                { "OpenPersonalizationSettings", "ms-settings:personalization" },
                { "default", "control" }
            };

            // ������Ϣ�б�
            Dictionary<string, string> errorMsgMap = new()
            {
                { "OpenStartAllBackSettings", "��StartAllBack����ʱ��������{0}" },
                { "OpenStart11Settings", "��Start11����ʱ��������{0}" },
                { "OpenPersonalizationSettings", "��ϵͳ���Ի�����ʱ��������{0}" },
                { "default", "�򿪿������ʱ��������{0}" }
            };

            ButtonClickHandler(sender, pathMap, errorMsgMap);
        }

        private void EggyUILinkButtonClick(object sender, EventArgs e)
        {
            Dictionary<string, string> pathMap = new()
            {
                {"VisitEggyUIBiliBili", "https://space.bilibili.com/3546563248916693"},
                {"default", "https://eggyui.neocities.org/support"}
            };

            Dictionary<string, string> errorMsgMap = new()
            {
                {"VisitEggyUIBiliBili", "����EggyUI�ٷ�Bվ��ҳʱ��������{0}"},
                {"default", "����EggyUI����Ⱥ��Ⱥҳ��ʱ��������{0}"}
            };

            ButtonClickHandler(sender, pathMap, errorMsgMap);
        }
    }
}
