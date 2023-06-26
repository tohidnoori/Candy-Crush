using Candy_Crush.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Candy_Crush
{
    public partial class SignInForm : Form
    {
        private bool isHide = true;
        public SignInForm()
        {
            InitializeComponent();
        }

        private void goLoginPageLbl_Click(object sender, EventArgs e)
        {
            LoginForm form= new LoginForm();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void goLoginPageLbl_MouseEnter(object sender, EventArgs e)
        {
            goLoginPageLbl.ForeColor = Color.LightPink;

        }

        private void goLoginPageLbl_MouseLeave(object sender, EventArgs e)
        {
            goLoginPageLbl.ForeColor = Color.Gray;

        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            String message = "";
            if (passwordTxt.Text.Length > 0 && cnfPasswordLbl.Text.Length > 0 && usernameTxt.Text.Length > 0)
            {
                if (usernameTxt.Text.Count() >= 8)
                {
                    if (passwordTxt.Text.Count() >= 8 && cnfPasswordLbl.Text.Count() >= 8)
                    {
                        if (passwordTxt.Text.ToString() == cnfPasswordTxt.Text.ToString())
                        {                            
                            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\programming project\\csharp\\Candy Crush\\Candy Crush\\CandyCrushDb.mdf\";Integrated Security=True");
                            connection.Open();
                            Player p = new Player
                            {
                                Username = usernameTxt.Text,
                                Password = passwordTxt.Text
                            };
                            Player player = AddUserToDataBase(connection, p);
                            if (player != null)
                            {
                                MessageBox.Show("Login successfully");
                                player.SavePlayerDataToFile();
                                MainMenuForm form = new MainMenuForm();
                                this.Hide();
                                form.ShowDialog();
                                this.Close();
                            }
                            connection.Close();
                        }
                        else
                        {
                            MessageBox.Show($"Password and its confirmation are not equal");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password and its confirmation must have more length of 8");
                    }
                }
                else
                {
                    MessageBox.Show("Username must have more length of 8");
                }
            }
            else
            {
                MessageBox.Show("Please fill the fields");
            }
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point((SystemInformation.PrimaryMonitorSize.Width - this.Width) / 2, (SystemInformation.PrimaryMonitorSize.Height - this.Height) / 2);
        }
        private Player AddUserToDataBase(SqlConnection connection,Player p)
        {
            SqlCommand command = new SqlCommand($"Select COUNT(*) from Player where username='{p.Username}'", connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int count = reader.GetInt32(0);
            reader.Close();
            if (count == 0)
            {
                 command = new SqlCommand($"Select COUNT(*) from Player", connection);
                 reader = command.ExecuteReader();
                reader.Read();
                 count = reader.GetInt32(0);
                reader.Close();
                command = new SqlCommand("Insert into Player(Id,username,password,wins,loses,record,firendsList) values (@id,@username,@password,0,0,0,0)", connection);
                command.Parameters.AddWithValue("@id", (count + 1));
                command.Parameters.AddWithValue("@username", p.Username);
                command.Parameters.AddWithValue("@password", p.Password);
                command.ExecuteNonQuery();
                
                MessageBox.Show("User addded");
                return new Player()
                {
                    Id = (count + 1),
                    Username = p.Username,
                    Password = p.Password,
                    Wins = 0,
                    Record = 0,
                    Loses= 0
                };
            }
            else
            {
                MessageBox.Show("User with this username already exsist");
                return null;
            }
        }

        private void eyePass_Click(object sender, EventArgs e)
        {
            if (isHide)
            {
                passwordTxt.UseSystemPasswordChar = false;
                cnfPasswordTxt.UseSystemPasswordChar = false;
                eyePass.BackgroundImage = Image.FromFile(@"D:\programming project\csharp\Candy Crush\Candy Crush\Images\eye_hide.jpg");
                isHide = false;
            }
            else
            {
                isHide = true;
                eyePass.BackgroundImage = Image.FromFile(@"D:\programming project\csharp\Candy Crush\Candy Crush\Images\eye_unhide.jpg");
                passwordTxt.UseSystemPasswordChar = true;
                cnfPasswordTxt.UseSystemPasswordChar = true;
            }
        }
    }
}
