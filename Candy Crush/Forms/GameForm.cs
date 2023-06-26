using Candy_Crush.Forms;
using Candy_Crush.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Candy_Crush
{

    public partial class GameForm : Form
    {
        private static readonly Random random = new Random();
        Panel lastSelectedPanel = null;
        Game game;
        Player currentPlayer = new Player().LoadPlayerDataFromFile();
        bool is2v2Game = false;
        string gameTableString;
        int gameId;
        public GameForm()
        {
            InitializeComponent();
        }
        public GameForm(string gameTableString,int gameId)
        {
            is2v2Game = true;
            this.gameTableString = gameTableString;
            this.gameId = gameId;
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point((SystemInformation.PrimaryMonitorSize.Width - this.Width) / 2, (SystemInformation.PrimaryMonitorSize.Height - this.Height) / 2);
            recordLbl.Text = "Record : " + currentPlayer.Record;
            if (is2v2Game)
            {
                Make2vs2Game();
            }
            else
            {
                MakeSingularGame();
            }

            //MessageBox.Show(messages);

        }

        private void MakeSingularGame()
        {
            game = new Game(10);
            Point gameTableStartPoint = new Point(20, 20);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    PictureBox image = new PictureBox();
                    Panel pan = new Panel();
                    Candy candy = new Candy(GetRandomNum(1, 5));
                    candy.Position = new Position(j, i);
                    game.gameTable[j, i] = candy;
                    pan.Size = new Size(60, 60);
                    pan.Location = new Point(gameTableStartPoint.X + (65) * (j), gameTableStartPoint.Y + (65 * (i)));
                    image.Size = new Size(60, 60);
                    image.Image = Image.FromFile($@"D:\programming project\csharp\Candy Crush\Candy Crush\Images\Candy{candy.Value}.png");
                    image.SizeMode = PictureBoxSizeMode.StretchImage;
                    //image.Location = new Point(5, 5);
                    pan.Tag = candy;
                    pan.Name = $"candy{i}{j}";
                    image.Click += new System.EventHandler(this.candy_Click);

                    pan.Controls.Add(image);
                    game.gameTable1[j, i] = (pan);
                    this.Controls.Add(pan);
                }
            }
        }

        private void Make2vs2Game()
        {
            game = new Game(10);
            game.StringToGameTable(gameTableString);

            Point gameTableStartPoint = new Point(20, 20);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    PictureBox image = new PictureBox();
                    Panel pan = new Panel();
                    pan.Size = new Size(60, 60);
                    pan.Location = new Point(gameTableStartPoint.X + (65) * (j), gameTableStartPoint.Y + (65 * (i)));
                    image.Size = new Size(60, 60);
                    image.Image = Image.FromFile($@"D:\programming project\csharp\Candy Crush\Candy Crush\Images\Candy{game.gameTable[j, i].Value}.png");
                    image.SizeMode = PictureBoxSizeMode.StretchImage;
                    //image.Location = new Point(5, 5);
                    pan.Tag = game.gameTable[j, i];
                    pan.Name = $"candy{i}{j}";
                    image.Click += new System.EventHandler(this.candy_Click);

                    pan.Controls.Add(image);
                    game.gameTable1[j, i] = (pan);
                    this.Controls.Add(pan);
                }
            }
        }
        private Panel GetPanelByPosition(Position pos)
        {
            int index = pos.y*10+ pos.x;
             return this.Controls.OfType<Panel>().ToList()[index];
        }

        private async void DestroyCandies(List<Candy> candies)
        {
            await Task.Delay(300);
            for (int i = 0; i < candies.Count; i++)
            {
                //message += "\n" + candies[i].Position.ToString();
                //GetPanelByPosition(candies[i].Position).Visible = false;
                GetPanelByPosition(candies[i].Position).Visible = false;
                game.GetCandyByPos(candies[i].Position).Value = 0;
            } 
        }
        private  void SwitchingCandies(ref Panel panel1,ref Panel panel2)
        {
            
            var tempPanelImage = (panel1.Controls[0] as PictureBox).Image;
            int tempCandyVal = (panel1.Tag as Candy).Value;
            var tempPanelVisibility = (panel1).Visible;

            (panel1.Controls[0] as PictureBox).Image = (panel2.Controls[0] as PictureBox).Image;
            (panel1.Tag as Candy).Value = (panel2.Tag as Candy).Value;
            game.GetCandyByPos((panel1.Tag as Candy).Position).Value = (panel2.Tag as Candy).Value;
            panel1.Visible = panel2.Visible;

            (panel2.Controls[0] as PictureBox).Image = tempPanelImage;
            (panel2.Tag as Candy).Value = tempCandyVal;
            game.GetCandyByPos((panel2.Tag as Candy).Position).Value = tempCandyVal;
            panel2.Visible = tempPanelVisibility;

            
        }

        private async void SettingRandomCandies()
        {
            // MessageBox.Show("");
            await Task.Delay(300);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (game.gameTable[i, j].Value == 0)
                    {
                        int val = GetRandomNum(1, 5);
                        game.gameTable[i, j].Value = val;
                        Panel p = GetPanelByPosition(game.gameTable[i, j].Position);
                        PictureBox a = p.Controls[0] as PictureBox;
                        a.Image = Image.FromFile($@"D:\programming project\csharp\Candy Crush\Candy Crush\Images\Candy{val}.png");
                        (p.Tag as Candy).Value = val;
                        p.Visible = true;
                    }
                }
            }
        }

        private async void CandyComingFromUp()
        {
            //loop through satr
            //await Task.Delay(2000);
            //string message = string.Empty;
            MessageBox.Show("");
            for (int i = 0; i < 10; i++)
            {
                //loop through soton from bottom
                for (int j = 9; j >= 0; j--)
                {
                    if (game.gameTable[i, j].Value == 0)
                    {
                        //message += "\n" + game.gameTable[i, j].Position;
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (game.gameTable[i, k].Value != 0)
                            {
                                //message += $"\n switching {game.gameTable[i, j].Position.ToString()} with {game.gameTable[i, k].Position.ToString()}" ;
                                Panel p1 = GetPanelByPosition(game.gameTable[i, k].Position);
                                Panel p2 = GetPanelByPosition(game.gameTable[i, j].Position);
                                SwitchingCandies(ref p1, ref p2);

                                break;
                            }
                        }
                    }
                }
            }
            ///MessageBox.Show(message);

        }

        public async void FadeOutCandy(Panel p)
        {
            await Task.Delay(300);
        }
        
        private void candy_Click(object sender, EventArgs e)
        {
            Panel candyBox = ((PictureBox)sender).Parent as Panel;
            Panel second = candyBox;
            Check( candyBox,  second);

        }

        private async void Check(Panel candyBox,  Panel second)
        {
            Candy secondCandy = second.Tag as Candy;
            if (game.Moves < 10)
            {
                if (lastSelectedPanel != null && !(lastSelectedPanel.Tag as Candy).Position.Equal(secondCandy.Position))
                {
                    Panel first = lastSelectedPanel;
                    Candy firstCandy = first.Tag as Candy;
                    //osition newPos = new Position(changeCandy.Position.x, changeCandy.Position.y);
                    bool canTransfer = firstCandy.Position.CanChange(secondCandy.Position);
                    //MessageBox.Show(canTransfer.ToString());

                    if (canTransfer && firstCandy.Value != secondCandy.Value)
                    {
                        //Panel changePanel = GetPanelByPosition(newPos);
                        game.Moves++;
                        movesLbl.Text = "Moves : " + game.Moves;
                        SwitchingCandies(ref second, ref first);
                        List<Candy> candies = game.DestroyableCandies(secondCandy.Position);
                        if (candies.Count >= 3)
                        {
                            game.Score += candies.Count * candies[0].Value;
                            DestroyCandies(candies);
                            CandyComingFromUp();
                            SettingRandomCandies();
                            scoreLbl.Text = "Score : " + game.Score;
                        }
                        else
                        {
                            await Task.Delay(300);
                            SwitchingCandies(ref second, ref first);

                        }
                    }
                    lastSelectedPanel = null;
                }
                else
                {
                    lastSelectedPanel = candyBox;
                }
            }
            else
            {
                if (!is2v2Game)
                {
                    DialogResult result = MessageBox.Show($"Your moves finished and your score is {game.Score}.");
                    if (result == DialogResult.OK)
                    {
                        UpdatePlayerData(game.Score);
                        MainMenuForm form = new MainMenuForm();
                        this.Hide();
                        form.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show($"Your 2vs2 match has been ended with score of {game.Score} wait until game result.");
                    if (result == DialogResult.OK)
                    {
                        Update2vs2GameData(game.Score);
                        MainMenuForm form = new MainMenuForm();
                        this.Hide();
                        form.ShowDialog();
                        this.Close();
                    }
                }
            }
        }

        public static int GetRandomNum(int min, int max)
        {
            return random.Next(min, max);
        }

        private void UpdatePlayerData(int score)
        {
            if (score > currentPlayer.Record)
            {
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\programming project\\csharp\\Candy Crush\\Candy Crush\\CandyCrushDb.mdf\";Integrated Security=True;MultipleActiveResultSets=True");
                connection.Open();
                currentPlayer.Record = score;
                SqlCommand command = new SqlCommand("UPDATE Player SET record = @record WHERE (Id = @id)", connection);
                command.Parameters.AddWithValue("@id", currentPlayer.Id);
                command.Parameters.AddWithValue("@record", currentPlayer.Record);
                command.ExecuteNonQuery();
                currentPlayer.SavePlayerDataToFile();
                connection.Close(); 
            }
        }

        private void Update2vs2GameData(int score)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\programming project\\csharp\\Candy Crush\\Candy Crush\\CandyCrushDb.mdf\";Integrated Security=True;MultipleActiveResultSets=True");
            connection.Open();
            SqlCommand command = new SqlCommand($"Select * from Game where (Id={gameId})", connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            if (reader.GetInt32(3)==0)
            {
                command = new SqlCommand($"UPDATE Game SET player1Score = {score} WHERE (Id = {gameId})", connection);
                command.ExecuteNonQuery();
            }
            else
            {
                int player1score = reader.GetInt32(3);
                int player2score = score;
                int player1Id = reader.GetInt32(5);
                int winnerId,player1Wins,player1Loses;

                //getting first player (player1) data
                SqlCommand getFirstPlayerCommand = new SqlCommand($"Select * from Player WHERE (Id = {player1Id})", connection);
                SqlDataReader getFirstPlayerReader = getFirstPlayerCommand.ExecuteReader();
                getFirstPlayerReader.Read();
                player1Wins = getFirstPlayerReader.GetInt32(3);
                player1Loses = getFirstPlayerReader.GetInt32(4);

                if (player1score > player2score)
                {
                    winnerId = reader.GetInt32(5);
                    currentPlayer.Loses++;
                    player1Wins++;
                }
                else
                {
                    winnerId = currentPlayer.Id;
                    currentPlayer.Wins++;
                    player1Loses++;
                }
                //updating game database
                command = new SqlCommand($"UPDATE Game SET player2Score = {player2score},winnerId={winnerId},gameStatus=1 WHERE (Id = {gameId})", connection);
                command.ExecuteNonQuery();

                //updating player1 record in database
                command = new SqlCommand($"UPDATE Player SET wins = {player1Wins},loses={player1Loses} WHERE (Id = {player1Id})", connection);
                command.ExecuteNonQuery();
            }
            currentPlayer.Record = score;
            currentPlayer.PlayedNum++;

            //updating currentplayer (player2) record in database
            command = new SqlCommand($"UPDATE Player SET wins = {currentPlayer.Wins},loses={currentPlayer.Loses},record={currentPlayer.Record} WHERE (Id = {currentPlayer.Id})", connection);
            command.ExecuteNonQuery();

            reader.Close();
            connection.Close();
            currentPlayer.SavePlayerDataToFile();
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenuForm form = new MainMenuForm();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
    
}
