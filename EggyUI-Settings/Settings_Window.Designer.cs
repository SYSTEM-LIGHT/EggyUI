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
            tabControl1.Margin = new Padding(4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(579, 706);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4);
            tabPage1.Size = new Size(571, 673);
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
            groupBox3.Location = new Point(10, 386);
            groupBox3.Margin = new Padding(4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4);
            groupBox3.Size = new Size(548, 275);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "其它设置";
            // 
            // OpenLusrmgrMsc
            // 
            OpenLusrmgrMsc.Location = new Point(278, 135);
            OpenLusrmgrMsc.Margin = new Padding(4);
            OpenLusrmgrMsc.Name = "OpenLusrmgrMsc";
            OpenLusrmgrMsc.Size = new Size(262, 47);
            OpenLusrmgrMsc.TabIndex = 11;
            OpenLusrmgrMsc.Text = "打开本地用户和组";
            OpenLusrmgrMsc.UseVisualStyleBackColor = true;
            OpenLusrmgrMsc.Click += OtherSettingsButton_Click;
            // 
            // OpenGpeditMsc
            // 
            OpenGpeditMsc.Location = new Point(8, 135);
            OpenGpeditMsc.Margin = new Padding(4);
            OpenGpeditMsc.Name = "OpenGpeditMsc";
            OpenGpeditMsc.Size = new Size(262, 47);
            OpenGpeditMsc.TabIndex = 10;
            OpenGpeditMsc.Text = "打开组策略编辑器";
            OpenGpeditMsc.UseVisualStyleBackColor = true;
            OpenGpeditMsc.Click += OtherSettingsButton_Click;
            // 
            // OpenControl
            // 
            OpenControl.Location = new Point(278, 80);
            OpenControl.Margin = new Padding(4);
            OpenControl.Name = "OpenControl";
            OpenControl.Size = new Size(262, 47);
            OpenControl.TabIndex = 9;
            OpenControl.Text = "打开控制面板";
            OpenControl.UseVisualStyleBackColor = true;
            OpenControl.Click += OtherSettingsButton_Click;
            // 
            // OpenPersonalizationSettings
            // 
            OpenPersonalizationSettings.Location = new Point(8, 80);
            OpenPersonalizationSettings.Margin = new Padding(4);
            OpenPersonalizationSettings.Name = "OpenPersonalizationSettings";
            OpenPersonalizationSettings.Size = new Size(262, 47);
            OpenPersonalizationSettings.TabIndex = 8;
            OpenPersonalizationSettings.Text = "打开系统个性化设置";
            OpenPersonalizationSettings.UseVisualStyleBackColor = true;
            OpenPersonalizationSettings.Click += OtherSettingsButton_Click;
            // 
            // OpenStart11Settings
            // 
            OpenStart11Settings.Location = new Point(278, 26);
            OpenStart11Settings.Margin = new Padding(4);
            OpenStart11Settings.Name = "OpenStart11Settings";
            OpenStart11Settings.Size = new Size(262, 47);
            OpenStart11Settings.TabIndex = 7;
            OpenStart11Settings.Text = "打开Start11设置";
            OpenStart11Settings.UseVisualStyleBackColor = true;
            OpenStart11Settings.Click += OtherSettingsButton_Click;
            // 
            // OpenStartAllBackSettings
            // 
            OpenStartAllBackSettings.Location = new Point(8, 26);
            OpenStartAllBackSettings.Margin = new Padding(4);
            OpenStartAllBackSettings.Name = "OpenStartAllBackSettings";
            OpenStartAllBackSettings.Size = new Size(262, 47);
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
            groupBox2.Location = new Point(10, 185);
            groupBox2.Margin = new Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4);
            groupBox2.Size = new Size(548, 194);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "文件夹背景设置";
            // 
            // ReloadFolderBackgroundPicButton
            // 
            ReloadFolderBackgroundPicButton.Location = new Point(8, 134);
            ReloadFolderBackgroundPicButton.Margin = new Padding(4);
            ReloadFolderBackgroundPicButton.Name = "ReloadFolderBackgroundPicButton";
            ReloadFolderBackgroundPicButton.Size = new Size(213, 47);
            ReloadFolderBackgroundPicButton.TabIndex = 5;
            ReloadFolderBackgroundPicButton.Text = "刷新预览图像";
            ReloadFolderBackgroundPicButton.UseVisualStyleBackColor = true;
            ReloadFolderBackgroundPicButton.Click += ReloadFolderBackgroundPicButton_Click;
            // 
            // FolderBackgroundPic
            // 
            FolderBackgroundPic.Image = (Image)resources.GetObject("FolderBackgroundPic.Image");
            FolderBackgroundPic.Location = new Point(229, 26);
            FolderBackgroundPic.Margin = new Padding(4);
            FolderBackgroundPic.Name = "FolderBackgroundPic";
            FolderBackgroundPic.Size = new Size(311, 155);
            FolderBackgroundPic.SizeMode = PictureBoxSizeMode.Zoom;
            FolderBackgroundPic.TabIndex = 4;
            FolderBackgroundPic.TabStop = false;
            // 
            // OpenFBGImageFolder
            // 
            OpenFBGImageFolder.Location = new Point(8, 80);
            OpenFBGImageFolder.Margin = new Padding(4);
            OpenFBGImageFolder.Name = "OpenFBGImageFolder";
            OpenFBGImageFolder.Size = new Size(213, 47);
            OpenFBGImageFolder.TabIndex = 3;
            OpenFBGImageFolder.Text = "打开文件夹背景图片目录";
            OpenFBGImageFolder.UseVisualStyleBackColor = true;
            OpenFBGImageFolder.Click += FBGSettingsButton_Click;
            // 
            // DisableFBG
            // 
            DisableFBG.Location = new Point(118, 26);
            DisableFBG.Margin = new Padding(4);
            DisableFBG.Name = "DisableFBG";
            DisableFBG.Size = new Size(103, 47);
            DisableFBG.TabIndex = 2;
            DisableFBG.Text = "关闭";
            DisableFBG.UseVisualStyleBackColor = true;
            DisableFBG.Click += FBGSettingsButton_Click;
            // 
            // EnableFBG
            // 
            EnableFBG.Location = new Point(8, 26);
            EnableFBG.Margin = new Padding(4);
            EnableFBG.Name = "EnableFBG";
            EnableFBG.Size = new Size(103, 47);
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
            groupBox1.Location = new Point(10, 7);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(548, 171);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rainmeter 设置";
            // 
            // InstallRainmeterSkin
            // 
            InstallRainmeterSkin.Location = new Point(8, 112);
            InstallRainmeterSkin.Margin = new Padding(4);
            InstallRainmeterSkin.Name = "InstallRainmeterSkin";
            InstallRainmeterSkin.Size = new Size(262, 47);
            InstallRainmeterSkin.TabIndex = 4;
            InstallRainmeterSkin.Text = "安装 .rmskin 皮肤包";
            InstallRainmeterSkin.UseVisualStyleBackColor = true;
            InstallRainmeterSkin.Click += RainmeterSettingsButton_Click;
            // 
            // ResetRainmeterConfig
            // 
            ResetRainmeterConfig.Location = new Point(278, 112);
            ResetRainmeterConfig.Margin = new Padding(4);
            ResetRainmeterConfig.Name = "ResetRainmeterConfig";
            ResetRainmeterConfig.Size = new Size(262, 47);
            ResetRainmeterConfig.TabIndex = 3;
            ResetRainmeterConfig.Text = "重置 Rainmeter";
            ResetRainmeterConfig.UseVisualStyleBackColor = true;
            ResetRainmeterConfig.Click += ResetRainmeterButton_Click;
            // 
            // OpenRainmeterSkinFolder
            // 
            OpenRainmeterSkinFolder.Location = new Point(278, 58);
            OpenRainmeterSkinFolder.Margin = new Padding(4);
            OpenRainmeterSkinFolder.Name = "OpenRainmeterSkinFolder";
            OpenRainmeterSkinFolder.Size = new Size(262, 47);
            OpenRainmeterSkinFolder.TabIndex = 2;
            OpenRainmeterSkinFolder.Text = "打开皮肤文件夹";
            OpenRainmeterSkinFolder.UseVisualStyleBackColor = true;
            OpenRainmeterSkinFolder.Click += RainmeterSettingsButton_Click;
            // 
            // CheckRainmeterStartup
            // 
            CheckRainmeterStartup.AutoSize = true;
            CheckRainmeterStartup.Location = new Point(8, 26);
            CheckRainmeterStartup.Margin = new Padding(4);
            CheckRainmeterStartup.Name = "CheckRainmeterStartup";
            CheckRainmeterStartup.Size = new Size(170, 24);
            CheckRainmeterStartup.TabIndex = 1;
            CheckRainmeterStartup.Text = "开机启动 Rainmeter";
            CheckRainmeterStartup.UseVisualStyleBackColor = true;
            CheckRainmeterStartup.CheckedChanged += CheckRainmeterStartup_CheckedChanged;
            // 
            // OpenRainmeterFolder
            // 
            OpenRainmeterFolder.Location = new Point(8, 58);
            OpenRainmeterFolder.Margin = new Padding(4);
            OpenRainmeterFolder.Name = "OpenRainmeterFolder";
            OpenRainmeterFolder.Size = new Size(262, 47);
            OpenRainmeterFolder.TabIndex = 0;
            OpenRainmeterFolder.Text = "打开 Rainmeter 文件夹";
            OpenRainmeterFolder.UseVisualStyleBackColor = true;
            OpenRainmeterFolder.Click += RainmeterSettingsButton_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox5);
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4);
            tabPage2.Size = new Size(571, 673);
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
            groupBox5.Location = new Point(10, 526);
            groupBox5.Margin = new Padding(4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(4);
            groupBox5.Size = new Size(548, 135);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "EggyUI 相关链接";
            // 
            // VisitBSODMEMZWebsite
            // 
            VisitBSODMEMZWebsite.Location = new Point(282, 80);
            VisitBSODMEMZWebsite.Margin = new Padding(4);
            VisitBSODMEMZWebsite.Name = "VisitBSODMEMZWebsite";
            VisitBSODMEMZWebsite.Size = new Size(262, 47);
            VisitBSODMEMZWebsite.TabIndex = 10;
            VisitBSODMEMZWebsite.Text = "访问 BSOD-MEMZ 的官方网站";
            VisitBSODMEMZWebsite.UseVisualStyleBackColor = true;
            VisitBSODMEMZWebsite.Click += EggyUILinkButtonClick;
            // 
            // VisitEggyUIWebsite
            // 
            VisitEggyUIWebsite.Location = new Point(8, 80);
            VisitEggyUIWebsite.Margin = new Padding(4);
            VisitEggyUIWebsite.Name = "VisitEggyUIWebsite";
            VisitEggyUIWebsite.Size = new Size(262, 47);
            VisitEggyUIWebsite.TabIndex = 9;
            VisitEggyUIWebsite.Text = "访问 EggyUI 官网";
            VisitEggyUIWebsite.UseVisualStyleBackColor = true;
            VisitEggyUIWebsite.Click += EggyUILinkButtonClick;
            // 
            // JoinEggyUIGroup
            // 
            JoinEggyUIGroup.Location = new Point(278, 26);
            JoinEggyUIGroup.Margin = new Padding(4);
            JoinEggyUIGroup.Name = "JoinEggyUIGroup";
            JoinEggyUIGroup.Size = new Size(262, 47);
            JoinEggyUIGroup.TabIndex = 8;
            JoinEggyUIGroup.Text = "加入 EggyUI 交流群";
            JoinEggyUIGroup.UseVisualStyleBackColor = true;
            JoinEggyUIGroup.Click += EggyUILinkButtonClick;
            // 
            // VisitEggyUIBiliBili
            // 
            VisitEggyUIBiliBili.Location = new Point(8, 26);
            VisitEggyUIBiliBili.Margin = new Padding(4);
            VisitEggyUIBiliBili.Name = "VisitEggyUIBiliBili";
            VisitEggyUIBiliBili.Size = new Size(262, 47);
            VisitEggyUIBiliBili.TabIndex = 7;
            VisitEggyUIBiliBili.Text = "EggyUI 官方B站账号";
            VisitEggyUIBiliBili.UseVisualStyleBackColor = true;
            VisitEggyUIBiliBili.Click += EggyUILinkButtonClick;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(VersionInfoText);
            groupBox4.Controls.Add(VersionPic);
            groupBox4.Location = new Point(10, 7);
            groupBox4.Margin = new Padding(4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(4);
            groupBox4.Size = new Size(548, 512);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "关于 EggyUI";
            // 
            // VersionInfoText
            // 
            VersionInfoText.BackColor = SystemColors.Window;
            VersionInfoText.BorderStyle = BorderStyle.None;
            VersionInfoText.Dock = DockStyle.Fill;
            VersionInfoText.Location = new Point(4, 106);
            VersionInfoText.Margin = new Padding(4);
            VersionInfoText.Name = "VersionInfoText";
            VersionInfoText.ReadOnly = true;
            VersionInfoText.Size = new Size(540, 402);
            VersionInfoText.TabIndex = 1;
            VersionInfoText.Text = "EggyUI 当前版本：v3.5\nby EggyUI 项目组";
            // 
            // VersionPic
            // 
            VersionPic.Dock = DockStyle.Top;
            VersionPic.Image = (Image)resources.GetObject("VersionPic.Image");
            VersionPic.Location = new Point(4, 24);
            VersionPic.Margin = new Padding(4);
            VersionPic.Name = "VersionPic";
            VersionPic.Size = new Size(540, 82);
            VersionPic.SizeMode = PictureBoxSizeMode.Zoom;
            VersionPic.TabIndex = 0;
            VersionPic.TabStop = false;
            // 
            // Settings_Window
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 706);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
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
