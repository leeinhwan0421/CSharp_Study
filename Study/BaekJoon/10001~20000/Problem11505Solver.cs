using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11505
    // 구간 곱 구하기

    internal class Problem11505Solver
    {
        static List<long> tree = new List<long>();
        static int N;
        static int leftNodeStartIndex;
        static int MOD = 1000000007;

        static public long getTimes(int s, int e)
        {
            long partTimes = 1;

            while (s <= e)
            {
                if (s % 2 == 1)
                {
                    partTimes = (partTimes * tree[s]) % MOD;
                    s++;
                }
                if (e % 2 == 0)
                {
                    partTimes = (partTimes * tree[e]) % MOD;
                    e--;
                }

                s = s / 2;
                e = e / 2;
            }

            return partTimes % MOD;
        }

        static public void ChangeValue(int index, long val)
        {
            tree[index] = val % MOD;

            while (index > 1)
            {
                index /= 2;
                tree[index] = tree[index * 2] % MOD * tree[index * 2 + 1] % MOD;
            }
        }

        static public void SetTree()
        {
            for (int i = leftNodeStartIndex - 1; i > 0; i--)
            {
                tree[i] = tree[2 * i] * tree[2 * i + 1] % MOD;
            }
        }

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');
            N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);
            int K = int.Parse(inputs[2]);

            int treeHeight = (int)Math.Ceiling(Math.Log(N) / Math.Log(2));
            int treeSize = (int)Math.Pow(2, treeHeight + 1);
            leftNodeStartIndex = treeSize / 2;

            for (int i = 0; i < treeSize; i++)
            {
                tree.Add(1);
            }

            for (int i = leftNodeStartIndex; i < leftNodeStartIndex + N; i++)
            {
                tree[i] = long.Parse(Console.ReadLine());
            }

            SetTree();

            for (int i = 0; i < M + K; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                long a = long.Parse(inputs[0]);
                long s = long.Parse(inputs[1]);
                long e = long.Parse(inputs[2]);

                if (a == 1)
                {
                    ChangeValue((int)(leftNodeStartIndex + s - 1), e);
                }
                else
                {
                    s = s + leftNodeStartIndex - 1;
                    e = e + leftNodeStartIndex - 1;
                    Console.WriteLine(getTimes((int)s, (int)e));
                }
            }

            Console.ReadKey();
        }
    }
}
