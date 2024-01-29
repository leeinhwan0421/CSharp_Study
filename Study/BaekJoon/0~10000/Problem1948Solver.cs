using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1948
    // 임계경로

    internal class Problem1948Solver
    {
        static public void Solve()
        {
            string[] inputs;

            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());

            List<List<(int, int)>> A = new List<List<(int, int)>>();
            List<List<(int, int)>> reverseA = new List<List<(int, int)>>();
            List<int> indegree = new List<int>();

            for (int i = 0; i < N + 1; i++)
            {
                A.Add(new List<(int, int)>());
                reverseA.Add(new List<(int, int)>());
                indegree.Add(0);
            }

            for (int i = 0; i < M; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int S, E, V;

                S = int.Parse(inputs[0]);
                E = int.Parse(inputs[1]);
                V = int.Parse(inputs[2]);

                A[S].Add((E, V));
                reverseA[E].Add((S, V));
                indegree[E]++;
            }

            inputs = Console.ReadLine().Split(' ');
            int start, end;

            start = int.Parse(inputs[0]);
            end = int.Parse(inputs[1]);

            Queue<int> mq = new Queue<int>();
            mq.Enqueue(start);

            List<int> result = new List<int>();
            for (int i = 0; i < N + 1; i++)
                result.Add(0);

            while (mq.Count > 0)
            {
                int nw = mq.First();
                mq.Dequeue();

                foreach ((int, int) next in A[nw])
                {
                    indegree[next.Item1]--;
                    result[next.Item1] = Math.Max(result[next.Item1], result[nw] + next.Item2);

                    if (indegree[next.Item1] == 0)
                    {
                        mq.Enqueue(next.Item1);
                    }
                }
            }

            /* ========================================================================================== */

            int resultCnt = 0;

            List<bool> visited = new List<bool>();
            for (int i = 0; i < N + 1; i++)
                visited.Add(false);

            Queue<int> rq = new Queue<int>();

            rq.Enqueue(end);
            visited[end] = true;

            while (rq.Count > 0)
            {
                int nw = rq.First();
                rq.Dequeue();

                foreach ((int, int) next in reverseA[nw])
                {
                    if (result[next.Item1] + next.Item2 == result[nw])
                    {
                        resultCnt++;

                        if (visited[next.Item1] == false)
                        {
                            visited[next.Item1] = true;
                            rq.Enqueue(next.Item1);
                        }
                    }
                }
            }

            Console.Write($"{result[end]}\n{resultCnt}");
            Console.ReadKey();
        }
    }
}
