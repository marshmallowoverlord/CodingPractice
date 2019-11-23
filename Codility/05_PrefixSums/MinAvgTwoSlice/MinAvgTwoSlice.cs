using System;

namespace CodingPractice
{
    class MinAvgTwoSlice
    {
        public int solution(int[] A)
        {
            double min = Double.MaxValue;
            int idx = 0;
            for (int i = 0; i < A.Length; i++)
            {
                double avg2 = Double.MaxValue;
                double avg3 = Double.MaxValue;
                if (i + 1 < A.Length)
                {
                    avg2 = (double)(A[i] + A[i + 1]) / 2;
                }
                if (i + 2 < A.Length)
                {
                    avg3 = (double)(A[i] + A[i + 1] + A[i + 2]) / 3;
                }

                if (Math.Min(avg2, avg3) < min)
                {
                    min = Math.Min(avg2, avg3);
                    idx = i;
                }
            }
            return idx;
        }
    }
}
