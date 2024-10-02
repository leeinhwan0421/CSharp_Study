using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11726
    // 2*n 타일링

    internal class Problem11726Solver
    {
        static public void Solve()
        {
            int[] dp = new int[1001];

            int n = int.Parse(Console.ReadLine());

            dp[1] = 1;
            dp[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
                dp[i] = dp[i] % 10007;
            }

            Console.Write(dp[n]);
            
        }
    }
}
