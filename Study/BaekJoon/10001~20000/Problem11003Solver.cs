using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11003
    // 최소값 찾기
    // 이 방식이 맞는데, 시간초과로 인한 이슈로 문제를 풀 수 없음

    internal class Problem11003Solver
    {
        static List<(int, int)> deque = new List<(int, int)>();
        static StringBuilder sb = new StringBuilder();

        static public void Solve()
        {
            Console.InputEncoding = Encoding.ASCII;
            Console.OutputEncoding = Encoding.ASCII;

            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string[] inputs = sr.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int L = int.Parse(inputs[1]);

            inputs = sr.ReadLine().Split(' ');

            for (int i = 0; i < N; i++)
            {
                int nw = int.Parse(inputs[i]);
                while (deque.Count != 0 && deque[deque.Count - 1].Item1 > nw)
                {
                    deque.RemoveAt(deque.Count - 1);
                }

                deque.Add((nw, i));

                if (deque[0].Item2 <= i - L)
                {
                    deque.RemoveAt(0);
                }

                sb.Append($"{deque[0].Item1} ");
            }

            sw.Write(sb.ToString());
            sw.Flush();
            sr.ReadLine();
        }
    }
}
