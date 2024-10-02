using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/31668
    // 특별한 가지

    class Problem31668Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int K = int.Parse(Console.ReadLine());

            Console.Write(M / N * K);
            
        }
    }
}
