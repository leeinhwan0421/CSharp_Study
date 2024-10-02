using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1068
    // 트리

    internal class Problem1068Solver
    {
        static List<List<int>> tree = new List<List<int>>();
        static bool[] visited = new bool[0];
        static int root = 0;
        static int removeAt = 0;
        static int ans = 0;

        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            visited = new bool[N];
            for (int i = 0; i < N; i++)
                tree.Add(new List<int>());

            string[] inputs = Console.ReadLine().Split(' ');

            for (int i = 0; i < inputs.Length; i++)
            {
                int p = int.Parse(inputs[i]);

                if (p == -1)
                {
                    root = i;
                }
                else
                {
                    tree[i].Add(p);
                    tree[p].Add(i);
                }
            }

            removeAt = int.Parse(Console.ReadLine());

            if (removeAt == root)
            {
                Console.Write("0");
            }
            else
            {
                DFS(root);
                Console.Write(ans);
            }

            
        }

        static public void DFS(int x)
        {
            visited[x] = true;

            int child = 0;
            foreach (int next in tree[x])
            {
                if (visited[next] == false && next != removeAt)
                {
                    child++;
                    DFS(next);
                }
            }

            if (child == 0)
            {
                ans++;
            }
        }
    }
}
