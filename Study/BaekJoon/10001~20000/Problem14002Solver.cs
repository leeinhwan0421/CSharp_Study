using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/14002
    // 가장 긴 증가하는 부분 수열 4

    // https://www.acmicpc.net/problem/14003
    // 가장 긴 증가하는 부분 수열 5

    internal class Problem14002Solver
    {
        static int[] lis;
        static int[] arr;
        static int[] parent;

        static public int BinarySearch(int left, int right, int target)
        {
            int mid;
            while (left < right)
            {
                mid = (left + right) / 2;
                if (lis[mid] < target)
                    left = mid + 1;
                else
                    right = mid;
            }
            return right;
        }

        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());

            arr = new int[n];
            lis = new int[n];
            parent = new int[n];

            string[] inputs = Console.ReadLine().Split(' ');
            for (int k = 0; k < n; k++)
            {
                arr[k] = int.Parse(inputs[k]);
            }

            int len = 0;
            for (int i = 0; i < n; i++)
            {
                int pos = BinarySearch(0, len, arr[i]);
                lis[pos] = arr[i];
                parent[i] = pos;
                if (pos == len) len++;
            }

            Console.WriteLine(len);

            int[] sequence = new int[len];
            for (int i = n - 1, j = len - 1; j >= 0; i--)
            {
                if (parent[i] == j)
                {
                    sequence[j] = arr[i];
                    j--;
                }
            }

            Console.WriteLine(string.Join(" ", sequence));
            Console.ReadKey();
        }
    }
}
