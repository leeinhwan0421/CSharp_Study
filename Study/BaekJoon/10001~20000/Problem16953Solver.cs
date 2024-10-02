using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1629
    // 곱셈

    internal class Problem16953Solver
    {
        static long A;
        static long B;

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            A = long.Parse(inputs[0]);
            B = long.Parse(inputs[1]);

            AtoB();

            
        }

        static public void AtoB()
        {
            Queue<(long, long, int)> q = new Queue<(long, long, int)>();
            q.Enqueue((A, B, 1));

            while(q.Count > 0)
            {
                var nw = q.Dequeue();

                if (nw.Item1 == nw.Item2)
                {
                    Console.Write(nw.Item3);
                    return;
                }
                else if (nw.Item1 > nw.Item2)
                {
                    continue;
                }
                else
                {
                    long a1 = nw.Item1 * 2;
                    long a2 = long.Parse(nw.Item1.ToString() + "1");

                    q.Enqueue((a1, B, nw.Item3 + 1));
                    q.Enqueue((a2, B, nw.Item3 + 1));
                }
            }

            Console.Write(-1);
        }
    }
}
