using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Sorting_algorithm
{
    internal class Merge_sort
    {
        static public void Sort()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            MergeSortRecursive(arr, 0, arr.Length - 1);

            foreach (int it in arr)
            {
                Console.WriteLine(it);
            }

            Console.ReadLine();
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
