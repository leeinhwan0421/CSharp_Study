using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1377
    // 버블 소트

    using item = System.ValueTuple<int, int>;

    internal class Problem1377Solver
    {
        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            int N = int.Parse(sr.ReadLine());
            item[] list = new item[N];

            for (int i = 0; i < N; i++)
            {
                list[i] = new item(int.Parse(sr.ReadLine()), i);
            }

            Array.Sort(list);

            int max = 0;

            for (int i = 0; i < N; i++)
            {
                if (list[i].Item2 - i > max)
                {
                    max = list[i].Item2 - i;
                }
            }

            Console.Write(max + 1);
        }
    }
}
