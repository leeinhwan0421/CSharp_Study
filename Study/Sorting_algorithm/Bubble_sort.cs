using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Sorting_algorithm
{
    /*
     * 
     *  [버블 정렬]
     *  데이터의 인접 요소끼리 비교하고, swap 연산을 수행하여 정렬하는 방식
     *  시간 복잡도 O(n^2)
     * 
     *  [정렬 과정]
     *  1. 비교 연산이 필요한 루프 범위 지정
     *  2. 인접한 데이터 값 비교
     *  3. swap 조건에 부합하면 swap 연산 실행
     *  4. 루프 범위가 끝날 때 까지, (2)~(3) 번을 반복합니다.
     *  5. 정렬된 영역을 설정합니다. 다음 루프를 실행할 때에는 이 영역을 제외합니다.
     *  6. 비교 대상이 없어질 때까지 (1)~(5) 번을 반복합니다.
     *  
     */


    internal class Bubble_sort
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

            Bubble(arr);

            Console.WriteLine("정렬 이후 값");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }

        static private void Bubble(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
            }
        }
    }
}
