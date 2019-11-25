using System;
using System.Collections.Generic;

namespace CodingPractice
{
    class MissingInteger
    {
        public int solution(int[] A)
        {
            HashSet<int> set = new HashSet<int>(A);

            int num = 1;
            int counter = 1;
            bool found = false;
            while (!found)
            {
                if (!set.Contains(counter))
                {
                    found = true;
                    num = counter;
                    break;
                }
                counter++;
            }

            return num;
        }

    }
}
