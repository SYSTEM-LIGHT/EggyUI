// Author：一只野生的蛋小绿_Minty（https://space.bilibili.com/1591761987）
// 还没做完。

using Microsoft.Win32;
using System.Diagnostics;

namespace EggyUI_Settings
{
    public partial class Settings_Window : Form
    {
        private static string RainmeterPath = @"C:\Program Files"; // Rainmeter路径
        private static string RainmeterSkinPath = @"%USERPROFILE%\Documents\Rainmeter"; // Rainmeter路径

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

                // 遍历所有子项（每个任务对应一个GUID子项）
                foreach (string subKeyName in key.GetSubKeyNames())
                {
                    using (RegistryKey? taskKey = key.OpenSubKey(subKeyName))
                    {
                        // 检查任务的名称是否匹配
                        if (taskKey?.GetValue("Name")?.ToString() == taskName)
                            return true;
                    }
                }
            }
            return false;
        }

        private void Settings_Window_Load(object sender, EventArgs e)
        {
            // 检测Rainmeter计划任务是否存在
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
            // 设置Rainmeter开启启动
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 打开Rainmeter文件夹
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
                MessageBox.Show($"打开Rainmeter文件夹时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 打开Rainmeter皮肤文件夹
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
                MessageBox.Show($"打开Rainmeter皮肤文件夹时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
