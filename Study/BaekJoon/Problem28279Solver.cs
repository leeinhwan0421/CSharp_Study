using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/28278
    // 덱 2

    internal class Problem28279Solver
    {
        static LinkedList<int> deque = new LinkedList<int>();
        static StringBuilder sb = new StringBuilder();

        static void push_front(int x)
        {
            deque.AddFirst(x);
        }

        static void push_back(int x)
        {
            deque.AddLast(x);
        }

        static void pop_front()
        {
            if (deque.Count > 0)
            {
                sb.AppendLine(deque.First.Value.ToString());
                deque.RemoveFirst();
            }
            else
            {
                sb.AppendLine("-1");
            }
        }

        static void pop_back()
        {
            if (deque.Count > 0)
            {
                sb.AppendLine(deque.Last.Value.ToString());
                deque.RemoveLast();
            }
            else
            {
                sb.AppendLine("-1");
            }
        }

        static void count()
        {
            sb.AppendLine(deque.Count.ToString());
        }

        static void empty()
        {
            if (deque.Count == 0)
            {
                sb.AppendLine("1");
            }
            else
            {
                sb.AppendLine("0");
            }
        }

        static void peek_front()
        {
            if (deque.Count > 0)
            {
                sb.AppendLine(deque.First.Value.ToString());
            }
            else
            {
                sb.AppendLine("-1");
            }
        }

        static void peek_back()
        {
            if (deque.Count > 0)
            {
                sb.AppendLine(deque.Last.Value.ToString());
            }
            else
            {
                sb.AppendLine("-1");
            }
        }

        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] command = Console.ReadLine().Split(' ');

                switch (command[0])
                {
                    case "1":
                        push_front(int.Parse(command[1]));
                        break;
                    case "2":
                        push_back(int.Parse(command[1]));
                        break;
                    case "3":
                        pop_front();
                        break;
                    case "4":
                        pop_back();
                        break;
                    case "5":
                        count();
                        break;
                    case "6":
                        empty();
                        break;
                    case "7":
                        peek_front();
                        break;
                    case "8":
                        peek_back();
                        break;
                }
            }

            Console.Write(sb.ToString());
        }
    }
}
