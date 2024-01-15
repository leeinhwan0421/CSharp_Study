using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1707
    // 이분 그래프

    // 인접한 정점끼리 서로 다른 색으로 칠해서 모든 정점을 두 가지 색으로만 칠할 수 있는 그래프

    internal class Problem1707Solver
    {
        static List<int>[] A;
        static int[] chk;
        static bool[] visited;
        static bool isBipartiteGraph;

        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int K = int.Parse(sr.ReadLine());

            for (int i = 0; i < K; i++)
            {
                string[] inputs = sr.ReadLine().Split(' ');

                int V = int.Parse(inputs[0]);
                int E = int.Parse(inputs[1]);

                A = new List<int>[V + 1];
                visited = new bool[V + 1];
                chk = new int[V + 1];
                isBipartiteGraph = true;

                for (int p = 0; p < V + 1; p++)
                    A[p] = new List<int>();

                for (int j = 0; j < E; j++)
                {
                    inputs = sr.ReadLine().Split(' ');

                    int s = int.Parse(inputs[0]);
                    int e = int.Parse(inputs[1]);

                    A[s].Add(e);
                    A[e].Add(s);
                }

                for (int j = 0; j <= V; j++)
                {
                    if (isBipartiteGraph)
                        DFS(j);
                    else
                        break;
                }

                if (isBipartiteGraph)
                    sw.Write("YES\n");
                else
                    sw.Write("NO\n");
            }

            sw.Flush();
            sr.ReadLine();
        }

        static public void DFS(int nde)
        {
            visited[nde] = true;

            foreach(var it in A[nde])
            {
                if (!visited[it])
                {
                    chk[it] = (chk[nde] + 1) % 2;
                    DFS(it);
                }
                else if (chk[nde] == chk[it])
                {
                    isBipartiteGraph = false;
                }
            }
        }
    }
}
