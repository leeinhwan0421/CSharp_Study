using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1934
    // 최소 공배수

    internal class Problem1934Solver
    {
        static public int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            else
            {
                return GCD(b, a % b);
            }
        }

        static public void Solve()
        {
            int T = int.Parse(Console.ReadLine());

            for (int task = 0; task < T; task++)
            {
                string[] inputs = Console.ReadLine().Split(' ');

                int A = int.Parse(inputs[0]);
                int B = int.Parse(inputs[1]);

                int result = A * B / GCD(A, B);

                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}
