using System;

namespace CodingPractice
{
    class PassingCars
    {
        public int solution(int[] A)
        {
            int eastCars = 0;
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (count < 1000000000)
                {
                    if (A[i] == 0)
                    {
                        eastCars = eastCars + 1;
                    }
                    else
                    {
                        count = count + (1 * eastCars);
                    }
                }
                else
                {
                    count = -1;
                    break;
                }

            }
            return count;
        }
    }
}
