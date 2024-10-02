using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Numerics;
using System.Linq;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/23046
    // 큰 수 뒤집기 

    class Problem23046Solver
    {
        private class DQ
        {
            public int[] arr;
            public int s, e;
            public int updateCnt;

            public DQ(int n, int first)
            {
                arr = new int[n * 2 + 1];
                s = e = n;
                arr[s] = first;
                updateCnt = 1;
            }

            public void AddFirst(int n)
            {
                arr[--s] = n;
                updateCnt++;
            }

            public void AddLast(int n)
            {
                arr[++e] = n;
                updateCnt++;
            }

            public void SetUpdateCntZero()
            {
                updateCnt = 0;
            }

            public bool NeedUpdate()
            {
                return updateCnt != 0;
            }
        }

        private static int[] x;
        private static DQ s;
        private static bool isReverse = false;

        private static void AddToX()
        {
            if (!s.NeedUpdate()) return;

            int updateCnt = s.updateCnt;
            s.SetUpdateCntZero();

            int len = s.e - s.s + 1;
            int[] tmp = new int[len];
            int[] tmp2 = new int[len];

            if (isReverse)
            {
                for (int i = s.s, tmpIdx1 = tmp.Length - 1; i <= s.e; i++, tmpIdx1--)
                {
                    tmp[tmpIdx1] = s.arr[i];
                    tmp2[tmpIdx1] = s.arr[i];
                }
            }
            else
            {
                for (int i = s.e, tmpIdx2 = tmp.Length - 1; i >= s.s; i--, tmpIdx2--)
                {
                    tmp[tmpIdx2] = s.arr[i];
                    tmp2[tmpIdx2] = s.arr[i];
                }
            }

            for (int i = 1; i < tmp.Length; i++)
            {
                tmp[i] += tmp2[i - 1];
                tmp2[i] += tmp2[i - 1];
                if (i - updateCnt >= 0)
                    tmp[i] -= tmp2[i - updateCnt];
            }

            int idx = x.Length - 1;
            int tmpIdx = tmp.Length - 1;
            while (len-- > 0)
            {
                x[idx--] += tmp[tmpIdx--];
            }
        }

        public static void Solve()
        {
            using (StreamReader sr = new StreamReader(Console.OpenStandardInput()))
            {
                string input = sr.ReadLine();

                x = new int[input.Length + 2];
                s = new DQ(input.Length, input[0] - '0');

                int cnt = 0;
                for (int i = 1; i < input.Length; i++)
                {
                    char c = input[i];
                    if (c == '-')
                    {
                        AddToX();
                        isReverse = !isReverse;
                        continue;
                    }

                    cnt++;
                    if (!isReverse) s.AddLast(c - '0');
                    else s.AddFirst(c - '0');
                }
                AddToX();

                for (int i = x.Length - 1; i > input.Length + 1 - cnt; i--)
                {
                    if (x[i] >= 10)
                    {
                        x[i - 1] += x[i] / 10;
                        x[i] %= 10;
                    }
                }

                StringBuilder sb = new StringBuilder();
                int startIdx = input.Length + 1 - cnt;
                for (int i = startIdx; i < x.Length; i++)
                {
                    if (x[i] != 0) break;
                    startIdx++;
                }
                for (int i = startIdx; i < x.Length; i++)
                {
                    sb.Append(x[i]);
                }

                Console.WriteLine(sb.ToString());
                
            }
        }
    }
}
