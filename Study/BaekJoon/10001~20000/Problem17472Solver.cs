using System;
using System.Collections.Generic;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/17472
    // 다리 만들기 2

    internal class Problem17472Solver
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

        static int[] dirRow = { -1, 0, 1, 0 };
        static int[] dirCol = { 0, 1, 0, -1 };
        static int[,] map = new int[101, 101];
        static bool[,] visited = new bool[101, 101];
        static List<int> parent = new List<int>();
        static string[] inputs;
        static int N, M, sNum;
        static List<List<(int, int)>> sumList = new List<List<(int, int)>>();
        static SortedSet<Edge> pq = new SortedSet<Edge>();

        static public void Solve()
        {
            inputs = Console.ReadLine().Split(' ');
            N = int.Parse(inputs[0]);
            M = int.Parse(inputs[1]);

            for (int i = 0; i < N; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                for (int j = 0; j < M; j++)
                    map[i, j] = int.Parse(inputs[j]);
            }

            sNum = 1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (map[i, j] != 0 && !visited[i, j])
                    {
                        var mList = new List<(int, int)>();
                        BFS(i, j, mList);
                        sumList.Add(mList);
                        sNum++;
                    }
                }
            }

            foreach (var now in sumList)
            {
                foreach (var (r, c) in now)
                {
                    int nowS = map[r, c];

                    for (int dir = 0; dir < 4; dir++)
                    {
                        int nr = r, nc = c, blength = 0;
                        while (true)
                        {
                            nr += dirRow[dir];
                            nc += dirCol[dir];

                            if (nr < 0 || nr >= N || nc < 0 || nc >= M) break;
                            if (map[nr, nc] == nowS) break;
                            if (map[nr, nc] != 0)
                            {
                                if (blength > 1)
                                    pq.Add(new Edge(nowS, map[nr, nc], blength));
                                break;
                            }
                            blength++;
                        }
                    }
                }
            }

            parent.Clear();
            for (int i = 0; i < sNum; i++) parent.Add(i);

            int useEdge = 0, result = 0;
            while (pq.Count != 0)
            {
                var now = pq.Min;
                pq.Remove(now);

                if (Find(now.s) != Find(now.e))
                {
                    Union(now.s, now.e);
                    result += now.v;
                    useEdge++;
                }
            }

            Console.WriteLine(useEdge == sNum - 2 ? result.ToString() : "-1");

            Console.ReadKey();
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

        static public void BFS(int x, int y, List<(int, int)> mList)
        {
            Queue<(int, int)> q = new Queue<(int, int)>();
            map[x, y] = sNum;
            visited[x, y] = true;
            q.Enqueue((x, y));
            mList.Add((x, y));

            while (q.Count != 0)
            {
                var (r, c) = q.Dequeue();

                for (int dir = 0; dir < 4; dir++)
                {
                    int nr = r + dirRow[dir], nc = c + dirCol[dir];

                    if (nr >= 0 && nr < N && nc >= 0 && nc < M && !visited[nr, nc] && map[nr, nc] != 0)
                    {
                        map[nr, nc] = sNum;
                        visited[nr, nc] = true;
                        mList.Add((nr, nc));
                        q.Enqueue((nr, nc));
                    }
                }
            }
        }
    }
}
