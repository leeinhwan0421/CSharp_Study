using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1629
    // 곱셈

    internal class Problem1629Solver
    {
        static long A;
        static long B;
        static long C;

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            A = long.Parse(inputs[0]);
            B = long.Parse(inputs[1]);
            C = long.Parse(inputs[2]);

            Console.Write(multi(B));
            Console.ReadKey();
        }

        static long multi(long y)
        {
            if (y == 1)
            {
                return A % C;
            }

            long k = multi(y / 2) % C;

            if (y % 2 == 0)
            {
                return k * k % C;
            }
            else
            {
                return k * k % C * A % C;
            }
        }
    }
}
