using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candy_Crush.Model
{
    internal class Competetion
    {
        public int Id { get; set; }
        public int WinnerId { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public int GameStatus { get; set; }
        public string GameTable { get; set; }
    }
}
