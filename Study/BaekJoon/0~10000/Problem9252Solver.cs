using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/9252
    // LCS 2

    internal class Problem9252Solver
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
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);

                    }
                }
            }

            Console.Write(dp[A.Length, B.Length]);

            if (dp[A.Length, B.Length] != 0)
            {
                StringBuilder sb = new StringBuilder();

                int x = A.Length;
                int y = B.Length;

                while(x > 0 && y > 0)
                {
                    if (A[x - 1] == B[y - 1])
                    {
                        sb.Append(A[x - 1]);
                        x--;
                        y--;
                    }
                    else if (dp[x - 1, y] >= dp[x, y - 1])
                    {
                        x--;
                    }
                    else
                    {
                        y--;
                    }
                }

                Console.Write($"\n{new string(sb.ToString().ToCharArray().Reverse().ToArray())}");
            }

            Console.ReadKey();
        }
    }
}
