using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investition
{
    public class Investition
    {
        public int[,] initTable(int[,] originTable, int[] step, int[] companies)
        {
            int[,] newTable = new int[originTable.GetLength(0) + 1, originTable.GetLength(1) + 1];
            for (int i = 0; i < originTable.GetLength(0); i++)
            {
                for (int j = 0; j < originTable.GetLength(1); j++)
                {
                    newTable[0, j + 1] = companies[j];
                    newTable[i + 1, 0] = step[i];
                    newTable[i + 1, j + 1] = originTable[i, j];
                }
            }
            return newTable;
        }

        public void print(int[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    Console.Write(mas[i, j] + "\t");
                }
                Console.WriteLine(" ");
            }
        }

        public void MainMethod(int[,] originTable, int[] step, int[] companies)
        {
            int[,] table = initTable(originTable, step, companies);
            int rows = table.GetLength(0);
            print(table);

            int summ = 0;

            for (int i = 0; i < step.Length; i++)
            {
                int firstStepCount = 2;
                firstStepCount += i;
                summ += firstStepCount;
            }

            List<int[]> stepCalc = new List<int[]>();

            int stepCount = 2;
            for (int i = 0; i < step.Length; i++)
            {
                int a = 0;
                int b = step[i];

                for (int k = 0; k < stepCount; k++)
                {
                    stepCalc.Add(new int[] { a, b });
                    a += step[0];
                    b -= step[0];
                }
                stepCount++;
            }
            Console.WriteLine("\n");
            foreach (int[] item in stepCalc)
            {
                Console.WriteLine(string.Join("\t", item));
            }

            List<int> summPost = new List<int>(summ);

            int index1 = 0;
            stepCount = 2;

            for (int i = 0; i < summ; i++)
            {
                int a = 0, b = 0;
                int index2 = 0;

                for (int k = 0; k < table.GetLength(0); k++)
                {
                    for (int m = 0; m < table.GetLength(1); m++)
                    {
                        if (stepCalc[index1][index2] != 0)
                        {
                            if (table[k, 0] == stepCalc[index1][index2])
                            {
                                a = table[k, table.GetLength(1) - 2];
                            }
                        }
                        else a = 0;

                        if (stepCalc[index1][index2 + 1] != 0)
                        {
                            if (table[k, 0] == stepCalc[index1][index2 + 1])
                            {
                                b = table[k, table.GetLength(1) - 1];
                            }
                        }
                        else b = 0;

                    }
                }
                summPost.Add(a + b);
                index1++;
            }
        }

    }
}

