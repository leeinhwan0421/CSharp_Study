using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11053
    // 가장 긴 증가하는 부분 수열

    internal class Problem11053Solver
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
                int point = 0;

                for (int j = 1; j < i; j++)
                {
                    if (arr[i] > arr[j])
                        point = Math.Max(point, dp[j]);
                }

                dp[i] = point + 1;
                result = Math.Max(result, dp[i]);
            }

            Console.Write(result);
            
        }
    }
}
