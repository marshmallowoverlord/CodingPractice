using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.DetectivePikaptcha2
{
    class DetectivePikaptcha2
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int width = int.Parse(inputs[0]);
            int height = int.Parse(inputs[1]);

            Map map = new Map(height, width);

            string[,] grid = map.Grid;

            int startX = 0;
            int startY = 0;
            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < width; j++)
                {
                    string cell = line[j].ToString();
                    grid[i, j] = cell;

                    if (cell != "0" && cell != "#")
                    {
                        map.Direction = cell;
                        grid[i, j] = "0";
                        startX = i;
                        startY = j;
                    }
                }
            }

            map.Side = Console.ReadLine();

            // debug
            /*
            Console.Error.WriteLine("start: " + startX + " , " + startY);

            for (int i = 0; i < height; i++)
            {
                var line = Enumerable.Range(0, grid.GetLength(1))
                    .Select(x => grid[i, x]);

                Console.Error.WriteLine(string.Join("", line));
            }

            Console.Error.WriteLine(map.Side);
            */

            int h = startX;
            int w = startY;

            while (grid[startX, startY] == "0")
            {
                if (!map.MoveOne(h, w, out h, out w))
                {
                    break;
                }
            }

            for (int i = 0; i < height; i++)
            {
                var line = Enumerable.Range(0, grid.GetLength(1))
                    .Select(x => grid[i, x]);

                Console.WriteLine(string.Join("", line));
            }
        }

        public class Map
        {
            public int H;
            public int W;
            public string[,] Grid;
            public string Direction;
            public string Side;

            public Map(int h, int w)
            {
                H = h;
                W = w;
                Grid = new string[h, w];
            }

            public bool MoveOne(int startX, int startY, out int i, out int j)
            {
                i = startX;
                j = startY;

                GetDirection(startX, startY);
                //Console.Error.WriteLine("Direction: " + Direction);
                bool moved = false;
                switch (Direction)
                {
                    case ">":
                        if (CanMoveRight(startX, startY))
                        {
                            j = j + 1;
                            Grid[i, j] = (Int32.Parse(Grid[i, j]) + 1).ToString();
                            moved = true;
                        }
                        break;
                    case "v":
                        if (CanMoveDown(startX, startY))
                        {
                            i = i + 1;
                            Grid[i, j] = (Int32.Parse(Grid[i, j]) + 1).ToString();
                            moved = true;
                        }
                        break;
                    case "<":
                        if (CanMoveLeft(startX, startY))
                        {
                            j = j + -1;
                            Grid[i, j] = (Int32.Parse(Grid[i, j]) + 1).ToString();
                            moved = true;
                        }
                        break;
                    case "^":
                        if (CanMoveUp(startX, startY))
                        {
                            i = i - 1;
                            Grid[i, j] = (Int32.Parse(Grid[i, j]) + 1).ToString();
                            moved = true;
                        }
                        break;
                }

                //Console.Error.WriteLine("ij: " + i + " " + j + " = " + Grid[i,j]);
                return moved;
            }

            public void GetDirection(int x, int y)
            {

                switch (Direction)
                {
                    case ">":
                        if (Side == "L")
                        {
                            Direction = CanMoveUp(x, y) ? "^" :
                                CanMoveRight(x, y) ? ">" :
                                    CanMoveDown(x, y) ? "v" :
                                        "<";
                        }
                        else
                        {
                            Direction = CanMoveDown(x, y) ? "v" :
                               CanMoveRight(x, y) ? ">" :
                                   CanMoveUp(x, y) ? "^" :
                                       "<";
                        }
                        break;
                    case "v":
                        if (Side == "L")
                        {
                            Direction = CanMoveRight(x, y) ? ">" :
                                CanMoveDown(x, y) ? "v" :
                                    CanMoveLeft(x, y) ? "<" :
                                        "^";
                        }
                        else
                        {
                            Direction = CanMoveLeft(x, y) ? "<" :
                               CanMoveDown(x, y) ? "v" :
                                   CanMoveRight(x, y) ? ">" :
                                       "^";
                        }
                        break;
                    case "<":
                        if (Side == "L")
                        {
                            Direction = CanMoveDown(x, y) ? "v" :
                                CanMoveLeft(x, y) ? "<" :
                                    CanMoveUp(x, y) ? "^" :
                                        ">";
                        }
                        else
                        {
                            Direction = CanMoveUp(x, y) ? "^" :
                               CanMoveLeft(x, y) ? "<" :
                                   CanMoveDown(x, y) ? "v" :
                                       ">";
                        }
                        break;
                    case "^":
                        if (Side == "L")
                        {
                            Direction = CanMoveLeft(x, y) ? "<" :
                                CanMoveUp(x, y) ? "^" :
                                    CanMoveRight(x, y) ? ">" :
                                        "v";
                        }
                        else
                        {
                            Direction = CanMoveRight(x, y) ? ">" :
                               CanMoveUp(x, y) ? "^" :
                                   CanMoveLeft(x, y) ? "<" :
                                       "v";
                        }
                        break;
                }
            }

            public bool CanMoveUp(int startX, int startY)
            {
                return startX > 0 && Grid[startX - 1, startY] != "#";
            }
            public bool CanMoveDown(int startX, int startY)
            {
                return startX < H - 1 && Grid[startX + 1, startY] != "#";
            }
            public bool CanMoveLeft(int startX, int startY)
            {

                return startY > 0 && Grid[startX, startY - 1] != "#";
            }
            public bool CanMoveRight(int startX, int startY)
            {
                return startY < W - 1 && Grid[startX, startY + 1] != "#";
            }
        }
    }
}
