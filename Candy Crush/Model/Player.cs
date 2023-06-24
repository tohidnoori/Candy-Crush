using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Candy_Crush
{
    internal class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public int Record { get; set; } 
        public int Wins { get; set; } 
        public int Loses { get; set; } 
        public int PlayedNum { get; set; }

        public string IsFriend { get; set; }

        public List<int> FriendList { get; set;} = new List<int>();   
    
        public string PlayerToFileFormat()
        {
            string friendListString = "";
            for (int i =0;i< FriendList.Count(); i++)
            {
                friendListString += FriendList[i].ToString()+ "-";
            }
            return $"{Id},{Username},{Password},{Wins},{Loses},{Record},{friendListString}";
        }
        public void SavePlayerDataToFile()
        {
            string path = @"D:\candy_crush.txt";
            if(!File.Exists(path))
            {
                File.Create(path);
            }
            File.WriteAllText( path,"");
            File.WriteAllText(path,this.PlayerToFileFormat());
        }

        public Player LoadPlayerDataFromFile()
        {
            string path = @"D:\candy_crush.txt";
            string[] playerDetails = File.ReadAllText(path).Split(',');
            var friendList = playerDetails[6].Split('-').ToList();
            List<int> friendIdList = new List<int>();
            //MessageBox.Show(friendList.Count().ToString());
            friendList.ForEach(friendId => {
                if (friendId != "")
                {
                    friendIdList.Add(int.Parse(friendId));
                }
            });
            return new Player()
            {
                Id = int.Parse(playerDetails[0]),
                Username = playerDetails[1],
                Password = playerDetails[2],
                Wins = int.Parse(playerDetails[3]),
                Loses = int.Parse(playerDetails[4]),
                Record = int.Parse(playerDetails[5]),
                FriendList= friendIdList
            };

        }
    }
}
