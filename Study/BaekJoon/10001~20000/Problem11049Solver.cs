using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11049
    // 행렬 곱셈 순서

    internal class Problem11049Solver
    {
        static int matrixCount;
        static (int rows, int cols)[] matrixDimensions = new (int, int)[501];
        static int[,] minMultiplications = new int[501, 501];
        static (int rows, int cols)[,] dpMatrices = new (int, int)[501, 501];

        static int CalculateMultiplicationCost(int start, int middle, int end)
        {
            return dpMatrices[start, middle].rows * dpMatrices[start, middle].cols * dpMatrices[middle + 1, end].cols;
        }

        static public void Solve()
        {
            matrixCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= matrixCount; i++)
            {
                var input = Console.ReadLine().Split();
                int rows = int.Parse(input[0]);
                int cols = int.Parse(input[1]);
                matrixDimensions[i] = (rows, cols);
                dpMatrices[i, i] = matrixDimensions[i];
            }

            for (int length = 1; length < matrixCount; length++)
            {
                for (int start = 1; start + length <= matrixCount; start++)
                {
                    int end = start + length;
                    minMultiplications[start, end] = int.MaxValue;

                    for (int middle = start; middle < end; middle++)
                    {
                        minMultiplications[start, end] = Math.Min(
                            minMultiplications[start, end],
                            minMultiplications[start, middle] + minMultiplications[middle + 1, end] + CalculateMultiplicationCost(start, middle, end)
                        );
                    }

                    dpMatrices[start, end].rows = matrixDimensions[start].rows;
                    dpMatrices[start, end].cols = matrixDimensions[end].cols;
                }
            }

            Console.WriteLine(minMultiplications[1, matrixCount]);
            Console.ReadKey();
        }
    }
}
