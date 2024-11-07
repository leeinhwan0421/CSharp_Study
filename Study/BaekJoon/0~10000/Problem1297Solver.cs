using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1297
    // TV 크기

    internal class Problem1297Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int D = int.Parse(inputs[0]);
            int H = int.Parse(inputs[1]);
            int W = int.Parse(inputs[2]);

            double DIAGONAL = Math.Sqrt(W * W + H * H);
            double width = D * W / DIAGONAL;
            double height = D * H / DIAGONAL;

            Console.Write($"{(int)height} {(int)width}");
        }
    }
}
