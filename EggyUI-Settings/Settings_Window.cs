// Author��һֻҰ���ĵ�С��_Minty��https://space.bilibili.com/1591761987��
// ��û���ꡣ

using Microsoft.Win32;
using System.Diagnostics;

namespace EggyUI_Settings
{
    public partial class Settings_Window : Form
    {
        private static string RainmeterPath = @"L:\EggyCore\Rainmeter"; // Rainmeter·��
        private static string RainmeterSkinPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Rainmeter"); // RainmeterƤ��·��
        private static string FolderBackgroundPath = @"L:\EggyCore\FolderBackground"; // �ļ��б���Ŀ¼

        public Settings_Window()
        {
            InitializeComponent();
        }

        public static bool TaskExists(string taskName)
        {
            string registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\TaskCache\Tasks";
            using (RegistryKey? key = Registry.LocalMachine.OpenSubKey(registryPath))
            {
                if (key == null) return false;

                // �����������ÿ�������Ӧһ��GUID���
                foreach (string subKeyName in key.GetSubKeyNames())
                {
                    using (RegistryKey? taskKey = key.OpenSubKey(subKeyName))
                    {
                        // �������������Ƿ�ƥ��
                        if (taskKey?.GetValue("Name")?.ToString() == taskName)
                            return true;
                    }
                }
            }
            return false;
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
            ReloadFolderBackgroundPic();
            // ���Rainmeter�ƻ������Ƿ����
            if (TaskExists("EggyUIWidgets"))
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // ����Rainmeter��������
        }

        private void RainmeterSettingsButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // �⼸����ť�������鶼�����н��̣������¼�����ɴ�ֱ��д��һ����
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = btn.Name switch
                    {
                        "OpenRainmeterFolder" => RainmeterPath, // �� Rainmeter �ļ���
                        "OpenRainmeterSkinFolder" => RainmeterSkinPath, // ��Ƥ���ļ���
                        _ => Path.Combine(RainmeterPath, "ResetRainmeter.exe") // ����Rainmeter
                    },
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show((btn.Name switch
                {
                    "OpenRainmeterFolder" => $"��Rainmeter�ļ���ʱ��������{ex.Message}",
                    "OpenRainmeterSkinFolder" => $"��RainmeterƤ���ļ���ʱ��������{ex.Message}",
                    _ => $"����Rainmeterʱ��������{ex.Message}"
                }), "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FBGSettingsButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // �⼸����ť�������鶼�����н��̣������¼�����ɴ�ֱ��д��һ����
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = btn.Name switch
                    {
                        "EnableFBG" => Path.Combine(FolderBackgroundPath, "Register.cmd"), // �����ļ��б���
                        "DisableFBG" => Path.Combine(FolderBackgroundPath, "Uninstall.cmd"), // �ر��ļ��б���
                        _ => Path.Combine(FolderBackgroundPath, "image") // ���ļ��б���ͼƬĿ¼
                    },
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show((btn.Name switch
                {
                    "EnableFBG" => $"�����ļ��б�������ʱ��������{ex.Message}",
                    "DisableFBG" => $"�ر��ļ��б�������ʱ��������{ex.Message}",
                    _ => $"���ļ��б���ͼƬĿ¼ʱ��������{ex.Message}"
                }), "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadFolderBackgroundPicButton_Click(object sender, EventArgs e)
        {
            // ˢ���ļ��б���Ԥ��ͼƬ
            ReloadFolderBackgroundPic();
        }
    }
}
