using System;

namespace CodingPractice
{
    class CyclicRotation
    {
        public int[] solution(int[] A, int K)
        {
            int[] result = new int[A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                result[(i + K) % A.Length] = A[i];
            }

            return result;
        }

    }
}
