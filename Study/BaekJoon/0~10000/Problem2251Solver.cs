using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2251
    // 물통

    // 1번째 물통이 비어있는 경우, 3번째 물통에 담겨있을 수 있는 물의 양을 오름차순으로 정렬해 보이면 된다.

    internal class Problem2251Solver
    {
        static int[] Sender = { 0, 0, 1, 1, 2, 2 };
        static int[] Receiver = { 1, 2, 0, 2, 0, 1 };

        static bool[,] visited = new bool[201, 201];
        static bool[] answer = new bool[201];
        static int[] bottle = new int[3]; 

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            for (int i = 0; i < 3; i++)
                bottle[i] = int.Parse(inputs[i]);

            BFS();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 201; i++)
            {
                if (answer[i])
                    sb.Append($"{i} ");
            }

            Console.Write(sb.ToString());
            Console.ReadKey();
        }

        static public void BFS()
        {
            Queue<ValueTuple<int, int>> queue = new Queue<ValueTuple<int, int>>();
            queue.Enqueue((0, 0));
            visited[0, 0] = true;
            answer[bottle[2]] = true;

            while (queue.Count > 0)
            {
                var pair_val = queue.Dequeue();
                int A = pair_val.Item1;
                int B = pair_val.Item2;
                int C = bottle[2] - A - B;

                for (int i = 0; i < 6; i++)
                {
                    int[] nxt = { A, B, C };
                    nxt[Receiver[i]] += nxt[Sender[i]];
                    nxt[Sender[i]] = 0;

                    if (nxt[Receiver[i]] > bottle[Receiver[i]])
                    {
                        nxt[Sender[i]] = nxt[Receiver[i]] - bottle[Receiver[i]];
                        nxt[Receiver[i]] = bottle[Receiver[i]];
                    }
                    if (!visited[nxt[0], nxt[1]])
                    {
                        visited[nxt[0], nxt[1]] = true;
                        queue.Enqueue((nxt[0], nxt[1]));
                    }
                    if (nxt[0] == 0)
                    {
                        answer[nxt[2]] = true;
                    }
                }
            }
        }
    }
}
