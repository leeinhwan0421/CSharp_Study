using System;
using System.Collections.Generic;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/9655
    // 돌 게임

    internal class Problem9655Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            // 간단하게 풀 수 있네..

            if (N % 2 == 1)
            {
                Console.Write("SK");
            }
            else
            {
                Console.Write("CY");
            }

            
        }
    }
}
