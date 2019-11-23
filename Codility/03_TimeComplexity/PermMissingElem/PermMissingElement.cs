using System.Collections.Generic;
using System.Linq;

namespace CodingPractice
{
    class PermMissingElement
    {
        public int solution(int[] A)
        {
            HashSet<int> set = new HashSet<int>();

            for (int i = 1; i < A.Length + 2; i++)
            {
                set.Add(i);
            }

            foreach (int a in A)
            {
                if (set.Contains(a))
                {
                    set.Remove(a);
                }
            }
            return set.First();
        }
    }
}
