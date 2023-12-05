using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2579
    // 계단 오르기

    internal class Problem2579Solver
    {
        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());

            int[] stairs = new int[301];
            int[] dp = new int[301];

            for (int i = 0; i < n; i++)
            {
                stairs[i] = int.Parse(Console.ReadLine());
            }

            dp[0] = stairs[0];
            dp[1] = Math.Max(stairs[0] + stairs[1], stairs[1]);
            dp[2] = Math.Max(stairs[0] + stairs[2], stairs[1] + stairs[2]);

            for (int i = 3; i < n; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + stairs[i], stairs[i - 1] + stairs[i] + dp[i - 3]);
            }

            Console.Write(dp[n - 1]);
            Console.ReadLine();
        }
    }
}
