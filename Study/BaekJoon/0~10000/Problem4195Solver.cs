using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/4195
    // 친구 네트워크

    internal class Problem4195Solver
    {
        static string[] inputs;

        static Dictionary<string, int> dict = new Dictionary<string, int>();
        static int[] parent;
        static int[] size;

        static public void Union(string A, string B)
        {

        }

        static public int Find(int x)
        {
            if (x == parent[x]) return x;
            return parent[x] = Find(parent[x]);
        }

        static public void Solve()
        {
            int F = int.Parse(Console.ReadLine());

            for (int i = 0; i < F; i++)
            {
                inputs = Console.ReadLine().Split(' ');


            }
        }
    }
}
