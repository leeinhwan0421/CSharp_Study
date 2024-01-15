using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/21568
    // Ax + By = C

    // 확장 유클리드 호제법

    class Problem21568Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            long a = long.Parse(inputs[0]);
            long b = long.Parse(inputs[1]);
            long c = long.Parse(inputs[2]);

            long tgcd = GCD(a, b);

            if (c % tgcd != 0)
            {
                Console.Write("-1");
                Console.ReadKey();
                return;
            }

            int result = (int)(c / tgcd);
            var ret = Execute_Solve(a, b);
            Console.Write($"{ret[0] * result} {ret[1] * result}");
            Console.ReadKey();
        }
        
        static public long[] Execute_Solve(long a, long b)
        {
            long[] ret = new long[2];

            if ( b == 0 )
            {
                ret[0] = 1;
                ret[1] = 0;
                return ret;
            }

            long q = a / b;
            var v = Execute_Solve(b, a % b);
            ret[0] = v[1];
            ret[1] = v[0] - v[1] * q;

            return ret;
        }

        static public long GCD(long a, long b)
        {
            if (b == 0)
                return a;
            else
                return GCD(b, a % b);
        }
    }
}
