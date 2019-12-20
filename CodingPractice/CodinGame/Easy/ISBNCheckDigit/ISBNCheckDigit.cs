using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.ISBNCheckDigit
{
    class ISBNCheckDigit
    {
        static void Main(string[] args)
        {
            List<string> invalid = new List<string>();
            int N = int.Parse(Console.ReadLine());
            bool valid = true;
            for (int i = 0; i < N; i++)
            {
                string ISBN = Console.ReadLine();

                if (ISBN.Length == 10)
                {
                    valid = ISBN10(ISBN);
                }
                else if (ISBN.Length == 13)
                {
                    valid = ISBN13(ISBN);
                }
                else
                {
                    valid = false;
                }

                if (!valid)
                {
                    invalid.Add(ISBN);
                }
            }
            
            Console.WriteLine(invalid.Count() + " invalid:");
            foreach (string s in invalid)
            {
                Console.WriteLine(s);
            }
        }

        public static bool ISBN10(string s)
        {
            char[] code = s.ToCharArray();

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int curr = 0;
                if (int.TryParse(code[i].ToString(), out curr))
                {
                    sum += curr * (10 - i);
                }
                else
                {
                    return false;
                }
            }
            int num = sum % 11 == 0 ? 0 : (11 - (sum % 11));

            string check = num < 10 ? num.ToString() : "X";

            return code[s.Length - 1].ToString() == check;
        }

        public static bool ISBN13(string s)
        {
            char[] code = s.ToCharArray();

            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                int curr = 0;
                if (int.TryParse(code[i].ToString(), out curr))
                {
                    sum += curr * (i % 2 == 0 ? 1 : 3);
                }
                else
                {
                    return false;
                }
            }
            string check = (sum % 10 == 0 ? 0 : (10 - (sum % 10))).ToString();

            return code[s.Length - 1].ToString() == check;
        }
    }
}
