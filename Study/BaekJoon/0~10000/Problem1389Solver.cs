using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1389
    // 케빈 베이컨의 6단계 법칙

    internal class Problem1389Solver
    {
        static string[] inputs;

        static public void Solve()
        {
            inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            long[,] arr = new long[N + 1, N + 1];

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (i == j)
                        arr[i, j] = 0;
                    else
                        arr[i, j] = 100000001;
                }
            }

            for (int i = 0; i < M; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                int A = int.Parse(inputs[0]);
                int B = int.Parse(inputs[1]);

                arr[A, B] = 1;
                arr[B, A] = 1;
            }

            for (int k = 1; k <= N; k++)
            {
                for (int i = 1; i <= N; i++)
                {
                    for (int j = 1; j <= N; j++)
                    {
                        arr[i, j] = Math.Min(arr[i, j], arr[i, k] + arr[k, j]);
                    }
                }
            }

            int min = int.MaxValue;
            int result = -1;

            for (int i = 1; i <= N; i++)
            {
                long sum = 0;

                for (int j = 1; j <= N; j++)
                {
                    sum += arr[i, j];
                }

                if (min > (int)sum)
                {
                    min = (int)sum;
                    result = i;
                }
            }

            Console.Write(result);

            
        }
    }
}
