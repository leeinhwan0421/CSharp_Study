using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/28278
    // 스택 2
    // 기존에 존재하는 스택문제를 응용해서 풀면 된다.

    // WriteLine을 사용하면 시간 초과가 발생하기 때문에, StringBuilder를 활용해서 풀어줍니다.
    // Write(stirng + "\n"); 을 해도 되는지는 모르겠습니다.

    internal class Problem28278Solver
    {

        static private Stack stack = new Stack();
        static private StringBuilder sb = new StringBuilder();


        static void Push(int x) 
        { 
            stack.Push(x); 
        }

        static void Pop() 
        {
            if (stack.Count == 0)
                sb.AppendLine("-1");
            else
                sb.AppendLine(stack.Pop().ToString());
        }

        static void Count()
        {
            sb.AppendLine(stack.Count.ToString());
        }

        static void Empty()
        {
            if (stack.Count == 0)
                sb.AppendLine("1");
            else
                sb.AppendLine("0");
        }

        static void Peek()
        {
            if (stack.Count == 0)
                sb.AppendLine("-1");
            else
                sb.AppendLine(stack.Peek().ToString());
        }

        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string command = Console.ReadLine();
                
                switch(command.Split(' ')[0])
                {
                    case "1":
                        Push(int.Parse(command.Split(' ')[1]));
                        break;
                    case "2":
                        Pop();
                        break;
                    case "3":
                        Count();
                        break;
                    case "4":
                        Empty();
                        break;
                    case "5":
                        Peek();
                        break;
                }
            }

            Console.Write(sb.ToString());
        }
    }
}
