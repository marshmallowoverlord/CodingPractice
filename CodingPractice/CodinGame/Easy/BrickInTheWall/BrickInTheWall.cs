using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.BrickInTheWall
{
    class BrickInTheWall
    {
        static void Main(string[] args)
        {
            int X = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            string[] inputs = Console.ReadLine().Split(' ');

            int[] bricks = new int[N];

            for (int i = 0; i < N; i++)
            {
                int m = int.Parse(inputs[i]);
                bricks[i] = m;
            }

            bricks = bricks.OrderByDescending(c => c).ToArray();

            int placed = 0;
            int row = 0;
            double count = 0.000;
            while (placed < bricks.Length)
            {
                for (int i = 0; i < X && placed < bricks.Length; i++)
                {
                    Console.Error.WriteLine(X + " " + row + " " + i + " = " + (X * row + i));
                    count += CalcWork(row, bricks[X * row + i]);
                    placed++;
                }
                row++;
            }

            Console.WriteLine(string.Format("{0:0.000}", count));
        }

        public static double CalcWork(int row, int weight)
        {
            return (row * 6.5 / 100) * 10 * weight;
        }
    }
}
