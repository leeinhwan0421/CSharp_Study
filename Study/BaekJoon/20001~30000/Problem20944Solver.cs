using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/20944
    // 팰린드롬 척화비

    class Problem20944Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                sb.Append('a');
            }

            Console.Write(sb.ToString());
            Console.ReadKey();
        }
    }
}
