using System;

namespace CodingPractice.CodinGame.Medium.ShadowsOfTheKnight
{
    class ShadowsOfTheKnight
    {
        public static int XLower;
        public static int XUpper;
        public static int YLower;
        public static int YUpper;

        static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            XLower = 0;
            YLower = 0;
            XUpper = int.Parse(inputs[0]) - 1; // width of the building.
            YUpper = int.Parse(inputs[1]) - 1; // height of the building.
            int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
            inputs = Console.ReadLine().Split(' ');
            int X0 = int.Parse(inputs[0]);
            int Y0 = int.Parse(inputs[1]);

            int prevX = -1;
            int prevY = -1;
            // game loop
            while (true)
            {
                string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

                int X1 = GetX(X0, bombDir);
                int Y1 = GetY(Y0, bombDir);

                prevX = X0;
                prevY = Y0;

                X0 = X1;
                Y0 = Y1;

                // the location of the next window Batman should jump to.
                Console.WriteLine($"{X0} {Y0}");
            }
        }

        public static int GetX(int currX, string dir)
        {
            int result;
            if (dir[0] == 'R' || (dir.Length > 1 && dir[1] == 'R'))
            {
                result = currX + (int)Math.Ceiling((double)(XUpper - currX) / 2);
                XLower = currX;
            }
            else if (dir[0] == 'L' || (dir.Length > 1 && dir[1] == 'L'))
            {
                result = XLower + (int)Math.Floor((double)(currX - XLower) / 2);
                XUpper = currX;
            }
            else
            {
                result = currX;
            }

            return result;
        }

        public static int GetY(int currY, string dir)
        {
            int result;
            if (dir[0] == 'D')
            {
                result = currY + (int)Math.Ceiling((double)(YUpper - currY) / 2);
                YLower = currY;
            }
            else if (dir[0] == 'U')
            {
                result = YLower + (int)Math.Floor((double)(currY - YLower) / 2);
                YUpper = currY;
            }
            else
            {
                result = currY;
            }

            return result;
        }
    }
}
