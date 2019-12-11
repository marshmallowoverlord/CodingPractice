using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.AChildsPlay
{
    class AChildsPlay
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int width = int.Parse(inputs[0]);
            int height = int.Parse(inputs[1]);
            long n = long.Parse(Console.ReadLine());

            Map map = new Map(height, width, "N");
            char[,] grid = map.Grid;

            map.RowObstacles = new Dictionary<long, List<long>>();
            map.ColObstacles = new Dictionary<long, List<long>>();

            int startX = -1, startY = -1;
            // build grid
            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < width; j++)
                {
                    grid[i, j] = line[j];

                    if (grid[i, j] == 'O')
                    {
                        startX = i;
                        startY = j;
                    }
                    else if (grid[i, j] == '#')
                    {
                        if (!map.RowObstacles.ContainsKey(i))
                        {
                            map.RowObstacles.Add(i, new List<long> { j });
                        }
                        else
                        {
                            map.RowObstacles[i].Add(j);
                        }
                        if (!map.ColObstacles.ContainsKey(j))
                        {
                            map.ColObstacles.Add(j, new List<long> { i });
                        }
                        else
                        {
                            map.ColObstacles[j].Add(i);
                        }
                    }
                }
            }

            /*foreach(var kv in map.RowObstacles){
                Console.Error.WriteLine(kv.Key + " : " + string.Join(" ", kv.Value));
            }*/
            long h = startX,
                w = startY;
            long count = 0;
            while (n > 0)
            {
                if (!map.Seen.Contains($"{h}{w}") && count == 0)
                {
                    map.Seen.Add($"{h}{w}");
                    n = n - map.Move(h, w, n, out h, out w);
                }
                else if (map.Seen.Contains($"{h}{w}") && count == 0)
                {
                    map.Seen.Clear();
                    while (!map.Seen.Contains($"{h}{w}"))
                    {
                        map.Seen.Add($"{h}{w}");
                        count += map.Move(h, w, n, out h, out w);
                    }
                    Console.Error.WriteLine("count " + count);
                    n = n % count;
                }
                else
                {
                    n = n - map.Move(h, w, n, out h, out w);
                }
                Console.Error.WriteLine("n " + n);
            }

            Console.WriteLine(w + " " + h);
        }

        public class Map
        {
            public int H;
            public int W;
            public char[,] Grid;
            public string Direction;
            public Dictionary<long, List<long>> RowObstacles;
            public Dictionary<long, List<long>> ColObstacles;
            public Dictionary<string, long> Distances;
            public HashSet<string> Seen = new HashSet<string>();

            public Map(
                int h,
                int w,
                string direction
            )
            {
                H = h;
                W = w;
                Direction = direction;
                Grid = new char[h, w];
                Distances = new Dictionary<string, long>();
            }

            public long Move(long i, long j, long n, out long x, out long y)
            {
                x = i;
                y = j;
                Console.Error.WriteLine("ij " + i + " " + j);
                Console.Error.WriteLine("direction " + Direction);
                long moved = 0;
                string k1;
                switch (Direction)
                {
                    case "N":
                        k1 = $"N{i}{j}";
                        if (Distances.ContainsKey(k1))
                        {
                            moved = Distances[k1];
                        }
                        else
                        {
                            if (ColObstacles.ContainsKey(j))
                            {
                                for (int r = ColObstacles[j].Count() - 1; r >= 0; r--)
                                {
                                    if (ColObstacles[j][r] < i)
                                    {
                                        moved = Math.Abs(ColObstacles[j][r] + 1 - i);
                                        Distances.Add(k1, moved);
                                        break;
                                    }
                                }
                            }
                        }
                        moved = Math.Min(n, moved);
                        x = i - moved;
                        Direction = "E";
                        break;
                    case "E":
                        k1 = $"E{i}{j}";
                        if (Distances.ContainsKey(k1))
                        {
                            moved = Distances[k1];
                        }
                        else
                        {
                            if (RowObstacles.ContainsKey(i))
                            {
                                foreach (long c in RowObstacles[i])
                                {
                                    if (c > j)
                                    {
                                        moved = Math.Abs(c - 1 - j);
                                        Distances.Add(k1, moved);
                                        break;
                                    }
                                }
                            }
                        }
                        moved = Math.Min(n, moved);
                        y = j + moved;
                        Direction = "S";
                        break;
                    case "S":
                        k1 = $"S{i}{j}";
                        if (Distances.ContainsKey(k1))
                        {
                            moved = Distances[k1];
                        }
                        else
                        {
                            if (ColObstacles.ContainsKey(j))
                            {
                                foreach (long r in ColObstacles[j])
                                {
                                    if (r > i)
                                    {
                                        moved = Math.Abs(r - 1 - i);
                                        Distances.Add(k1, moved);
                                        break;
                                    }
                                }
                            }
                        }
                        moved = Math.Min(n, moved);
                        x = i + moved;
                        Direction = "W";
                        break;
                    case "W":
                        k1 = $"W{i}{j}";
                        if (Distances.ContainsKey(k1))
                        {
                            moved = Distances[k1];
                        }
                        else
                        {
                            if (RowObstacles.ContainsKey(i))
                            {
                                for (int c = RowObstacles[i].Count() - 1; c >= 0; c--)
                                {
                                    if (RowObstacles[i][c] < j)
                                    {
                                        moved = Math.Abs(RowObstacles[i][c] + 1 - j);
                                        Distances.Add(k1, moved);
                                        break;
                                    }
                                }
                            }
                        }
                        moved = Math.Min(n, moved);
                        y = j - moved;
                        Direction = "N";
                        break;
                }

                return moved;
            }
        }
    }
}
