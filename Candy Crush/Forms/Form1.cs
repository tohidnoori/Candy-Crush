using Candy_Crush.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Candy_Crush
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (DoesPlayerLoggedIn())
            {

                MainMenuForm form = new MainMenuForm();
                this.Hide();
                form.ShowDialog();
            }
            else
            {

                LoginForm form = new LoginForm();
                this.Hide();
                form.ShowDialog();
            }
            this.Close();

        }

        private bool DoesPlayerLoggedIn()
        {
            string path = @"D:\candy_crush.txt";
            return File.Exists(path)&&File.ReadAllText(path).Length != 0;
        }
    }
}
