using System;

namespace CodingPractice
{
    class FrogJump
    {
        public int solution(int X, int Y, int D)
        {
            int distance = Y - X;
            return (int)Math.Ceiling((double)distance / D);
        }

    }
}
