namespace Candy_Crush
{
    partial class SignInForm
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
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.LogInBtn = new System.Windows.Forms.Button();
            this.cnfPasswordLbl = new System.Windows.Forms.Label();
            this.cnfPasswordTxt = new System.Windows.Forms.TextBox();
            this.goLoginPageLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameTxt
            // 
            this.usernameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.usernameTxt.Location = new System.Drawing.Point(270, 152);
            this.usernameTxt.MaxLength = 35;
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(370, 32);
            this.usernameTxt.TabIndex = 0;
            // 
            // usernameLbl
            // 
            this.usernameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.usernameLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.usernameLbl.Location = new System.Drawing.Point(94, 133);
            this.usernameLbl.MaximumSize = new System.Drawing.Size(150, 70);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(150, 70);
            this.usernameLbl.TabIndex = 4;
            this.usernameLbl.Text = "Username";
            this.usernameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passwordTxt
            // 
            this.passwordTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.passwordTxt.Location = new System.Drawing.Point(270, 260);
            this.passwordTxt.MaximumSize = new System.Drawing.Size(700, 70);
            this.passwordTxt.MaxLength = 35;
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '*';
            this.passwordTxt.Size = new System.Drawing.Size(370, 32);
            this.passwordTxt.TabIndex = 1;
            // 
            // passwordLbl
            // 
            this.passwordLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.passwordLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.passwordLbl.Location = new System.Drawing.Point(94, 241);
            this.passwordLbl.MaximumSize = new System.Drawing.Size(150, 70);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(150, 70);
            this.passwordLbl.TabIndex = 6;
            this.passwordLbl.Text = "Password";
            this.passwordLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogInBtn
            // 
            this.LogInBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LogInBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.LogInBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LogInBtn.Location = new System.Drawing.Point(112, 463);
            this.LogInBtn.Margin = new System.Windows.Forms.Padding(10);
            this.LogInBtn.MaximumSize = new System.Drawing.Size(700, 60);
            this.LogInBtn.MinimumSize = new System.Drawing.Size(300, 60);
            this.LogInBtn.Name = "LogInBtn";
            this.LogInBtn.Size = new System.Drawing.Size(528, 60);
            this.LogInBtn.TabIndex = 4;
            this.LogInBtn.Text = "Sign in";
            this.LogInBtn.UseVisualStyleBackColor = true;
            this.LogInBtn.Click += new System.EventHandler(this.LogInBtn_Click);
            // 
            // cnfPasswordLbl
            // 
            this.cnfPasswordLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.cnfPasswordLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cnfPasswordLbl.Location = new System.Drawing.Point(94, 347);
            this.cnfPasswordLbl.MaximumSize = new System.Drawing.Size(150, 70);
            this.cnfPasswordLbl.Name = "cnfPasswordLbl";
            this.cnfPasswordLbl.Size = new System.Drawing.Size(150, 70);
            this.cnfPasswordLbl.TabIndex = 9;
            this.cnfPasswordLbl.Text = "Confirm Password";
            this.cnfPasswordLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cnfPasswordTxt
            // 
            this.cnfPasswordTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.cnfPasswordTxt.Location = new System.Drawing.Point(270, 366);
            this.cnfPasswordTxt.MaximumSize = new System.Drawing.Size(700, 70);
            this.cnfPasswordTxt.MaxLength = 35;
            this.cnfPasswordTxt.Name = "cnfPasswordTxt";
            this.cnfPasswordTxt.PasswordChar = '*';
            this.cnfPasswordTxt.Size = new System.Drawing.Size(370, 32);
            this.cnfPasswordTxt.TabIndex = 3;
            // 
            // goLoginPageLbl
            // 
            this.goLoginPageLbl.AutoSize = true;
            this.goLoginPageLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goLoginPageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.goLoginPageLbl.ForeColor = System.Drawing.SystemColors.GrayText;
            this.goLoginPageLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.goLoginPageLbl.Location = new System.Drawing.Point(364, 551);
            this.goLoginPageLbl.MaximumSize = new System.Drawing.Size(150, 70);
            this.goLoginPageLbl.Name = "goLoginPageLbl";
            this.goLoginPageLbl.Size = new System.Drawing.Size(44, 18);
            this.goLoginPageLbl.TabIndex = 10;
            this.goLoginPageLbl.Text = "Login";
            this.goLoginPageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.goLoginPageLbl.Click += new System.EventHandler(this.goLoginPageLbl_Click);
            this.goLoginPageLbl.MouseEnter += new System.EventHandler(this.goLoginPageLbl_MouseEnter);
            this.goLoginPageLbl.MouseLeave += new System.EventHandler(this.goLoginPageLbl_MouseLeave);
            // 
            // SignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 653);
            this.Controls.Add(this.goLoginPageLbl);
            this.Controls.Add(this.cnfPasswordLbl);
            this.Controls.Add(this.cnfPasswordTxt);
            this.Controls.Add(this.LogInBtn);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.usernameLbl);
            this.Controls.Add(this.usernameTxt);
            this.MaximumSize = new System.Drawing.Size(800, 700);
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "SignInForm";
            this.Text = "Sign In";
            this.Load += new System.EventHandler(this.SignInForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Button LogInBtn;
        private System.Windows.Forms.Label cnfPasswordLbl;
        private System.Windows.Forms.TextBox cnfPasswordTxt;
        private System.Windows.Forms.Label goLoginPageLbl;
    }
}