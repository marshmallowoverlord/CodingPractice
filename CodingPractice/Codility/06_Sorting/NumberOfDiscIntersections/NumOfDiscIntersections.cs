using System.Collections.Generic;
using System.Linq;

namespace CodingPractice
{
    class NumOfDiscIntersections
    {
        public int solution(int[] A)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < A.Length; i++)
            {
                points.Add(new Point(i, (long)i - A[i], 0));
                points.Add(new Point(i, (long)i + A[i], 1));
            }

            List<Point> sortedList = points.OrderBy(o => o.leftright).ThenBy(o => o.isLeft).ToList();
            HashSet<int> set = new HashSet<int>();

            long total = 0;
            long? lastRight = null;
            int lastRightCount = 0;
            for (int i = 0; i < sortedList.Count; i++)
            {
                if (!set.Contains(sortedList[i].centre))
                {
                    if (set.Count > 0)
                    {
                        total = total + set.Count;
                    }
                    if (lastRight != null && sortedList[i].leftright == lastRight)
                    {
                        total = total + lastRightCount;
                    }
                    set.Add(sortedList[i].centre);
                }
                else
                {
                    if (lastRight == sortedList[i].leftright)
                    {
                        lastRightCount = lastRightCount + 1;
                    }
                    else
                    {
                        lastRight = sortedList[i].leftright;
                        lastRightCount = 1;
                    }
                    set.Remove(sortedList[i].centre);
                }
                if (total > 10000000)
                {
                    total = -1;
                    break;
                }

            }

            return (int)total;
        }

        public class Point
        {
            public int centre { get; set; }
            public long leftright { get; set; }
            public int isLeft { get; set; }

            public Point(
                int centre,
                long leftright,
                int isleft
            )
            {
                this.centre = centre;
                this.leftright = leftright;
                this.isLeft = isLeft;
            }
        }
    }
}
