using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2606
    // 바이러스

    internal class Problem2606Solver
    {
        static bool[] visited;
        static List<int>[] node;
        static int cnt = 0;

        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            visited = new bool[n + 1];
            node = new List<int>[n + 1];

            for (int i = 0; i <= n; i++)
            {
                node[i] = new List<int>();
            }

            for (int i = 0; i < m; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');

                int s = int.Parse(inputs[0]);
                int e = int.Parse(inputs[1]);

                node[s].Add(e);
                node[e].Add(s);
            }

            DFS(1);

            Console.WriteLine(cnt - 1);
            
        }

        static public void DFS(int x)
        {
            visited[x] = true;
            cnt++;

            foreach(int it in node[x])
            {
                if (visited[it] == true)
                    continue;
                else
                    DFS(it);
            }
        }
    }
}
