using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/7576
    // 토마토

    internal class Problem7576Solver
    {
        static int[,] arr;

        static int rows;
        static int cols;

        static bool RipeTomato(int row, int col)
        {
            arr[row, col] = -1;

            if (FindCanRipe(row + 1, col) ||
                FindCanRipe(row - 1, col) ||
                FindCanRipe(row, col + 1) ||
                FindCanRipe(row, col - 1))
            {
                return true;
            }

            return false;
        }

        static bool FindCanRipe(int row, int col)
        {
            if (row < 0 || col < 0)
                return false;
            else if (row >= rows || col >= cols)
                return false;

            if (arr[row, col] == 0)
            {
                arr[row, col] = 1;
                return true;
            }

            return false;
        }

        static public void Solve()
        {
            String[] str = Console.ReadLine().Split(' ');

            rows = int.Parse(str[0]);
            cols = int.Parse(str[1]);

            arr = new int[rows, cols];

            for (int i = 0; i < cols; i++)
            {
                String[] line = Console.ReadLine().Split(' ');

                for (int j = 0; j < rows; j++)
                {
                    arr[j, i] = int.Parse(line[j]);
                }
            }

            int result = 0;
            bool isKey = true;

            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();

            while (isKey)
            {
                isKey = false;

                for (int i = 0; i < cols; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        if (arr[j, i] == 1)
                        {
                            list.Add(new KeyValuePair<int, int>(j, i));
                        }
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    int row = list[i].Key;
                    int col = list[i].Value;

                    if (isKey)
                        RipeTomato(row, col);
                    else
                        isKey = RipeTomato(row, col);
                }

                if (isKey)
                    result++;
            }

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (arr[j, i] == 0)
                    {
                        Console.WriteLine("-1");
                        Console.ReadKey();
                        return;
                    }
                }
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
