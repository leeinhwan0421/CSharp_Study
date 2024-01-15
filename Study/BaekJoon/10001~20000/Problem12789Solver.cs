using System;
using System.Collections;
using System.Linq;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/12789
    // 도키도키 간식드리미

    internal class Problem12789Solver
    {
        static Stack first = new Stack();

        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());
            int cnt = 1;

            string[] lineStr = Console.ReadLine().Split(' ');
            foreach (string numStr in lineStr)
            {
                int num = int.Parse(numStr);

                if (num == cnt)
                {
                    cnt++;
                }
                else
                {
                    first.Push(num);
                }

                while (first.Count > 0 && (int)first.Peek() == cnt)
                {
                    first.Pop();
                    cnt++;
                }
            }

            if (cnt == N + 1)
            {
                Console.WriteLine("Nice");
            }
            else
            {
                Console.WriteLine("Sad");
            }
        }
    }
}
