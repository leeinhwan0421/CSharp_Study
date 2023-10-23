using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11725
    // 트리의 부모 찾기

    internal class Problem11725Solver
    {
        static bool[] visited;
        static int[] parent;
        static List<int>[] list; 

        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int n = int.Parse(sr.ReadLine());

            visited = new bool[n + 1];
            parent = new int[n + 1];
            list = new List<int>[n + 1];

            for (int i = 0; i <= n; i++)
                list[i] = new List<int>();

            for (int i = 0; i < n - 1; i++)
            {
                string[] inputs = sr.ReadLine().Split(' ');
                int e = int.Parse(inputs[0]);
                int s = int.Parse(inputs[1]);

                list[e].Add(s);
                list[s].Add(e);
            }

            DFS(1);

            for (int i = 2; i <= n; i++)
                sw.Write($"{parent[i]}\n");

            sw.Flush();
            Console.ReadLine();
        }

        static void DFS(int idx)
        {
            visited[idx] = true;

            foreach (var item in list[idx])
            {
                if (visited[item] == false)
                {
                    parent[item] = idx;
                    DFS(item);
                }
            }
        }
    }
}
