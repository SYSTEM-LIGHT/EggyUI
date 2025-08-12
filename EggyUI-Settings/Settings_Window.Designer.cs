namespace EggyUI_Settings
{
    partial class Settings_Window
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings_Window));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox3 = new GroupBox();
            groupBox2 = new GroupBox();
            ReloadFolderBackgroundPicButton = new Button();
            FolderBackgroundPic = new PictureBox();
            OpenFBGImageFolder = new Button();
            DisableFBG = new Button();
            EnableFBG = new Button();
            groupBox1 = new GroupBox();
            ResetRainmeterConfig = new Button();
            OpenRainmeterSkinFolder = new Button();
            checkBox1 = new CheckBox();
            OpenRainmeterFolder = new Button();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FolderBackgroundPic).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(450, 600);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(442, 570);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "常规设置";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(8, 283);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(426, 279);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "其它设置";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ReloadFolderBackgroundPicButton);
            groupBox2.Controls.Add(FolderBackgroundPic);
            groupBox2.Controls.Add(OpenFBGImageFolder);
            groupBox2.Controls.Add(DisableFBG);
            groupBox2.Controls.Add(EnableFBG);
            groupBox2.Location = new Point(8, 112);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(426, 165);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "文件夹背景设置";
            // 
            // ReloadFolderBackgroundPicButton
            // 
            ReloadFolderBackgroundPicButton.Location = new Point(6, 114);
            ReloadFolderBackgroundPicButton.Name = "ReloadFolderBackgroundPicButton";
            ReloadFolderBackgroundPicButton.Size = new Size(166, 40);
            ReloadFolderBackgroundPicButton.TabIndex = 5;
            ReloadFolderBackgroundPicButton.Text = "刷新预览图像";
            ReloadFolderBackgroundPicButton.UseVisualStyleBackColor = true;
            ReloadFolderBackgroundPicButton.Click += ReloadFolderBackgroundPicButton_Click;
            // 
            // FolderBackgroundPic
            // 
            FolderBackgroundPic.Image = (Image)resources.GetObject("FolderBackgroundPic.Image");
            FolderBackgroundPic.Location = new Point(178, 22);
            FolderBackgroundPic.Name = "FolderBackgroundPic";
            FolderBackgroundPic.Size = new Size(242, 132);
            FolderBackgroundPic.SizeMode = PictureBoxSizeMode.Zoom;
            FolderBackgroundPic.TabIndex = 4;
            FolderBackgroundPic.TabStop = false;
            // 
            // OpenFBGImageFolder
            // 
            OpenFBGImageFolder.Location = new Point(6, 68);
            OpenFBGImageFolder.Name = "OpenFBGImageFolder";
            OpenFBGImageFolder.Size = new Size(166, 40);
            OpenFBGImageFolder.TabIndex = 3;
            OpenFBGImageFolder.Text = "打开文件夹背景图片目录";
            OpenFBGImageFolder.UseVisualStyleBackColor = true;
            OpenFBGImageFolder.Click += FBGSettingsButton_Click;
            // 
            // DisableFBG
            // 
            DisableFBG.Location = new Point(92, 22);
            DisableFBG.Name = "DisableFBG";
            DisableFBG.Size = new Size(80, 40);
            DisableFBG.TabIndex = 2;
            DisableFBG.Text = "关闭";
            DisableFBG.UseVisualStyleBackColor = true;
            DisableFBG.Click += FBGSettingsButton_Click;
            // 
            // EnableFBG
            // 
            EnableFBG.Location = new Point(6, 22);
            EnableFBG.Name = "EnableFBG";
            EnableFBG.Size = new Size(80, 40);
            EnableFBG.TabIndex = 1;
            EnableFBG.Text = "开启";
            EnableFBG.UseVisualStyleBackColor = true;
            EnableFBG.Click += FBGSettingsButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ResetRainmeterConfig);
            groupBox1.Controls.Add(OpenRainmeterSkinFolder);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(OpenRainmeterFolder);
            groupBox1.Location = new Point(8, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(426, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rainmeter 设置";
            // 
            // ResetRainmeterConfig
            // 
            ResetRainmeterConfig.Location = new Point(288, 49);
            ResetRainmeterConfig.Name = "ResetRainmeterConfig";
            ResetRainmeterConfig.Size = new Size(132, 40);
            ResetRainmeterConfig.TabIndex = 3;
            ResetRainmeterConfig.Text = "重置 Rainmeter";
            ResetRainmeterConfig.UseVisualStyleBackColor = true;
            ResetRainmeterConfig.Click += RainmeterSettingsButton_Click;
            // 
            // OpenRainmeterSkinFolder
            // 
            OpenRainmeterSkinFolder.Location = new Point(162, 49);
            OpenRainmeterSkinFolder.Name = "OpenRainmeterSkinFolder";
            OpenRainmeterSkinFolder.Size = new Size(120, 40);
            OpenRainmeterSkinFolder.TabIndex = 2;
            OpenRainmeterSkinFolder.Text = "打开皮肤文件夹";
            OpenRainmeterSkinFolder.UseVisualStyleBackColor = true;
            OpenRainmeterSkinFolder.Click += RainmeterSettingsButton_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 22);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(138, 21);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "开机启动 Rainmeter";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // OpenRainmeterFolder
            // 
            OpenRainmeterFolder.Location = new Point(6, 49);
            OpenRainmeterFolder.Name = "OpenRainmeterFolder";
            OpenRainmeterFolder.Size = new Size(150, 40);
            OpenRainmeterFolder.TabIndex = 0;
            OpenRainmeterFolder.Text = "打开 Rainmeter 文件夹";
            OpenRainmeterFolder.UseVisualStyleBackColor = true;
            OpenRainmeterFolder.Click += RainmeterSettingsButton_Click;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(442, 570);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "关于EggyUI";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Settings_Window
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 600);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Settings_Window";
            Text = "EggyUI 设置";
            Load += Settings_Window_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FolderBackgroundPic).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private Button OpenRainmeterFolder;
        private Button ResetRainmeterConfig;
        private Button OpenRainmeterSkinFolder;
        private CheckBox checkBox1;
        private Button EnableFBG;
        private Button DisableFBG;
        private Button OpenFBGImageFolder;
        private PictureBox FolderBackgroundPic;
        private Button ReloadFolderBackgroundPicButton;
    }
}
