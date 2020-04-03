using System;
using static System.Math;

namespace Sudoku
{
    static class GeneratorOperations
    {
        static Random rand = new Random();

        static public void TransposeMatrix(byte[,] table, int size)
        {
            for (int i = 0; i < size; i++)
                for (int j = i; j < size; j++)
                    Swap(ref table[i, j], ref table[j, i]);
        }

        static public void SwapColumnsInBlock(byte[,] table, int size)
        {
            int dim = (int)Sqrt(size);
            var startColumn = rand.Next(0, dim) * dim;
            var endColumn = startColumn + dim - 1;

            int randColumn1 = rand.Next(startColumn, endColumn);
            int randColumn2 = rand.Next(startColumn, endColumn);

            for (int i = 0; i < size; i++)
                Swap(ref table[i, randColumn1], ref table[i, randColumn2]);
        }

        static public void SwapRowsInBlock(byte[,] table, int size)
        {
            TransposeMatrix(table, size);
            SwapColumnsInBlock(table, size);
            TransposeMatrix(table, size);
        }

        static public void SwapBlockColumns(byte[,] table, int size)
        {
            int dim = (int)Sqrt(size);
            int randBlock1 = rand.Next(0, dim);
            int randBlock2 = rand.Next(0, dim);

            for (int i = 0; i < size; i++)
                for (int j = 0; j < dim; j++)
                    Swap(ref table[i, randBlock1 * dim + j], ref table[i, randBlock2 * dim + j]);
        }

        static public void SwapBlockRows(byte[,] table, int size)
        {
            TransposeMatrix(table, size);
            SwapBlockColumns(table, size);
            TransposeMatrix(table, size);
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
