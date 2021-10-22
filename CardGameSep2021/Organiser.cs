using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGameSep2021
{
    class Organiser
    {
        public List<Player> GetPlayers(string url) {
            List<Player> players = new List<Player>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(url).ToList();
            foreach (string line in lines) {
                
                string[] values = line.Split(',');
                if (values.Length >= 2) { 
                //MessageBox.Show("value 0 " + values[0] + " value 1 " + values[1] + " value2 " + values[2]);
                Player p = new Player(values[0], Convert.ToInt32(values[1]), Convert.ToInt32(values[2]));
                players.Add(p);
                }
            }
            return players;
        }
        public void storeData(List<Player> players,string url) {
            StringBuilder sb = new StringBuilder();
            List<string> outfiles = new List<string>();
            foreach(Player p in players)
            {
                sb.Append(p.player_Username);
                sb.Append(',');
                sb.Append(p.player_Tries.ToString());
                sb.Append(',');
                sb.Append(p.player_Seconds);
                sb.Append(Environment.NewLine);
                outfiles.Add(sb.ToString());
                sb.Clear();
            }
            File.WriteAllLines(url, outfiles);
        }
       public List<Player> getTop10(List<Player> players)
        {
            Console.WriteLine(players.Count);
            
            List<Player> top = bubbleSort(players);
           
            return top;
        }
        List<Player> bubbleSort(List<Player> players)
        {
            int n = players.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (players[j].player_Tries > players[j + 1].player_Tries)
                    {
                        // swap arr[j+1] and arr[j]
                        Player temp = players[j];
                        players[j] = players[j + 1];
                        players[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine(players.Count);
            return players;
        }
            
        
    }
}
