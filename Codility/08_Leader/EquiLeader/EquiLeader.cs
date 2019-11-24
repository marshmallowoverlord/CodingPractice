using System;
using System.Collections.Generic;

namespace CodingPractice
{
    class EquiLeader
    {
        public int solution(int[] A)
        {
            int result = 0;
            int[] left = new int[A.Length];
            int[] right = new int[A.Length];

            Dictionary<int, int> leftDic = new Dictionary<int, int>();
            Dictionary<int, int> rightDic = new Dictionary<int, int>();
            int leftMax = Int32.MaxValue;
            int leftMaxCount = 0;
            int rightMax = Int32.MaxValue;
            int rightMaxCount = 0;
            int lastIdx = A.Length - 1;
            for (int i = 0; i < A.Length; i++)
            {
                if (!leftDic.ContainsKey(A[i]))
                {
                    leftDic.Add(A[i], 1);
                }
                else
                {
                    leftDic[A[i]] += 1;
                }
                if (leftDic[A[i]] * 2 > i + 1)
                {
                    left[i] = A[i];
                    leftMax = A[i];
                    leftMaxCount = leftDic[A[i]];
                }
                else if (leftMaxCount * 2 > i + 1)
                {
                    left[i] = leftMax;
                }
                else
                {
                    left[i] = Int32.MinValue;
                }

                if (!rightDic.ContainsKey(A[lastIdx - i]))
                {
                    rightDic.Add(A[lastIdx - i], 1);
                }
                else
                {
                    rightDic[A[lastIdx - i]] += 1;
                }
                if (rightDic[A[lastIdx - i]] * 2 > i + 1)
                {
                    right[lastIdx - i] = A[lastIdx - i];
                    rightMax = A[lastIdx - i];
                    rightMaxCount = rightDic[A[lastIdx - i]];
                }
                else if (rightMaxCount * 2 > i + 1)
                {
                    right[lastIdx - i] = rightMax;
                }
                else
                {
                    right[lastIdx - i] = Int32.MinValue;
                }
            }
            for (int i = 0; i < A.Length - 1; i++)
            {
                //Console.WriteLine(left[i] + " : " + right[i+1]);
                if (
                    left[i] != Int32.MinValue &&
                    right[i + 1] != Int32.MinValue &&
                    left[i] == right[i + 1]
                    )
                {
                    result += 1;
                }
            }
            return result;
        }

    }
}
