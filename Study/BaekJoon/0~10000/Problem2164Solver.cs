using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2164
    // 카드2

    internal class Problem2164Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());
            Queue<int> S = new Queue<int>();

            for (int i = 1; i < N + 1; i++)
            {
                S.Enqueue(i);
            }

            // 버 - 옮 - 버 - 옮
            while(S.Count != 1)
            {
                S.Dequeue();
                S.Enqueue(S.Dequeue());
            }

            Console.WriteLine(S.Peek());
            Console.ReadKey();
        }
    }
}
