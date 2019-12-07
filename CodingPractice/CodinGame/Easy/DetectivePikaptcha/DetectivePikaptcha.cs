using System;

namespace CodingPractice.CodinGame.Easy
{
    class DetectivePikaptcha
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int width = int.Parse(inputs[0]);
            int height = int.Parse(inputs[1]);

            string[,] grid = new string[height, width];
            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < width; j++)
                {
                    grid[i, j] = line[j].ToString();
                }
            }

            for (int i = 0; i < height; i++)
            {
                string line = "";
                for (int j = 0; j < width; j++)
                {
                    if (grid[i, j] != "#")
                    {
                        int count = 0;
                        // north
                        count += 0 < i && grid[i - 1, j] != "#" ? 1 : 0;
                        // east
                        count += j < width - 1 && grid[i, j + 1] != "#" ? 1 : 0;
                        // south
                        count += i < height - 1 && grid[i + 1, j] != "#" ? 1 : 0;
                        //west
                        count += 0 < j && grid[i, j - 1] != "#" ? 1 : 0;

                        grid[i, j] = count.ToString();
                    }
                    line += grid[i, j];
                }
                Console.WriteLine(line);
            }
        }
    }
}
