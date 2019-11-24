using System;
using System.Collections.Generic;

namespace CodingPractice
{
    class Dominator
    {
        public int solution(int[] A)
        {
            Dictionary<int, int> set = new Dictionary<int, int>();
            int idx = -1;
            for (int i = 0; i < A.Length; i++)
            {
                if (!set.ContainsKey(A[i]))
                {
                    set.Add(A[i], 1);
                }
                else
                {
                    set[A[i]] = set[A[i]] + 1;
                }
                if (set[A[i]] * 2 > A.Length)
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }

    }
}
