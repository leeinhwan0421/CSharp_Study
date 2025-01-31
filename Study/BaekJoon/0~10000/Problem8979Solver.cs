using System;
using System.Collections.Generic;
using System.Linq;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/8979
    // 올림픽
    internal class Problem8979Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split();
            int N = int.Parse(inputs[0]);
            int K = int.Parse(inputs[1]);

            List<(int country, int gold, int silver, int bronze)> countries = new List<(int, int, int, int)>();

            for (int i = 0; i < N; i++)
            {
                inputs = Console.ReadLine().Split();
                int country = int.Parse(inputs[0]);
                int gold = int.Parse(inputs[1]);
                int silver = int.Parse(inputs[2]);
                int bronze = int.Parse(inputs[3]);

                countries.Add((country, gold, silver, bronze));
            }

            countries.Sort((a, b) =>
            {
                if (a.gold != b.gold) return b.gold.CompareTo(a.gold);
                if (a.silver != b.silver) return b.silver.CompareTo(a.silver);
                return b.bronze.CompareTo(a.bronze);
            });

            Dictionary<int, int> rankMap = new Dictionary<int, int>();
            int rank = 1;

            for (int i = 0; i < N; i++)
            {
                if (i > 0 &&
                    countries[i].gold == countries[i - 1].gold &&
                    countries[i].silver == countries[i - 1].silver &&
                    countries[i].bronze == countries[i - 1].bronze)
                {
                    rankMap[countries[i].country] = rankMap[countries[i - 1].country];
                }
                else
                {
                    rankMap[countries[i].country] = rank;
                }
                rank++;
            }

            Console.WriteLine(rankMap[K]);
        }
    }
}
