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

namespace Candy_Crush.Forms
{
    public partial class ChoosePlayerForm : Form
    {
        public ChoosePlayerForm()
        {
            InitializeComponent();
        }

        private void ChoosePlayerForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point((SystemInformation.PrimaryMonitorSize.Width - this.Width) / 2, (SystemInformation.PrimaryMonitorSize.Height - this.Height) / 2);
            SetFriendListFromFile();
            
        }
        private void SetFriendListFromFile()
        {
            var currentPlayer = new Player().LoadPlayerDataFromFile();
            var friendsIDList = currentPlayer.FriendList;
            this.PlayerListView.Items.Clear();
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\programming project\\csharp\\Candy Crush\\Candy Crush\\CandyCrushDb.mdf\";Integrated Security=True");
            connection.Open();
            List<Player> list = GetFriendListFromDataBase(connection, friendsIDList);
            SetDataToListView(list);
            connection.Close();
        }
        private void SetDataToListView(List<Player> list)
        {
            this.PlayerListView.Items.Clear();     
            list.ForEach( p =>
            {
              AddItemToList(p); 
            });
        }

        private void AddItemToList(Player player)
        //private void AddTodo(TodoEventArgs todoItem) Wrong
        {
            var todoData = new string[] { player.Id.ToString(), player.Username, player.Wins.ToString(),player.Record.ToString() };
            var todoListItem = new ListViewItem(todoData);
            PlayerListView.Items.Add(todoListItem);
        }

        private List<Player> GetDataFromDataBase(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand($"Select * from Player", connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Player> list = new List<Player>();
            while (reader.Read())
            {
                list.Add(new Player()
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Record = reader.GetInt32(5),
                    Wins = reader.GetInt32(3),
                    Loses = reader.GetInt32(4),
                });
            }
            reader.Close();
            return list;
        }
        
        private List<Player> GetFriendListFromDataBase(SqlConnection connection,List<int> friendsIdList)
        {
            List<Player> friendList = new List<Player>();

            for (int i = 0; i < friendsIdList.Count(); i++)
            {
                SqlCommand command = new SqlCommand($"Select * from Player where Id={friendsIdList[i]}", connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                friendList.Add(new Player()
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Record = reader.GetInt32(5),
                    Wins = reader.GetInt32(3),
                    Loses = reader.GetInt32(4),
                });
                reader.Close();
            }
           
            return friendList;
        }
        private void PlayerListView_Click(object sender, EventArgs e)
        {
            var selectedPlayer = PlayerListView.SelectedItems[0];
            if(selectedPlayer != null )
            {
                DialogResult dialogResult = MessageBox.Show("Do you wanna add this player to your friend?", "Friend Addtion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show("OK");
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("No");
                }
            }
        }
    }
}
