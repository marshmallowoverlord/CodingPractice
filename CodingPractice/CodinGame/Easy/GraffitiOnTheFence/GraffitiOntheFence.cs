using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingPractice.CodinGame.Easy.GraffitiOnTheFence
{
    class GraffitiOntheFence
    {
        static void Main(string[] args)
        {
            int L = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());

            List<Node> unpainted = new List<Node>();

            List<Node> unsections = new List<Node>();

            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int st = int.Parse(inputs[0]);
                int ed = int.Parse(inputs[1]);

                unsections.Add(new Node(st, ed));
            }

            List<Node> sections = unsections.OrderBy(x => x.Start).ToList();

            int prevEnd = 0;
            int currentStart = sections[0].Start;
            int currentEnd = sections[0].End;

            if (currentStart > 0)
            {
                unpainted.Add(new Node(prevEnd, currentStart));
            }

            for (int i = 1; i < N; i++)
            {
                //Console.Error.WriteLine("== " + i + " : " + currentStart + " " + currentEnd);
                if (sections[i].Start <= currentEnd)
                {
                    currentEnd = Math.Max(currentEnd, sections[i].End);
                }
                else
                {
                    prevEnd = currentEnd;
                    currentStart = sections[i].Start;
                    currentEnd = sections[i].End;
                    unpainted.Add(new Node(prevEnd, currentStart));
                }
            }

            if (currentEnd < L)
            {
                unpainted.Add(new Node(currentEnd, L));
            }

            bool painted = false;
            foreach (Node n in unpainted)
            {
                if (unpainted[0].Start != unpainted[0].End)
                {
                    Console.WriteLine(n.Start + " " + n.End);
                    painted = true;
                }
            }

            if (unpainted.Count() == 0 || !painted)
            {
                Console.WriteLine("All painted");
            }
        }

        public class Node
        {
            public int Start;
            public int End;

            public Node(
                int start,
                int end
            )
            {
                Start = start;
                End = end;
            }
        }
    }
}
}
