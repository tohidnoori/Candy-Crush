using Candy_Crush.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Candy_Crush
{
    public partial class LoginForm : Form
    {
        private bool isHide = true;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void goSingInPageLbl_MouseHover(object sender, EventArgs e)
        {

        }

        private void goSingInPageLbl_MouseEnter(object sender, EventArgs e)
        {
            goSingInPageLbl.ForeColor = Color.LightPink;

        }

        private void goSingInPageLbl_MouseLeave(object sender, EventArgs e)
        {
            goSingInPageLbl.ForeColor = Color.Gray;

        }

        private void usernameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            String message = "";
            if (passwordTxt.Text.Length > 0 && usernameTxt.Text.Length > 0)
            {
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\programming project\\csharp\\Candy Crush\\Candy Crush\\CandyCrushDb.mdf\";Integrated Security=True");
                connection.Open();
                Player p = new Player
                {
                    Username = usernameTxt.Text,
                    Password = passwordTxt.Text
                };
                LoginCheck(connection, p);
                connection.Close();
            }
            else
            {
                MessageBox.Show("Please fill the fields");
            }
        }

        private void goSingInPageLbl_Click(object sender, EventArgs e)
        {
            SignInForm form = new SignInForm();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point((SystemInformation.PrimaryMonitorSize.Width - this.Width) / 2, (SystemInformation.PrimaryMonitorSize.Height - this.Height) / 2);
        }

        private void LoginCheck(SqlConnection connection, Player p)
        {
            SqlCommand command = new SqlCommand($"Select * from Player where username='{p.Username}'", connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetString(2) == p.Password)
                {
                    var friendList = reader.GetString(6).Split('-').ToList();
                    List<int> friendIdList = new List<int>();

                    //MessageBox.Show(friendList.Count().ToString());
                    friendList.ForEach(friendId => { if (friendId != "") {
                            friendIdList.Add(int.Parse(friendId));
                        } 
                    });
                    Player player = new Player { 
                        Id= reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        Wins= reader.GetInt32(3),
                        Loses= reader.GetInt32(4),
                        Record = reader.GetInt32(5),
                        FriendList= friendIdList
                    };
                    player.SavePlayerDataToFile();
                    MessageBox.Show("Login successfully");
                    MainMenuForm form = new MainMenuForm();
                    this.Hide();
                    form.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("User or pass are not correct");
                }
            }
            else
            {
                MessageBox.Show("User or pass are not correct");
            }
            reader.Close();
        }

        private void eyePass_Click(object sender, EventArgs e)
        {
            if(isHide)
            {
                passwordTxt.UseSystemPasswordChar= false;
                eyePass.BackgroundImage = Image.FromFile(@"D:\programming project\csharp\Candy Crush\Candy Crush\Images\eye_hide.jpg");
                isHide = false;
            }
            else
            {
                isHide= true;
                eyePass.BackgroundImage = Image.FromFile(@"D:\programming project\csharp\Candy Crush\Candy Crush\Images\eye_unhide.jpg");
                passwordTxt.UseSystemPasswordChar = true;
            }
        }
    }

}
