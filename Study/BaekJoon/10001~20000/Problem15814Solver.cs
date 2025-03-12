using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/15814
    // 야바위 대장

    internal class Problem15814Solver
    {
        static public void Solve()
        {
            char[] arr = Console.ReadLine().ToCharArray();
            string input = Console.ReadLine();
            int T = int.Parse(input);
            for (int i = 0; i < T; i++)
            {
                string[] inputs = Console.ReadLine().Split();
                int a = int.Parse(inputs[0]);
                int b = int.Parse(inputs[1]);
                char temp = arr[a];
                arr[a] = arr[b];
                arr[b] = temp;
            }
            Console.WriteLine(new string(arr));
        }
    }
}
