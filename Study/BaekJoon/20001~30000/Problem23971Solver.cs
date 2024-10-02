using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/23971
    // ZOAC 4

    class Problem23971Solver
    {
        public static void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int H = int.Parse(inputs[0]);
            int W = int.Parse(inputs[1]);
            int N = int.Parse(inputs[2]);
            int M = int.Parse(inputs[3]);

            int r = (H + N) / (N + 1);
            int c = (W + M) / (M + 1);

            Console.Write(r * c);
            
        }
    }
}
