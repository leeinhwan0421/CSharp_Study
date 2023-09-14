using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Sorting_algorithm
{
    /*
     * 
     *  [삽입 정렬]
     *  이미 정렬된 데이터 범위에 정렬되지 않은 데이터를 적절한 위치에 삽입하여 정렬하는 방식
     *  시간 복잡도 O(n^2)
     * 
     *  [정렬 과정]
     *  1. 현재 index에 있는 데이터 값을 선택한다.
     *  2. 현재 선택한 데이터가 정렬된 데이터 범위에 삽입될 위치를 탐색한다.
     *  3. 삽입 위치부터 index에 있는 위치까지 shift 연산을 수행한다.
     *  4. 삽입 위치에 현재 선택한 데이터를 삽입하고 index++ 연산을 수행한다.
     *  5. 전체 데이터의 크기만큼 index가 커질 때까지, 즉 선택한 데이터가 없을 때까지 반복한다. 
     *  
     */


    internal class Insertion_sort
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

            Insertion(arr);

            Console.WriteLine("정렬 이후 값");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }

        static private void Insertion(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int insert_point = i;
                int insert_val = arr[insert_point];

                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[j] < arr[i])
                    {
                        insert_point = j + 1;
                        break;
                    }
                    if (j == 0)
                    {
                        insert_point = 0;
                    }
                }

                for (int j = i; j > insert_point; j--)
                {
                    arr[j] = arr[j - 1];
                }

                arr[insert_point] = insert_val;
            }
        }
    }
}
