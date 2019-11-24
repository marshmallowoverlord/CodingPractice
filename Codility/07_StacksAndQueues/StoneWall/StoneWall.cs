using System;
using System.Collections.Generic;

namespace CodingPractice
{
    class StoneWall
    {
        public int solution(int[] H)
        {
            Stack<int> stack = new Stack<int>();
            int total = 0;

            for (int i = 0; i < H.Length; i++)
            {
                if (
                    i == 0 ||
                    (stack.Count > 0 && H[i] > stack.Peek())
                )
                {
                    total += 1;
                    stack.Push(H[i]);
                }
                else if (stack.Count > 0 && H[i] < stack.Peek())
                {
                    while (stack.Count > 0 && stack.Peek() > H[i])
                    {
                        stack.Pop();
                    }
                    if (stack.Count == 0 || stack.Peek() < H[i])
                    {
                        stack.Push(H[i]);
                        total += 1;
                    }
                }
            }
            return total;
        }

    }
}
