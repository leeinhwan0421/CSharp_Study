using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/27889
    // 특별한 학교 이름

    internal class Problem27889Solver
    {
        static public void Solve()
        {
            /*
            NLCS: North London Collegiate School
            BHA: Branksome Hall Asia
            KIS: Korea International School
            SJA: St. Johnsbury Academy
            */

            string school = Console.ReadLine();

            if (school == "NLCS")
                Console.Write("North London Collegiate School");

            else if (school == "BHA")
                Console.Write("Branksome Hall Asia");

            else if (school == "KIS")
                Console.Write("Korea International School");
            
            else
                Console.Write("St. Johnsbury Academy");

            
        }
    }
}
