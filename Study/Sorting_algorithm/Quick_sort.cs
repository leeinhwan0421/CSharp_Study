using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Sorting_algorithm
{
    /*
     * 
     *  [퀵 정렬]
     *  기준 값(pivot)을 선정하여 해당 값보다 작은 데이터와 큰 데이터로 분류하는 것을 반복해 정렬하는 알고리즘
     *  시간 복잡도 O(nlogn) ~ O(n^2)
     * 
     *  [정렬 과정]
     *  1. 데이터를 분할하는 pivot을 설정한다. (오른쪽 끝이나, 왼쪽 끝이나..)
     *  2. pivot을 기준으로 다음 A~E 과정을 거쳐 데이터를 2개의 집합으로 분리한다.
     *      A. start가 가리키는 데이터가 pivot이 가리키는 데이터보다 작으면 start를 오른쪽으로 한 칸 이동한다.
     *      B. end가 가리키는 데이터가 pivot이 가리키는 데이터보다 크면 end를 왼쪽으로 한 칸 이동한다.
     *      C. start가 가리키는 데이터가 pivot이 가리키는 데이터보다 크고, end가 가리키는 데이터가 pivot이 가리키는 데이터보다 작으면
     *         start, end가 가리키는 데이터를 swap 하고, start는 오른쪽, end는 왼쪽으로 한 칸씩 이동합니다.
     *      D. start와 end가 만날 때 까지 (A)~(C)를 반복합니다.
     *      E. start와 end가 만나면, 만난 지점에서 가리키는 데이터와 pivot이 가리키는 데이터를 비교하여 pivot이 가리키는 데이터가 크면
     *         만난 지점의 오른쪽에, 작으면 만난 지점의 왼쪽에 pivot이 가리키는 데이터를 삽입한다.
     *  3. 분리 집합에서 각각 다시 pivot을 선정한다.
     *  4. 분리 집합이 1개 이하가 될 때 까지 과정 (1)~(3)을 반복합니다.
     *  
     */


    internal class Quick_sort
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

            QuickSortRecursive(arr, 0, arr.Length - 1);

            Console.WriteLine("정렬 이후 값");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }

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

            for (int j = low; j <= high - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);
            return i + 1;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
