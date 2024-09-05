using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1414
    // 불우이웃돕기

    internal class Problem1414Solver
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
                return this.v != other.v ? this.v.CompareTo(other.v) :
                       this.s != other.s ? this.s.CompareTo(other.s) :
                       this.e.CompareTo(other.e);
            }
        }

        static public void Union(int a, int b)
        {
            a = Find(a);
            b = Find(b);
            if (a != b) parent[b] = a;
        }

        static public int Find(int a)
        {
            if (a == parent[a]) return a;
            return parent[a] = Find(parent[a]);
        }

        static SortedSet<Edge> pq = new SortedSet<Edge>();
        static List<int> parent = new List<int>();

        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < N; i++)
            {
                char[] arr = Console.ReadLine().ToCharArray();

                for (int j = 0; j < N; j++)
                {
                    char tempc = arr[j];
                    int temp = 0;

                    if (tempc >= 'a' && tempc <= 'z')
                    {
                        temp = tempc - 'a' + 1;
                    }
                    else if (tempc >= 'A' && tempc <= 'Z')
                    {
                        temp = tempc - 'A' + 27;
                    }

                    sum += temp;

                    if (i != j && temp != 0)
                    {
                        pq.Add(new Edge(i, j, temp));
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                parent.Add(i);
            }

            int useEdge = 0;
            int result = 0;

            while (pq.Count != 0)
            {
                var now = pq.First();
                pq.Remove(now);

                if (Find(now.s) != Find(now.e))
                {
                    Union(now.s, now.e);
                    result += now.v;
                    useEdge++;
                }
            }

            if (useEdge == N - 1)
            {
                Console.Write(sum - result);
            }
            else
            {
                Console.Write("-1");
            }

            Console.ReadKey();
        }
    }
}
