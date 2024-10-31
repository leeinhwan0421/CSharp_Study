using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/31429
    // SUAPC 2023 Summer

    class Problem31429Solver
    {
        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());

            int[] solved = { 12, 11, 11, 10, 9, 9, 9, 8, 7, 6, 6 };
            int[] penalty = { 1600, 894, 1327, 1311, 1004, 1178, 1357, 837, 1055, 556, 773};

            Console.Write($"{solved[n - 1]} {penalty[n - 1]}");
        }
    }
}
