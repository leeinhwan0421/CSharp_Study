using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1806
    // 부분합

    internal class Problem1806Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int n = int.Parse(inputs[0]);
            int s = int.Parse(inputs[1]);

            inputs = Console.ReadLine().Split(' ');

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(inputs[i]);
            }

            int startIndex = 0, endIndex = 0;
            int min_len = n + 1;
            int sum = arr[0];

            while(true)
            {
                if (sum < s)
                {
                    endIndex++;
                    if (endIndex == n)
                        break;

                    sum += arr[endIndex];
                }
                else
                {
                    sum -= arr[startIndex];
                    min_len = Math.Min(min_len, endIndex - startIndex + 1);
                    startIndex++;
                }
            }

            Console.Write(min_len == n + 1 ? 0 : min_len);
            Console.ReadLine();
        }
    }
}
