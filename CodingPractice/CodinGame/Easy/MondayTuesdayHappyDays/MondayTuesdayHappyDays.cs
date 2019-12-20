using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.MondayTuesdayHappyDays
{
    class MondayTuesdayHappyDays
    {
        public static Dictionary<string, int> months = new Dictionary<string, int>(){
            {"Jan", 0}, {"Feb", 1}, {"Mar", 2}, {"Apr", 3}, {"May", 4}, {"Jun", 5},
            {"Jul", 6}, {"Aug", 7}, {"Sep", 8}, {"Oct", 9}, {"Nov", 10}, {"Dec", 11}
        };
            public static int[] days = new int[12]{
            31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
        };
            public static Dictionary<string, int> dayOfWeek = new Dictionary<string, int>(){
            {"Monday", 0}, {"Tuesday", 1}, {"Wednesday", 2}, {"Thursday", 3}, {"Friday", 4}, {"Saturday", 5}, {"Sunday", 6}
        };

        static void Main(string[] args)
        {


            string[] inputs;
            int leapYear = int.Parse(Console.ReadLine());

            inputs = Console.ReadLine().Split(' ');
            string sourceDayOfWeek = inputs[0];
            string sourceMonth = inputs[1];
            int sourceDayOfMonth = int.Parse(inputs[2]);

            inputs = Console.ReadLine().Split(' ');
            string targetMonth = inputs[0];
            int targetDayOfMonth = int.Parse(inputs[1]);

            int sourceDays = GetDays(sourceMonth, leapYear, sourceDayOfMonth);
            int targetDays = GetDays(targetMonth, leapYear, targetDayOfMonth);

            int diff = mod(targetDays - sourceDays, 7);

            Console.WriteLine(dayOfWeek.FirstOrDefault(
                x =>
                x.Value == mod(dayOfWeek[sourceDayOfWeek] + diff, 7)
            ).Key);
        }

        public static int GetDays(string month, int leapYear, int dayOfMonth)
        {
            int sourceIdx = months[month];
            int sourceDays = 0;
            for (int i = 0; i < sourceIdx; i++)
            {
                sourceDays += days[i] + (i == 1 ? leapYear : 0);
            }
            return sourceDays + dayOfMonth;
        }

        public static int mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}
