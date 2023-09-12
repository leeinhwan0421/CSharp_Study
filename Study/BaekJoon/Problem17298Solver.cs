using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/17298
    // 오큰수

    internal class Problem17298Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            string[] inputs = Console.ReadLine().Split(' ');

            int[] arr = new int[N];
            int[] result_arr = new int[N];
            for (int i = 0; i < N; i++)
            {
                arr[i] = int.Parse(inputs[i]);
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            for (int i = 0; i < N; i++)
            {
                while(stack.Count > 0 && arr[stack.Peek()] < arr[i])
                {
                    result_arr[stack.Peek()] = arr[i];
                    stack.Pop();
                }

                stack.Push(i);
            }

            while (stack.Count > 0)
            {
                result_arr[stack.Peek()] = -1;
                stack.Pop();
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                sb.Append($"{result_arr[i]} ");
            }

            Console.Write(sb.ToString());
            Console.ReadLine();
        }
    }
}
