using System;
using static System.Math;

namespace Sudoku
{
    static class GeneratorOperations
    {
        static Random rand = new Random();

        static public void TransposeMatrix(byte[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
                for (int j = i; j < table.GetLength(1); j++)
                    Swap(ref table[i, j], ref table[j, i]);
        }

        static public void SwapColumnsInBlock(byte[,] table)
        {
            int dim = (int)Sqrt(table.GetLength(0));
            var startColumn = rand.Next(0, dim) * dim;
            var endColumn = startColumn + dim - 1;

            int randColumn1 = rand.Next(startColumn, endColumn);
            int randColumn2 = rand.Next(startColumn, endColumn);

            for (int i = 0; i < table.GetLength(0); i++)
                Swap(ref table[i, randColumn1], ref table[i, randColumn2]);
        }

        static public void SwapRowsInBlock(byte[,] table)
        {
            TransposeMatrix(table);
            SwapColumnsInBlock(table);
            TransposeMatrix(table);
        }

        static public void SwapBlockColumns(byte[,] table)
        {
            int dim = (int)Sqrt(table.GetLength(0));
            int randBlock1 = rand.Next(0, dim);
            int randBlock2 = rand.Next(0, dim);

            for (int i = 0; i < table.GetLength(0); i++)
                for (int j = 0; j < dim; j++)
                    Swap(ref table[i, randBlock1 * dim + j], ref table[i, randBlock2 * dim + j]);
        }

        static public void SwapBlockRows(byte[,] table)
        {
            TransposeMatrix(table);
            SwapBlockColumns(table);
            TransposeMatrix(table);
        }

        static void Swap(ref byte a, ref byte b)
        {
            byte temp;
            temp = a;
            a = b;
            b = temp;
        }
    }
}
