using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Sorting_algorithm
{
    /*
     * 
     *  [선택 정렬]
     *  대상에서 가장 크거나 작은 데이터를 찾아가 선택을 반복하면서 정렬하는 방식
     *  시간 복잡도 O(n^2)
     * 
     *  [정렬 과정]
     *  1. 남은 정렬 부분에서 최소, 최대 값을 찾는다.
     *  2. 남은 정렬 부분에서 가장 앞에 있는 데이터와 선택된 데이터를 swap 한다.
     *  3. 가장 앞에 있는 데이터의 위치를 변경해(index++) 남은 정렬 부분을 축소한다.
     *  4. 전체 데이터 크기만큼 index가 커질 때 까지 반복합니다.
     *  
     */


    internal class Selection_sort
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

            Selection(arr);

            Console.WriteLine("정렬 이후 값");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }

        static private void Selection(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                if (arr[i] > arr[min])
                {
                    int tmp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = tmp;
                }
            }
        }
    }
}
