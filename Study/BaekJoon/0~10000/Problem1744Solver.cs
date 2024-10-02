using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1744
{
    public class Asc : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }

    public class Desc : IComparer<int>
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
    // https://www.acmicpc.net/problem/1744
    // 수 묶기

    using Problem1744;

    internal class Problem1744Solver
    {
        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            int n = int.Parse(sr.ReadLine());

            PriorityQueue<int> positive = new PriorityQueue<int>(new Desc());
            PriorityQueue<int> negative = new PriorityQueue<int>(new Asc());
            int _0 = 0;
            int _1 = 0;

            for (int i = 0; i < n; i++)
            {
                int k = int.Parse(sr.ReadLine());

                if (k > 1)
                    positive.Enqueue(k);
                else if (k < 0)
                    negative.Enqueue(k);
                else if (k == 0)
                    _0++;
                else if (k == 1)
                    _1++;
            }

            int result = 0;

            while (positive.Count > 1) 
            {
                int a = positive.Dequeue();
                int b = positive.Dequeue();

                result += a * b;
            }

            if (positive.Count != 0)
            {
                result += positive.Dequeue();
            }

            while (negative.Count > 1)
            {
                int a = negative.Dequeue();
                int b = negative.Dequeue();

                result += a * b;
            }

            if (negative.Count != 0)
            {
                if (_0 == 0)
                    result += negative.Dequeue();
            }

            result += _1;

            Console.Write(result);
            
        }
    }
}
