using System;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/30445
    // 행복 점수

    class Problem30445Solver
    {
        static public void Solve()
        {
            string line = Console.ReadLine();

            int pH = 0; // 행복 점수
            int pG = 0; // 우울 점수

            foreach (char c in line)
            {
                if (c == 'H' || c == 'A' || c == 'P' || c == 'Y')
                {
                    pH++;
                }

                if (c == 'S' || c == 'A' || c == 'D')
                {
                    pG++;
                }
            }

            if (pH == 0 && pG == 0)
            {
                Console.WriteLine("50.00");
            }
            else
            {
                float result = (float)pH / (pH + pG) * 100;
                Console.WriteLine($"{result:0.00}");
            }
        }
    }
}
