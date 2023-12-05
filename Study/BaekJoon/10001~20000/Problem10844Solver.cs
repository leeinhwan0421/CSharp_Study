using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/10844
    // 쉬운 계단 수

    internal class Problem10844Solver
    {
        static int[,] dp = new int[101, 10];

        static public void StairNumber(int n)
        {
            for (int i = 0; i <= 9; i++)
            {
                dp[1, i] = 1;
            }

            dp[1, 0] = 0;

            for (int i = 2; i <= n; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    if (j == 0)
                    {
                        dp[i, j] = dp[i - 1, j + 1] % 1000000000;
                    }
                    else if (j == 9)
                    {
                        dp[i, j] = dp[i - 1, j - 1] % 1000000000;
                    }
                    else
                    {
                        dp[i, j] = (dp[i - 1, j - 1] + dp[i - 1, j + 1]) % 1000000000;
                    }
                }
            }
        }

        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());

            StairNumber(n);

            long result = 0;

            for (int i = 0; i <= 9; i++)
            {
                result = (result + dp[n, i]) % 1000000000;
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
