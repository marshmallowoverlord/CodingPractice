using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.CreditCardVerifier
{
    class CreditCardVerifier
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                int[] card = line.Replace(" ", "").Select(x => Int32.Parse(x.ToString())).ToArray();
                int sum = SumEven(card) + SumOdd(card);
                Console.WriteLine(sum % 10 == 0 ? "YES" : "NO");

            }
        }

        public static int SumEven(int[] card)
        {
            int sum = 0;
            for (int i = 0; i < card.Length; i++)
            {
                if (i % 2 != 0)
                {
                    int db = card[card.Length - 1 - i] * 2;
                    sum += db >= 10 ? db - 9 : db;
                }
            }
            Console.Error.WriteLine("SumEven: " + sum);
            return sum;
        }

        public static int SumOdd(int[] card)
        {
            int sum = 0;
            for (int i = 0; i < card.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sum += card[card.Length - 1 - i];
                }
            }
            Console.Error.WriteLine("SumOdd: " + sum);
            return sum;
        }
    }
}
