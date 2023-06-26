namespace Candy_Crush.Forms
{
    partial class MainMenuForm
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
            this.SinglePlayerBtn = new System.Windows.Forms.Button();
            this.TowPlayerBtn = new System.Windows.Forms.Button();
            this.friendRequestBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.recordValLbl = new System.Windows.Forms.Label();
            this.recordLbl = new System.Windows.Forms.Label();
            this.losesValLbl = new System.Windows.Forms.Label();
            this.losesLbl = new System.Windows.Forms.Label();
            this.winsvalLbl = new System.Windows.Forms.Label();
            this.winsLbl = new System.Windows.Forms.Label();
            this.playerNameValLbl = new System.Windows.Forms.Label();
            this.playerNameLbl = new System.Windows.Forms.Label();
            this.candyCrushLbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SinglePlayerBtn
            // 
            this.SinglePlayerBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.SinglePlayerBtn.Font = new System.Drawing.Font("Microsoft Uighur", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SinglePlayerBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SinglePlayerBtn.Location = new System.Drawing.Point(561, 194);
            this.SinglePlayerBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SinglePlayerBtn.Name = "SinglePlayerBtn";
            this.SinglePlayerBtn.Size = new System.Drawing.Size(350, 350);
            this.SinglePlayerBtn.TabIndex = 0;
            this.SinglePlayerBtn.Text = "Single Player";
            this.SinglePlayerBtn.UseVisualStyleBackColor = false;
            this.SinglePlayerBtn.Click += new System.EventHandler(this.SinglePlayerBtn_Click);
            this.SinglePlayerBtn.Paint += new System.Windows.Forms.PaintEventHandler(this.SinglePlayerBtn_Paint_1);
            // 
            // TowPlayerBtn
            // 
            this.TowPlayerBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TowPlayerBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.TowPlayerBtn.Font = new System.Drawing.Font("Microsoft Uighur", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TowPlayerBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TowPlayerBtn.Location = new System.Drawing.Point(561, 574);
            this.TowPlayerBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TowPlayerBtn.Name = "TowPlayerBtn";
            this.TowPlayerBtn.Size = new System.Drawing.Size(350, 81);
            this.TowPlayerBtn.TabIndex = 1;
            this.TowPlayerBtn.Text = "Two Player";
            this.TowPlayerBtn.UseVisualStyleBackColor = false;
            this.TowPlayerBtn.Click += new System.EventHandler(this.TowPlayerBtn_Click);
            // 
            // friendRequestBtn
            // 
            this.friendRequestBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.friendRequestBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.friendRequestBtn.Font = new System.Drawing.Font("Microsoft Uighur", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friendRequestBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.friendRequestBtn.Location = new System.Drawing.Point(561, 683);
            this.friendRequestBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.friendRequestBtn.Name = "friendRequestBtn";
            this.friendRequestBtn.Size = new System.Drawing.Size(337, 81);
            this.friendRequestBtn.TabIndex = 2;
            this.friendRequestBtn.Text = "Friend Request";
            this.friendRequestBtn.UseVisualStyleBackColor = false;
            this.friendRequestBtn.Click += new System.EventHandler(this.friendRequestBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.logoutBtn.BackgroundImage = global::Candy_Crush.Properties.Resources.logout;
            this.logoutBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoutBtn.Font = new System.Drawing.Font("Microsoft Uighur", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.logoutBtn.Location = new System.Drawing.Point(1217, 33);
            this.logoutBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(69, 70);
            this.logoutBtn.TabIndex = 3;
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.recordValLbl);
            this.panel1.Controls.Add(this.recordLbl);
            this.panel1.Controls.Add(this.losesValLbl);
            this.panel1.Controls.Add(this.losesLbl);
            this.panel1.Controls.Add(this.winsvalLbl);
            this.panel1.Controls.Add(this.winsLbl);
            this.panel1.Controls.Add(this.playerNameValLbl);
            this.panel1.Controls.Add(this.playerNameLbl);
            this.panel1.Location = new System.Drawing.Point(23, 122);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 656);
            this.panel1.TabIndex = 4;
            // 
            // recordValLbl
            // 
            this.recordValLbl.AutoSize = true;
            this.recordValLbl.Font = new System.Drawing.Font("Grasping", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordValLbl.ForeColor = System.Drawing.Color.LightGray;
            this.recordValLbl.Location = new System.Drawing.Point(153, 545);
            this.recordValLbl.Name = "recordValLbl";
            this.recordValLbl.Size = new System.Drawing.Size(26, 28);
            this.recordValLbl.TabIndex = 12;
            this.recordValLbl.Text = "2";
            // 
            // recordLbl
            // 
            this.recordLbl.AutoSize = true;
            this.recordLbl.Font = new System.Drawing.Font("Grasping", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordLbl.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.recordLbl.Location = new System.Drawing.Point(87, 488);
            this.recordLbl.Name = "recordLbl";
            this.recordLbl.Size = new System.Drawing.Size(153, 45);
            this.recordLbl.TabIndex = 11;
            this.recordLbl.Text = "Record";
            // 
            // losesValLbl
            // 
            this.losesValLbl.AutoSize = true;
            this.losesValLbl.Font = new System.Drawing.Font("Grasping", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losesValLbl.ForeColor = System.Drawing.Color.LightGray;
            this.losesValLbl.Location = new System.Drawing.Point(149, 393);
            this.losesValLbl.Name = "losesValLbl";
            this.losesValLbl.Size = new System.Drawing.Size(26, 28);
            this.losesValLbl.TabIndex = 10;
            this.losesValLbl.Text = "2";
            // 
            // losesLbl
            // 
            this.losesLbl.AutoSize = true;
            this.losesLbl.Font = new System.Drawing.Font("Grasping", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losesLbl.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.losesLbl.Location = new System.Drawing.Point(98, 336);
            this.losesLbl.Name = "losesLbl";
            this.losesLbl.Size = new System.Drawing.Size(126, 45);
            this.losesLbl.TabIndex = 9;
            this.losesLbl.Text = "Loses";
            // 
            // winsvalLbl
            // 
            this.winsvalLbl.AutoSize = true;
            this.winsvalLbl.Font = new System.Drawing.Font("Grasping", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winsvalLbl.ForeColor = System.Drawing.Color.LightGray;
            this.winsvalLbl.Location = new System.Drawing.Point(148, 243);
            this.winsvalLbl.Name = "winsvalLbl";
            this.winsvalLbl.Size = new System.Drawing.Size(26, 28);
            this.winsvalLbl.TabIndex = 8;
            this.winsvalLbl.Text = "2";
            this.winsvalLbl.Click += new System.EventHandler(this.label3_Click);
            // 
            // winsLbl
            // 
            this.winsLbl.AutoSize = true;
            this.winsLbl.Font = new System.Drawing.Font("Grasping", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winsLbl.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.winsLbl.Location = new System.Drawing.Point(108, 186);
            this.winsLbl.Name = "winsLbl";
            this.winsLbl.Size = new System.Drawing.Size(105, 45);
            this.winsLbl.TabIndex = 7;
            this.winsLbl.Text = "Wins";
            // 
            // playerNameValLbl
            // 
            this.playerNameValLbl.AutoSize = true;
            this.playerNameValLbl.Font = new System.Drawing.Font("Grasping", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameValLbl.ForeColor = System.Drawing.Color.LightGray;
            this.playerNameValLbl.Location = new System.Drawing.Point(77, 93);
            this.playerNameValLbl.Name = "playerNameValLbl";
            this.playerNameValLbl.Size = new System.Drawing.Size(175, 28);
            this.playerNameValLbl.TabIndex = 6;
            this.playerNameValLbl.Text = "Amin frozande";
            // 
            // playerNameLbl
            // 
            this.playerNameLbl.AutoSize = true;
            this.playerNameLbl.Font = new System.Drawing.Font("Grasping", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameLbl.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.playerNameLbl.Location = new System.Drawing.Point(37, 30);
            this.playerNameLbl.Name = "playerNameLbl";
            this.playerNameLbl.Size = new System.Drawing.Size(254, 45);
            this.playerNameLbl.TabIndex = 5;
            this.playerNameLbl.Text = "Player Name";
            // 
            // candyCrushLbl
            // 
            this.candyCrushLbl.AutoSize = true;
            this.candyCrushLbl.Font = new System.Drawing.Font("Candy Crush", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.candyCrushLbl.ForeColor = System.Drawing.Color.Violet;
            this.candyCrushLbl.Location = new System.Drawing.Point(539, 12);
            this.candyCrushLbl.Name = "candyCrushLbl";
            this.candyCrushLbl.Size = new System.Drawing.Size(428, 128);
            this.candyCrushLbl.TabIndex = 5;
            this.candyCrushLbl.Text = "Candy Crush";
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1308, 846);
            this.Controls.Add(this.candyCrushLbl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.friendRequestBtn);
            this.Controls.Add(this.TowPlayerBtn);
            this.Controls.Add(this.SinglePlayerBtn);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1326, 910);
            this.MinimumSize = new System.Drawing.Size(1326, 813);
            this.Name = "MainMenuForm";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SinglePlayerBtn;
        private System.Windows.Forms.Button TowPlayerBtn;
        private System.Windows.Forms.Button friendRequestBtn;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label candyCrushLbl;
        private System.Windows.Forms.Label playerNameLbl;
        private System.Windows.Forms.Label winsvalLbl;
        private System.Windows.Forms.Label winsLbl;
        private System.Windows.Forms.Label playerNameValLbl;
        private System.Windows.Forms.Label losesValLbl;
        private System.Windows.Forms.Label losesLbl;
        private System.Windows.Forms.Label recordValLbl;
        private System.Windows.Forms.Label recordLbl;
    }
}