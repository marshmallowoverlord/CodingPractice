using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.HorseRacingHyperduals
{
    class HorseRacingHyperduals
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Horse[] horses = new Horse[N];
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                long V = Int64.Parse(inputs[0]);
                long E = Int64.Parse(inputs[1]);
                horses[i] = new Horse(V, E);
            }

            horses = horses.OrderBy(x => x.V).ToArray();
            //Console.Error.WriteLine(string.Join(",", horses.Select(x => x.V)));


            Console.WriteLine(CalculateShortest(horses, Int64.MaxValue));
        }

        public static long CalculateShortest(Horse[] horses, long distance)
        {
            if (horses.Length <= 3)
            {
                //Console.Error.WriteLine("Brute: " + BruteCalculate(horses) + " , " + distance);
                return Math.Min(BruteCalculate(horses), distance);
            }

            int mid = horses.Length / 2;

            long disLeft = CalculateShortest(horses.Take(mid).ToArray(), distance);
            long disRight = CalculateShortest(horses.Skip(mid).Take(horses.Length - mid).ToArray(), distance);

            long shortest = Math.Min(disLeft, disRight);
            //Console.Error.WriteLine("LR: " + disLeft + " , " + disRight);

            long stripD = (long)Math.Sqrt(shortest - Math.Pow(mid, 2));
            List<Horse> stripL = new List<Horse>();
            List<Horse> stripR = new List<Horse>();
            List<Horse> stripM = new List<Horse>();

            for (int i = 0; i < horses.Length; i++)
            {
                if (horses[mid].V - shortest <= horses[i].V && horses[i].V < horses[mid].V)
                {
                    stripL.Add(horses[i]);
                }
                else if (horses[i].V <= horses[mid].V + shortest && horses[i].V >= horses[mid].V)
                {
                    stripR.Add(horses[i]);
                }
                if (horses[i].V == horses[mid].V)
                {
                    stripM.Add(horses[i]);
                }
            }

            stripL = stripL.OrderBy(x => x.E).ToList();
            stripR = stripR.OrderBy(x => x.E).ToList();
            //Console.Error.WriteLine("stripL: " + string.Join(",", stripL.Select(x => x.V + "-" + x.E)));
            //Console.Error.WriteLine("stripR: " + string.Join(",", stripR.Select(x => x.V + "-" + x.E)));
            for (int i = 0; i < stripL.Count(); i++)
            {
                for (int j = 0; j < stripR.Count(); j++)
                {
                    shortest = Math.Min(shortest, CalculateDistance(stripL[i], stripR[j]));
                    //Console.Error.WriteLine("strip: " + shortest + " , " + CalculateDistance(stripL[i], stripR[j]));
                }
            }
            for (int i = 0; i < stripM.Count(); i++)
            {
                for (int j = i + 1; j < stripM.Count(); j++)
                {
                    shortest = Math.Min(shortest, CalculateDistance(stripM[i], stripM[j]));
                    //Console.Error.WriteLine("middle: " + shortest + " , " + CalculateDistance(stripM[i], stripM[j]));
                }
            }
            //Console.Error.WriteLine("dis: " + shortest + " , " + distance);
            return Math.Min(shortest, distance);
        }

        public static long BruteCalculate(Horse[] h)
        {
            long shortest = Int64.MaxValue;

            for (int i = 0; i < h.Length; i++)
            {
                shortest = Math.Min(shortest, CalculateDistance(h[i % h.Length], h[(i + 1) % h.Length]));
            }
            return shortest;
        }

        public static long CalculateDistance(Horse h1, Horse h2)
        {
            return Math.Abs(h2.V - h1.V) + Math.Abs(h2.E - h1.E);
        }

        public class Horse
        {
            public long V;
            public long E;

            public Horse(
                long v,
                long e
            )
            {
                V = v;
                E = e;
            }
        }
    }
}
