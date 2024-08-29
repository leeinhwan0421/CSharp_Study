using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1547
    // 공

    internal class Problem1547Solver
    {
        static public void Solve()
        {
            List<(int, bool)> list = new List<(int, bool)>
            {
                (1, true),
                (2, false),
                (3, false)
            };

            int M = int.Parse(Console.ReadLine());

            for (int i = 0; i < M; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');

                int x = int.Parse(inputs[0]) - 1;
                int y = int.Parse(inputs[1]) - 1;

                var temp = list[x];
                
                list[x] = list[y];
                list[y] = temp;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item2 == true)
                    Console.Write(i + 1);
            }

            Console.ReadKey();
        }
    }
}
