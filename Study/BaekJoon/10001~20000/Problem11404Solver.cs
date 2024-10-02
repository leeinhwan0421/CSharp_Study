using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11404
    // 플로이드
    // 플로이드-워셜 알고리즘

    internal class Problem11404Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());

            long[,] arr = new long[N + 1, N + 1];

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (i == j)
                        arr[i, j] = 0;
                    else
                        arr[i, j] = 1000000001;
                }
            }

            for (int i = 0; i < M; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');

                int s = int.Parse(inputs[0]);
                int e = int.Parse(inputs[1]);
                int w = int.Parse(inputs[2]);

                if (arr[s, e] > w)
                    arr[s, e] = w;
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

            for (int  i= 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (arr[i, j] == 1000000001)
                    {
                        Console.Write("0 ");
                    }
                    else
                    {
                        Console.Write($"{arr[i, j]} ");
                    }
                }

                Console.Write("\n");
            }

            
        }
    }
}
