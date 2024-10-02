using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1197
    // 최소 스패닝 트리

    internal class Problem1197Solver
    {
        struct Edge : IComparable<Edge>
        {
            public Edge(int s, int e, int v)
            {
                this.s = s;
                this.e = e;
                this.v = v;
            }

            public int s;
            public int e;
            public int v;

            public int CompareTo(Edge other)
            {
                if (this.v == other.v)
                {
                    if (this.s == other.s)
                    {
                        return this.e.CompareTo(other.e);
                    }
                    return this.s.CompareTo(other.s);
                }
                return this.v.CompareTo(other.v);
            }
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

            return parent[a] = Find(parent[a]);
        }

        static public int[] parent = new int[0];
        static string[] inputs;

        static public void Solve()
        {
            inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            SortedSet<Edge> edges = new SortedSet<Edge>();
            parent = new int[N + 1];

            for (int i = 0; i <= N; i++) { parent[i] = i; }

            for (int i = 0; i < M; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                int s = int.Parse(inputs[0]);
                int e = int.Parse(inputs[1]);
                int v = int.Parse(inputs[2]);

                edges.Add(new Edge(s, e, v));
            }

            int useEdge = 0;
            int result = 0;

            while (useEdge < N - 1)
            {
                Edge now = edges.First();
                edges.Remove(now);

                if (Find(now.s) != Find(now.e))
                {
                    Union(now.s, now.e);
                    result = result + now.v;
                    useEdge++;
                }
            }

            Console.Write(result);
            
        }
    }
}
