using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.AddEmUp
{
    class AddEmUp
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string[] inputs = Console.ReadLine().Split(' ');
            List<int> cards = new List<int>();
            for (int i = 0; i < N; i++)
            {
                int x = int.Parse(inputs[i]);
                cards.Add(x);
            }

            int sum = 0;
            while (cards.Count() > 1)
            {
                cards = cards.OrderBy(x => x).ToList();
                int newcard = cards[0] + cards[1];
                sum += newcard;
                cards.RemoveAt(1);
                cards.RemoveAt(0);
                cards.Add(newcard);
            }
            Console.WriteLine(sum);
        }
    }
}
