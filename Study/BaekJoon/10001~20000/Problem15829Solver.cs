using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/15829
    // hashing

    internal class Problem15829Solver
    {
        static public void Solve()
        {
            int L = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();

            long hash_v = 0;
            long mod_m = 1234567891;
            long r = 1;

            for (int i = 0; i < L; i++)
            {
                char c = str[i];
                hash_v = (hash_v + (c - 'a' + 1) * r) % mod_m;
                r = (r * 31) % mod_m;
            }

            Console.Write(hash_v.ToString());
            
        }
    }
}
