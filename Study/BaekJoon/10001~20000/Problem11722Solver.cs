using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11722
    // 가장 긴 감소하는 부분 수열

    internal class Problem11722Solver
    {
        static public void Solve()
        {
            int[] arr = new int[1001];
            int[] lds = new int[1001];
            int result = 0;

            int n = int.Parse(Console.ReadLine());

            string[] inputs = Console.ReadLine().Split(' ');

            for (int i = n; i >= 1; i--)
            {
                arr[i] = int.Parse(inputs[i - 1]);
                lds[i] = 1;
                for (int j = n; j > i; j--)
                {
                    if (arr[j] < arr[i] && lds[i] < lds[j] + 1)
                    {
                        lds[i] = lds[j] + 1;
                    }
                }
            }

            for (int i = 1; i <= n; i++)
            {
                result = Math.Max(result, lds[i]);
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
