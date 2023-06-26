using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candy_Crush.Model
{
    internal class FriendReq
    {
        public int ID { get; set; }
        public int SenderID { get; set; }
        public int GeterID { get; set; }

        public Player SenderPlayer { get; set; }

        public int Status { get; set; }
    }
}
