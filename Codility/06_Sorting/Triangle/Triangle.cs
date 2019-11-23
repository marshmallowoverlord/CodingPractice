using System;

namespace CodingPractice
{
    class Triangle
    {
        public int solution(int[] A)
        {
            int found = 0;
            Array.Sort(A);

            for (int i = 0; i < A.Length; i++)
            {
                if (i + 2 < A.Length)
                {
                    double p = A[i];
                    double q = A[i + 1];
                    double r = A[i + 2];
                    if (
                        (p + q > r) &&
                        (q + r > p) &&
                        (r + p > q)
                    )
                    {
                        found = 1;
                        break;
                    }
                }
            }
            return found;
        }
    }
