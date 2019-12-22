using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Medium
{
    class ThereIsNoSpoon
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<int>> horizontal = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> vertical = new Dictionary<int, List<int>>();

            int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
            int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
            for (int i = 0; i < height; i++)
            {
                horizontal.Add(i, new List<int>());
                string line = Console.ReadLine(); // width characters, each either 0 or .
                                                  //Console.Error.WriteLine(line);
                for (int j = 0; j < line.Length; j++)
                {
                    if (!vertical.ContainsKey(j))
                    {
                        vertical.Add(j, new List<int>());
                    }

                    if (line[j] == '0')
                    {
                        horizontal[i].Add(j);
                        vertical[j].Add(i);
                    }
                }
            }

            HashSet<string> seen = new HashSet<string>();

            foreach (int i in horizontal.Keys)
            {
                for (int j = 0; j < horizontal[i].Count(); j++)
                {
                    int curr = horizontal[i][j];

                    int rightX = j + 1 < horizontal[i].Count() ? horizontal[i][j + 1] : -1;
                    int rightY = rightX == -1 ? -1 : i;

                    int idx = vertical[curr].IndexOf(i);
                    int bottomY = idx + 1 < vertical[curr].Count() ? vertical[curr][idx + 1] : -1;
                    int bottomX = bottomY == -1 ? -1 : curr;

                    Console.WriteLine($"{curr} {i} {rightX} {rightY} {bottomX} {bottomY}");
                }
            }
            
            Console.WriteLine("0 0 1 0 0 1");
        }
    }
}
