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
            this.SuspendLayout();
            // 
            // SinglePlayerBtn
            // 
            this.SinglePlayerBtn.Font = new System.Drawing.Font("Microsoft Uighur", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SinglePlayerBtn.Location = new System.Drawing.Point(436, 189);
            this.SinglePlayerBtn.Name = "SinglePlayerBtn";
            this.SinglePlayerBtn.Size = new System.Drawing.Size(337, 92);
            this.SinglePlayerBtn.TabIndex = 0;
            this.SinglePlayerBtn.Text = "Single Player";
            this.SinglePlayerBtn.UseVisualStyleBackColor = true;
            this.SinglePlayerBtn.Click += new System.EventHandler(this.SinglePlayerBtn_Click);
            // 
            // TowPlayerBtn
            // 
            this.TowPlayerBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.TowPlayerBtn.Font = new System.Drawing.Font("Microsoft Uighur", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TowPlayerBtn.Location = new System.Drawing.Point(436, 345);
            this.TowPlayerBtn.Name = "TowPlayerBtn";
            this.TowPlayerBtn.Size = new System.Drawing.Size(337, 81);
            this.TowPlayerBtn.TabIndex = 1;
            this.TowPlayerBtn.Text = "Two Player";
            this.TowPlayerBtn.UseVisualStyleBackColor = true;
            this.TowPlayerBtn.Click += new System.EventHandler(this.TowPlayerBtn_Click);
            // 
            // friendRequestBtn
            // 
            this.friendRequestBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.friendRequestBtn.Font = new System.Drawing.Font("Microsoft Uighur", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friendRequestBtn.Location = new System.Drawing.Point(436, 490);
            this.friendRequestBtn.Name = "friendRequestBtn";
            this.friendRequestBtn.Size = new System.Drawing.Size(337, 81);
            this.friendRequestBtn.TabIndex = 2;
            this.friendRequestBtn.Text = "Friend Request";
            this.friendRequestBtn.UseVisualStyleBackColor = true;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 865);
            this.Controls.Add(this.friendRequestBtn);
            this.Controls.Add(this.TowPlayerBtn);
            this.Controls.Add(this.SinglePlayerBtn);
            this.MaximumSize = new System.Drawing.Size(1327, 912);
            this.MinimumSize = new System.Drawing.Size(1327, 912);
            this.Name = "MainMenuForm";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SinglePlayerBtn;
        private System.Windows.Forms.Button TowPlayerBtn;
        private System.Windows.Forms.Button friendRequestBtn;
    }
}