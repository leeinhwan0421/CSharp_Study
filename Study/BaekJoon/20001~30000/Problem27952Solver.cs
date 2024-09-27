using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/27952
    // 보디빌딩

    internal class Problem27952Solver
    {
        static string[] inputs;

        static public void Solve()
        {
            inputs = Console.ReadLine().Split(' ');

            long N = long.Parse(inputs[0]);
            long X = long.Parse(inputs[1]);

            inputs = Console.ReadLine().Split(' ');

            long[] arrA = new long[N];
            long[] arrB = new long[N];

            for (long i = 0; i < N; i++)
            {
                arrA[i] = long.Parse(inputs[i]);
            }

            long sum = 0;

            inputs = Console.ReadLine().Split(' ');

            for (long i = 0; i < N; i++)
            {
                arrB[i] = long.Parse(inputs[i]);
                sum += arrB[i];
                if (sum < arrA[i])
                {
                    Console.Write("-1");
                    Console.ReadKey();
                    return;
                }
            }

            Console.Write($"{(sum - arrA[N - 1]) / X}");
            Console.ReadKey();
        }
    }
}
