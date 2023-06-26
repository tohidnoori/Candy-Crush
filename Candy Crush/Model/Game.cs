using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Candy_Crush
{
    enum Directions
    {
        Up=0, Left = 1, Right = 2, Down =3,Static=4
    }
    internal class Game
    {

        public Candy[,] gameMatrix { get; set; }
        public PictureBox[,] gameMatrix1 { get; set; }

        public int GameMatrixSize { get; set; } = 0;
        public int Moves { get; set; } = 0;

        public int Score { get; set; } = 0;

        public Game(int size) {
            gameMatrix = new Candy[size,size]; 
            gameMatrix1= new PictureBox[size,size];
            GameMatrixSize = size;
        }
        public void MakeRandomGameMatrix()
        {
            for(int i = 0; i < GameMatrixSize; i++)
            {
                for (int j = 0; j < GameMatrixSize; j++)
                {
                    Candy candy = new Candy(GameForm.GetRandomNum(1, 5));
                    candy.Position = new Position(j, i);
                    gameMatrix[j, i] = (candy);
                }
            }
            
        }

        public string GameMatrixToString()
        {
            String gameMatrixString = "";
            for (int i = 0; i < GameMatrixSize; i++)
            {
                for (int j = 0; j < GameMatrixSize; j++)
                {
                    gameMatrixString+= gameMatrix[j, i].Value +"-";
                }
            }
            return gameMatrixString;
        }

        public void StringTogameMatrix(string gameMatrixString)
        {
            List<String> list = gameMatrixString.Split('-').ToList();
            for (int i = 0; i < GameMatrixSize; i++)
            {
                for (int j = 0; j < GameMatrixSize; j++)
                {
                    Candy candy = new Candy(int.Parse(list[j + i * 10]));
                    candy.Position = new Position(j, i);
                    gameMatrix[j, i] = (candy);
                }
            }
        }
        public ref Candy GetCandyByPos(Position pos)
        {
            return ref gameMatrix[pos.x, pos.y];

        }
        public bool DoesThisPosExist(Position pos)
        {
            if (pos.x < GameMatrixSize && pos.x>=0 && pos.y>=0&&pos.y<GameMatrixSize)
            {
                return true;
            }
            return false;
        }

        public PictureBox GetPanelByPos(Position pos)
        {
            return gameMatrix1[pos.x, pos.y];
        }
        public List<Directions> checkMovingOptions(Position position)
        {

            List<Directions> directions = new List<Directions>();
            if (position.x - 1 >= 0 && gameMatrix[position.x - 1, position.y].Value != gameMatrix[position.x,position.y].Value)
            {
                directions.Add(Directions.Left);
            }
            if (position.x + 1 < 10 && gameMatrix[position.x +1, position.y].Value != gameMatrix[position.x, position.y].Value)
            {
                directions.Add(Directions.Right);

            }
            if (position.y - 1 >= 0 && gameMatrix[position.x, position.y-1].Value != gameMatrix[position.x, position.y].Value)
            {
                directions.Add(Directions.Up);

            }
            if (position.y + 1 < 10 && gameMatrix[position.x , position.y+1].Value != gameMatrix[position.x, position.y].Value)
            {
                directions.Add(Directions.Down);

            }
            return directions;
        }
        private List<Candy> candies = new List<Candy>();

        public bool IsExistInDestrotingCandiesList(Position pos)
        {
            for(int i=0; i< candies.Count; i++)
            {
                if (pos.Equal(candies[i].Position))
                {
                    return true;
                }
            }
            return false;
        }
        public void FindCandiesToDestroy(Position position, Directions opdirections1)
        {
            Position checkingPos = new Position(position.x - 1, position.y);
            if (opdirections1 != Directions.Left
                && position.x - 1 >= 0
                && GetCandyByPos(checkingPos).Value == GetCandyByPos(position).Value
                && !IsExistInDestrotingCandiesList(checkingPos)
                )
            {
                candies.Add(GetCandyByPos(checkingPos));
                FindCandiesToDestroy(checkingPos, Directions.Right);
            }

            checkingPos = new Position(position.x + 1, position.y);
            if (opdirections1 != Directions.Right
                && position.x + 1 < 10
                && GetCandyByPos(checkingPos).Value == GetCandyByPos(position).Value
                && !IsExistInDestrotingCandiesList(checkingPos)
                )
            {
                candies.Add(GetCandyByPos(checkingPos));
                FindCandiesToDestroy(checkingPos, Directions.Left);
            }

            checkingPos = new Position(position.x, position.y - 1);
            if (opdirections1 != Directions.Up
                && position.y - 1 >= 0
                && GetCandyByPos(checkingPos).Value == GetCandyByPos(position).Value
                && !IsExistInDestrotingCandiesList(checkingPos)
                )
            {
                candies.Add(GetCandyByPos(checkingPos));
                FindCandiesToDestroy(checkingPos, Directions.Down);
            }

            checkingPos = new Position(position.x, position.y + 1);
            if (
                opdirections1 != Directions.Down
                && position.y + 1 < 10
                && GetCandyByPos(checkingPos).Value == GetCandyByPos(position).Value
                &&!IsExistInDestrotingCandiesList(checkingPos)
               )
            {
                candies.Add(GetCandyByPos(checkingPos));
                FindCandiesToDestroy(checkingPos, Directions.Up);
            }
        }

        public List<Candy> ListOfDestroyableCandies(Position position)
        {
            candies.Clear();
            candies.Add(gameMatrix[position.x, position.y]);
            FindCandiesToDestroy(position, Directions.Static);
            return candies;
        }

    }
}
