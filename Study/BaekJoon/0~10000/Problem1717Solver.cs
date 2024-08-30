using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1717
    // 집합의 표현

    internal class Problem1717Solver
    {
        static int[] arr = new int[0];

        static public int getParent(int x)
        {
            if (arr[x] == x) return x;
            return arr[x] = getParent(arr[x]);
        }

        static public void Union(int a, int b)
        {
            a = getParent(a);
            b = getParent(b);

            if (a > b) arr[a] = b;
            else arr[b] = a;
        }

        static public void Find(int a, int b)
        {
            a = getParent(a);
            b = getParent(b);

            if (a == b) Console.Write("YES\n");
            else Console.Write("NO\n");
        }

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            arr = new int[N + 1];

            for (int i = 0; i <= N; i++)
            {
                arr[i] = i;
            }

            for (int i = 0; i < M; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                int oper    = int.Parse(inputs[0]);
                int a       = int.Parse(inputs[1]);
                int b       = int.Parse(inputs[2]);

                if (oper == 1)
                {
                    Find(a, b);
                }
                else
                {
                    Union(a, b);
                }
            }

            Console.ReadKey();
        }
    }
}
