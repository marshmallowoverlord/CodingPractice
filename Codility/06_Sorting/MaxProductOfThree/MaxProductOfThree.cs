using System;

namespace CodingPractice
{
    class MaxProductOfThree
    {
        public int solution(int[] A)
        {
            Array.Sort(A);
            int res = Int32.MinValue;
            if (
                Math.Abs(A[0]) >= A[A.Length - 1] && Math.Abs(A[1]) >= A[A.Length - 2] ||
                Math.Abs(A[0]) >= A[A.Length - 2] && Math.Abs(A[1]) >= A[A.Length - 3]
            )
            {
                res = A[0] * A[1] * A[A.Length - 1];
            }

            return Math.Max(A[A.Length - 1] * A[A.Length - 2] * A[A.Length - 3], res);
        }
    }
}
