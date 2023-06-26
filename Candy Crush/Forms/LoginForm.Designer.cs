namespace Candy_Crush
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.LogInBtn = new System.Windows.Forms.Button();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.goSingInPageLbl = new System.Windows.Forms.Label();
            this.eyePass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogInBtn
            // 
            resources.ApplyResources(this.LogInBtn, "LogInBtn");
            this.LogInBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.LogInBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LogInBtn.Name = "LogInBtn";
            this.LogInBtn.UseVisualStyleBackColor = false;
            this.LogInBtn.Click += new System.EventHandler(this.LogInBtn_Click);
            // 
            // passwordTxt
            // 
            this.passwordTxt.AllowDrop = true;
            resources.ApplyResources(this.passwordTxt, "passwordTxt");
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.UseSystemPasswordChar = true;
            this.passwordTxt.TextChanged += new System.EventHandler(this.passwordTxt_TextChanged);
            // 
            // usernameLbl
            // 
            resources.ApplyResources(this.usernameLbl, "usernameLbl");
            this.usernameLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.usernameLbl.Name = "usernameLbl";
            // 
            // passwordLbl
            // 
            resources.ApplyResources(this.passwordLbl, "passwordLbl");
            this.passwordLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.passwordLbl.Name = "passwordLbl";
            // 
            // usernameTxt
            // 
            resources.ApplyResources(this.usernameTxt, "usernameTxt");
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.TextChanged += new System.EventHandler(this.usernameTxt_TextChanged);
            // 
            // goSingInPageLbl
            // 
            resources.ApplyResources(this.goSingInPageLbl, "goSingInPageLbl");
            this.goSingInPageLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goSingInPageLbl.ForeColor = System.Drawing.SystemColors.GrayText;
            this.goSingInPageLbl.Name = "goSingInPageLbl";
            this.goSingInPageLbl.Click += new System.EventHandler(this.goSingInPageLbl_Click);
            this.goSingInPageLbl.MouseEnter += new System.EventHandler(this.goSingInPageLbl_MouseEnter);
            this.goSingInPageLbl.MouseLeave += new System.EventHandler(this.goSingInPageLbl_MouseLeave);
            this.goSingInPageLbl.MouseHover += new System.EventHandler(this.goSingInPageLbl_MouseHover);
            // 
            // eyePass
            // 
            this.eyePass.BackgroundImage = global::Candy_Crush.Properties.Resources.eye_unhide;
            resources.ApplyResources(this.eyePass, "eyePass");
            this.eyePass.Name = "eyePass";
            this.eyePass.UseVisualStyleBackColor = true;
            this.eyePass.Click += new System.EventHandler(this.eyePass_Click);
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.eyePass);
            this.Controls.Add(this.goSingInPageLbl);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.usernameLbl);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.LogInBtn);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogInBtn;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.Label goSingInPageLbl;
        private System.Windows.Forms.Button eyePass;
    }
}

