using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2252
    // 줄 세우기

    internal class Problem2252Solver
    {
        static StringBuilder sb = new StringBuilder();

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int n = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);

            List<int>[] A = new List<int>[n + 1];
            int[] indegree = new int[n + 1];

            for (int i = 0; i < n + 1; i++)
                A[i] = new List<int>();

            for (int i = 0; i < m; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                int s = int.Parse(inputs[0]);
                int e = int.Parse(inputs[1]);

                A[s].Add(e);
                indegree[e]++;
            }

            Queue<int> m_queue = new Queue<int>();

            for (int i = 1; i <= n; i++)
            {
                if (indegree[i] == 0)
                {
                    m_queue.Enqueue(i);
                }
            }

            while(m_queue.Count() > 0)
            {
                int nw = m_queue.Dequeue();
                sb.Append($"{nw} ");

                foreach(var nxt in A[nw])
                {
                    indegree[nxt]--;
                    if (indegree[nxt] == 0)
                        m_queue.Enqueue(nxt);
                }
            }

            Console.Write(sb.ToString());
            
        }
    }
}
