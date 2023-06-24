namespace Candy_Crush.Forms
{
    partial class SendFriendRequestForm
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
            this.Friend = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // PlayerListView
            // 
            this.PlayerListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.PlayerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Username,
            this.Wins,
            this.Record,
            this.Friend});
            this.PlayerListView.FullRowSelect = true;
            this.PlayerListView.GridLines = true;
            this.PlayerListView.HideSelection = false;
            this.PlayerListView.Location = new System.Drawing.Point(12, 21);
            this.PlayerListView.MultiSelect = false;
            this.PlayerListView.Name = "PlayerListView";
            this.PlayerListView.ShowItemToolTips = true;
            this.PlayerListView.Size = new System.Drawing.Size(657, 785);
            this.PlayerListView.TabIndex = 1;
            this.PlayerListView.UseCompatibleStateImageBehavior = false;
            this.PlayerListView.View = System.Windows.Forms.View.Details;
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
            this.Username.Width = 186;
            // 
            // Wins
            // 
            this.Wins.Text = "Wins";
            this.Wins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Wins.Width = 78;
            // 
            // Record
            // 
            this.Record.Text = "Record";
            this.Record.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Record.Width = 90;
            // 
            // Friend
            // 
            this.Friend.Text = "Friend";
            // 
            // SendFriendRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 853);
            this.Controls.Add(this.PlayerListView);
            this.MaximumSize = new System.Drawing.Size(700, 900);
            this.MinimumSize = new System.Drawing.Size(700, 900);
            this.Name = "SendFriendRequest";
            this.Text = "ChoosePlayerForm";
            this.Load += new System.EventHandler(this.SendFriendRequest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView PlayerListView;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Username;
        private System.Windows.Forms.ColumnHeader Wins;
        private System.Windows.Forms.ColumnHeader Record;
        private System.Windows.Forms.ColumnHeader Friend;
    }
}