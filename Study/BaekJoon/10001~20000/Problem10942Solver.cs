using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/10942
    // 팰린드롬?

    internal class Problem10942Solver
    {
        static public void Solve()
        {
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            string[] inputs = sr.ReadLine().Split(' ');

            int[] arr = new int[N + 1];
            for (int i = 1; i <= N; i++)
            {
                arr[i] = int.Parse(inputs[i - 1]);
            }

            bool[,] DP = new bool[N + 1, N + 1];
            for (int i = 1; i <= N - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                    DP[i, i + 1] = true;
            }

            for (int i = 1; i <= N; i++)
            {
                DP[i, i] = true;
            }

            for (int i = N - 1; i >= 1; i--)
            {
                for (int j = i + 2; j <= N; j++)
                {
                    if (arr[i] == arr[j] && DP[i + 1, j - 1] == true)
                    {
                        DP[i, j] = true;
                    }
                }
            }

            int M = int.Parse(sr.ReadLine());

            for (int i = 0; i < M; i++)
            {
                inputs = sr.ReadLine().Split(' ');

                int S = int.Parse(inputs[0]);
                int E = int.Parse(inputs[1]);

                sb.Append($"{(DP[S, E] == true ? 1 : 0)}\n");
            }

            sw.Write(sb.ToString());
            sw.Flush();
            Console.ReadKey();
        }
    }
}
