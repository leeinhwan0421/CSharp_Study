using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/24049
    // 정원 (Easy)

    class Problem24049Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            int[,] arr = new int[N + 1, M + 1];
            inputs = Console.ReadLine().Split(' ');

            for (int i = 1; i <= N; i++)
            {
                arr[i, 0] = int.Parse(inputs[i - 1]); 
            }

            inputs = Console.ReadLine().Split(' ');
            for (int i = 1; i <= M; i++)
            {
                arr[0, i] = int.Parse(inputs[i - 1]);
            }

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= M; j++)
                {
                    if (arr[i, j - 1] == arr[i - 1, j])
                    {
                        arr[i, j] = 0;
                    }
                    else
                    {
                        arr[i, j] = 1;
                    }
                }
            }

            Console.Write(arr[N, M]);
            
        }
    }
}
