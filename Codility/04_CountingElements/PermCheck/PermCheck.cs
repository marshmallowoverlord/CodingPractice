using System.Collections.Generic;

namespace CodingPractice
{
    class PermCheck
    {
        public int solution(int[] A)
        {
            int result = 1;
            HashSet<int> set = new HashSet<int>();
            for (int i = 1; i < A.Length + 1; i++)
            {
                set.Add(i);
            }
            foreach (int a in A)
            {
                if (set.Contains(a))
                {
                    set.Remove(a);
                }
                else
                {
                    result = 0;
                    break;
                }
            }

            return result;
        }
    }
}
