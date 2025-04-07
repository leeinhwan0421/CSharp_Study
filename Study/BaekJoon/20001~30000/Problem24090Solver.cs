using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/24090
    // 알고리즘 수업 - 퀵 정렬 1

    class Problem24090Solver
    {
        private static int cnt = 0;
        private static int K = 0;

        private static void QuickSortRecursive(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(arr, low, high);
                QuickSortRecursive(arr, low, pivotIndex - 1);
                QuickSortRecursive(arr, pivotIndex + 1, high);
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot) 
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            if (i + 1 != high)
                Swap(arr, i + 1, high);

            return i + 1;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            cnt++;

            if (cnt == K)
            {
                int a = arr[i];
                int b = arr[j];
                Console.WriteLine($"{Math.Min(a, b)} {Math.Max(a, b)}");
                Environment.Exit(0);
            }

            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int N = int.Parse(inputs[0]);
            K = int.Parse(inputs[1]);

            int[] arr = new int[N];
            inputs = Console.ReadLine().Split(' ');

            for (int i = 0; i < N; i++)
            {
                arr[i] = int.Parse(inputs[i]);
            }

            QuickSortRecursive(arr, 0, N - 1);

            if (cnt < K)
                Console.WriteLine("-1");
        }
    }
}
