using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Interfaces
{
    internal interface IGrid
    {
        void Print();
        bool Reveal(int x, int y);
        bool CheckWin();
    }
}
