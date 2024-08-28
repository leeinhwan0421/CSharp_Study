using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Sorting_algorithm
{
    /*
     * 
     *  [기수 정렬]
     *  대상에서 가장 크거나 작은 데이터를 찾아가 선택을 반복하면서 정렬하는 방식
     *  시간 복잡도 O(Kn)
     *  k = 데이터의 자릿수
     * 
     *  [설명]
     *  위 코드에서는 기수 정렬 대신 계수 정렬이라는 방식을 사용했습니다.
     *  계수 정렬 방식은 기수 정렬보다 훨씬 간단한 로직을 가지고 있어 많이 사용됩니다.
     */


    internal class Radix_sort
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

            Console.WriteLine("정렬 이후 값");
            Radix(arr);

            Console.WriteLine();
            Console.ReadKey();
        }

        static private void Radix(int[] arr)
        {
            int[] count = new int[arr.Max() + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i]]++;
            }

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] != 0)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
