using System;
using System.Collections.Generic;

namespace CodingPractice
{
    class Nesting
    {
        public int solution(string S)
        {
            Stack<char> stack = new Stack<char>();
            char[] array = S.ToCharArray();
            foreach (char c in array)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count > 0 && stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(c);
                    }
                }
            }

            return (stack.Count > 0 ? 0 : 1);
        }
    }
}
