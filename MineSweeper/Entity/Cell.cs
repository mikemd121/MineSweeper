using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Entity
{
    public class Cell
    {
        public bool IsMine { get; set; }
        public int AdjacentMines { get; set; }
    }
}
