using System;

namespace CodingPractice
{
    class CountDiv
    {
        public int solution(int A, int B, int K)
        {
            int x = A;
            if ((A % K) > 0)
            {
                x = A + K - (A % K);
            }
            int y = B - (B % K);
            return ((y - x) / K) + 1;
        }
    }
}
