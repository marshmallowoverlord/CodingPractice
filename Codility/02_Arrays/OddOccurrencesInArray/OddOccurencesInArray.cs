using System.Collections.Generic;
using System.Linq;

namespace CodingPractice
{
    class OddOccurencesInArray
    {
        public int solution(int[] A)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int a in A)
            {
                if (!set.Contains(a))
                {
                    set.Add(a);
                }
                else
                {
                    set.Remove(a);
                }
            }
            return set.First();
        }

    }
}
