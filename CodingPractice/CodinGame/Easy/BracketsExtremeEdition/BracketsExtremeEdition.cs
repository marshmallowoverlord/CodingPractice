using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.BracketsExtremeEdition
{
    class BracketsExtremeEdition
    {
        static void Main(string[] args)
        {
            Dictionary<char, char> map = new Dictionary<char, char>(){
            {'}','{'},
            {']','['},
            {')','('}
        };

            Stack<char> stack = new Stack<char>();

            string expression = Console.ReadLine();

            char[] exp = expression.ToCharArray();

            bool balanced = true;

            foreach (char c in exp)
            {
                if (map.ContainsValue(c))
                {
                    stack.Push(c);
                }
                else if (map.ContainsKey(c))
                {
                    if (
                        stack.Count > 0 &&
                        stack.Peek() == map[c]
                    )
                    {
                        stack.Pop();
                    }
                    else
                    {
                        balanced = false;
                        break;
                    }
                }
            }

            if (stack.Count > 0)
            {
                balanced = false;
            }
 
            Console.WriteLine(balanced ? "true" : "false");
        }
    }
}
