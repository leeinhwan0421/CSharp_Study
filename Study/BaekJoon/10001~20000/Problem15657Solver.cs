using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/15657
    // N과 M (8)

    internal class Problem15657Solver
    {
        static int[] arr = new int[10];
        static int[] num = new int[10];
        static bool[] chk = new bool[10];

        static StringBuilder sb = new StringBuilder();

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int n = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);

            inputs = Console.ReadLine().Split(' ');

            for (int i = 0; i < n; i++)
                num[i] = int.Parse(inputs[i]);

            Array.Sort(num, 0, n);

            BT(0, 0, n, m);

            Console.Write(sb.ToString());

            
        }

        static void BT(int x, int len, int n, int m)
        {
            if (len == m)
            {
                for (int i = 0; i < m; i++)
                {
                    sb.Append($"{arr[i]} ");
                }

                sb.Append("\n");
                return;
            }

            for (int i = x; i < n; i++)
            {
                arr[len] = num[i];
                BT(i, len + 1, n, m);
            }
        }
    }
}
