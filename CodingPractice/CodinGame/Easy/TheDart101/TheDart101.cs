using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingPractice.CodinGame.Easy.TheDart101
{
    class TheDart101
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Player> players = new List<Player>();

            for (int i = 0; i < N; i++)
            {
                string PLAYER = Console.ReadLine();
                players.Add(new Player()
                {
                    Name = PLAYER
                });
            }
            for (int i = 0; i < N; i++)
            {
                string[] SHOOTS = Console.ReadLine().Split(' ');
                int shotNum = 0;
                int prevRoundScore = 0;
                foreach (string shot in SHOOTS)
                {
                    if (shot == "X")
                    {
                        players[i].ConsecMisses++;

                        switch (players[i].ConsecMisses)
                        {
                            case 3:
                                players[i].Score = 0;
                                players[i].ConsecMisses = 0;
                                players[i].Rounds++;
                                shotNum = 0;
                                break;
                            case 2:
                                players[i].Score -= 30;
                                shotNum++;
                                break;
                            case 1:
                                players[i].Score -= 20;
                                shotNum++;
                                break;
                        }
                    }
                    else
                    {
                        if (shot.IndexOf("*") > -1)
                        {
                            string[] compound = shot.Split('*');
                            players[i].Score += Int32.Parse(compound[0]) * Int32.Parse(compound[1]);
                        }
                        else
                        {
                            players[i].Score += Int32.Parse(shot);
                        }

                        players[i].ConsecMisses = 0;
                        shotNum++;

                        if (players[i].Score == 101)
                        {
                            break;
                        }
                        else if (players[i].Score > 101)
                        {
                            players[i].Score = prevRoundScore;
                            players[i].Rounds++;
                            shotNum = 0;
                        }
                    }

                    Console.Error.WriteLine(players[i].Rounds + " " + shotNum + " : " + players[i].Score);

                    if (shotNum == 3)
                    {
                        prevRoundScore = players[i].Score;
                        shotNum = 0;
                        players[i].Rounds++;
                        players[i].ConsecMisses = 0;
                    }


                }
            }

            Console.WriteLine(players.OrderBy(x => x.Rounds).ToList()[0].Name);
        }

        public class Player
        {
            public string Name;
            public int Rounds = 0;
            public int ConsecMisses = 0;
            public int Score = 0;
        }
    }
}