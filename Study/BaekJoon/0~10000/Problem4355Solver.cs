using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/4355
    // 서로소

    internal class Problem4355Solver
    {
        static string[] inputs;

        static public void Solve()
        {
            while (true)
            {
                int N = int.Parse(Console.ReadLine());
                
                if (N == 0) break;

                if (N == 1)
                {
                    Console.WriteLine("0");
                    continue;
                }

                int result = N;

                for (int P = 2; P * P <= N; P++)
                {
                    if (N % P == 0)
                    {
                        result -= result / P;
                        while (N % P == 0)
                        {
                            N /= P;
                        }
                    }
                }

                if (N > 1)
                {
                    result -= result / N;
                }

                Console.WriteLine(result);
            }
        }
    }
}
