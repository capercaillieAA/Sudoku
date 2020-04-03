namespace Sudoku
{
    class Table
    {
        private readonly int size;
        private readonly byte[,] table;

        public Table(int dim)
        {
            size = dim * dim;
            table = new byte[size, size];
        }

        public void Create(Difficult difficult)
        {
            SudokuGenerator.Generate(table, size, difficult);
        }
    }
}
