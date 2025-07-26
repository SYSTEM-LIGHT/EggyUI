namespace EggyUIHelp
{
    partial class Help_Window : Form
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help_Window));
            Label1 = new Label();
            TreeView1 = new TreeView();
            Button1 = new Button();
            Button2 = new Button();
            Button3 = new Button();
            SuspendLayout();
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.BackColor = Color.Transparent;
            Label1.Font = new Font("方正兰亭圆简体_准", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Label1.Location = new Point(60, 48);
            Label1.Name = "Label1";
            Label1.Size = new Size(395, 27);
            Label1.TabIndex = 0;
            Label1.Text = "已列出部分常见问题，希望能帮助您~";
            // 
            // TreeView1
            // 
            TreeView1.BackColor = SystemColors.Window;
            TreeView1.Font = new Font("方正兰亭圆简体_准", 9F);
            TreeView1.Location = new Point(60, 78);
            TreeView1.Margin = new Padding(3, 4, 3, 4);
            TreeView1.Name = "TreeView1";
            TreeView1.Size = new Size(644, 276);
            TreeView1.TabIndex = 1;
            // 
            // Button1
            // 
            Button1.Font = new Font("方正兰亭圆简体_准", 9F);
            Button1.Location = new Point(600, 362);
            Button1.Margin = new Padding(3, 4, 3, 4);
            Button1.Name = "Button1";
            Button1.Size = new Size(104, 29);
            Button1.TabIndex = 2;
            Button1.Text = "关闭本窗口";
            Button1.UseVisualStyleBackColor = true;
            // 
            // Button2
            // 
            Button2.Font = new Font("方正兰亭圆简体_准", 9F);
            Button2.Location = new Point(500, 362);
            Button2.Margin = new Padding(3, 4, 3, 4);
            Button2.Name = "Button2";
            Button2.Size = new Size(94, 29);
            Button2.TabIndex = 3;
            Button2.Text = "联机帮助";
            Button2.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            Button3.Font = new Font("方正兰亭圆简体_准", 9F);
            Button3.Location = new Point(400, 362);
            Button3.Margin = new Padding(3, 4, 3, 4);
            Button3.Name = "Button3";
            Button3.Size = new Size(94, 29);
            Button3.TabIndex = 4;
            Button3.Text = "关闭音乐";
            Button3.UseVisualStyleBackColor = true;
            // 
            // Help_Window
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(765, 425);
            Controls.Add(Button3);
            Controls.Add(Button2);
            Controls.Add(Button1);
            Controls.Add(TreeView1);
            Controls.Add(Label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Help_Window";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "手册";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TreeView TreeView1;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Button Button3;
    }
}