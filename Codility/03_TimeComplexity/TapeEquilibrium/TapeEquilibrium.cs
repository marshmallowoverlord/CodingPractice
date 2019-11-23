using System;

namespace CodingPractice
{
    class TapeEquilibrium
    {
        public int solution(int[] A)
        {
            int total = 0;

            foreach (int a in A)
            {
                total = total + a;
            }
            int left = A[0];
            int right = total - A[0];
            int minDiff = Math.Abs(left - right);
            for (int i = 2; i < A.Length - 1; i++)
            {
                left = left + A[i - 1];
                right = right - A[i - 1];

                if (Math.Abs(right - left) < minDiff)
                {
                    minDiff = Math.Abs(right - left);
                }
            }

            return minDiff;
        }

    }
}
