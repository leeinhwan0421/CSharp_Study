using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2098
    // 외판 원 순회

    internal class Problem2098Solver
    {
        static int INF = 1000000000;
        static int N;
        static int[,] cost = new int[16, 16];
        static int[,] DP = new int[1 << 16, 16];

        static public int TSP(int visited, int current)
        {
            if (visited == (1 << N) - 1)
            {
                return cost[current, 0] == 0 ? INF : cost[current, 0];
            }

            if (DP[visited, current] != -1)
            {
                return DP[visited, current];
            }

            int minCost = INF;

            for (int next = 0; next < N; next++)
            {
                if ((visited & (1 << next)) != 0) continue;

                if (cost[current, next] == 0) continue;

                int newVisited = visited | (1 << next);
                int nextCost = TSP(newVisited, next) + cost[current, next];

                minCost = Math.Min(minCost, nextCost);
            }

            DP[visited, current] = minCost;
            return minCost;
        }

        static public void Solve()
        {
            N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');

                for (int j = 0; j < N; j++)
                {
                    cost[i, j] = int.Parse(inputs[j]);
                }
            }

            for (int i = 0; i < (1 << N); i++)
            {
                for (int j = 0; j < N; j++)
                {
                    DP[i, j] = -1;
                }
            }

            Console.Write(TSP(1, 0));
            Console.ReadKey();
        }
    }
}
