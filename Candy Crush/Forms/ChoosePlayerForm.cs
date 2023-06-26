using Candy_Crush.Model;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Candy_Crush.Forms
{
    public partial class ChoosePlayerForm : Form
    {
        Player currentPlayer = new Player().LoadPlayerDataFromFile();
        private string whichList = "FriendList";
        List<Competetion> competionList = new List<Competetion>();

        public ChoosePlayerForm()
        {
            InitializeComponent();
        }

        private void ChoosePlayerForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point((SystemInformation.PrimaryMonitorSize.Width - this.Width) / 2, (SystemInformation.PrimaryMonitorSize.Height - this.Height) / 2);
            SetDataToList();
        }
        private void SetDataToList()
        {
            this.PlayerListView.Items.Clear();

            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\programming project\\csharp\\Candy Crush\\Candy Crush\\CandyCrushDb.mdf\";Integrated Security=True;MultipleActiveResultSets=True");
            connection.Open();
            if (whichList == "FriendList")
            {
                this.Username.Text = "Name";
                this.Wins.Text = "Wins";
                this.Record.Text = "Record";
                SetFriendListFromFile();
            }
            else
            {
                this.Username.Text = "My Score";
                this.Wins.Text = "Other Score";
                this.Record.Text = "Winner";
                SetDataToListView(GetGameListFromDataBase(connection));

            }
            connection.Close();
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

        private void SetDataToListView<T>(List<T> list)
        {
            this.PlayerListView.Items.Clear();
            if (whichList == "FriendList")
            {
                list.ForEach(p =>
                {
                    AddFriendToList(p as Player);
                });
            }
            else
            {
                list.ForEach(p =>
                {
                    AddGameToList(p as Competetion);
                });

            }
        }
        private void AddFriendToList(Player player)
        {
            var todoData = new string[] { player.Id.ToString(), player.Username, player.Wins.ToString(), player.Record.ToString() };
            var todoListItem = new ListViewItem(todoData);
            PlayerListView.Items.Add(todoListItem);
        }
        private void AddGameToList(Competetion competetion)
        {
            int myScore, otherScore;
            string winner;
            if (competetion.Player1Id == currentPlayer.Id)
            {
                myScore = competetion.Player1Score;
                otherScore = competetion.Player2Score;
            }
            else
            {
                myScore = competetion.Player2Score;
                otherScore = competetion.Player1Score;
            }
            if (competetion.Player1Score != 0 && competetion.Player2Score != 0)
            {
                if (competetion.WinnerId == currentPlayer.Id)
                {
                    winner = "Yes";
                }
                else
                {
                    winner = "No";
                }
            }
            else
            {
                winner = "None";
            }
            var todoData = new string[] { competetion.Id.ToString(), myScore.ToString(), otherScore.ToString(), winner };
            var todoListItem = new ListViewItem(todoData);
            PlayerListView.Items.Add(todoListItem);
        }

        private List<Player> GetFriendListFromDataBase(SqlConnection connection, List<int> friendsIdList)
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

        private void MakeNewGameInDatabase(int player2Id)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\programming project\\csharp\\Candy Crush\\Candy Crush\\CandyCrushDb.mdf\";Integrated Security=True;MultipleActiveResultSets=True");
            connection.Open();
            SqlCommand command = new SqlCommand($"Select COUNT(*) from Game", connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int count = reader.GetInt32(0);
            reader.Close();
            Game newGame = new Game(10);
            newGame.MakeRandomGameMatrix();
            string gameTableString = newGame.GameMatrixToString();
            command = new SqlCommand($"Insert into Game(Id,player1Id,player2Id,gameTable,player1Score,player2Score,winnerId,gameStatus) values (@id,@player1Id,@player2Id,@gameTable,0,0,0,0)", connection);
            command.Parameters.AddWithValue("@id", (count + 1));
            command.Parameters.AddWithValue("@player1Id", currentPlayer.Id);
            command.Parameters.AddWithValue("@player2Id", player2Id);
            command.Parameters.AddWithValue("@gameTable", gameTableString);
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Game added for both of you lets start.....");

            GameForm form = new GameForm(gameTableString, (count + 1));
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private List<Competetion> GetGameListFromDataBase(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand($"Select * from Game where (player1Id={currentPlayer.Id} OR player2Id = {currentPlayer.Id})", connection);
            var gameReader = command.ExecuteReader();

            competionList.Clear();
            while (gameReader.Read())
            {
                competionList.Add(new Competetion()
                {
                    Id = gameReader.GetInt32(0),
                    WinnerId = gameReader.GetInt32(1),
                    GameTable = gameReader.GetString(2),
                    Player1Score = gameReader.GetInt32(3),
                    Player2Score = gameReader.GetInt32(4),
                    Player1Id = gameReader.GetInt32(5),
                    Player2Id = gameReader.GetInt32(6),
                    GameStatus = gameReader.GetInt32(7)
                });
            }
            gameReader.Close();
            return competionList;
        }
        private void ChoosePlayerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenuForm form = new MainMenuForm();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
        private void choosePlayerBtn_Click(object sender, EventArgs e)
        {
            whichList = "FriendList";
            SetDataToList();
        }
        private void showMyGamesBtnBtn_Click(object sender, EventArgs e)
        {
            whichList = "GameList";
            SetDataToList();
        }

        private void PlayerListView_Click(object sender, EventArgs e)
        {

            if (whichList == "FriendList")
            {
                var selectedPlayer = PlayerListView.SelectedItems[0];
                if (selectedPlayer != null)
                {
                    DialogResult dialogResult = MessageBox.Show($"Do you start 2vs2 game with {selectedPlayer.SubItems[1].Text}?", "Friend game battle", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MakeNewGameInDatabase(int.Parse(selectedPlayer.SubItems[0].Text));
                    }
                }

            }
            else
            {
                var selectedGame = PlayerListView.SelectedItems[0];
                if (selectedGame != null && selectedGame.SubItems[3].Text == "None")
                {
                    Competetion g = competionList[selectedGame.Index];
                    if ((currentPlayer.Id == g.Player1Id && g.Player1Score == 0) || (currentPlayer.Id == g.Player2Id && g.Player2Score == 0))
                    {
                        DialogResult dialogResult = MessageBox.Show($"You have unfinished game do you wanna play?", "Friend game battle", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                MessageBox.Show("Game will start now....");

                                GameForm form = new GameForm(g.GameTable, g.Id);
                                this.Hide();
                                form.ShowDialog();
                                this.Close();
                          }
                        
                    }
                }
            }
        }
    }
}
