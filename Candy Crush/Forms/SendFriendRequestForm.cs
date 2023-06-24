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

namespace Candy_Crush.Forms
{
    public partial class SendFriendRequestForm : Form
    {
        public SendFriendRequestForm()
        {
            InitializeComponent();
        }

        private void SendFriendRequest_Load(object sender, EventArgs e)
        {
            this.Location = new Point((SystemInformation.PrimaryMonitorSize.Width - this.Width) / 2, (SystemInformation.PrimaryMonitorSize.Height - this.Height) / 2);


        }
        private void SetFriendListFromFile()
        {
            var currentPlayer = new Player().LoadPlayerDataFromFile();
            var friendsIDList = currentPlayer.FriendList;
            this.PlayerListView.Items.Clear();
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\programming project\\csharp\\Candy Crush\\Candy Crush\\CandyCrushDb.mdf\";Integrated Security=True");
            connection.Open();
            List<Player> list = GetDataFromDataBase(connection, new Player().LoadPlayerDataFromFile());
            SetDataToListView(list);
            connection.Close();
        }
        private void SetDataToListView(List<Player> list)
        {
            this.PlayerListView.Items.Clear();
            list.ForEach(p =>
            {
                AddItemToList(p);
            });
        }

        private void AddItemToList(Player player)
        //private void AddTodo(TodoEventArgs todoItem) Wrong
        {
            var todoData = new string[] { player.Id.ToString(), player.Username, player.Wins.ToString(), player.Record.ToString(),player.IsFriend.ToString() };
            var todoListItem = new ListViewItem(todoData);
            PlayerListView.Items.Add(todoListItem);
        }

        private List<Player> GetDataFromDataBase(SqlConnection connection,Player CurrentPlayer)
        {
            SqlCommand command = new SqlCommand($"Select * from Player", connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Player> list = new List<Player>();
            while (reader.Read())
            {
                string isFriend;
                if (CurrentPlayer.FriendList.Contains(reader.GetInt32(0)))
                {
                    isFriend=  "yes";
                }
                else
                {
                    isFriend = "no";
                }
                list.Add(new Player()
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Record = reader.GetInt32(5),
                    Wins = reader.GetInt32(3),
                    Loses = reader.GetInt32(4),
                    IsFriend = isFriend
                });
            }
            reader.Close();
            return list;
        }

    }
}
