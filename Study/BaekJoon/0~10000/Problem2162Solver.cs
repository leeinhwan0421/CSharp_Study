using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2162
    // 선분 그룹

    internal class Problem2162Solver
    {
        static int[] parent;
        static int[] size;

        static public int Find(int a)
        {
            if (parent[a] == a) return a;
            return parent[a] = Find(parent[a]);
        }

        static public void Union(int a, int b)
        {
            a = Find(a);
            b = Find(b);
        
            if (a != b)
            {
                parent[b] = a;
                size[a] += size[b];
            }
        }

        static int CCW(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            long result = (long)(x2 - x1) * (y3 - y1) - (long)(x3 - x1) * (y2 - y1);
            if (result > 0) return 1;
            if (result < 0) return -1;
            return 0;
        }

        static bool IsIntersect(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            int ccw1 = CCW(x1, y1, x2, y2, x3, y3);
            int ccw2 = CCW(x1, y1, x2, y2, x4, y4);
            int ccw3 = CCW(x3, y3, x4, y4, x1, y1);
            int ccw4 = CCW(x3, y3, x4, y4, x2, y2);

            if (ccw1 * ccw2 <= 0 && ccw3 * ccw4 <= 0)
            {
                if (ccw1 == 0 && ccw2 == 0 && ccw3 == 0 && ccw4 == 0)
                {
                    if (Math.Min(x1, x2) <= Math.Max(x3, x4) && Math.Min(x3, x4) <= Math.Max(x1, x2) &&
                        Math.Min(y1, y2) <= Math.Max(y3, y4) && Math.Min(y3, y4) <= Math.Max(y1, y2))
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
            return false;
        }

        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            int[][] lines = new int[n][];

            parent = new int[n];
            size = new int[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                lines[i] = new int[4];

                for (int j = 0; j < 4; j++)
                {
                    lines[i][j] = int.Parse(input[j]);
                }

                parent[i] = i;
                size[i] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i  + 1; j < n; j++)
                {
                    if (IsIntersect(lines[i][0], lines[i][1], lines[i][2], lines[i][3],
                                    lines[j][0], lines[j][1], lines[j][2], lines[j][3]))
                    {
                        Union(i, j);     
                    }
                }
            }

            int groupCount = 0;
            int maxGroupSize = 0;
            bool[] counted = new bool[n];

            for (int i = 0; i < n; i++)
            {
                int root = Find(i);
                if (!counted[root])
                {
                    groupCount++;
                    maxGroupSize = Math.Max(maxGroupSize, size[root]);
                    counted[root] = true;
                }
            }

            Console.Write($"{groupCount}\n");
            Console.Write($"{maxGroupSize}");
            
        }
    }
}
