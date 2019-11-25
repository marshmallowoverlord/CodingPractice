using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace CodingPractice.CodinGame
{
    class OneDSpreadSheet
    {
        public static List<Cell> Cells = new List<Cell>();

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                string operation = inputs[0];
                string arg1 = inputs[1];
                string arg2 = inputs[2];

                Cells.Add(new Cell(operation, arg1, arg2));
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(CalcValue(Cells[i]));
            }
        }

        public static int GetValue(string val)
        {
            Regex refRegEx = new Regex(@"\$[0-9]+");

            if (refRegEx.IsMatch(val))
            {

                int idx = Int32.Parse(val.Substring(1));

                if (Cells[idx].Value != Int32.MinValue)
                {
                    return Cells[idx].Value;
                }
                else
                {
                    return CalcValue(Cells[idx]);
                }
            }

            return Int32.Parse(val);
        }

        public static int CalcValue(Cell cell)
        {
            if (cell.Operation == "VALUE")
            {
                cell.Value = GetValue(cell.Arg1);
            }
            else
            {
                int v1 = GetValue(cell.Arg1);
                int v2 = GetValue(cell.Arg2);

                switch (cell.Operation)
                {
                    case "ADD":
                        cell.Value = v1 + v2;
                        break;
                    case "SUB":
                        cell.Value = v1 - v2;
                        break;
                    case "MULT":
                        cell.Value = v1 * v2;
                        break;
                }
            }
            return cell.Value;
        }

        public class Cell
        {
            public string Operation;
            public string Arg1;
            public string Arg2;
            public int Value = Int32.MinValue;

            public Cell(
                string operation,
                string arg1,
                string arg2
            )
            {
                Operation = operation;
                Arg1 = arg1;
                Arg2 = arg2;
            }


        }
    }
}
