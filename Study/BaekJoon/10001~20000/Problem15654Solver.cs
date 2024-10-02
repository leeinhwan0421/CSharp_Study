using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/15654
    // N과 M (5)

    internal class Problem15654Solver
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

            BT(0, n, m);

            Console.Write(sb.ToString());

            
        }

        static void BT(int len, int n, int m)
        {
            if (len == m)
            {
                for (int i = 0; i < m; i++)
                {
                    sb.Append($"{arr[i]} ");
                }

                sb.Append("\n");
            }

            for (int i = 0; i < n; i++)
            {
                if (chk[i] == false)
                {
                    arr[len] = num[i];
                    chk[i] = true;
                    BT(len + 1, n, m);
                    chk[i] = false;
                }
            }
        }
    }
}
