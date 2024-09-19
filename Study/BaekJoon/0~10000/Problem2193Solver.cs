using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2193
    // 이친수

    internal class Problem2193Solver
    {
        static public void Solve()
        {
            long[] D = new long[91];

            D[0] = 0;
            D[1] = 1;

            for (int i = 2; i < D.Length; i++)
            {
                D[i] = D[i - 2] + D[i - 1];
            }

            int N = int.Parse(Console.ReadLine());

            Console.Write(D[N]);
            Console.ReadKey();
        }
    }
}
