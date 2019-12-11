using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.Smooth
{
    class Smooth
    {
        static void Main(string[] args)
        {
            int[] bundles = new int[] { 5, 3, 2 };

            Dictionary<long, bool> victorious = new Dictionary<long, bool>();

            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                long F = long.Parse(Console.ReadLine());
                long f = F;
                bool victory = true;
                while (f > 1 && victory)
                {
                    if (victorious.ContainsKey(f))
                    {
                        victory = victorious[f];
                        break;
                    }

                    foreach (int b in bundles)
                    {
                        if (f % b == 0)
                        {
                            f = f / b;
                            victory = true;
                            break;
                        }
                        else
                        {
                            victory = false;
                        }
                    }
                }

                if (!victorious.ContainsKey(F))
                {
                    victorious.Add(F, victory);
                }
                Console.WriteLine(victory ? "VICTORY" : "DEFEAT");
            }
        }
}
