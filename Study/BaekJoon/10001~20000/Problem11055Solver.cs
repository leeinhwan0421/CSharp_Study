using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11055
    // 가장 큰 증가하는 부분 수열

    internal class Problem11055Solver
    {
        static public void Solve()
        {
            int[] arr = new int[1001];
            int[] dp = new int[1001];
            int result = 0;

            int n = int.Parse(Console.ReadLine());

            string[] inputs = Console.ReadLine().Split(' ');
            for (int i = 1; i <= n; i++)
            {
                arr[i] = int.Parse(inputs[i - 1]);
                dp[i] = arr[i];

                for (int j = 1; j < i; j++)
                {
                    if (arr[i] > arr[j])
                        dp[i] = Math.Max(dp[i], dp[j] + arr[i]);
                }

                result = Math.Max(result, dp[i]);
            }

            Console.Write(result);
            
        }
    }
}
