using System;

namespace CodingPractice
{
    class GenomicRangeQuery
    {
        public int[] solution(string S, int[] P, int[] Q)
        {
            int[] result = new int[P.Length];
            for (int i = 0; i < P.Length; i++)
            {
                string sub = S.Substring(P[i], Q[i] + 1 - P[i]);
                if (sub.Contains("A"))
                {
                    result[i] = 1;
                }
                else if (sub.Contains("C"))
                {
                    result[i] = 2;
                }
                else if (sub.Contains("G"))
                {
                    result[i] = 3;
                }
                else if (sub.Contains("T"))
                {
                    result[i] = 4;
                }
            }

            return result;
        }
    }
}
