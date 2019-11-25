using System;

namespace CodingPractice
{
    class MaxCounters
    {
        public int[] solution(int N, int[] A)
        {
            int[] res = new int[N];
            for (int i = 0; i < N; i++)
            {
                res[i] = 0;
            }

            int maxCounter = 0;
            int maxUpdate = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] <= N)
                {
                    if (res[A[i] - 1] < maxUpdate)
                    {
                        res[A[i] - 1] = maxUpdate + 1;
                    }
                    else
                    {
                        res[A[i] - 1] = res[A[i] - 1] + 1;
                    }

                    if (res[A[i] - 1] > maxCounter)
                    {
                        maxCounter = res[A[i] - 1];
                    }

                }
                else
                {
                    maxUpdate = maxCounter;
                }
            }

            for (int i = 0; i < N; i++)
            {
                if (res[i] < maxUpdate)
                {
                    res[i] = maxUpdate;
                };
            }

            return res;
        }

    }
}
