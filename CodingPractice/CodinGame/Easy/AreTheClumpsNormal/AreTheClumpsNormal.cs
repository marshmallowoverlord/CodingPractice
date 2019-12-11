using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.AreTheClumpsNormal
{
    class AreTheClumpsNormal
    {
        static void Main(string[] args)
        {
            string N = Console.ReadLine();

            // Get all mods        
            Dictionary<int, List<int>> mods = new Dictionary<int, List<int>>();

            for (int i = 1; i < 10; i++)
            {
                List<int> m = new List<int>();
                for (int j = 0; j < 10; j++)
                {
                    m.Add(j % i);
                }
                mods.Add(i, m);
                Console.Error.WriteLine(i + " " + string.Join(",", m));
            }

            // Get N as int[]
            List<int> number = GetNum(N);

            bool normal = true;
            int b = 1;
            int currClumps = 0;
            while (normal && b < 10)
            {

                int clumps = 0;
                int prevMod = -1;
                foreach (int n in number)
                {
                    int currMod = mods[b][n];
                    Console.Error.WriteLine(n + " " + currMod);
                    if (currMod != prevMod)
                    {
                        clumps++;
                        prevMod = currMod;
                    }
                }

                Console.Error.WriteLine(" = " + b + " " + clumps);
                Console.Error.WriteLine("---------------");
                if (clumps >= currClumps)
                {
                    currClumps = clumps;
                    b++;
                }
                else
                {
                    normal = false;
                }
            }



            Console.WriteLine(normal ? "Normal" : b.ToString());
        }

        public static List<int> GetNum(string n)
        {
            List<int> res = new List<int>();
            while (n.Length > 0)
            {
                res.Add(Int32.Parse(n.Substring(n.Length - 1)));
                n = n.Substring(0, n.Length - 1);
            }

            return res;
        }
    }
}
