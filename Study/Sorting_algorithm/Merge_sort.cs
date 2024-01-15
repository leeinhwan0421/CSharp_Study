using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Sorting_algorithm
{
    /*
     * 
     *  [병합 정렬]
     *  분할 정복 방식을 사용해 데이터를 분할하고 분할한 집합을 정렬하며 합치는 알고리즘
     *  시간 복잡도 O(nlogn)
     * 
     *  [정렬 과정]
     *  1. 주어진 배열을 반으로 나눕니다. 이것을 재귀적으로 수행합니다. 즉, 배열을 더 이상 나눌 수 없을 때까지 계속 반으로 나눕니다.
     *     나누는 과정에서 중간 지점(midpoint)을 찾아 배열을 두 개로 분할합니다.
     *  2. 분할된 각 부분 배열을 정렬합니다. 이것도 재귀적으로 수행됩니다. 배열의 크기가 1 또는 0이 될 때까지 정렬 작업을 수행합니다. 
     *     이 때, 정렬 알고리즘은 재귀적으로 Merge Sort를 호출하여 부분 배열을 정렬합니다.
     *  3. 정렬된 부분 배열을 병합합니다. 이때 두 개의 정렬된 배열을 하나로 합치는데, 합칠 때 정렬 순서를 유지하면서 합칩니다. 
     *     즉, 두 배열의 원소를 비교하여 작은 순서대로 합치는 것이 핵심입니다.
     *  4. 배열의 크기가 1이거나 0이 될 때까지 위의 단계를 재귀적으로 수행합니다. 
     *     이후 모든 부분 배열이 정렬되고 병합되면 최종 정렬된 배열이 반환됩니다.
     *  
     */


    internal class Merge_sort
    {
        static public void Sort()
        {
            int[] arr = { 1, 3, 2, 5, 9, 7, 8, 6, 4 };

            Console.WriteLine("정렬 이전 값");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();

            MergeSortRecursive(arr, 0, arr.Length - 1);

            Console.WriteLine("정렬 이후 값");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();

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
