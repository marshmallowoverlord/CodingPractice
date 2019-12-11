using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.SelfDrivingCarTesting
{
    class SelfDrivingCarTesting
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string xthenCommands = Console.ReadLine();

            int idx = xthenCommands.IndexOf(';');

            int pos = Int32.Parse(xthenCommands.Substring(0, idx)) - 1;
            string[] commands = xthenCommands.Substring(idx + 1).Split(';');

            List<string> road = new List<string>();
            for (int i = 0; i < N; i++)
            {
                string rthenRoadpattern = Console.ReadLine();
                int len = Int32.Parse(rthenRoadpattern.Split(';')[0]);
                for (int j = 0; j < len; j++)
                {
                    road.Add(rthenRoadpattern.Split(';')[1]);
                }
            }

            int currIdx = 0;
            for (int i = 0; i < commands.Length; i++)
            {
                int rep = Int32.Parse(commands[i].Substring(0, commands[i].Length - 1));
                string dir = commands[i].Substring(commands[i].Length - 1);
                for (int j = 0; j < rep; j++)
                {
                    StringBuilder sb = new StringBuilder(road[currIdx]);
                    switch (dir)
                    {
                        case "R":
                            pos++;
                            break;
                        case "L":
                            pos--;
                            break;
                    }
                    sb[pos] = '#';
                    Console.WriteLine(sb.ToString());
                    currIdx++;
                }
            }
        }
    }
}
