using System;

namespace CodingPractice
{
    class BinaryGap
    {
        public int solution(int N)
        {
            string binary = Convert.ToString(N, 2);
            char[] bitArray = binary.ToCharArray();

            int counter = 0;
            int maxCount = 0;

            foreach (char c in bitArray)
            {
                if (c == '0')
                {
                    counter = counter + 1;
                }
                if (c == '1')
                {
                    if (counter > maxCount)
                    {
                        maxCount = counter;
                    }
                    counter = 0;
                }
            }

            return maxCount;
        }

    }
}
