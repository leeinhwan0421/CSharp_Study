using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11724
    // 연결 요소의 개수

    internal class Problem11724Solver
    {
        static bool[] visited;
        static List<List<int>> nodes = new List<List<int>>();

        static private void DFS(int v)
        {
            visited[v] = true;

            foreach (var i in nodes[v])
            {
                if (visited[i] == false)
                    DFS(i);
            }
        }

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            visited = new bool[N + 1];

            for (int i = 0; i < N + 1; i++)
                nodes.Add(new List<int>());

            for (int i = 0; i < M; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                int u = int.Parse(inputs[0]);
                int v = int.Parse(inputs[1]);

                nodes[u].Add(v);
                nodes[v].Add(u);
            }

            int cnt = 0;

            for (int i = 1; i < N; i++)
            {
                if (visited[i] == false)
                {
                    DFS(i);
                    cnt++;
                }
            }

            Console.Write(cnt);
        }
    }
}
