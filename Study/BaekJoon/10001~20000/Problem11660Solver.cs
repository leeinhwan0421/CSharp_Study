using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11660
    // 구간 합 구하기 5

    internal class Problem11660Solver
    {
        static StringBuilder sb = new StringBuilder();

        static public void Solve()
        {
            string input = Console.ReadLine();

            int n = int.Parse(input.Split(' ')[0]);
            int m = int.Parse(input.Split(' ')[1]);

            int[,] arr = new int[n + 1, n + 1];
            int[,] arr_D = new int[n + 1, n + 1];

            for (int i = 1; i <= n; i++)
            {
                String[] str = Console.ReadLine().Split(' ');

                for (int j = 1; j <= n; j++)
                {
                    arr[i, j] = int.Parse(str[j - 1]);
                    arr_D[i, j] = arr_D[i, j - 1] + arr_D[i - 1, j] - arr_D[i - 1, j - 1] + arr[i, j]; 
                }
            }

            for (int i = 0; i < m; i++)
            {
                int x1, y1, x2, y2;
                string[] str = Console.ReadLine().Split(' ');

                x1 = int.Parse(str[0]);
                y1 = int.Parse(str[1]);
                x2 = int.Parse(str[2]);
                y2 = int.Parse(str[3]);

                int result = arr_D[x2, y2] - arr_D[x1 - 1, y2] - arr_D[x2, y1 - 1] + arr_D[x1 - 1, y1 - 1];

                sb.AppendLine(result.ToString());
            }

            Console.Write(sb.ToString());
            Console.ReadLine();
        }
    }
}
