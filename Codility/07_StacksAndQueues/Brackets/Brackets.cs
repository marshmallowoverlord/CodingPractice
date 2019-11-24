using System;
using System.Collections.Generic;

namespace CodingPractice
{
    class Brackets
    {
        public int solution(string S)
        {
            Stack<char> stack = new Stack<char>();
            char[] brackets = S.ToCharArray();
            bool balanced = true;
            foreach (char c in brackets)
            {
                switch (c)
                {
                    case ')':
                        if (stack.Count > 0 && stack.Peek() == '(')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            balanced = false;
                        }
                        break;
                    case '}':
                        if (stack.Count > 0 && stack.Peek() == '{')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            balanced = false;
                        }
                        break;
                    case ']':
                        if (stack.Count > 0 && stack.Peek() == '[')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            balanced = false;
                        }
                        break;
                    default:
                        stack.Push(c);
                        break;
                }
            }
            if (stack.Count > 0)
            {
                balanced = false;
            }

            return (balanced ? 1 : 0);
        }

    }
}
