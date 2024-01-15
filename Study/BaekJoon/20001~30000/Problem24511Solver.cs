using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/24511
    // queuestack

    class Problem24511Solver
    {
        static Deque<int> dq = new Deque<int>();
        static bool[] flag = new bool[100001];

        static public void Solve()
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            {
                int n = int.Parse(reader.ReadLine());

                string[] flagInputs = reader.ReadLine().Split();
                for (int i = 0; i < n; i++)
                {
                    flag[i] = flagInputs[i] == "1";
                }

                string[] xInputs = reader.ReadLine().Split();
                for (int i = 0; i < n; i++)
                {
                    int x = int.Parse(xInputs[i]);
                    if (!flag[i])
                    {
                        dq.PushBack(x);
                    }
                }

                int m = int.Parse(reader.ReadLine());
                string[] yInputs = reader.ReadLine().Split();
                for (int i = 0; i < m; i++)
                {
                    int y = int.Parse(yInputs[i]);
                    dq.PushFront(y);
                    sb.Append(dq.PopBack() + " ");
                }
            }

            Console.Write(sb.ToString());
        }
    }

    public class Deque<T>
    {
        LinkedList<T> list = new LinkedList<T>();

        public void PushFront(T item)
        {
            list.AddFirst(item);
        }

        public T PopFront()
        {
            T value = list.First.Value;
            list.RemoveFirst();
            return value;
        }

        public void PushBack(T item)
        {
            list.AddLast(item);
        }

        public T PopBack()
        {
            T value = list.Last.Value;
            list.RemoveLast();
            return value;
        }
    }
}
