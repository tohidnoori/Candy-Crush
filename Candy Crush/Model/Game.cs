using System;
using System.Collections.Generic;
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

        public Candy[,] gameTable { get; set; }
        public Panel[,] gameTable1 { get; set; }

        public int TableSize { get; set; } = 0;
        public int Moves { get; set; } = 0;

        public int Score { get; set; } = 0;

        public Game(int size) {
            gameTable = new Candy[size,size]; 
            gameTable1= new Panel[size,size];
            TableSize = size;
        }

        public ref Candy GetCandyByPos(Position pos)
        {
            return ref gameTable[pos.x, pos.y];

        }
        public bool DoesThisPosExist(Position pos)
        {
            if (pos.x < TableSize && pos.x>=0 && pos.y>=0&&pos.y<TableSize)
            {
                return true;
            }
            return false;
        }

        public Panel GetPanelByPos(Position pos)
        {
            return gameTable1[pos.x, pos.y];
        }
        public List<Directions> checkMovingOptions(Position position)
        {

            List<Directions> directions = new List<Directions>();
            if (position.x - 1 >= 0 && gameTable[position.x - 1, position.y].Value != gameTable[position.x,position.y].Value)
            {
                directions.Add(Directions.Left);
            }
            if (position.x + 1 < 10 && gameTable[position.x +1, position.y].Value != gameTable[position.x, position.y].Value)
            {
                directions.Add(Directions.Right);

            }
            if (position.y - 1 >= 0 && gameTable[position.x, position.y-1].Value != gameTable[position.x, position.y].Value)
            {
                directions.Add(Directions.Up);

            }
            if (position.y + 1 < 10 && gameTable[position.x , position.y+1].Value != gameTable[position.x, position.y].Value)
            {
                directions.Add(Directions.Down);

            }
            return directions;
        }
        private List<Candy> candies = new List<Candy>();

        public bool IsExistInDestrotingCAndiesList(Position pos)
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
        public void find(Position position, Directions opdirections1)
        {
            Position checkingPos = new Position(position.x - 1, position.y);
            if (opdirections1 != Directions.Left
                && position.x - 1 >= 0
                && GetCandyByPos(checkingPos).Value == GetCandyByPos(position).Value
                && !IsExistInDestrotingCAndiesList(checkingPos)
                )
            {
                candies.Add(GetCandyByPos(checkingPos));
                find(checkingPos, Directions.Right);
            }

            checkingPos = new Position(position.x + 1, position.y);
            if (opdirections1 != Directions.Right
                && position.x + 1 < 10
                && GetCandyByPos(checkingPos).Value == GetCandyByPos(position).Value
                && !IsExistInDestrotingCAndiesList(checkingPos)
                )
            {
                candies.Add(GetCandyByPos(checkingPos));
                find(checkingPos, Directions.Left);
            }

            checkingPos = new Position(position.x, position.y - 1);
            if (opdirections1 != Directions.Up
                && position.y - 1 >= 0
                && GetCandyByPos(checkingPos).Value == GetCandyByPos(position).Value
                && !IsExistInDestrotingCAndiesList(checkingPos)
                )
            {
                candies.Add(GetCandyByPos(checkingPos));
                find(checkingPos, Directions.Down);
            }

            checkingPos = new Position(position.x, position.y + 1);
            if (
                opdirections1 != Directions.Down
                && position.y + 1 < 10
                && GetCandyByPos(checkingPos).Value == GetCandyByPos(position).Value
                &&!IsExistInDestrotingCAndiesList(checkingPos)
               )
            {
                candies.Add(GetCandyByPos(checkingPos));
                find(checkingPos, Directions.Up);
            }
        }

        public List<Candy> destroyableCandies(Position position)
        {
            candies.Clear();
            candies.Add(gameTable[position.x, position.y]);
            find(position, Directions.Static);
            return candies;
        }

    }
}
