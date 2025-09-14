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
            OpenLusrmgrMsc = new Button();
            OpenGpeditMsc = new Button();
            OpenControl = new Button();
            OpenPersonalizationSettings = new Button();
            OpenStart11Settings = new Button();
            OpenStartAllBackSettings = new Button();
            groupBox2 = new GroupBox();
            ReloadFolderBackgroundPicButton = new Button();
            FolderBackgroundPic = new PictureBox();
            OpenFBGImageFolder = new Button();
            DisableFBG = new Button();
            EnableFBG = new Button();
            groupBox1 = new GroupBox();
            InstallRainmeterSkin = new Button();
            ResetRainmeterConfig = new Button();
            OpenRainmeterSkinFolder = new Button();
            CheckRainmeterStartup = new CheckBox();
            OpenRainmeterFolder = new Button();
            tabPage2 = new TabPage();
            groupBox5 = new GroupBox();
            VisitBSODMEMZWebsite = new Button();
            VisitEggyUIWebsite = new Button();
            JoinEggyUIGroup = new Button();
            VisitEggyUIBiliBili = new Button();
            groupBox4 = new GroupBox();
            VersionInfoText = new RichTextBox();
            VersionPic = new PictureBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FolderBackgroundPic).BeginInit();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VersionPic).BeginInit();
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
            groupBox3.Controls.Add(OpenLusrmgrMsc);
            groupBox3.Controls.Add(OpenGpeditMsc);
            groupBox3.Controls.Add(OpenControl);
            groupBox3.Controls.Add(OpenPersonalizationSettings);
            groupBox3.Controls.Add(OpenStart11Settings);
            groupBox3.Controls.Add(OpenStartAllBackSettings);
            groupBox3.Location = new Point(8, 328);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(426, 234);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "其它设置";
            // 
            // OpenLusrmgrMsc
            // 
            OpenLusrmgrMsc.Location = new Point(216, 115);
            OpenLusrmgrMsc.Name = "OpenLusrmgrMsc";
            OpenLusrmgrMsc.Size = new Size(204, 40);
            OpenLusrmgrMsc.TabIndex = 11;
            OpenLusrmgrMsc.Text = "打开本地用户和组";
            OpenLusrmgrMsc.UseVisualStyleBackColor = true;
            OpenLusrmgrMsc.Click += OtherSettingsButton_Click;
            // 
            // OpenGpeditMsc
            // 
            OpenGpeditMsc.Location = new Point(6, 115);
            OpenGpeditMsc.Name = "OpenGpeditMsc";
            OpenGpeditMsc.Size = new Size(204, 40);
            OpenGpeditMsc.TabIndex = 10;
            OpenGpeditMsc.Text = "打开组策略编辑器";
            OpenGpeditMsc.UseVisualStyleBackColor = true;
            OpenGpeditMsc.Click += OtherSettingsButton_Click;
            // 
            // OpenControl
            // 
            OpenControl.Location = new Point(216, 68);
            OpenControl.Name = "OpenControl";
            OpenControl.Size = new Size(204, 40);
            OpenControl.TabIndex = 9;
            OpenControl.Text = "打开控制面板";
            OpenControl.UseVisualStyleBackColor = true;
            OpenControl.Click += OtherSettingsButton_Click;
            // 
            // OpenPersonalizationSettings
            // 
            OpenPersonalizationSettings.Location = new Point(6, 68);
            OpenPersonalizationSettings.Name = "OpenPersonalizationSettings";
            OpenPersonalizationSettings.Size = new Size(204, 40);
            OpenPersonalizationSettings.TabIndex = 8;
            OpenPersonalizationSettings.Text = "打开系统个性化设置";
            OpenPersonalizationSettings.UseVisualStyleBackColor = true;
            OpenPersonalizationSettings.Click += OtherSettingsButton_Click;
            // 
            // OpenStart11Settings
            // 
            OpenStart11Settings.Location = new Point(216, 22);
            OpenStart11Settings.Name = "OpenStart11Settings";
            OpenStart11Settings.Size = new Size(204, 40);
            OpenStart11Settings.TabIndex = 7;
            OpenStart11Settings.Text = "打开Start11设置";
            OpenStart11Settings.UseVisualStyleBackColor = true;
            OpenStart11Settings.Click += OtherSettingsButton_Click;
            // 
            // OpenStartAllBackSettings
            // 
            OpenStartAllBackSettings.Location = new Point(6, 22);
            OpenStartAllBackSettings.Name = "OpenStartAllBackSettings";
            OpenStartAllBackSettings.Size = new Size(204, 40);
            OpenStartAllBackSettings.TabIndex = 6;
            OpenStartAllBackSettings.Text = "打开StartAllBack设置";
            OpenStartAllBackSettings.UseVisualStyleBackColor = true;
            OpenStartAllBackSettings.Click += OtherSettingsButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ReloadFolderBackgroundPicButton);
            groupBox2.Controls.Add(FolderBackgroundPic);
            groupBox2.Controls.Add(OpenFBGImageFolder);
            groupBox2.Controls.Add(DisableFBG);
            groupBox2.Controls.Add(EnableFBG);
            groupBox2.Location = new Point(8, 157);
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
            groupBox1.Controls.Add(InstallRainmeterSkin);
            groupBox1.Controls.Add(ResetRainmeterConfig);
            groupBox1.Controls.Add(OpenRainmeterSkinFolder);
            groupBox1.Controls.Add(CheckRainmeterStartup);
            groupBox1.Controls.Add(OpenRainmeterFolder);
            groupBox1.Location = new Point(8, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(426, 145);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rainmeter 设置";
            // 
            // InstallRainmeterSkin
            // 
            InstallRainmeterSkin.Location = new Point(6, 95);
            InstallRainmeterSkin.Name = "InstallRainmeterSkin";
            InstallRainmeterSkin.Size = new Size(204, 40);
            InstallRainmeterSkin.TabIndex = 4;
            InstallRainmeterSkin.Text = "安装 .rmskin 皮肤包";
            InstallRainmeterSkin.UseVisualStyleBackColor = true;
            InstallRainmeterSkin.Click += RainmeterSettingsButton_Click;
            // 
            // ResetRainmeterConfig
            // 
            ResetRainmeterConfig.Location = new Point(216, 95);
            ResetRainmeterConfig.Name = "ResetRainmeterConfig";
            ResetRainmeterConfig.Size = new Size(204, 40);
            ResetRainmeterConfig.TabIndex = 3;
            ResetRainmeterConfig.Text = "重置 Rainmeter";
            ResetRainmeterConfig.UseVisualStyleBackColor = true;
            ResetRainmeterConfig.Click += ResetRainmeterButton_Click;
            // 
            // OpenRainmeterSkinFolder
            // 
            OpenRainmeterSkinFolder.Location = new Point(216, 49);
            OpenRainmeterSkinFolder.Name = "OpenRainmeterSkinFolder";
            OpenRainmeterSkinFolder.Size = new Size(204, 40);
            OpenRainmeterSkinFolder.TabIndex = 2;
            OpenRainmeterSkinFolder.Text = "打开皮肤文件夹";
            OpenRainmeterSkinFolder.UseVisualStyleBackColor = true;
            OpenRainmeterSkinFolder.Click += RainmeterSettingsButton_Click;
            // 
            // CheckRainmeterStartup
            // 
            CheckRainmeterStartup.AutoSize = true;
            CheckRainmeterStartup.Location = new Point(6, 22);
            CheckRainmeterStartup.Name = "CheckRainmeterStartup";
            CheckRainmeterStartup.Size = new Size(138, 21);
            CheckRainmeterStartup.TabIndex = 1;
            CheckRainmeterStartup.Text = "开机启动 Rainmeter";
            CheckRainmeterStartup.UseVisualStyleBackColor = true;
            CheckRainmeterStartup.CheckedChanged += CheckRainmeterStartup_CheckedChanged;
            // 
            // OpenRainmeterFolder
            // 
            OpenRainmeterFolder.Location = new Point(6, 49);
            OpenRainmeterFolder.Name = "OpenRainmeterFolder";
            OpenRainmeterFolder.Size = new Size(204, 40);
            OpenRainmeterFolder.TabIndex = 0;
            OpenRainmeterFolder.Text = "打开 Rainmeter 文件夹";
            OpenRainmeterFolder.UseVisualStyleBackColor = true;
            OpenRainmeterFolder.Click += RainmeterSettingsButton_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox5);
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(442, 570);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "关于EggyUI";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(VisitBSODMEMZWebsite);
            groupBox5.Controls.Add(VisitEggyUIWebsite);
            groupBox5.Controls.Add(JoinEggyUIGroup);
            groupBox5.Controls.Add(VisitEggyUIBiliBili);
            groupBox5.Location = new Point(8, 447);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(426, 115);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "EggyUI 相关链接";
            // 
            // VisitBSODMEMZWebsite
            // 
            VisitBSODMEMZWebsite.Location = new Point(216, 68);
            VisitBSODMEMZWebsite.Name = "VisitBSODMEMZWebsite";
            VisitBSODMEMZWebsite.Size = new Size(204, 40);
            VisitBSODMEMZWebsite.TabIndex = 10;
            VisitBSODMEMZWebsite.Text = "访问 BSOD-MEMZ 的官方网站";
            VisitBSODMEMZWebsite.UseVisualStyleBackColor = true;
            VisitBSODMEMZWebsite.Click += EggyUILinkButtonClick;
            // 
            // VisitEggyUIWebsite
            // 
            VisitEggyUIWebsite.Location = new Point(6, 68);
            VisitEggyUIWebsite.Name = "VisitEggyUIWebsite";
            VisitEggyUIWebsite.Size = new Size(204, 40);
            VisitEggyUIWebsite.TabIndex = 9;
            VisitEggyUIWebsite.Text = "访问 EggyUI 官网";
            VisitEggyUIWebsite.UseVisualStyleBackColor = true;
            VisitEggyUIWebsite.Click += EggyUILinkButtonClick;
            // 
            // JoinEggyUIGroup
            // 
            JoinEggyUIGroup.Location = new Point(216, 22);
            JoinEggyUIGroup.Name = "JoinEggyUIGroup";
            JoinEggyUIGroup.Size = new Size(204, 40);
            JoinEggyUIGroup.TabIndex = 8;
            JoinEggyUIGroup.Text = "加入 EggyUI 交流群";
            JoinEggyUIGroup.UseVisualStyleBackColor = true;
            JoinEggyUIGroup.Click += EggyUILinkButtonClick;
            // 
            // VisitEggyUIBiliBili
            // 
            VisitEggyUIBiliBili.Location = new Point(6, 22);
            VisitEggyUIBiliBili.Name = "VisitEggyUIBiliBili";
            VisitEggyUIBiliBili.Size = new Size(204, 40);
            VisitEggyUIBiliBili.TabIndex = 7;
            VisitEggyUIBiliBili.Text = "EggyUI 官方B站账号";
            VisitEggyUIBiliBili.UseVisualStyleBackColor = true;
            VisitEggyUIBiliBili.Click += EggyUILinkButtonClick;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(VersionInfoText);
            groupBox4.Controls.Add(VersionPic);
            groupBox4.Location = new Point(8, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(426, 435);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "关于 EggyUI";
            // 
            // VersionInfoText
            // 
            VersionInfoText.BackColor = SystemColors.Window;
            VersionInfoText.BorderStyle = BorderStyle.None;
            VersionInfoText.Dock = DockStyle.Fill;
            VersionInfoText.Location = new Point(3, 89);
            VersionInfoText.Name = "VersionInfoText";
            VersionInfoText.ReadOnly = true;
            VersionInfoText.Size = new Size(420, 343);
            VersionInfoText.TabIndex = 1;
            VersionInfoText.Text = "EggyUI 当前版本：v3.5\nby EggyUI 项目组";
            // 
            // VersionPic
            // 
            VersionPic.Dock = DockStyle.Top;
            VersionPic.Image = (Image)resources.GetObject("VersionPic.Image");
            VersionPic.Location = new Point(3, 19);
            VersionPic.Name = "VersionPic";
            VersionPic.Size = new Size(420, 70);
            VersionPic.SizeMode = PictureBoxSizeMode.Zoom;
            VersionPic.TabIndex = 0;
            VersionPic.TabStop = false;
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
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FolderBackgroundPic).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)VersionPic).EndInit();
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
        private CheckBox CheckRainmeterStartup;
        private Button EnableFBG;
        private Button DisableFBG;
        private Button OpenFBGImageFolder;
        private PictureBox FolderBackgroundPic;
        private Button ReloadFolderBackgroundPicButton;
        private Button OpenStart11Settings;
        private Button OpenStartAllBackSettings;
        private Button OpenPersonalizationSettings;
        private Button OpenControl;
        private Button InstallRainmeterSkin;
        private PictureBox VersionPic;
        private GroupBox groupBox4;
        private RichTextBox VersionInfoText;
        private GroupBox groupBox5;
        private Button VisitEggyUIWebsite;
        private Button JoinEggyUIGroup;
        private Button VisitEggyUIBiliBili;
        private Button VisitBSODMEMZWebsite;
        private Button OpenGpeditMsc;
        private Button OpenLusrmgrMsc;
    }
}
