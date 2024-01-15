using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem11279
{
    public class Mycompare : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }

    public class PriorityQueue<T>
    {
        private readonly List<T> list;
        private readonly IComparer<T> comparer;

        public PriorityQueue(IComparer<T> comparer = null)
        {
            this.list = new List<T>();
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public void Enqueue(T item)
        {
            list.Add(item);
            int childIndex = list.Count - 1;

            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;
                if (comparer.Compare(list[childIndex], list[parentIndex]) >= 0) break;

                var tmp = list[childIndex];
                list[childIndex] = list[parentIndex];
                list[parentIndex] = tmp;
                childIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            int lastIndex = list.Count - 1;
            var frontItem = list[0];
            list[0] = list[lastIndex];
            list.RemoveAt(lastIndex--);

            int parentIndex = 0;

            while (true)
            {
                int leftChild = parentIndex * 2 + 1;
                if (leftChild > lastIndex) break;

                int rightChild = leftChild + 1;
                int childIndex = (rightChild <= lastIndex && comparer.Compare(list[rightChild], list[leftChild]) < 0)
                                 ? rightChild : leftChild;

                if (comparer.Compare(list[parentIndex], list[childIndex]) <= 0) break;

                var tmp = list[childIndex];
                list[childIndex] = list[parentIndex];
                list[parentIndex] = tmp;
                parentIndex = childIndex;
            }

            return frontItem;
        }

        public int Count => list.Count;
    }
}

namespace Study.BaekJoon
{
    using Problem11279;

    // https://www.acmicpc.net/problem/11279
    // 최대 힙

    internal class Problem11279Solver
    {
        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            var comparer = new Mycompare();
            PriorityQueue<int> pq = new PriorityQueue<int>(comparer);

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int rq = int.Parse(sr.ReadLine());

                if (rq == 0)
                {
                    if (pq.Count > 0)
                    {
                        sb.AppendLine(pq.Dequeue().ToString());
                    }
                    else
                    {
                        sb.AppendLine("0");
                    }
                }
                else
                {
                    pq.Enqueue(rq);
                }
            }

            sw.Write(sb.ToString());
            sw.Flush();
            sr.ReadLine();
        }
    }
}
