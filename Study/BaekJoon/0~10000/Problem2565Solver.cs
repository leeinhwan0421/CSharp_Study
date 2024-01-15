using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    internal class Problem2565Solver
    {
        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            var arr = new Tuple<int, int>[n];
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                arr[i] = new Tuple<int, int>(input[0], input[1]);
            }

            arr = arr.OrderBy(x => x.Item1).ToArray();

            int[] dp = new int[n];

            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (arr[i].Item2 > arr[j].Item2)
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            Console.WriteLine(n - dp.Max());
            Console.ReadKey();
        }
    }
}