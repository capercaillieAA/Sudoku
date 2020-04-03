using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Game
    {
        private Table table;
        private Settings settings;

        public void Start()
        {
            settings = new Settings().GetSettings();
            table = new Table(settings.Dimension);
            table.Create(settings.Difficult);
        }
    }
}
