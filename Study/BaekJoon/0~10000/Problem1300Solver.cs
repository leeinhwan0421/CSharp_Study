using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1300
    // K 번째 수

    internal class Problem1300Solver
    {
        static public void Solve()
        {
            long n = int.Parse(Console.ReadLine());
            long k = int.Parse(Console.ReadLine());

            long s = 1;
            long e = k;
            long result = 0;

            while (s <= e)
            {
                long m = (s + e) / 2;
                long cnt = 0;

                for (int i = 1; i <= n; i++)
                    cnt += Math.Min(m / i, n);

                if (cnt < k)
                {
                    s = m + 1;
                }
                else
                {
                    result = m;
                    e = m - 1;
                }
            }

            Console.Write(result);
            
        }
    }
}
