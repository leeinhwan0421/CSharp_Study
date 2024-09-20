using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1328
    // 고층 빌딩

    internal class Problem1328Solver
    {
        static int MOD = 1000000007;

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            long N = long.Parse(inputs[0]);
            long L = long.Parse(inputs[1]);
            long R = long.Parse(inputs[2]);

            long[,,] DP = new long[N + 1, L + 1, R + 1];

            DP[1, 1, 1] = 1;

            for (long n = 2; n <= N; n++)
            {
                for (long l = 1; l <= L; l++)
                {
                    for (long r = 1; r <= R; r++)
                    {
                        DP[n, l, r] = (DP[n - 1, l - 1, r] + DP[n - 1, l, r - 1] + (n - 2) * DP[n - 1, l, r]) % MOD;
                    }
                }
            }

            Console.Write(DP[N, L, R]);
            Console.ReadKey();
        }
    }
}
