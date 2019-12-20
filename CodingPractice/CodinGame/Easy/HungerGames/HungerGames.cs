using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.HungerGames
{
    class HungerGames
    {
        static void Main(string[] args)
        {
            Dictionary<string, Player> dic = new Dictionary<string, Player>();
            int tributes = int.Parse(Console.ReadLine());
            for (int i = 0; i < tributes; i++)
            {
                string playerName = Console.ReadLine();
                dic.Add(playerName, new Player()
                {
                    Name = playerName
                });
            }
            int turns = int.Parse(Console.ReadLine());
            for (int i = 0; i < turns; i++)
            {
                string[] info = Console.ReadLine().Split(new string[] { " killed " }, StringSplitOptions.None);
                Player p = dic[info[0].Trim()];

                foreach (string n in info[1].Split(','))
                {
                    string curr = n.Trim();
                    p.Killed.Add(curr);
                    dic[n.Trim()].Killer = p.Name;
                }
            }
            List<string> ls = dic.Keys.OrderBy(x => x).ToList();
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            foreach (string p in ls)
            {
                Console.WriteLine("Name: " + dic[p].Name);
                Console.WriteLine("Killed: " + (dic[p].Killed.Count > 0 ? string.Join(", ", dic[p].Killed.OrderBy(x => x)) : "None"));
                Console.WriteLine("Killer: " + (!string.IsNullOrWhiteSpace(dic[p].Killer) ? dic[p].Killer : "Winner"));
                if (p != ls[ls.Count - 1])
                {
                    Console.WriteLine();
                }
            }
        }

        public class Player
        {
            public string Name;
            public List<string> Killed = new List<string>();
            public string Killer;

        }
    }
}
