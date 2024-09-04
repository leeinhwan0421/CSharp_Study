using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11403
    // 경로 찾기

    internal class Problem11403Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            int[,] arr = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                for (int j = 0; j < N; j++)
                {
                    int s = int.Parse(inputs[j]);

                    arr[i, j] = s;
                }
            }

            for (int k = 0; k < N; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (arr[i, k] == 1 && arr[k, j] == 1)
                            arr[i, j] = 1;
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }

                Console.Write("\n");
            }

            Console.ReadKey();
        }
    }
}
