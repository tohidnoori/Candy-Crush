using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
