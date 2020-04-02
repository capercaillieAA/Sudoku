using System;
using static System.Math;

namespace Sudoku
{
    static class SudokuGenerator
    {
        static Random rand = new Random();

        static public void Generate(byte[,] table)
        {
            Init(table);
            Mix(table);
        }

        static void Init(byte[,] table)
        {
            int size = table.GetLength(0);
            int dim = (int)Sqrt(size);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    table[i, j] = (byte)((i * dim + i / dim + j) % (size) + 1);
        }

        static void Mix(byte[,] table)
        {
            const int lowerMixer = 20000;
            const int upperMixer = 30000;

            var methods = typeof(GeneratorOperations).GetMethods();
            int randValue = rand.Next(lowerMixer, upperMixer);
            for (int i = 0; i < randValue; i++)
            {
                int randMethod = rand.Next(methods.Length - 4);
                methods[randMethod].Invoke(null, new object[] { table });
            }
        }
    }
}
