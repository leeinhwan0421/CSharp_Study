using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/17404
    // RGB거리 2

    internal class Problem17404Solver
    {
        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int n = int.Parse(sr.ReadLine());
            int INF = 1000 * 1000 + 1;

            int[,] A = new int[n + 1, 3];
            for (int i = 1; i <= n; i++)
            {
                string[] inputs = sr.ReadLine().Split(' ');
                for (int j = 0; j < 3; j++)
                {
                    A[i, j] = int.Parse(inputs[j]);
                }
            }

            int result = INF;

            for (int firstColor = 0; firstColor < 3; firstColor++)
            {
                int[,] D = new int[n + 1, 3];

                for (int j = 0; j < 3; j++)
                {
                    if (j == firstColor)
                        D[1, j] = A[1, j];
                    else
                        D[1, j] = INF;
                }

                for (int i = 2; i <= n; i++)
                {
                    D[i, 0] = Math.Min(D[i - 1, 1], D[i - 1, 2]) + A[i, 0];
                    D[i, 1] = Math.Min(D[i - 1, 0], D[i - 1, 2]) + A[i, 1];
                    D[i, 2] = Math.Min(D[i - 1, 0], D[i - 1, 1]) + A[i, 2];
                }

                for (int lastColor = 0; lastColor < 3; lastColor++)
                {
                    if (lastColor != firstColor)
                    {
                        result = Math.Min(result, D[n, lastColor]);
                    }
                }
            }

            sw.WriteLine(result);
            sw.Flush();

            sr.Close();
            sw.Close();

            Console.ReadKey();
        }
    }
}
