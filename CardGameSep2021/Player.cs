using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameSep2021
{
     public class Player
    {
        private int tries;
        private string username;
        private int seconds;

        public Player(string username, int tries, int seconds)
        {
            this.tries = tries;
            this.username = username;
            this.seconds = seconds;
        }

        public int player_Tries{ 
            get{return tries;}
            set{tries=value;}
        }
        public int player_Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }
        public string player_Username
        {
            get { return username; }
            set { username = value; }
        }
    }
}
