using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/10986
    // 나머지 합

    internal class Problem10986Solver
    {
        static public void Solve()
        {
            string[] input = Console.ReadLine().Split(' ');
            
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            long[] arr = new long[n];
            long[] arr_M = new long[m];
            long result = 0;

            input = Console.ReadLine().Split(' ');

            arr[0] = int.Parse(input[0]);

            for (int i = 1; i < n; i++)
            {
                arr[i] = arr[i - 1] + int.Parse(input[i]);
            }

            for (int i = 0; i < n; i++)
            {
                long tx = arr[i] % m;

                if (tx == 0)
                {
                    result++;
                }

                arr_M[tx]++;
            }

            for (int i = 0; i < m; i++)
            {
                if (arr_M[i] > 1)
                {
                    result += (arr_M[i] * (arr_M[i] - 1) / 2);
                }
            }

            Console.WriteLine(result);
        }
    }
}
