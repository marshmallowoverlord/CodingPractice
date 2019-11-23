using System.Collections.Generic;

namespace CodingPractice
{
    class Distinct
    {
        public int solution(int[] A)
        {
            HashSet<int> dic = new HashSet<int>();

            foreach (int a in A)
            {
                if (!dic.Contains(a))
                {
                    dic.Add(a);
                }
            }

            return dic.Count;
        }
    }
}
