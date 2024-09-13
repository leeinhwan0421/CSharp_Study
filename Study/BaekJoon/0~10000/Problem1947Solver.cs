using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1947
    // 선물 전달 

    internal class Problem1947Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            ulong[] D = new ulong[1000001];
            ulong mod = 1000000000;

            D[1] = 0;
            D[2] = 1;

            for (int i = 3; i <= N; i++)
            {
                D[i] = (ulong)(i - 1) * (D[i - 1] + D[i - 2]) % mod;
            }

            Console.Write(D[N]);
            Console.ReadKey();
        }
    }
}
