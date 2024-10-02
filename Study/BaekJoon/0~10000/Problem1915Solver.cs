using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1915
    // 가장 큰 정사각형

    internal class Problem1915Solver
    {
        static string[] inputs;

        static public void Solve()
        {
            inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            int[,] arr = new int[N + 1, M + 1];

            for (int i = 1; i <= N; i++)
            {
                string input = Console.ReadLine();

                for (int j = 1; j <= M; j++)
                {
                    arr[i, j] = input[j - 1] - '0';
                }
            }

            int max = 0;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= M; j++)
                {
                    if (arr[i, j] != 0)
                    {
                        arr[i, j] = Math.Min(arr[i - 1, j - 1], Math.Min(arr[i - 1, j], arr[i, j - 1])) + 1;
                        if (max < arr[i, j]) max = arr[i, j];
                    }
                }
            }

            Console.Write($"{max * max}");
            
        }
    }
}
