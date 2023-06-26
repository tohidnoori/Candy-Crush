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
        PictureBox lastSelected = null;
        Game game;
        Player currentPlayer = new Player().LoadPlayerDataFromFile();
        bool isCompetion= false;
        string gameMatrixString;
        int gameId;
        public GameForm()
        {
            InitializeComponent();
        }
        public GameForm(string gameMatrixString,int gameId)
        {
            isCompetion = true;
            this.gameMatrixString = gameMatrixString;
            this.gameId = gameId;
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point((SystemInformation.PrimaryMonitorSize.Width - this.Width) / 2, (SystemInformation.PrimaryMonitorSize.Height - this.Height) / 2);
            recordLbl.Text = "Record : " + currentPlayer.Record;
            if (isCompetion)
            {
                StartCompetion();
            }
            else
            {
                StartSingularGame();
            }

            //MessageBox.Show(messages);

        }

        private void StartSingularGame()
        {
            game = new Game(10);
            Point gameMatrixStartPoint = new Point(20, 20);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    PictureBox image = new PictureBox();
                    Candy candy = new Candy(GetRandomNum(1, 5));
                    candy.Position = new Position(j, i);
                    game.gameMatrix[j, i] = candy;
                    image.Location = new Point(gameMatrixStartPoint.X + (65) * (j), gameMatrixStartPoint.Y + (65 * (i)));
                    image.Size = new Size(60, 60);
                    image.Image = Image.FromFile($@"D:\programming project\csharp\Candy Crush\Candy Crush\Images\Candy{candy.Value}.png");
                    image.SizeMode = PictureBoxSizeMode.StretchImage;
                    //image.Location = new Point(5, 5);
                    image.Tag = candy;
                    image.Name = $"candy{i}{j}";
                    image.Click += new System.EventHandler(this.candy_Click);
                    game.gameMatrix1[j, i] = (image);
                    this.Controls.Add(image);
                }
            }
        }

        private void StartCompetion()
        {
            game = new Game(10);
            game.StringTogameMatrix(gameMatrixString);

            Point gameMatrixStartPoint = new Point(20, 20);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    PictureBox image = new PictureBox();
                    image.Location = new Point(gameMatrixStartPoint.X + (65) * (j), gameMatrixStartPoint.Y + (65 * (i)));
                    image.Size = new Size(60, 60);
                    image.Image = Image.FromFile($@"D:\programming project\csharp\Candy Crush\Candy Crush\Images\Candy{game.gameMatrix[j, i].Value}.png");
                    image.SizeMode = PictureBoxSizeMode.StretchImage;
                    //image.Location = new Point(5, 5);
                    image.Tag = game.gameMatrix[j, i];
                    image.Name = $"candy{i}{j}";
                    image.Click += new System.EventHandler(this.candy_Click);

                    game.gameMatrix1[j, i] = (image);
                    this.Controls.Add(image);
                }
            }
        }
        private PictureBox GetPictureBoxByPosition(Position pos)
        {
            int index = pos.y*10+ pos.x;
             return this.Controls.OfType<PictureBox>().ToList()[index];
        }

        private async void DestroyCandies(List<Candy> candies)
        {
            await Task.Delay(300);
            for (int i = 0; i < candies.Count; i++)
            {
                //message += "\n" + candies[i].Position.ToString();
                //GetPictureBoxByPosition(candies[i].Position).Visible = false;
                GetPictureBoxByPosition(candies[i].Position).Visible = false;
                game.GetCandyByPos(candies[i].Position).Value = 0;
            } 
        }
        private  void SwitchingCandies(ref PictureBox picture1,ref PictureBox picture2)
        {
            
            var tempPictureBoxImage = (picture1).Image;
            int tempCandyVal = (picture1.Tag as Candy).Value;
            var tempPictureBoxVisibility = (picture1).Visible;

            (picture1).Image = (picture2).Image;
            (picture1.Tag as Candy).Value = (picture2.Tag as Candy).Value;
            game.GetCandyByPos((picture1.Tag as Candy).Position).Value = (picture2.Tag as Candy).Value;
            picture1.Visible = picture2.Visible;

            (picture2).Image = tempPictureBoxImage;
            (picture2.Tag as Candy).Value = tempCandyVal;
            game.GetCandyByPos((picture2.Tag as Candy).Position).Value = tempCandyVal;
            picture2.Visible = tempPictureBoxVisibility;

            
        }

        private async void SettingRandomCandies()
        {
            // MessageBox.Show("");
            await Task.Delay(300);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (game.gameMatrix[i, j].Value == 0)
                    {
                        int val = GetRandomNum(1, 5);
                        game.gameMatrix[i, j].Value = val;
                        
                        PictureBox p = GetPictureBoxByPosition(game.gameMatrix[i, j].Position); ;
                        p.Image = Image.FromFile($@"D:\programming project\csharp\Candy Crush\Candy Crush\Images\Candy{val}.png");
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
                    if (game.gameMatrix[i, j].Value == 0)
                    {
                        //message += "\n" + game.gameMatrix[i, j].Position;
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (game.gameMatrix[i, k].Value != 0)
                            {
                                //message += $"\n switching {game.gameMatrix[i, j].Position.ToString()} with {game.gameMatrix[i, k].Position.ToString()}" ;
                                PictureBox p1 = GetPictureBoxByPosition(game.gameMatrix[i, k].Position);
                                PictureBox p2 = GetPictureBoxByPosition(game.gameMatrix[i, j].Position);
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
            PictureBox candyBox = ((PictureBox)sender);
            PictureBox second = candyBox;
            Check( candyBox,  second);

        }

        private async void Check(PictureBox candyBox, PictureBox second)
        {
            Candy secondCandy = second.Tag as Candy;
            if (game.Moves < 10)
            {
                if (lastSelected != null && !(lastSelected.Tag as Candy).Position.Equal(secondCandy.Position))
                {
                    PictureBox first = lastSelected;
                    Candy firstCandy = first.Tag as Candy;
                    //osition newPos = new Position(changeCandy.Position.x, changeCandy.Position.y);
                    bool canTransfer = firstCandy.Position.CanChange(secondCandy.Position);
                    //MessageBox.Show(canTransfer.ToString());

                    if (canTransfer && firstCandy.Value != secondCandy.Value)
                    {
                        //Panel changePanel = GetPictureBoxByPosition(newPos);
                        game.Moves++;
                        movesLbl.Text = "Moves : " + game.Moves;
                        SwitchingCandies(ref second, ref first);
                        List<Candy> candies = game.ListOfDestroyableCandies(secondCandy.Position);
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
                    lastSelected = null;
                }
                else
                {
                    lastSelected = candyBox;
                }
            }
            else
            {
                if (!isCompetion)
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
                        UpdateCompetionData(game.Score);
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

        private void UpdateCompetionData(int score)
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
