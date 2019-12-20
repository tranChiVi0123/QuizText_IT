namespace TinHocDaiCuong.GUI
{
    partial class LogIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMSSV_LI = new System.Windows.Forms.TextBox();
            this.txtMatKhau_LI = new System.Windows.Forms.TextBox();
            this.simpleButton_Login = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu";
            // 
            // txtMSSV_LI
            // 
            this.txtMSSV_LI.Location = new System.Drawing.Point(172, 48);
            this.txtMSSV_LI.Name = "txtMSSV_LI";
            this.txtMSSV_LI.Size = new System.Drawing.Size(251, 22);
            this.txtMSSV_LI.TabIndex = 2;
            // 
            // txtMatKhau_LI
            // 
            this.txtMatKhau_LI.Location = new System.Drawing.Point(172, 101);
            this.txtMatKhau_LI.Name = "txtMatKhau_LI";
            this.txtMatKhau_LI.PasswordChar = '*';
            this.txtMatKhau_LI.Size = new System.Drawing.Size(251, 22);
            this.txtMatKhau_LI.TabIndex = 3;
            this.txtMatKhau_LI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatKhau_LI_KeyPress);
            // 
            // simpleButton_Login
            // 
            this.simpleButton_Login.AccessibleRole = System.Windows.Forms.AccessibleRole.Application;
            this.simpleButton_Login.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_Login.Appearance.Options.UseFont = true;
            this.simpleButton_Login.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_Login.ImageOptions.Image")));
            this.simpleButton_Login.ImeMode = System.Windows.Forms.ImeMode.HangulFull;
            this.simpleButton_Login.Location = new System.Drawing.Point(257, 160);
            this.simpleButton_Login.Name = "simpleButton_Login";
            this.simpleButton_Login.Size = new System.Drawing.Size(166, 45);
            this.simpleButton_Login.TabIndex = 6;
            this.simpleButton_Login.Text = "Đăng Nhập";
            this.simpleButton_Login.Click += new System.EventHandler(this.simpleButton_Login_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(453, 241);
            this.Controls.Add(this.simpleButton_Login);
            this.Controls.Add(this.txtMatKhau_LI);
            this.Controls.Add(this.txtMSSV_LI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMSSV_LI;
        private System.Windows.Forms.TextBox txtMatKhau_LI;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Login;
    }
}