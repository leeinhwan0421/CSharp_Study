using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2018
    // 수들의 합

    internal class Problem2018Solver
    {
        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());

            int startIndex = 1;
            int endIndex = 1;
            int result = 1;
            int sum = 1;

            while (endIndex != n)
            {
                if (sum == n)
                {
                    endIndex++;
                    result++;
                    sum += endIndex;
                }
                else if (sum > n)
                {
                    sum -= startIndex;
                    startIndex++;
                }
                else
                {
                    endIndex++;
                    sum += endIndex;

                }
            }

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
