using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;
using System.Resources;
using System.Xml.Linq;

namespace EggyUIHelp
{
    public partial class Help_Window : Form
    {
        private bool BGMEnable;
        private SoundPlayer? player;

        public Help_Window()
        {
            InitializeComponent();
            this.Button1.Click += Button1_Click;
            this.Button2.Click += Button2_Click;
            this.Button3.Click += Button3_Click;
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            this.FormClosing += Help_Window_FormClosing;
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            BGMEnable = true;
            LoadHelpContent();
            PlayPauseBGM();
        }

        private void LoadHelpContent()
        {
            try
            {
                // 清除现有节点
                TreeView1.Nodes.Clear();
                
                // 获取XML文件路径
                string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "HelpContent.xml");
                
                // 检查文件是否存在
                if (!File.Exists(xmlPath))
                {
                    TreeView1.Nodes.Add("帮助内容文件不存在");
                    return;
                }
                
                // 加载并解析XML
                XDocument doc = XDocument.Load(xmlPath);
                var categories = doc.Descendants("Category");
                
                foreach (var category in categories)
                {
                    string categoryText = category.Attribute("Text")?.Value ?? "未命名类别";
                    TreeNode categoryNode = new TreeNode(categoryText);
                    
                    // 添加Answer元素
                    var answerElements = category.Elements("Answer");
                    foreach (var answer in answerElements)
                    {
                        string answerText = answer.Attribute("Text")?.Value ?? "无回答内容";
                        categoryNode.Nodes.Add(new TreeNode(answerText));
                    }
                    
                    // 添加Item元素
                    var itemElements = category.Elements("Item");
                    foreach (var item in itemElements)
                    {
                        string itemText = item.Attribute("Text")?.Value ?? "无项目内容";
                        categoryNode.Nodes.Add(new TreeNode(itemText));
                    }
                    
                    TreeView1.Nodes.Add(categoryNode);
                }
                
                TreeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                TreeView1.Nodes.Add($"加载帮助内容时出错: {ex.Message}");
            }
        }

        private void Button3_Click(object? sender, EventArgs e)
        {
            PlayPauseBGM();
        }

        private void PlayPauseBGM()
        {
            if (BGMEnable)
            {
                // 尝试从嵌入资源加载音频
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "EggyUIHelp.Resources.BGM.wav";

                using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        Button3.Text = "关闭音乐";
                        player = new SoundPlayer(stream);
                        player.PlayLooping();
                        BGMEnable = false;
                        return;
                    }
                }

                // 如果嵌入资源加载失败，尝试从文件系统加载
                if (File.Exists("BGM.wav"))
                {
                    Button3.Text = "关闭音乐";
                    player = new SoundPlayer("BGM.wav");
                    player.PlayLooping();
                    BGMEnable = false;
                }
                else
                {
                    Button3.Text = "开启音乐";
                    Button3.Enabled = false;
                }
            }
            else
            {
                Button3.Text = "开启音乐";
                if (player != null)
                {
                    player.Stop();
                    player.Dispose();
                    player = null;
                }
                BGMEnable = true;
            }
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://qr16.cn/DlarsA",
                    UseShellExecute = true
                });
            }
            catch
            {
                MessageBox.Show("无法打开浏览器，请手动访问该链接");
            }
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e != null && e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Help_Window_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }
    }
}