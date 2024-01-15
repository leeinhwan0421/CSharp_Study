using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1976
    // 여행 가자

    internal class Problem1976Solver
    {
        static int[] parent;

        static public void Solve()
        {
            string[] inputs;
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int[,] city = new int[201, 201];

            for (int i = 1; i <= n; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                for (int j = 1; j <= n; j++)
                {
                    city[i, j] = int.Parse(inputs[j - 1]);
                }
            }

            int[] route = new int[1001];
            inputs = Console.ReadLine().Split(' ');

            for (int i = 1; i <= m; i++)
            {
                route[i] = int.Parse(inputs[i - 1]);
            }

            parent = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                parent[i] = i;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (city[i, j] == 1)
                    {
                        Union(i, j);
                    }
                }
            }

            int index = Find(route[1]);
            bool connect = true;

            for (int i = 2; i <= m; i++)
            {
                if (index != Find(route[i]))
                {
                    Console.Write("NO");
                    connect = false;

                    break;
                }
            }

            if (connect)
            {
                Console.Write("YES");
            }

            Console.ReadKey();
        }

        static public void Union(int a, int b)
        {
            a = Find(a);
            b = Find(b);

            if (a != b)
            {
                parent[b] = a;
            }
        }

        static public int Find(int a)
        {
            if (a == parent[a])
                return a;
            else
                return parent[a] = Find(parent[a]);
        }
    }
}
