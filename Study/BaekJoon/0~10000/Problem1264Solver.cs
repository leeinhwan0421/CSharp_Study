using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1264
    // 모음

    internal class Problem1264Solver
    {
        static public void Solve()
        {
            while (true)
            {
                string it = Console.ReadLine();

                if (it == "#")
                    return;

                it = it.ToLower();

                int cnt = 0;
                for (int i = 0; i < it.Length; i++)
                {
                    if (it[i] == 'a' || it[i] == 'e' || it[i] == 'i' || it[i] == 'o' || it[i] == 'u')
                        cnt++;
                }

                Console.WriteLine(cnt);
            }
        }
    }
}
