// Author��һֻҰ���ĵ�С��_Minty��https://space.bilibili.com/1591761987��
// ��û���ꡣ

using Microsoft.Win32;
using System.Diagnostics;

namespace EggyUI_Settings
{
    public partial class Settings_Window : Form
    {
        private static string RainmeterPath = @"C:\Program Files"; // Rainmeter·��
        private static string RainmeterSkinPath = @"%USERPROFILE%\Documents\Rainmeter"; // Rainmeter·��

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

        private void Settings_Window_Load(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            // ��Rainmeter�ļ���
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = RainmeterPath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"��Rainmeter�ļ���ʱ��������{ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ��RainmeterƤ���ļ���
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = RainmeterSkinPath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"��RainmeterƤ���ļ���ʱ��������{ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
