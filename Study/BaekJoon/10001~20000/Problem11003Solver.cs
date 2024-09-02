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

    internal class Problem11003Solver
    {
        static LinkedList<(int, int)> deque = new LinkedList<(int, int)>();
        static StringBuilder sb = new StringBuilder();

        static public void Solve()
        {
            Console.InputEncoding = Encoding.ASCII;
            Console.OutputEncoding = Encoding.ASCII;

            using (BufferedStream bs = new BufferedStream(Console.OpenStandardInput()))
            using (StreamReader sr = new StreamReader(bs))
            using (StreamWriter sw = new StreamWriter(Console.OpenStandardOutput()))
            {
                string[] inputs = sr.ReadLine().Split(' ');

                int N = int.Parse(inputs[0]);
                int L = int.Parse(inputs[1]);

                inputs = sr.ReadLine().Split(' ');

                for (int i = 0; i < N; i++)
                {
                    int nw = int.Parse(inputs[i]);

                    while (deque.Count != 0 && deque.Last.Value.Item1 > nw)
                    {
                        deque.RemoveLast();
                    }

                    // 새 값 추가
                    deque.AddLast((nw, i));

                    if (deque.First.Value.Item2 <= i - L)
                    {
                        deque.RemoveFirst();
                    }

                    sb.Append($"{deque.First.Value.Item1} ");
                }

                sw.Write(sb.ToString());
                sw.Flush();

                Console.ReadKey();
            }
        }
    }
}