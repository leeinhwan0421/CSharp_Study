using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2805
    // 나무 자르기

    internal class Problem2805Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            long N = long.Parse(inputs[0]);
            long M = long.Parse(inputs[1]);

            long[] arr = new long[N];

            inputs = Console.ReadLine().Split(' ');

            for (int i = 0; i < N; i++)
            {
                arr[i] = long.Parse(inputs[i]);
            }

            Array.Sort(arr);

            long max = 0;

            long low = 0;
            long high = arr[N - 1];

            while (low <= high)
            {
                long sum = 0;
                long middle = (low + high) / 2;

                for (int i = 0; i < N; i++)
                {
                    if (arr[i] - middle > 0) sum += arr[i] - middle;
                }

                if (sum >= M)
                {
                    max = middle;
                    low = middle + 1;
                }
                else
                {
                    high = middle - 1;
                }
            }

            Console.Write(max);
            Console.ReadKey();
        }
    }
}
