using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.StallTilt
{
    class StallTilt
    {
        static void Main(string[] args)
        {
            List<Bike> bikes = new List<Bike>();

            int n = int.Parse(Console.ReadLine());
            int v = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int speed = int.Parse(Console.ReadLine());
                bikes.Add(new Bike()
                {
                    Speed = speed,
                    Name = (char)(97 + i)
                });
            }
            int opt = 60;
            int bottomBound = 60;
            int topBound = 0;
            int[] topSpeeds = new int[v];

            List<char> rank = new List<char>();
            for (int i = 0; i < v; i++)
            {
                int radius = int.Parse(Console.ReadLine());
                int maxNotFall = 0;
                int minFall = 60;
                List<Bike> fell = new List<Bike>();
                foreach (Bike bike in bikes)
                {
                    //Console.Error.WriteLine(radius + "|" + bike.Name + ": " + bike.Speed + " : " +  CalcAngle(bike.Speed, radius));
                    if (CalcAngle(bike.Speed, radius) > 30)
                    {
                        maxNotFall = Math.Max(maxNotFall, bike.Speed);
                    }
                    else
                    {
                        minFall = Math.Min(minFall, bike.Speed);
                        if (!rank.Contains(bike.Name))
                        {
                            fell.Add(bike);
                        }
                    }
                }

                bottomBound = Math.Min(maxNotFall, bottomBound);
                topBound = Math.Max(minFall, topBound);

                Console.Error.WriteLine(bottomBound + " - " + topBound);
                int x = bottomBound;
                while (x < topBound)
                {
                    Console.Error.WriteLine(x + ": " + CalcAngle(x, radius));
                    if (CalcAngle(x, radius) > 30)
                    {
                        x++;
                    }
                    else
                    {
                        break;
                    }
                }
                opt = Math.Min(opt, x - 1);


                rank.AddRange(fell.OrderBy(b => b.Speed).Select(b => b.Name));
            }

            foreach (Bike b in bikes.OrderBy(x => x.Speed))
            {
                if (!rank.Contains(b.Name))
                {
                    rank.Add(b.Name);
                }
            }

            Console.WriteLine(opt);
            Console.WriteLine("y");
            rank.Reverse();
            foreach (char c in rank)
            {
                Console.WriteLine(c);
            }

        }

        public static int CalcAngle(int v, int r)
        {
            return 90 - (int)(Math.Atan(Math.Pow(v, 2) / (r * 9.81)) * (180 / Math.PI));
        }

        public static int CalcOpt(int r)
        {
            return (int)Math.Sqrt(Math.Tan(90 - 31) * (r * 9.81));
        }

        public class Bike
        {
            public int Speed;
            public char Name;
        }
    }
}
