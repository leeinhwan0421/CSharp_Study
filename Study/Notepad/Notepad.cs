using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Notepad
{
    class Notepad
    {
        static public void Run()
        {
            string[] line = Console.ReadLine().Split('-');

            int sum = Plus(line[0]);

            for (int i = 1; i < line.Length; i++)
            {
                sum -= Plus(line[i]);
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }

        static public int Plus(string n)
        {
            string[] line = n.Split('+');

            int sum = 0;

            for (int i = 0; i < line.Length; i++)
            {
                sum += int.Parse(line[i]);
            }

            return sum;
        }
    }
}
