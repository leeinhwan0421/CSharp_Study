using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2156
    // 포도주 시식

    internal class Problem2156Solver
    {
        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());

            List<int> wine = new List<int>();
            List<int> dp = new List<int>();

            wine.Add(0);
            wine.Add(0);
            wine.Add(0);

            dp.Add(0);
            dp.Add(0);
            dp.Add(0);

            for (int i = 0; i < n; i++)
            {
                wine.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 3; i < wine.Count; i++)
            {
                dp.Add(Math.Max(Math.Max(dp[i - 3] + wine[i - 1] + wine[i], dp[i - 2] + wine[i]), dp[i - 1]));
            }

            Console.Write(dp[dp.Count - 1]);

            Console.ReadKey();
        }
    }
}
