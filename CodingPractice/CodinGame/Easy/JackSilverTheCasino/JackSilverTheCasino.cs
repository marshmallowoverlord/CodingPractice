using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.JackSilverTheCasino
{
    class JackSilverTheCasino
    {
        static void Main(string[] args)
        {
            int ROUNDS = int.Parse(Console.ReadLine());
            int CASH = int.Parse(Console.ReadLine());

            for (int i = 0; i < ROUNDS; i++)
            {
                int bet = (int)Math.Ceiling((double)CASH / 4);
                string[] PLAY = Console.ReadLine().Split(' ');

                int ball = Int32.Parse(PLAY[0]);

                switch (PLAY[1])
                {
                    case "PLAIN":
                        if (ball == Int32.Parse(PLAY[2]))
                        {
                            CASH += bet * 35;
                        }
                        else
                        {
                            CASH -= bet;
                        }
                        break;
                    case "EVEN":
                        if (ball % 2 == 0 && ball != 0)
                        {
                            CASH += bet;
                        }
                        else
                        {
                            CASH -= bet;
                        }
                        break;
                    case "ODD":
                        if (ball % 2 != 0)
                        {
                            CASH += bet;
                        }
                        else
                        {
                            CASH -= bet;
                        }
                        break;
                }
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine(CASH);
        }
    }
}
