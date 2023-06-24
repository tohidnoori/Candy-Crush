using Candy_Crush.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point((SystemInformation.PrimaryMonitorSize.Width - this.Width) / 2, (SystemInformation.PrimaryMonitorSize.Height - this.Height) / 2);
            Point gameTableStartPoint = new Point(20, 20);
            string Messages = "";

            game = new Game(10);
            for (int i = 0;i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    PictureBox image = new PictureBox();
                    Panel pan = new Panel();
                    Candy candy = new Candy(GetRandomNum(1, 5));
                    candy.Position = new Position(j, i);
                    game.gameTable[j, i] = candy;
                    pan.Size = new Size(60,60);
                    pan.Location = new Point(gameTableStartPoint.X + (65) * (j), gameTableStartPoint.Y + (65 * (i)));
                    image.Size = new Size(60, 60);
                    image.Image = Image.FromFile($@"D:\programming project\csharp\Candy Crush\Candy Crush\Images\Candy{candy.Value}.png");
                    image.SizeMode = PictureBoxSizeMode.StretchImage;
                    //image.Location = new Point(5, 5);

                    for(int k = 0; k < 4; k++)
                    {
                        PictureBox arrow = new PictureBox();
                        arrow.Size = new Size(20, 20);
                        arrow.SizeMode = PictureBoxSizeMode.StretchImage;
                        switch (k)
                        {
                            case 0:
                                arrow.Image = Image.FromFile($@"D:\programming project\csharp\Candy Crush\Candy Crush\Images\up.png");
                                arrow.Location = new Point(20, 0);
                                arrow.Tag = "Right";
                                break;
                            case 1:
                                arrow.Image = Image.FromFile($@"D:\programming project\csharp\Candy Crush\Candy Crush\Images\left.png");
                                arrow.Location = new Point(0, 20);
                                arrow.Tag = "Left";
                                break;
                            case 2:
                                arrow.Image = Image.FromFile($@"D:\programming project\csharp\Candy Crush\Candy Crush\Images\right1.png");
                                arrow.Location = new Point(40, 20);
                                arrow.Tag = "Right";
                                break;
                            case 3:
                                arrow.Image = Image.FromFile($@"D:\programming project\csharp\Candy Crush\Candy Crush\Images\bottom.png");
                                arrow.Location = new Point(20, 40);
                                arrow.Tag = "Down";
                                break;
                        }
                        arrow.Visible= false;
                        arrow.Click += new System.EventHandler(this.arrow_Click);
                        pan.Controls.Add(arrow);
                    }
                    pan.Tag = candy;
                    pan.Name = $"candy{i}{j}";
                    image.Click += new System.EventHandler(this.candy_Click);
                    
                    pan.Controls.Add(image);
                    game.gameTable1[j, i]=(pan);
                    this.Controls.Add(pan);
                }
            }

            //MessageBox.Show(messages);

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

        private void arrow_Click(object sender, EventArgs e)
        {

            Panel candyBox = ((PictureBox)sender).Parent as Panel;
            PictureBox arrow = ((PictureBox)sender);
            Candy changeCandy = candyBox.Tag as Candy;
            Position newPos = new Position(changeCandy.Position.x,changeCandy.Position.y);
            switch (arrow.Tag)
            {
                case "Right":
                    newPos.x = newPos.x + 1;

                    break;
                case "Left":
                    newPos.x = newPos.x - 1;

                    break;
                case "Up":
                    newPos.y = newPos.y - 1;

                    break;
                case "Down":
                    newPos.y = newPos.y + 1;

                    break;
            }
            //moving candy
            if (lastSelectedPanel != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    candyBox.Controls[i].Visible = false;
                }
            }
            if (game.DoesThisPosExist(newPos))
            {
                if (game.GetCandyByPos(newPos).Value != changeCandy.Value)
                {
                    Panel changePanel = GetPanelByPosition(newPos);
                    game.Moves++;
                    movesLbl.Text = "Moves : " + game.Moves;
                    SwitchingCandies(ref changePanel, ref candyBox);
                    List<Candy> candies = game.destroyableCandies(newPos);
                    if (candies.Count >= 3)
                    {
                        game.Score += candies.Count * candies[0].Value;
                        DestroyCandies(candies);
                        CandyComingFromUp();
                        SettingRandomCandies();
                        scoreLbl.Text = "Score : " + game.Score;
                    }
                }
            }
            
        }

        private void SwitchingCandies(ref Panel panel1,ref Panel panel2)
        {
            var tempPanelImage = (panel1.Controls[4] as PictureBox).Image;
            int tempCandyVal = (panel1.Tag as Candy).Value;
            var tempPanelVisibility = (panel1).Visible;

            (panel1.Controls[4] as PictureBox).Image = (panel2.Controls[4] as PictureBox).Image;
            (panel1.Tag as Candy).Value = (panel2.Tag as Candy).Value;
            game.GetCandyByPos((panel1.Tag as Candy).Position).Value = (panel2.Tag as Candy).Value;
            panel1.Visible = panel2.Visible;

            (panel2.Controls[4] as PictureBox).Image = tempPanelImage;
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
                        PictureBox a = p.Controls[4] as PictureBox;
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
            Candy c = candyBox.Tag as Candy;

            if (lastSelectedPanel != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    lastSelectedPanel.Controls[i].Visible = false;
                }
            }
            
            //List<Directions> directions = game.checkMovingOptions(c.Position);
            for (int i = 0; i < 4; i++)
            {
                candyBox.Controls[i].Visible = true;
            }
            lastSelectedPanel = candyBox;
        }

        public static int GetRandomNum(int min, int max)
        {
            return random.Next(min, max);
        }

        private void gameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

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
