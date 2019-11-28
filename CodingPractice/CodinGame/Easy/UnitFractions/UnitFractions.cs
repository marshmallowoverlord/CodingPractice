using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingPractice.CodinGame.Easy.UnitFractions
{
    class UnitFractions
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double target = (double)1 / n;
            double v1 = n + 1;
            double v2 = Double.MinValue;

            List<Pair> pairs = new List<Pair>();

            while (v1 != v2 && v1 <= n * 2)
            {
                v2 = (n * v1) / (v1 - n);
                if (v2 % 1 == 0)
                {
                    pairs.Add(new Pair(
                        Math.Max(v1, v2),
                        Math.Min(v1, v2)
                    ));
                }

                v1++;
            }

            foreach (Pair p in pairs.OrderByDescending(v => v.X))
            {
                Console.WriteLine($"1/{n} = 1/{p.X} + 1/{p.Y}");
            }
        }

        public class Pair
        {
            public double X;
            public double Y;

            public Pair(
                double x,
                double y
            )
            {
                X = x;
                Y = y;
            }
        }

        public static int LCM(int a, int b)
        {
            return (a * b) / GCD(a, b);
        }

        public static int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return GCD(b, a % b);
            }
        }
    }
}
