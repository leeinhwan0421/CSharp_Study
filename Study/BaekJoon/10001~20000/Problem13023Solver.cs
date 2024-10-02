using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/13023
    // ABCDE

    internal class Problem13023Solver
    {
        static List<List<int>> a = new List<List<int>>();
        static bool[] visited;
        static bool arrive = false;

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            for (int i = 0; i < N; i++)
                a.Add(new List<int>());

            visited = new bool[N];

            for (int i = 0; i < M; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                int e = int.Parse(inputs[0]);
                int s = int.Parse(inputs[1]);

                a[e].Add(s);
                a[s].Add(e);
            }

            for (int i = 0; i < N; i++)
            {
                DFS(i, 1);
            }

            Console.WriteLine($"{(arrive ? 1 : 0)}");
            
        }

        static public void DFS(int nw, int depth)
        {
            if (depth == 5 || arrive)
            {
                arrive = true;
                return;
            }

            visited[nw] = true;

            foreach (var nxt in a[nw])
            {
                if (!visited[nxt])
                    DFS(nxt, depth + 1);
            }

            visited[nw] = false;
        }
    }
}