using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2166
    // 다각형의 면적

    internal class Problem2166Solver
    {
        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            long[] x = new long[n + 1];
            long[] y = new long[n + 1];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                x[i] = long.Parse(input[0]);
                y[i] = long.Parse(input[1]);
            }

            x[n] = x[0];
            y[n] = y[0];

            long sum1 = 0, sum2 = 0;
            for (int i = 0; i < n; i++)
            {
                sum1 += x[i] * y[i + 1];
                sum2 += y[i] * x[i + 1];
            }

            double area = Math.Abs(sum1 - sum2) / 2.0;

            Console.WriteLine($"{area:F1}");
            
        }
    }
}
