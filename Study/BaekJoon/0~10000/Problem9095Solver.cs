using System;
using System.Collections.Generic;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/9095
    // 1,2,3 더하기

    internal class Problem9095Solver
    {
        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int T = int.Parse(sr.ReadLine());

            int[] dp = new int[11];

            dp[1] = 1;
            dp[2] = 2;
            dp[3] = 4;

            for (int i = 4; i < 11; i++)
            {
                dp[i] = dp[i - 3] + dp[i - 2] + dp[i - 1];
            }


            for (int i = 0; i < T; i++)
            {
                int n = int.Parse(sr.ReadLine());

                sw.Write($"{dp[n]}\n");
            }

            sw.Flush();
            sr.ReadLine();

            sr.Close();
            sw.Close();
        }
    }
}
