using System;
using System.Collections.Generic;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/9251
    // LCS

    internal class Problem9251Solver
    {
        private static int[,] dp;

        static public void Solve()
        {
            string A = Console.ReadLine();
            string B = Console.ReadLine();

            dp = new int[A.Length + 1, B.Length + 1];

            for (int i = 1; i <= A.Length; i++)
            {
                for (int j = 1; j <= B.Length; j++)
                {
                    if (A[i - 1] == B[j - 1])
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            Console.Write(dp[A.Length, B.Length]);
            
        }
    }
}
