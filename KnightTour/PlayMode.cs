using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    interface PlayMode
    {
        Cell[,] Initialize();
        ArrayList PossibleRoutes(int x, int y);
        bool checkCellValid(int x, int y);
    }
}
