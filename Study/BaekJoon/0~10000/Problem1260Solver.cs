using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1260
    // DFS와 BFS

    internal class Problem1260Solver
    {
        static List<List<int>> a = new List<List<int>>();
        static bool[] visit; 

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');
            
            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);
            int V = int.Parse(inputs[2]);

            for (int i = 0; i < N + 1; i++)
                a.Add(new List<int>());

            for (int i = 0; i < M; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                int e = int.Parse(inputs[0]);
                int s = int.Parse(inputs[1]);

                a[e].Add(s);
                a[s].Add(e);
            }

            for (int i = 0; i < N + 1; i++)
                a[i].Sort();

            visit = new bool[N + 1];
            DFS(V);

            Console.Write("\n");

            visit = new bool[N + 1];
            BFS(V);

            Console.ReadKey();
        }

        static public void DFS(int v)
        {
            Console.Write($"{v} ");
            visit[v] = true;
            
            foreach(var i in a[v])
            {
                if (!visit[i])
                    DFS(i);
            }
        }

        static public void BFS(int v)
        {
            Queue<int> m_queue = new Queue<int>();
            m_queue.Enqueue(v);
            visit[v] = true;

            while(m_queue.Count != 0)
            {
                int nw = m_queue.Dequeue();
                Console.Write($"{nw} ");

                foreach (var i in a[nw])
                {
                    if (!visit[i])
                    {
                        m_queue.Enqueue(i);
                        visit[i] = true;
                    }
                }
            }
        }
    }
}
