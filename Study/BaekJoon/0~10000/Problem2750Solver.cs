using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2750
    // 수 정렬하기

    internal class Problem2750Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();

            for (int i = 0; i < N; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            list.Sort();
            list.Reverse();

            foreach(var item in list)
            {
                Console.Write($"item\n");
            }

            
        }
    }
}
