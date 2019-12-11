using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.CodinGame.Easy.RectanglePartition
{
    class RectanglePartition
    {
        static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int w = int.Parse(inputs[0]);
            int h = int.Parse(inputs[1]);
            int countX = int.Parse(inputs[2]);
            int countY = int.Parse(inputs[3]);

            List<int> columns = new List<int>();
            inputs = Console.ReadLine().Split(' ');
            int prevX = 0;
            for (int i = 0; i < countX; i++)
            {
                int x = int.Parse(inputs[i]);
                if (i == 0)
                {
                    columns.Add(x);
                }
                else if (i > 0)
                {
                    columns.Add(x - prevX);
                }
                prevX = x;
            }
            columns.Add(w - prevX);

            List<int> rowsParts = new List<int>();
            inputs = Console.ReadLine().Split(' ');
            int prevY = 0;
            for (int i = 0; i < countY; i++)
            {
                int y = int.Parse(inputs[i]);
                if (i == 0)
                {
                    rowsParts.Add(y);
                }
                if (i > 0)
                {
                    rowsParts.Add(y - prevY);
                }
                prevY = y;
            }
            rowsParts.Add(h - prevY);

            Dictionary<int, int> rows = new Dictionary<int, int>();
            for (int i = 0; i < rowsParts.Count(); i++)
            {
                int rAcc = rowsParts[i];

                if (!rows.ContainsKey(rowsParts[i]))
                {
                    rows.Add(rowsParts[i], 1);
                }
                else
                {
                    rows[rowsParts[i]]++;
                }
                for (int j = i + 1; j < rowsParts.Count(); j++)
                {
                    rAcc += rowsParts[j];
                    if (!rows.ContainsKey(rAcc))
                    {
                        rows.Add(rAcc, 1);
                    }
                    else
                    {
                        rows[rAcc]++;
                    }
                }
            }

            //Console.Error.WriteLine(string.Join(" ", columns));
            //Console.Error.WriteLine(string.Join(" ", rows));
            int count = 0;

            for (int i = 0; i < columns.Count(); i++)
            {
                if (rows.ContainsKey(columns[i]))
                {
                    count += rows[columns[i]];
                }
                int acc = columns[i];
                for (int j = i + 1; j < columns.Count(); j++)
                {
                    acc += columns[j];
                    //Console.Error.WriteLine("j: " + acc);
                    if (rows.ContainsKey(acc))
                    {
                        count += rows[acc];
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
