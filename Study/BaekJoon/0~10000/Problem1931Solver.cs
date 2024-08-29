using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1931
    // 회의실 배정하기

    internal class Problem1931Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            List<(int, int)> list = new List<(int, int)>();

            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');

                list.Add((int.Parse(inputs[1]), int.Parse(inputs[0])));
            }

            list.Sort();

            int cnt = 0;
            int end = -1;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item2 >= end)
                {
                    end = list[i].Item1;
                    cnt++;
                }
            }

            Console.Write(cnt);
            Console.ReadKey();
        }
    }
}
