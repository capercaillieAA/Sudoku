using System;
using static System.Math;

namespace Sudoku
{
    static class SudokuGenerator
    {
        static Random rand = new Random();

        static public void Generate(byte[,] table, int size, Difficult difficult)
        {
            Init(table, size);
            Mix(table, size);
            Delete(table, size, difficult);
        }

        static void Init(byte[,] table, int size)
        {
            int dim = (int)Sqrt(size);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    table[i, j] = (byte)((i * dim + i / dim + j) % (size) + 1);
        }

        static void Mix(byte[,] table, int size)
        {
            const int lowerMixer = 20000;
            const int upperMixer = 30000;

            var methods = typeof(GeneratorOperations).GetMethods();
            int randValue = rand.Next(lowerMixer, upperMixer);
            for (int i = 0; i < randValue; i++)
            {
                int randMethod = rand.Next(methods.Length - 4);
                methods[randMethod].Invoke(null, new object[] { table, size });
            }
        }

        static void Delete(byte[,] table, int size, Difficult difficult)
        {
            int numberOfEmpty = 0;
            var look = new byte[size, size];
            switch (difficult)
            {
                case Difficult.Easy: numberOfEmpty = rand.Next(40, 45); break;
                case Difficult.Medium: numberOfEmpty = rand.Next(45, 50); break;
                case Difficult.Hard: numberOfEmpty = rand.Next(50, 55); break;
            }
            while (numberOfEmpty > 0)
            {
                int i = rand.Next(size);
                int j = rand.Next(size);
                if (look[i, j] == 0)
                {
                    table[i, j] = 0;
                    look[i, j] = 1;
                    numberOfEmpty--;
                }
            }

        }
    }
}
