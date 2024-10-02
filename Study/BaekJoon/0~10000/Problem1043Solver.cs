using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1043
    // 거짓말

    internal class Problem1043Solver
    {
        static int[] parent;

        static public void Solve()
        {
            var inputs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int N = inputs[0];
            int M = inputs[1];

            parent = Enumerable.Range(0, N + 1).ToArray();

            var truth = Console.ReadLine().Split(' ').Skip(1).Select(int.Parse).ToList();
            var parties = new int[M][];

            for (int i = 0; i < M; i++)
            {
                var partyMembers = Console.ReadLine().Split(' ').Skip(1).Select(int.Parse).ToArray();
                parties[i] = partyMembers;

                for (int j = 1; j < partyMembers.Length; j++)
                {
                    Union(partyMembers[0], partyMembers[j]);
                }
            }

            int count = 0;
            foreach (var party in parties)
            {
                bool canLie = true;

                foreach (var member in party)
                {
                    if (truth.Any(t => Find(t) == Find(member)))
                    {
                        canLie = false;
                        break;
                    }
                }

                if (canLie)
                    count++;
            }

            Console.WriteLine(count);

            
        }

        static int Find(int x)
        {
            if (x == parent[x]) return x;
            return parent[x] = Find(parent[x]);
        }

        static void Union(int a, int b)
        {
            a = Find(a);
            b = Find(b);

            if (a != b)
                parent[b] = a;
        }
    }
}
