using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Candy_Crush.Forms
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.Location = new Point((SystemInformation.PrimaryMonitorSize.Width - this.Width) / 2, (SystemInformation.PrimaryMonitorSize.Height - this.Height) / 2);
            SinglePlayerBtn.Location = new Point((this.Width - SinglePlayerBtn.Width) / 2, SinglePlayerBtn.Location.Y);
            TowPlayerBtn.Location = new Point((this.Width - TowPlayerBtn.Width) / 2, TowPlayerBtn.Location.Y);
            friendRequestBtn.Location = new Point((this.Width - friendRequestBtn.Width) / 2, friendRequestBtn.Location.Y);
            candyCrushLbl.Location = new Point((this.Width - candyCrushLbl.Width) / 2, candyCrushLbl.Location.Y);
          }

        private void SinglePlayerBtn_Click(object sender, EventArgs e)
        {
            GameForm form = new GameForm();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void TowPlayerBtn_Click(object sender, EventArgs e)
        {
            ChoosePlayerForm form = new ChoosePlayerForm();
            this.Hide();
            form.ShowDialog();
            this.Close();

        }

        private void friendRequestBtn_Click(object sender, EventArgs e)
        {
            SendFriendRequestForm form = new SendFriendRequestForm();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            string path = @"D:\candy_crush.txt";
            File.WriteAllText(path, "");
            Form1 form = new Form1();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

    

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void SinglePlayerBtn_Paint_1(object sender, PaintEventArgs e)
        {
            this.SinglePlayerBtn.Paint += new System.Windows.Forms.PaintEventHandler(this.SinglePlayerBtn_Paint_1);
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, SinglePlayerBtn.Width-10, SinglePlayerBtn.Height-10);
           SinglePlayerBtn.Region = new System.Drawing.Region(grPath);
        }
    }
}
