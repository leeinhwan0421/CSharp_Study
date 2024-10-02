using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/25682
    // 체스판 다시 칠하기 2

    internal class Problem25682Solver
    {
        static public void Solve()
        {
            int rows, cols, kSize, minTotal = 2000001;
            int[,] prefixSum = new int[2001, 2001];

            string[] input = Console.ReadLine().Split();
            rows = int.Parse(input[0]);
            cols = int.Parse(input[1]);
            kSize = int.Parse(input[2]);

            for (int i = 1; i <= rows; i++)
            {
                string line = Console.ReadLine();
                for (int j = 1; j <= cols; j++)
                {
                    char color = line[j - 1];
                    if (((i + j) % 2 == 0 && color != 'B') || ((i + j) % 2 != 0 && color == 'B'))
                        prefixSum[i, j] = 1;
                    prefixSum[i, j] += prefixSum[i - 1, j] + prefixSum[i, j - 1] - prefixSum[i - 1, j - 1];
                }
            }

            for (int i = kSize; i <= rows; i++)
            {
                for (int j = kSize; j <= cols; j++)
                {
                    int countPainting = prefixSum[i, j] - prefixSum[i - kSize, j] - prefixSum[i, j - kSize] + prefixSum[i - kSize, j - kSize];
                    countPainting = Math.Min(kSize * kSize - countPainting, countPainting);
                    minTotal = Math.Min(minTotal, countPainting);
                }
            }

            Console.WriteLine(minTotal);
            
        }
    }
}
