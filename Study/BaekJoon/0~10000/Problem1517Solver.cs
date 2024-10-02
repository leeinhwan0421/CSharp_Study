using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1517
    // 버블 소트

    internal class Problem1517Solver
    {
        static long cnt = 0;

        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];

            string[] inputs = Console.ReadLine().Split(' ');

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(inputs[i]);
            }

            MergeSortRecursive(a, 0, a.Length - 1);
            Console.Write(cnt);
            Console.ReadKey();
        }

        private static void MergeSortRecursive(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSortRecursive(arr, left, mid);
                MergeSortRecursive(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            for (int i = 0; i < n1; i++)
                leftArray[i] = arr[left + i];
            for (int i = 0; i < n2; i++)
                rightArray[i] = arr[mid + 1 + i];

            int leftIdx = 0;
            int rightIdx = 0;
            int mergedIdx = left;

            while (leftIdx < n1 && rightIdx < n2)
            {
                if (leftArray[leftIdx] <= rightArray[rightIdx])
                {
                    arr[mergedIdx] = leftArray[leftIdx];
                    leftIdx++;
                }
                else
                {
                    arr[mergedIdx] = rightArray[rightIdx];
                    cnt += n1 - leftIdx;
                    rightIdx++;
                }
                mergedIdx++;
            }

            while (leftIdx < n1)
            {
                arr[mergedIdx] = leftArray[leftIdx];
                leftIdx++;
                mergedIdx++;
            }
            while (rightIdx < n2)
            {
                arr[mergedIdx] = rightArray[rightIdx];
                rightIdx++;
                mergedIdx++;
            }
        }
    }
}
