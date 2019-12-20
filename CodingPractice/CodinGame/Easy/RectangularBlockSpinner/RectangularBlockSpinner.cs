using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.RectangularBlockSpinner
{
    class RectangularBlockSpinner
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int angle = int.Parse(Console.ReadLine());
            int rotate = (angle / 45) % 8;
            string[,] diamond = new string[size * 2 - 1, size * 2 - 1];
            string[,] square = new string[size, size];
            for (int i = 0; i < size; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                for (int j = 0; j < line.Length; j++)
                {
                    switch (rotate)
                    {
                        case 1:
                            diamond[size - 1 + i - j, j + i] = line[j];
                            break;
                        case 3:
                            diamond[2 * size - 2 - i - j, size - 1 + i - j] = line[j];
                            break;
                        case 5:
                            diamond[size - 1 - i + j, 2 * size - 2 - i - j] = line[j];
                            break;
                        case 7:
                            diamond[i + j, size - 1 - i + j] = line[j];
                            break;
                        case 2:
                            square[size - 1 + i, j] = line[j];
                            break;
                        case 4:
                            square[size - 1 - i, size - 1 - j] = line[j];
                            break;
                        case 6:
                            square[j, size - 1 - i] = line[j];
                            break;
                    }
                }
            }
            string[,] shape = rotate % 2 == 0 ? square : diamond;
            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int j = 0; j < shape.GetLength(1); j++)
                {
                    Console.Write((shape[i, j] != null ? shape[i, j] : " "));
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
