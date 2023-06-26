using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candy_Crush
{
    public class Position
    {
        public int x;
        public int y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"({x},{y})";
        }

        public  bool Equal(Position other)
        {
            if(x== other.x&& y== other.y)
                return true ;
            return false ;
        }

        public bool CanChange(Position other)
        {
            if (Math.Abs(other.x - x) == 1 && other.y - y == 0)
            {
                return true ;
            }
            if (Math.Abs(other.y - y) == 1 && other.x - x == 0)
            {
                return true;
            }
            return false ;
        }
    }
    internal class Candy
    {
        public int Value { get; set; } = 0;
        public  Position Position { get; set; }
        public Candy(int value)
        {
            Value = value;
        }
        public Candy()
        {

        }
    }
}
