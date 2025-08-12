// Author：一只野生的蛋小绿_Minty（https://space.bilibili.com/1591761987）
// 还没做完。

using Microsoft.Win32;
using System.Diagnostics;

namespace EggyUI_Settings
{
    public partial class Settings_Window : Form
    {
        private static string RainmeterPath = @"L:\EggyCore\Rainmeter"; // Rainmeter路径
        private static string RainmeterSkinPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Rainmeter"); // Rainmeter皮肤路径
        private static string FolderBackgroundPath = @"L:\EggyCore\FolderBackground"; // 文件夹背景目录

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

        private void RainmeterSettingsButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // 这几个按钮做的事情都是运行进程，所以事件处理干脆直接写到一块上
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = btn.Name switch
                    {
                        "OpenRainmeterFolder" => RainmeterPath, // 打开 Rainmeter 文件夹
                        "OpenRainmeterSkinFolder" => RainmeterSkinPath, // 打开皮肤文件夹
                        _ => Path.Combine(RainmeterPath, "ResetRainmeter.exe") // 重置Rainmeter
                    },
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show((btn.Name switch
                {
                    "OpenRainmeterFolder" => $"打开Rainmeter文件夹时发生错误：{ex.Message}",
                    "OpenRainmeterSkinFolder" => $"打开Rainmeter皮肤文件夹时发生错误：{ex.Message}",
                    _ => $"重置Rainmeter时发生错误：{ex.Message}"
                }), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FBGSettingsButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // 这几个按钮做的事情都是运行进程，所以事件处理干脆直接写到一块上
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = btn.Name switch
                    {
                        "EnableFBG" => Path.Combine(FolderBackgroundPath, "Register.cmd"), // 开启文件夹背景
                        "DisableFBG" => Path.Combine(FolderBackgroundPath, "Uninstall.cmd"), // 关闭文件夹背景
                        _ => Path.Combine(FolderBackgroundPath, "image") // 打开文件夹背景图片目录
                    },
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show((btn.Name switch
                {
                    "EnableFBG" => $"开启文件夹背景功能时发生错误：{ex.Message}",
                    "DisableFBG" => $"关闭文件夹背景功能时发生错误：{ex.Message}",
                    _ => $"打开文件夹背景图片目录时发生错误：{ex.Message}"
                }), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadFolderBackgroundPicButton_Click(object sender, EventArgs e)
        {
            // 刷新文件夹背景预览图片
            ReloadFolderBackgroundPic();
        }
    }
}
