namespace Candy_Crush.Forms
{
    partial class ChoosePlayerForm
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
            this.PlayerListView = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Wins = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Record = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.choosePlayerBtn = new System.Windows.Forms.Button();
            this.showMyGamesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayerListView
            // 
            this.PlayerListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.PlayerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Username,
            this.Wins,
            this.Record});
            this.PlayerListView.FullRowSelect = true;
            this.PlayerListView.GridLines = true;
            this.PlayerListView.HideSelection = false;
            this.PlayerListView.Location = new System.Drawing.Point(12, 21);
            this.PlayerListView.MultiSelect = false;
            this.PlayerListView.Name = "PlayerListView";
            this.PlayerListView.ShowItemToolTips = true;
            this.PlayerListView.Size = new System.Drawing.Size(513, 785);
            this.PlayerListView.TabIndex = 1;
            this.PlayerListView.UseCompatibleStateImageBehavior = false;
            this.PlayerListView.View = System.Windows.Forms.View.Details;
            this.PlayerListView.Click += new System.EventHandler(this.PlayerListView_Click);
            // 
            // Id
            // 
            this.Id.Text = "ID";
            this.Id.Width = 51;
            // 
            // Username
            // 
            this.Username.Text = "Name";
            this.Username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Username.Width = 145;
            // 
            // Wins
            // 
            this.Wins.Text = "Wins";
            this.Wins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Wins.Width = 119;
            // 
            // Record
            // 
            this.Record.Text = "Record";
            this.Record.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Record.Width = 89;
            // 
            // choosePlayerBtn
            // 
            this.choosePlayerBtn.Location = new System.Drawing.Point(547, 21);
            this.choosePlayerBtn.Name = "choosePlayerBtn";
            this.choosePlayerBtn.Size = new System.Drawing.Size(181, 70);
            this.choosePlayerBtn.TabIndex = 5;
            this.choosePlayerBtn.Text = "Choose Player";
            this.choosePlayerBtn.UseVisualStyleBackColor = true;
            this.choosePlayerBtn.Click += new System.EventHandler(this.choosePlayerBtn_Click);
            // 
            // showMyGamesBtn
            // 
            this.showMyGamesBtn.Location = new System.Drawing.Point(547, 125);
            this.showMyGamesBtn.Name = "showMyGamesBtn";
            this.showMyGamesBtn.Size = new System.Drawing.Size(181, 70);
            this.showMyGamesBtn.TabIndex = 4;
            this.showMyGamesBtn.Text = "My games";
            this.showMyGamesBtn.UseVisualStyleBackColor = true;
            this.showMyGamesBtn.Click += new System.EventHandler(this.showMyGamesBtnBtn_Click);
            // 
            // ChoosePlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 853);
            this.Controls.Add(this.choosePlayerBtn);
            this.Controls.Add(this.showMyGamesBtn);
            this.Controls.Add(this.PlayerListView);
            this.MaximumSize = new System.Drawing.Size(770, 900);
            this.MinimumSize = new System.Drawing.Size(770, 900);
            this.Name = "ChoosePlayerForm";
            this.Text = "ChoosePlayerForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChoosePlayerForm_FormClosed);
            this.Load += new System.EventHandler(this.ChoosePlayerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView PlayerListView;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Username;
        private System.Windows.Forms.ColumnHeader Wins;
        private System.Windows.Forms.ColumnHeader Record;
        private System.Windows.Forms.Button choosePlayerBtn;
        private System.Windows.Forms.Button showMyGamesBtn;
    }
}