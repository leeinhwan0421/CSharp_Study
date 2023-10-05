using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2630
    // 색종이 만들기

    internal class Problem2630Solver
    {
        static int[,] field;
        static int white = 0;
        static int blue = 0;

        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());

            field = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');

                for (int j = 0; j < inputs.Length; j++)
                {
                    field[i, j] = int.Parse(inputs[j]);
                }
            }

            checkSlash(0, 0, n);

            Console.Write($"{white}\n");
            Console.Write($"{blue}\n");

            Console.ReadKey();
        }

        static public void checkSlash(int x, int y, int N)
        {
            int tmp = 0;
            for (int i = x; i < x + N; i++)
            {
                for (int k = y; k < y + N; k++)
                {
                    if (field[i, k] == 1)
                    {
                        tmp++;
                    }
                }
            }

            if (tmp == 0)
                white++;
            else if (tmp == N * N)
                blue++;
            else
            {
                checkSlash(x, y, N / 2);
                checkSlash(x, y + N / 2, N / 2);
                checkSlash(x + N / 2, y, N / 2);
                checkSlash(x + N / 2, y + N / 2, N / 2);
            }

            return;
        }
    }
}
