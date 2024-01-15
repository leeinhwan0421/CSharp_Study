using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1715
{
    public class Mycompare : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
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
    // https://www.acmicpc.net/problem/1715
    // 카드 정렬하기

    using Problem1715;

    internal class Problem1715Solver
    {
        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            PriorityQueue<int> m_queue = new PriorityQueue<int>(); 

            int n = int.Parse(sr.ReadLine());

            for (int i = 0; i < n; i++)
            { 
                m_queue.Enqueue(int.Parse(sr.ReadLine()));
            }

            int result = 0;

            while (m_queue.Count != 1)
            {
                int a = m_queue.Dequeue();
                int b = m_queue.Dequeue();

                m_queue.Enqueue(a + b);
                result += a + b;
            }

            Console.Write(result);
            Console.ReadKey();
        }
    }
}
