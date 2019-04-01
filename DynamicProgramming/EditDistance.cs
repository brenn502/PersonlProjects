using System;

namespace DynamicProgramming
{
    static class EditDistance
    {
        public static void Distance(string str1, string str2)
        {
            int length1 = str1.Length;
            int length2 = str2.Length;

            int[,] table = new int[length1+1, length2+1];

            for (int row = 0; row <= length1; row++)
            {
                for (int column = 0; column <= length2; column++)
                {
                    if (row == 0)
                    {
                        table[row, column] = column;
                    }
                    else if (column == 0)
                    {
                        table[row, column] = row;
                    }
                    else if (str1[row-1] == str2[column - 1])
                    {
                        table[row, column] = table[row - 1, column - 1];
                    }
                    else
                    {
                        table[row, column] = 1 + Math.Min(table[row, column - 1],
                                                 Math.Min(table[row - 1, column],
                                                          table[row - 1, column - 1]));
                    }            
                }
            }
            Console.WriteLine(table[length1, length2]);

            PrintArray(table);
        }
        static void PrintArray(int[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write(table[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
