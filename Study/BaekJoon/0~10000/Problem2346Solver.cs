using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2346
    // 풍선 터뜨리기

    internal class Problem2346Solver
    {
        static List<(int, int)> deque = new List<(int, int)>();
        static StringBuilder sb = new StringBuilder();

        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());
            string[] M = Console.ReadLine().Split(' ');
            
            for (int i = 0; i < N; i++)
            {
                deque.Add((i + 1, int.Parse(M[i])));
            }

            int idx = 0;
            while (deque.Count != 0)
            {
                int cnt = deque[idx].Item2;
                sb.Append($"{deque[idx].Item1} ");
                deque.RemoveAt(idx);

                if (deque.Count == 0)
                {
                    break;
                }

                if (cnt > 0)
                {
                    idx = (idx + cnt - 1) % deque.Count;
                }
                else
                {
                    idx = (idx + cnt) % deque.Count;
                    if (idx < 0) idx += deque.Count;
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
