using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1516
    // 게임 개발

    internal class Problem1516Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            List<int>[] A = new List<int>[N + 1];
            int[] indegree = new int[N + 1];
            int[] selfBuild = new int[N + 1];

            for (int i = 0; i <= N; i++)
                A[i] = new List<int>();

            for (int i = 1; i <= N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                selfBuild[i] = int.Parse(inputs[0]);

                for (int j = 1; j < inputs.Length; j++)
                {
                    int preTemp = int.Parse(inputs[j]);

                    if (preTemp == -1)
                        break;

                    A[preTemp].Add(i);
                    indegree[i]++;
                }
            }

            Queue<int> queue = new Queue<int>();

            for (int i = 1; i <= N; i++)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            int[] result = new int[N + 1];

            while(queue.Count() > 0)
            {
                int nw = queue.Dequeue();

                foreach(var nxt in A[nw])
                {
                    indegree[nxt]--;
                    result[nxt] = Math.Max(result[nxt], result[nw] + selfBuild[nw]);
                    if (indegree[nxt] == 0)
                    {
                        queue.Enqueue(nxt);
                    }
                }
            }

            for (int i = 1; i <= N; i++)
            {
                Console.Write($"{result[i] + selfBuild[i]}\n");
            }

            
        }
    }
}
