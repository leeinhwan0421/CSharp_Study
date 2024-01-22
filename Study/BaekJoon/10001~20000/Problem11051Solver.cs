using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11051
    // 이항 계수 2

    internal class Problem11051Solver
    {
        static public void Solve()
        {
            int n, k;

            string inputs = Console.ReadLine();

            n = int.Parse(inputs.Split(' ')[0]);
            k = int.Parse(inputs.Split(' ')[1]);


            Int64[,] dp = new Int64[1001, 1001];

            dp[0, 0] = 1;
            dp[1, 0] = 1;
            dp[1, 1] = 1;

            for (int i = 2; i <= n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0)
                        dp[i, 0] = 1;
                    else if (j == i)
                        dp[i, j] = 1;
                    else
                        dp[i, j] = (dp[i - 1, j - 1] + dp[i - 1, j]) % 10007;
                }
            }

            Console.Write(dp[n, k]);
            Console.ReadKey();
        }
    }
}
