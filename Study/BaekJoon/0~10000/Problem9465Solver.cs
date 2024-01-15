using System;
using System.Collections.Generic;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/9465
    // 스티커

    internal class Problem9465Solver
    {
        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int n = int.Parse(sr.ReadLine());

                int[,] arr = new int[2, n + 1]; 
                int[,] dp = new int[2, n + 1];

                for (int j = 0; j < 2; j++)
                {
                    string[] inputs = sr.ReadLine().Split(' ');
                    for (int k = 1; k <= n; k++)
                    {
                        arr[j, k] = int.Parse(inputs[k - 1]);
                    }
                }

                dp[0, 1] = arr[0, 1];
                dp[1, 1] = arr[1, 1];

                for (int a = 2; a <= n; a++)
                {
                    dp[0, a] = Math.Max(dp[1, a - 1], dp[1, a - 2]) + arr[0, a];
                    dp[1, a] = Math.Max(dp[0, a - 1], dp[0, a - 2]) + arr[1, a];
                }

                sw.Write($"{Math.Max(dp[0, n], dp[1, n])}\n");
            }

            sw.Flush();
            sr.ReadLine();

            sw.Close();
            sr.Close();
        }
    }
}
