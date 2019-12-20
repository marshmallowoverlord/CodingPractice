using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.LongestSequenceOf1
{
    class LongestSequenceOf1
    {
        static void Main(string[] args)
        {

            List<int> counts = new List<int>();
            string b = Console.ReadLine();
            int currCount = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == '1')
                {
                    currCount++;
                }
                else
                {
                    counts.Add(currCount);
                    currCount = 0;
                    if (i > 0 && b[i - 1] == '0')
                    {
                        counts.Add(currCount);
                    }
                }
            }
            counts.Add(currCount);
            
            int max = 0;
            for (int i = 0; i < counts.Count() - 1; i++)
            {
                max = Math.Max(counts[i] + counts[i + 1] + 1, max);
            }

            Console.WriteLine(max);
        }
    }
}
