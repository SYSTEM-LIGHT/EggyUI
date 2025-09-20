/*
 * ============================================================================
 * EggyUI - Windows �������������
 * �������ס������ɶԡ�UI���ķ�˿���δ������ǹٷ�������ҵ��Ŀ
 * ============================================================================
 *  
 * ����: �����С���� (SYSTEM-LIGHT)
 * ������: EggyUI �����Ŷ� (https://github.com/SYSTEM-LIGHT/EggyUI)
 * 
 * ��Ȩ���� (c) 2024-2025 EggyUI �����Ŷ�
 * 
 * ���Э��:
 * ����ĿΪ��˿�������Ͻ������κ���ҵ��;��
 * �����زľ�Ϊ�Ϸ���ȡ�������ػ棬δʹ���κ���Ϸ������ݡ�
 * 
 * ��������:
 * 1. �������΢�������޹أ�Windows �͡������ɶԡ��ֱ�Ϊ��������˾��ע���̱ꡣ
 * 2. ʹ���������ге���ʹ�ñ�������ܴ����ķ��ա�
 * 3. ��ֹ�Ա����������ҵ��ʹ�á��ַ��򼯳�����ҵ��Ʒ�С�
 * 
 * ============================================================================
 */

using System.Diagnostics;

namespace EggyUI_Settings
{
    public partial class Settings_Window : Form
    {
        #region ����������

        // ���÷���
        private readonly ConfigurationService _configurationService;

        // �����߳�ͬ���Ķ���
        private object _syncObject => new();

        // ���ڱ���Ƿ���������Rainmeter
        private bool isResetting = false;

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

        // ��ȡStartAllBack���ó���·��
        private readonly Lazy<string> _startAllBackSettingsPath;
        private string StartAllBackSettingsPath => _startAllBackSettingsPath.Value;
        
        // ��ȡStart11���ó���·��
        private readonly Lazy<string> _start11SettingsPath;
        private string Start11SettingsPath => _start11SettingsPath.Value;
        
        // ��ͼ·��
        private static readonly Lazy<string> _artWorkPath = new(() => Path.Combine(Application.StartupPath, "artwork"));
        private static string ArtWorkPath => _artWorkPath.Value;
        
        // �汾��Ϣ�ļ�·��
        private static readonly Lazy<string> _versionInfoFile = new(() => Path.Combine(ArtWorkPath, "VersionInfo.txt"));
        private static string VersionInfoFile => _versionInfoFile.Value;

        public Settings_Window()
        {
            // ʵ�������÷���
            _configurationService = new ConfigurationService();
            _configurationService.LoadConfiguration();
            
            // ��ʼ�������ص�����·��
            _startAllBackSettingsPath = new(() => Path.Combine(StartAllBackPath, "StartAllBackCfg.exe"));
            _start11SettingsPath = new(() => Path.Combine(Start11Path, "Start11Config.exe"));

            InitializeComponent();
        }

        private static bool TaskExists(string taskName)
        {
            try
            {
                // ʹ��schtasks�����й��߲�ѯ����
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
                            // ��UI�߳��ϸ���ͼƬ
                            if (picBox.InvokeRequired)
                            {
                                picBox.Invoke(new Action(() =>
                                {
                                    picBox.Image?.Dispose(); // ����ԭͼ�����
                                    picBox.Image = Image.FromFile(randomImagePath);
                                }));
                            }
                            else
                            {
                                picBox.Image?.Dispose(); // ����ԭͼ�����
                                picBox.Image = Image.FromFile(randomImagePath);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"����ͼƬʱ��������{ex.Message}", "����",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// ͨ�ð�ť���������
        /// </summary>
        /// <param name="sender">��ť����</param>
        /// <param name="pathMap">·���ֵ�</param>
        /// <param name="errorMsgMap">������Ϣ�ֵ�</param>
        /* /// <param name="argumentsMap">�����ֵ䣨��ѡ������Ĭ������Ϊ�գ�</param> */
        private static void ButtonClickHandler(
            object sender,
            Dictionary<string, string> pathMap, // ·���ֵ�
            Dictionary<string, string> errorMsgMap // ������Ϣ�ֵ�
            /* Dictionary<string, string>? argumentsMap = null // �����ֵ䣨��ѡ������Ĭ������Ϊ�գ�*/
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
                    /* Arguments = argumentsMap is not null
                    ? (argumentsMap.TryGetValue(btn.Name, out string? value1)
                    ? value1 : argumentsMap["default"])
                    : "", */
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                string errorMsg = errorMsgMap.TryGetValue(btn.Name, out string? msg)
                    ? msg : errorMsgMap["default"];
                MessageBox.Show(string.Format(errorMsg, ex.Message), "����",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region �¼��������

        private void Settings_Window_Load(object sender, EventArgs e)
        {
            // ���ذ汾ͼƬ
            string VersionImage = Path.Combine(ArtWorkPath, "EggyUI_Version.png");
            if (File.Exists(VersionImage))
                VersionPic.Image = Image.FromFile(VersionImage);

            // �����ļ��б���Ԥ��ͼ
            ReloadFolderBackgroundPic();

            // ��⵱ǰϵͳ�Ƿ��ܹ�ʹ�ñ����û����飨һ���ͥ�治���ã�
            string? lusrMgrMscPath = SpecialValue.GetValidToolPath("lusrmgr.msc");
            OpenLusrmgrMsc.Enabled = !SystemVersionChecker.IsHomeEdition()
                && lusrMgrMscPath is not null;

            // ��⵱ǰϵͳ�Ƿ��ܹ�ʹ������Ա༭��
            string? gpeditMscPath = SpecialValue.GetValidToolPath("gpedit.msc");
            OpenGpeditMsc.Enabled = gpeditMscPath is not null;

            // ��⿪ʼ�˵��޸�����Ƿ����
            OpenStartAllBackSettings.Enabled = File.Exists(StartAllBackSettingsPath)
                && SpecialValue.IsWin11; // ����Ƿ�ΪWin11
            OpenStart11Settings.Enabled = File.Exists(Start11SettingsPath)
                && !SpecialValue.IsWin10OrWin11; // ����Ƿ�ΪWin10/Win11

            // ���Rainmeter�ƻ������Ƿ����
            CheckRainmeterStartup.Checked = TaskExists("EggyUIWidgets");

            // ʹ��Task�첽��ȡ�汾��Ϣ�ļ�
            Task.Run(() =>
            {
                if (File.Exists(VersionInfoFile))
                {
                    try
                    {
                        string versionInfo = File.ReadAllText(VersionInfoFile);
                        // ��UI�߳��ϸ����ı�
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
                        Debug.WriteLine($"��ȡ�汾��Ϣ�ļ�ʱ��������{ex.Message}");
                    }
                }
            });
        }

        private void CheckRainmeterStartup_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            try
            {
                // ������ȷ���̰߳�ȫ
                lock (_syncObject)
                {
                    // ����Rainmeter��������
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "schtasks",
                        Arguments = box.Checked
                            && !TaskExists("EggyUIWidgets")
                            ? $"/create /tn EggyUIWidgets /sc onlogon /tr \"{Path.Combine(RainmeterPath, "Rainmeter.exe")}\" /f"
                            : "/delete /tn EggyUIWidgets /f",
                        CreateNoWindow = true, // �޴��ڴ�������
                        UseShellExecute = false
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"����Rainmeter��������ʱ��������{ex.Message}", "����",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetRainmeterButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("��ȷ��Ҫ����Rainmeter��", "��ʾ",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                lock (_syncObject)
                {
                    if (isResetting)
                    {
                        // ��ʾ�������ڽ�����
                        SettingsNotifyIcon.BalloonTipTitle = "��ʾ";
                        SettingsNotifyIcon.BalloonTipText = "���ò������ڽ����У����Ժ�...";
                        SettingsNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                        SettingsNotifyIcon.ShowBalloonTip(3000);
                        return;
                    }
                    isResetting = true;
                }

                ResetRainmeterConfig.Enabled = false;

                Task.Run(() =>
                {
                    try
                    {
                        ResetRainmeter reset = new(RainmeterPath, RainmeterSkinPath);
                        reset.Start();
                        // ���óɹ�����֪ͨ
                        SettingsNotifyIcon.BalloonTipTitle = "Rainmeter���óɹ�";
                        SettingsNotifyIcon.BalloonTipText = "���ɼ���ʹ��Rainmeter��";
                        SettingsNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                        SettingsNotifyIcon.ShowBalloonTip(3000);
                    }
                    catch (Exception ex)
                    {
                        // ����ʧ������֪ͨ
                        SettingsNotifyIcon.BalloonTipTitle = "Rainmeter����ʧ��";
                        SettingsNotifyIcon.BalloonTipText = $"����Rainmeterʱ��������{ex.Message}";
                        SettingsNotifyIcon.BalloonTipIcon = ToolTipIcon.Error;
                        SettingsNotifyIcon.ShowBalloonTip(3000);
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
            }
        }

        private void RainmeterSettingsButton_Click(object sender, EventArgs e)
        {
            // ·���б�
            Dictionary<string, string> pathMap = new()
            {
                { "OpenRainmeterFolder", RainmeterPath },
                { "OpenRainmeterSkinFolder", RainmeterSkinPath },
                { "default", Path.Combine(RainmeterPath, "SkinInstaller.exe") },
            };

            // ������Ϣ�б�
            Dictionary<string, string> errorMsgMap = new()
            {
                { "OpenRainmeterFolder", "��Rainmeter�ļ���ʱ��������{0}" },
                { "OpenRainmeterSkinFolder", "��RainmeterƤ���ļ���ʱ��������{0}" },
                { "default", "��װRainmeterƤ��ʱ��������{0}" },
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
                { "OpenStartAllBackSettings", StartAllBackSettingsPath },
                { "OpenStart11Settings", Start11SettingsPath },
                { "OpenPersonalizationSettings", "ms-settings:personalization" },
                { "default", "control" },
                { "OpenGpeditMsc", SpecialValue.GetValidToolPath("gpedit.msc") ?? string.Empty },
                { "OpenLusrMgrMsc", SpecialValue.GetValidToolPath("lusrmgr.msc") ?? string.Empty }
            };

            // ������Ϣ�б�
            Dictionary<string, string> errorMsgMap = new()
            {
                { "OpenStartAllBackSettings", "��StartAllBack����ʱ��������{0}" },
                { "OpenStart11Settings", "��Start11����ʱ��������{0}" },
                { "OpenPersonalizationSettings", "��ϵͳ���Ի�����ʱ��������{0}" },
                { "default", "�򿪿������ʱ��������{0}" },
                { "OpenGpeditMsc", "������Ա༭��ʱ��������{0}" },
                { "OpenLusrMgrMsc", "�򿪱����û�����ʱ��������{0}" }
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
                {"VisitEggyUIBiliBili", "����EggyUI�ٷ�Bվ��ҳʱ��������{0}"},
                {"JoinEggyUIGroup", "����EggyUI����Ⱥ��Ⱥҳ��ʱ��������{0}"},
                {"VisitEggyUIWebsite", "����EggyUI����ʱ��������{0}"},
                {"default", "����BSOD-MEMZ�ĸ�����վʱ��������{0}"}
            };

            ButtonClickHandler(sender, pathMap, errorMsgMap);
        }

        private void Quit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
