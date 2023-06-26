using Candy_Crush.Model;
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
        private string whichList = "PlayerList";
        Player currentPlayer;
        List<FriendReq> friendReqList = new List<FriendReq>();
        public SendFriendRequestForm()
        {
            InitializeComponent();
        }

        private void SendFriendRequest_Load(object sender, EventArgs e)
        {
            this.Location = new Point((SystemInformation.PrimaryMonitorSize.Width - this.Width) / 2, (SystemInformation.PrimaryMonitorSize.Height - this.Height) / 2);
             currentPlayer = new Player().LoadPlayerDataFromFile();

            SetDataToList();
        }
        private void SetDataToList()
        {
            this.PlayerListView.Items.Clear();
            
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\programming project\\csharp\\Candy Crush\\Candy Crush\\CandyCrushDb.mdf\";Integrated Security=True;MultipleActiveResultSets=True");
            connection.Open();
            if (whichList == "PlayerList")
            {
                this.Friend.Text = "Friend";
                List<Player> list = GetPlayersListFromDataBase(connection);
                SetDataToListView(list);
            }
            else
            {
                this.Friend.Text = "Status";
                List<FriendReq> list = GetReqListFromDataBase(connection);
                if (list.Count() == 0)
                {
                    MessageBox.Show("There is no friend request for you.");
                }
                else
                {
                    SetDataToListView(list);
                }
            }
            connection.Close();
        }

        private void SetFriendReqList()
        {
            this.PlayerListView.Items.Clear();

            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\programming project\\csharp\\Candy Crush\\Candy Crush\\CandyCrushDb.mdf\";Integrated Security=True;MultipleActiveResultSets=True");
            connection.Open();
            
            connection.Close();
        }

        private void SetDataToListView<T>(List<T> list)
        {
            this.PlayerListView.Items.Clear();
            if(whichList== "PlayerList")
            {
                list.ForEach(p =>
                {
                    AddUserToList(p as Player);
                });
            }
            else
            {
                list.ForEach(p =>
                {
                    AddFriendReqToList(p as FriendReq);
                });

            }
        }

        private void AddUserToList(Player player)
        {
            var todoData = new string[] { player.Id.ToString(), player.Username, player.Wins.ToString(), player.Record.ToString(),player.IsFriend.ToString() };
            var todoListItem = new ListViewItem(todoData);
            PlayerListView.Items.Add(todoListItem);
        }
        private void AddFriendReqToList(FriendReq req)
        {
            string status;
            switch (req.Status)
            {
                case 0:
                    status = "None";
                    break;
                case 1:
                    status = "Accept";
                    break;
                case 2:
                    status = "Denied";
                    break;
                default:
                    status = "";
                    break;
            }
            var todoData = new string[] { req.ID.ToString(), req.SenderPlayer.Username, req.SenderPlayer.Wins.ToString(), req.SenderPlayer.Record.ToString(), status };
            var todoListItem = new ListViewItem(todoData);
            PlayerListView.Items.Add(todoListItem);
        }
        private List<Player> GetPlayersListFromDataBase(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand($"Select * from Player", connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Player> list = new List<Player>();
            while (reader.Read())
            {
                string isFriend;
                if (currentPlayer.FriendList.Contains(reader.GetInt32(0)))
                {
                    isFriend=  "Yes";
                }
                else
                {
                    isFriend = "No";
                }
                if(currentPlayer.Id != reader.GetInt32(0))
                {
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
            }
            reader.Close();
            return list;
        }
        private List<FriendReq> GetReqListFromDataBase(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand($"Select * from FriendRequests where GeterId={currentPlayer.Id}", connection);
            var friendRequestsReader = command.ExecuteReader();

            friendReqList.Clear();
            while (friendRequestsReader.Read())
            {

                int senderID = friendRequestsReader.GetInt32(1);
                SqlCommand command2 = new SqlCommand($"Select * from Player where Id={senderID}", connection);
                SqlDataReader playerReader = command2.ExecuteReader();
                playerReader.ReadAsync();
                friendReqList.Add(new FriendReq
                {
                    SenderID = senderID,
                    GeterID = friendRequestsReader.GetInt32(2),
                    ID = friendRequestsReader.GetInt32(0),
                    Status = friendRequestsReader.GetInt32(3),
                    SenderPlayer = new Player()
                    {
                        Id = playerReader.GetInt32(0),
                        Username = playerReader.GetString(1),
                        Record = playerReader.GetInt32(5),
                        Wins = playerReader.GetInt32(3),
                        Loses = playerReader.GetInt32(4),
                        FriendList = new Player().FriendListFromString(playerReader.GetString(6))
                    }
                });
                playerReader.Close();
            }
            friendRequestsReader.Close();
            return friendReqList;
        }

        private void PlayerListView_Click(object sender, EventArgs e)
        {
            var selectedPlayer = PlayerListView.SelectedItems[0];
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\programming project\\csharp\\Candy Crush\\Candy Crush\\CandyCrushDb.mdf\";Integrated Security=True;MultipleActiveResultSets=True");
            connection.Open();
            if (selectedPlayer != null )
            {
                if(whichList == "PlayerList")
                {
                    if (selectedPlayer.SubItems[4].Text=="No")
                    {
                        DialogResult dialogResult = MessageBox.Show($"Do you wanna send freind request to {selectedPlayer.SubItems[1].Text} ?", "Friend Addtion", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //MessageBox.Show(selectedPlayer.SubItems[0].Text.ToString());
                            InsertingData(connection, currentPlayer.Id, int.Parse(selectedPlayer.SubItems[0].Text));
                            MessageBox.Show($"The friend request to {selectedPlayer.SubItems[1].Text} has been sent.");
                        }
                    }
                }
                else if(selectedPlayer.SubItems[4].Text=="None")
                {
                    DialogResult dialogResult = MessageBox.Show($"Do you wanna accept {selectedPlayer.SubItems[1].Text} freind request?", "Friend Addtion", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //MessageBox.Show(selectedPlayer.SubItems[0].Text.ToString());
                        friendReqList[PlayerListView.SelectedItems[0].Index].Status = 1;
                        UpdateFreindReq(connection, friendReqList[PlayerListView.SelectedItems[0].Index]);
                        selectedPlayer.SubItems[4].Text = "Accept";
                        MessageBox.Show($"{selectedPlayer.SubItems[1].Text} is now one of your friends.");
                    }
                    else
                    {
                        friendReqList[PlayerListView.SelectedItems[0].Index].Status = 2;
                        UpdateFreindReq(connection, friendReqList[PlayerListView.SelectedItems[0].Index]);
                        selectedPlayer.SubItems[4].Text = "Denied";
                        MessageBox.Show($"The Friend request of {selectedPlayer.SubItems[1].Text} was deined by you.");
                    }
                }
            }
            connection.Close();
        }

        private  void InsertingData(SqlConnection connection, int senderPlayer, int geterPlayer)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM FriendRequests", connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int count = reader.GetInt32(0);
            reader.Close();
            command = new SqlCommand("Insert into FriendRequests(Id,SenderId,GeterId,Status) values (@id,@sender,@geter,@status)", connection);
            command.Parameters.AddWithValue("@id", count+1);
            command.Parameters.AddWithValue("@sender", senderPlayer);
            command.Parameters.AddWithValue("@geter", geterPlayer);
            command.Parameters.AddWithValue("@status", 0);
            command.ExecuteNonQuery();        
        }

        private void UpdateFreindReq(SqlConnection connection, FriendReq friendReq)
        {
            SqlCommand command = new SqlCommand("UPDATE FriendRequests SET Status = @status WHERE (Id = @reqId)", connection);
            command.Parameters.AddWithValue("@reqId", friendReq.ID);
            command.Parameters.AddWithValue("@status", friendReq.Status);
            command.ExecuteNonQuery();

            if (friendReq.Status != 2)
            {
                command = new SqlCommand("UPDATE Player SET firendsList = @firendsList WHERE (Id = @senderId)", connection);
                command.Parameters.AddWithValue("@senderId", friendReq.SenderID);
                command.Parameters.AddWithValue("@firendsList", friendReq.SenderPlayer.FriendListToString() + $"{friendReq.GeterID}-");
                command.ExecuteNonQuery();

                string currentPlayerFriendListString = currentPlayer.FriendListToString() + $"{friendReq.SenderID}-";
                command = new SqlCommand("UPDATE Player SET firendsList = @firendsList WHERE (Id = @geterId)", connection);
                command.Parameters.AddWithValue("@geterId", friendReq.GeterID);
                command.Parameters.AddWithValue("@firendsList", currentPlayerFriendListString);
                command.ExecuteNonQuery();

                currentPlayer.FriendList = currentPlayer.FriendListFromString(currentPlayerFriendListString);
                currentPlayer.SavePlayerDataToFile();
            }
        }

        private void showMyFriendReqBtn_Click(object sender, EventArgs e)
        {
            whichList = "ReqList";
            SetDataToList();
        }

        private void showListOFPlayersBtn_Click(object sender, EventArgs e)
        {
            whichList = "PlayerList";
            SetDataToList();
        }

        private void PlayerListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SendFriendRequestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenuForm form = new MainMenuForm();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
}
