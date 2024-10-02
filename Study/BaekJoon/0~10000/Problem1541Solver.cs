using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1541
    // 잃어버린 괄호

    internal class Problem1541Solver
    {
        static public void Solve()
        {
            string[] list = Console.ReadLine().Split('-');       

            int sum = Plus(list[0]);
            for (int i = 1; i < list.Length; i++)
            {
                sum -= Plus(list[i]);
            }

            Console.Write(sum);
            
        }

        static public int Plus(string n) 
        {
            string[] n_list = n.Split('+');

            int sum = 0;

            for (int i = 0; i < n_list.Length; i++)
                sum += int.Parse(n_list[i]);

            return sum;
        }
    }
}
