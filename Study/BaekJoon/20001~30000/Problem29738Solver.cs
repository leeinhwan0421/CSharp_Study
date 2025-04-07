using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/29738
    // Goodbye, Code Jam

    internal class Problem29738Solver
    {
        static public void Solve()
        {
            int T = int.Parse(Console.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(Console.ReadLine());

                if (N <= 25)
                {
                    Console.WriteLine($"Case #{i + 1}: World Finals");
                }
                else if (N <= 1000)
                {
                    Console.WriteLine($"Case #{i + 1}: Round 3");
                }
                else if (N <= 4500)
                {
                    Console.WriteLine($"Case #{i + 1}: Round 2");
                }
                else
                {
                    Console.WriteLine($"Case #{i + 1}: Round 1");
                }
            }
        }
    }
}
