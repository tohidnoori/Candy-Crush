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
