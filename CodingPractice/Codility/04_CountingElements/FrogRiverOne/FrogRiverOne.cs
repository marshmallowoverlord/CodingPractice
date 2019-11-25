using System.Collections.Generic;

namespace CodingPractice
{
    class FrogRiverOne
    {
        public int solution(int X, int[] A)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 1; i < X + 1; i++)
            {
                set.Add(i);
            }

            int timeIdx = -1;
            for (int i = 0; i < A.Length; i++)
            {
                if (set.Contains(A[i]))
                {
                    set.Remove(A[i]);
                    if (set.Count == 0)
                    {
                        timeIdx = i;
                    }
                }
            }

            return timeIdx;
        }
    }
}
