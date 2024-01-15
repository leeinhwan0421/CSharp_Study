using System;
using System.Collections.Generic;
using System.Linq;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/18111
    // 마인크래프트

    internal class Problem18111Solver
    {
        static public void Solve()
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int b = int.Parse(input[2]);

            int[,] land = new int[n, m];
            int maxHeight = 0;
            int minHeight = 257; // 0 ~ 256 범위의 높이

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                {
                    land[i, j] = int.Parse(input[j]);
                    maxHeight = Math.Max(maxHeight, land[i, j]);
                    minHeight = Math.Min(minHeight, land[i, j]);
                }
            }

            int minTime = int.MaxValue;
            int maxHeightResult = 0;

            for (int h = minHeight; h <= maxHeight; h++)
            {
                int blocksNeeded = 0;
                int blocksRemoved = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        int diff = land[i, j] - h;

                        if (diff < 0)
                        {
                            blocksNeeded -= diff;
                        }
                        else
                        {
                            blocksRemoved += diff;
                        }
                    }
                }

                int inventory = blocksRemoved + b;

                if (inventory >= blocksNeeded)
                {
                    int time = 2 * blocksRemoved + blocksNeeded;

                    if (time < minTime)
                    {
                        minTime = time;
                        maxHeightResult = h;
                    }
                    else if (time == minTime && maxHeightResult < h)
                    {
                        maxHeightResult = h;
                    }
                }
            }

            Console.Write($"{minTime} {maxHeightResult}");
            Console.ReadKey();
        }
    }
}
