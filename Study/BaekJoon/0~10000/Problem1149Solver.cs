using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1149
    // RGB거리

    internal class Problem1149Solver
    {
        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int n = int.Parse(sr.ReadLine());

            int[,] D = new int[n + 1, 3];
            int[,] A = new int[n + 1, 3];

            for (int i = 1; i <= n; i++)
            {
                string[] inputs = sr.ReadLine().Split(' ');

                for (int j = 0; j < 3; j++)
                {
                    A[i, j] = int.Parse(inputs[j]);
                }
            }

            D[0, 0] = D[0, 1] = D[0, 2] = A[0, 0] = A[0, 1] = A[0, 2];
            
            for (int i = 1; i <= n; i++)
            {
                D[i, 0] = Math.Min(D[i - 1, 1], D[i - 1, 2]) + A[i, 0];
                D[i, 1] = Math.Min(D[i - 1, 0], D[i - 1, 2]) + A[i, 1];
                D[i, 2] = Math.Min(D[i - 1, 0], D[i - 1, 1]) + A[i, 2];
            }

            sw.Write(Math.Min(Math.Min(D[n, 0], D[n, 1]), D[n, 2]));
            sw.Flush();

            sr.ReadLine();

            sr.Close();
            sw.Close();
        }
    }
}
