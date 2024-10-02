using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/12865
    // 평범쓰 배낭

    internal class Problem12865Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split();

            int n = int.Parse(inputs[0]);
            int k = int.Parse(inputs[1]);

            int[] weight = new int[101];
            int[] price = new int[101];
            int[,] DP = new int[101, 100001];

            for (int i = 1; i <= n; i++)
            {
                inputs = Console.ReadLine().Split();

                weight[i] = int.Parse(inputs[0]);
                price[i] = int.Parse(inputs[1]);
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    if (j >= weight[i])
                    {
                        DP[i, j] = Math.Max(DP[i - 1, j], DP[i - 1, j - weight[i]] + price[i]);
                    }
                    else
                    {
                        DP[i, j] = DP[i - 1, j];
                    }
                }
            }

            Console.WriteLine(DP[n, k]);
            // 
        }
    }
}
