using System;
using System.Collections.Generic;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/13398
    // 연속합 2

    internal class Problem13398Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            int[] arr = new int[N + 1];

            string[] inputs = Console.ReadLine().Split(' ');
            for (int i = 0; i < N; i++)
            {
                arr[i] = int.Parse(inputs[i]);
            }

            // ,0 인덱스는 수를 빼지 않았을 때, ,1 인덱스는 수를 뺄 경우를 구합니다.
            int[,] DP = new int[N + 1, 2];

            DP[0, 0] = arr[0];
            DP[0, 1] = arr[0];
            int result = arr[0];

            for (int i = 1; i < N; i++)
            {
                DP[i, 0] = Math.Max(DP[i - 1, 0] + arr[i], arr[i]);
                DP[i, 1] = Math.Max(DP[i - 1, 0], DP[i - 1, 1] + arr[i]);
                result = Math.Max(result, Math.Max(DP[i, 0], DP[i, 1]));
            }

            Console.Write(result);
            Console.ReadKey();
        }
    }
}
