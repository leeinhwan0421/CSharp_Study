using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/31831
    // 과민성 대장 증후군

    class Problem31831Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            string[] A = Console.ReadLine().Split(' ');
            int delta = 0;
            int result = 0;

            for (int i = 0; i < N; i++)
            {
                delta += int.Parse(A[i]);

                if (delta < 0)
                {
                    delta = 0;
                }

                if (delta >= M)
                {
                    result++;
                }
            }

            Console.Write(result);
        }
    }
}
