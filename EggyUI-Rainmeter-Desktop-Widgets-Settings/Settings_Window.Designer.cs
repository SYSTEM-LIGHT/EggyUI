// Settings_Window.Designer.cs
namespace ERWS
{
    partial class Settings_Window
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings_Window));
            Panel1 = new Panel();
            panel2 = new Panel();
            header12 = new PictureBox();
            header11 = new PictureBox();
            header10 = new PictureBox();
            header9 = new PictureBox();
            header6 = new PictureBox();
            header5 = new PictureBox();
            header4 = new PictureBox();
            customheader = new PictureBox();
            header8 = new PictureBox();
            header7 = new PictureBox();
            header3 = new PictureBox();
            header2 = new PictureBox();
            header1 = new PictureBox();
            selectcustomheader = new OpenFileDialog();
            mainheader = new PictureBox();
            Label1 = new Label();
            Button1 = new Button();
            Label2 = new Label();
            PictureBox1 = new PictureBox();
            PictureBox2 = new PictureBox();
            ContextMenuStrip1 = new ContextMenuStrip(components);
            ToolStripMenuItem1 = new ToolStripMenuItem();
            Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)header12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)header11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)header10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)header9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)header6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)header5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)header4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customheader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)header8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)header7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)header3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)header2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)header1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mainheader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).BeginInit();
            ContextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // Panel1
            // 
            Panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Panel1.AutoScroll = true;
            Panel1.BackColor = Color.FromArgb(15, 108, 230);
            Panel1.Controls.Add(panel2);
            Panel1.Controls.Add(header12);
            Panel1.Controls.Add(header11);
            Panel1.Controls.Add(header10);
            Panel1.Controls.Add(header9);
            Panel1.Controls.Add(header6);
            Panel1.Controls.Add(header5);
            Panel1.Controls.Add(header4);
            Panel1.Controls.Add(customheader);
            Panel1.Controls.Add(header8);
            Panel1.Controls.Add(header7);
            Panel1.Controls.Add(header3);
            Panel1.Controls.Add(header2);
            Panel1.Controls.Add(header1);
            Panel1.Location = new Point(10, 220);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size(400, 400);
            Panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Location = new Point(30, 630);
            panel2.Name = "panel2";
            panel2.Size = new Size(50, 30);
            panel2.TabIndex = 13;
            // 
            // header12
            // 
            header12.BackgroundImageLayout = ImageLayout.None;
            header12.Image = (Image)resources.GetObject("header12.Image");
            header12.Location = new Point(290, 420);
            header12.Name = "header12";
            header12.Size = new Size(80, 80);
            header12.SizeMode = PictureBoxSizeMode.Zoom;
            header12.TabIndex = 12;
            header12.TabStop = false;
            header12.Click += Header_Click;
            // 
            // header11
            // 
            header11.BackgroundImageLayout = ImageLayout.None;
            header11.Image = (Image)resources.GetObject("header11.Image");
            header11.Location = new Point(160, 420);
            header11.Name = "header11";
            header11.Size = new Size(80, 80);
            header11.SizeMode = PictureBoxSizeMode.Zoom;
            header11.TabIndex = 11;
            header11.TabStop = false;
            header11.Click += Header_Click;
            // 
            // header10
            // 
            header10.BackgroundImageLayout = ImageLayout.None;
            header10.Image = (Image)resources.GetObject("header10.Image");
            header10.Location = new Point(30, 420);
            header10.Name = "header10";
            header10.Size = new Size(80, 80);
            header10.SizeMode = PictureBoxSizeMode.Zoom;
            header10.TabIndex = 10;
            header10.TabStop = false;
            header10.Click += Header_Click;
            // 
            // header9
            // 
            header9.BackgroundImageLayout = ImageLayout.None;
            header9.Image = (Image)resources.GetObject("header9.Image");
            header9.Location = new Point(290, 290);
            header9.Name = "header9";
            header9.Size = new Size(80, 80);
            header9.SizeMode = PictureBoxSizeMode.Zoom;
            header9.TabIndex = 9;
            header9.TabStop = false;
            header9.Click += Header_Click;
            // 
            // header6
            // 
            header6.BackgroundImageLayout = ImageLayout.None;
            header6.Image = (Image)resources.GetObject("header6.Image");
            header6.Location = new Point(290, 160);
            header6.Name = "header6";
            header6.Size = new Size(80, 80);
            header6.SizeMode = PictureBoxSizeMode.Zoom;
            header6.TabIndex = 8;
            header6.TabStop = false;
            header6.Click += Header_Click;
            // 
            // header5
            // 
            header5.BackgroundImageLayout = ImageLayout.None;
            header5.Image = (Image)resources.GetObject("header5.Image");
            header5.Location = new Point(160, 160);
            header5.Name = "header5";
            header5.Size = new Size(80, 80);
            header5.SizeMode = PictureBoxSizeMode.Zoom;
            header5.TabIndex = 7;
            header5.TabStop = false;
            header5.Click += Header_Click;
            // 
            // header4
            // 
            header4.BackgroundImageLayout = ImageLayout.None;
            header4.Image = (Image)resources.GetObject("header4.Image");
            header4.Location = new Point(30, 160);
            header4.Name = "header4";
            header4.Size = new Size(80, 80);
            header4.SizeMode = PictureBoxSizeMode.Zoom;
            header4.TabIndex = 6;
            header4.TabStop = false;
            header4.Click += Header_Click;
            // 
            // customheader
            // 
            customheader.BackgroundImageLayout = ImageLayout.None;
            customheader.Image = (Image)resources.GetObject("customheader.Image");
            customheader.Location = new Point(30, 550);
            customheader.Name = "customheader";
            customheader.Size = new Size(80, 80);
            customheader.SizeMode = PictureBoxSizeMode.Zoom;
            customheader.TabIndex = 5;
            customheader.TabStop = false;
            customheader.Click += customheader_Click;
            // 
            // header8
            // 
            header8.BackgroundImageLayout = ImageLayout.None;
            header8.Image = (Image)resources.GetObject("header8.Image");
            header8.Location = new Point(160, 290);
            header8.Name = "header8";
            header8.Size = new Size(80, 80);
            header8.SizeMode = PictureBoxSizeMode.Zoom;
            header8.TabIndex = 4;
            header8.TabStop = false;
            header8.Click += Header_Click;
            // 
            // header7
            // 
            header7.BackgroundImageLayout = ImageLayout.None;
            header7.Image = (Image)resources.GetObject("header7.Image");
            header7.Location = new Point(30, 290);
            header7.Name = "header7";
            header7.Size = new Size(80, 80);
            header7.SizeMode = PictureBoxSizeMode.Zoom;
            header7.TabIndex = 3;
            header7.TabStop = false;
            header7.Click += Header_Click;
            // 
            // header3
            // 
            header3.BackgroundImageLayout = ImageLayout.None;
            header3.Image = (Image)resources.GetObject("header3.Image");
            header3.Location = new Point(290, 30);
            header3.Name = "header3";
            header3.Size = new Size(80, 80);
            header3.SizeMode = PictureBoxSizeMode.Zoom;
            header3.TabIndex = 2;
            header3.TabStop = false;
            header3.Click += Header_Click;
            // 
            // header2
            // 
            header2.BackgroundImageLayout = ImageLayout.None;
            header2.Image = (Image)resources.GetObject("header2.Image");
            header2.Location = new Point(160, 30);
            header2.Name = "header2";
            header2.Size = new Size(80, 80);
            header2.SizeMode = PictureBoxSizeMode.Zoom;
            header2.TabIndex = 1;
            header2.TabStop = false;
            header2.Click += Header_Click;
            // 
            // header1
            // 
            header1.BackgroundImageLayout = ImageLayout.None;
            header1.Image = (Image)resources.GetObject("header1.Image");
            header1.Location = new Point(30, 30);
            header1.Name = "header1";
            header1.Size = new Size(80, 80);
            header1.SizeMode = PictureBoxSizeMode.Zoom;
            header1.TabIndex = 0;
            header1.TabStop = false;
            header1.Click += Header_Click;
            // 
            // selectcustomheader
            // 
            selectcustomheader.Filter = "受支持的图片文件|*.png;";
            selectcustomheader.Title = "选择自定义头像";
            // 
            // mainheader
            // 
            mainheader.BackColor = Color.Transparent;
            mainheader.BackgroundImageLayout = ImageLayout.Zoom;
            mainheader.Location = new Point(10, 10);
            mainheader.Name = "mainheader";
            mainheader.Size = new Size(96, 96);
            mainheader.SizeMode = PictureBoxSizeMode.Zoom;
            mainheader.TabIndex = 1;
            mainheader.TabStop = false;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.BackColor = Color.Transparent;
            Label1.Font = new Font("方正兰亭圆简体_粗", 24F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Label1.ForeColor = Color.White;
            Label1.Location = new Point(112, 10);
            Label1.Name = "Label1";
            Label1.Size = new Size(260, 46);
            Label1.TabIndex = 2;
            Label1.Text = "玩家名六个字";
            // 
            // Button1
            // 
            Button1.Font = new Font("方正兰亭圆简体_粗", 12F);
            Button1.Location = new Point(120, 66);
            Button1.Name = "Button1";
            Button1.Size = new Size(150, 40);
            Button1.TabIndex = 3;
            Button1.Text = "更改昵称";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += changeNameButton_Click;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.BackColor = Color.Transparent;
            Label2.Font = new Font("方正兰亭圆简体_粗", 16.2F);
            Label2.ForeColor = Color.Transparent;
            Label2.Location = new Point(12, 185);
            Label2.Name = "Label2";
            Label2.Size = new Size(182, 32);
            Label2.TabIndex = 4;
            Label2.Text = "选择一个头像";
            // 
            // PictureBox1
            // 
            PictureBox1.BackColor = Color.Transparent;
            PictureBox1.Image = (Image)resources.GetObject("PictureBox1.Image");
            PictureBox1.Location = new Point(34, 112);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(160, 65);
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox1.TabIndex = 5;
            PictureBox1.TabStop = false;
            // 
            // PictureBox2
            // 
            PictureBox2.BackColor = Color.Transparent;
            PictureBox2.Image = (Image)resources.GetObject("PictureBox2.Image");
            PictureBox2.Location = new Point(212, 112);
            PictureBox2.Name = "PictureBox2";
            PictureBox2.Size = new Size(168, 65);
            PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox2.TabIndex = 6;
            PictureBox2.TabStop = false;
            PictureBox2.Click += PictureBox2_Click;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.ImageScalingSize = new Size(20, 20);
            ContextMenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem1 });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.Size = new Size(244, 28);
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size(243, 24);
            ToolStripMenuItem1.Text = "重置此Rainmeter小组件";
            ToolStripMenuItem1.Click += ToolStripMenuItem1_Click;
            // 
            // Settings_Window
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(420, 630);
            ContextMenuStrip = ContextMenuStrip1;
            Controls.Add(PictureBox2);
            Controls.Add(PictureBox1);
            Controls.Add(Label2);
            Controls.Add(Button1);
            Controls.Add(Panel1);
            Controls.Add(Label1);
            Controls.Add(mainheader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Settings_Window";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "鸡蛋鸭蛋荷包蛋";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)header12).EndInit();
            ((System.ComponentModel.ISupportInitialize)header11).EndInit();
            ((System.ComponentModel.ISupportInitialize)header10).EndInit();
            ((System.ComponentModel.ISupportInitialize)header9).EndInit();
            ((System.ComponentModel.ISupportInitialize)header6).EndInit();
            ((System.ComponentModel.ISupportInitialize)header5).EndInit();
            ((System.ComponentModel.ISupportInitialize)header4).EndInit();
            ((System.ComponentModel.ISupportInitialize)customheader).EndInit();
            ((System.ComponentModel.ISupportInitialize)header8).EndInit();
            ((System.ComponentModel.ISupportInitialize)header7).EndInit();
            ((System.ComponentModel.ISupportInitialize)header3).EndInit();
            ((System.ComponentModel.ISupportInitialize)header2).EndInit();
            ((System.ComponentModel.ISupportInitialize)header1).EndInit();
            ((System.ComponentModel.ISupportInitialize)mainheader).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).EndInit();
            ContextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.PictureBox header6;
        private System.Windows.Forms.PictureBox header5;
        private System.Windows.Forms.PictureBox header4;
        private System.Windows.Forms.PictureBox customheader;
        private System.Windows.Forms.PictureBox header8;
        private System.Windows.Forms.PictureBox header7;
        private System.Windows.Forms.PictureBox header3;
        private System.Windows.Forms.PictureBox header2;
        private System.Windows.Forms.PictureBox header1;
        private System.Windows.Forms.OpenFileDialog selectcustomheader;
        private System.Windows.Forms.PictureBox mainheader;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.PictureBox PictureBox2;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
        private Panel panel2;
        private PictureBox header12;
        private PictureBox header11;
        private PictureBox header10;
        private PictureBox header9;
    }
}