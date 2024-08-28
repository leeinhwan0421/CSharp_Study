using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1874
    // 스택 수열 

    internal class Problem1874Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());
            List<int> A = new List<int>(); 

            for (int i = 0; i < N; i++)
            {
                A.Add(int.Parse(Console.ReadLine()));
            }
            
            Stack<int> S = new Stack<int>();
            StringBuilder sb = new StringBuilder();
            int num = 1;

            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] >= num)
                {
                    while (A[i] >= num)
                    {
                        S.Push(num++);
                        sb.Append("+\n");
                    }

                    S.Pop();
                    sb.Append("-\n");
                }
                else
                {
                    int temp = S.Pop();

                    if (temp != A[i])
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else
                    {
                        sb.Append("-\n");
                    }
                }
            }

            Console.Write(sb.ToString());
        }
    }
}
