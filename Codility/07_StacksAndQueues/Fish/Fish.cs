using System;
using System.Collections.Generic;

namespace CodingPractice
{
    class Fish
    {
        public int solution(int[] A, int[] B)
        {
            Stack<int> upstream = new Stack<int>();
            Stack<int> downstream = new Stack<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (B[i] == 0)
                {
                    if (upstream.Count > 0)
                    {
                        if (upstream.Peek() < A[i])
                        {
                            while (upstream.Count > 0 && upstream.Peek() < A[i])
                            {
                                upstream.Pop();
                            }
                            if (upstream.Count == 0)
                            {
                                downstream.Push(A[i]);
                            }
                        }
                    }
                    else
                    {
                        downstream.Push(A[i]);
                    }
                }
                else
                {
                    upstream.Push(A[i]);
                }
            }
            return (upstream.Count + downstream.Count);
        }

    }
}
