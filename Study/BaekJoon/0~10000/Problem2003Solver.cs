using System;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2003
    // 수들의 합 2

    internal class Problem2003Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            int[] arr = new int[N];
            inputs = Console.ReadLine().Split(' ');

            for (int i = 0; i < N; i++)
            {
                arr[i] = int.Parse(inputs[i]);
            }

            int start = 0, end = 0, sum = 0, result = 0;

            while (true)
            {
                if (sum >= M)
                {
                    sum -= arr[start++];
                }
                else if (end == N)
                {
                    break;
                }
                else
                {
                    sum += arr[end++];
                }

                if (sum == M)
                {
                    result++;
                }
            }

            Console.Write(result);
            
        }
    }
}
