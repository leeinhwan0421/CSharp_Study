using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Item = System.ValueTuple<int, int>;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1916
    // 최소비용 구하기

    internal class Problem1916Solver
    {
        static int N;
        static int M;

        static int[] dist;
        static bool[] visited;
        static List<List<Item>> list = new List<List<Item>>();

        static public void Solve()
        {
            string[] inputs;

            N = int.Parse(Console.ReadLine());
            M = int.Parse(Console.ReadLine());

        }
    }
}
