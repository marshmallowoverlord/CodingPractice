using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.DolbearsLaw
{
    class DolbearsLaw
    {
        static void Main(string[] args)
        {
            int M = int.Parse(Console.ReadLine());

            List<double> chirpsPerMin = new List<double>();
            List<double> chirpsPerSec = new List<double>();

            double n8 = 0;
            for (int i = 0; i < M; i++)
            {
                string[] LINE = Console.ReadLine().Split(' ');
                double n60 = 0;
                for (int j = 0; j < LINE.Length; j++)
                {
                    double n = Int32.Parse(LINE[j]);
                    n60 += n;
                    n8 += n;

                    if ((i * LINE.Length + j + 1) % 2 == 0)
                    {
                        chirpsPerSec.Add(n8);
                        n8 = 0;
                    }
                }
                chirpsPerMin.Add(n60);
            }

            double avgN60 = (double)chirpsPerMin.Select(x => CalcN60(x)).Sum() / chirpsPerMin.Count();

            Console.WriteLine(string.Format("{0:0.0}", avgN60));
            if (5 <= avgN60 && avgN60 <= 30)
            {
                double avgN8 = chirpsPerSec.Select(x => CalcN8(x)).Sum() / chirpsPerSec.Count();
                Console.WriteLine(string.Format("{0:0.0}", avgN8));
            }
        }

        public static double CalcN60(double chirps)
        {
            return 10 + (chirps - 40) / 7;
        }

        public static double CalcN8(double chirps)
        {
            return chirps + 5;
        }
    }
}
