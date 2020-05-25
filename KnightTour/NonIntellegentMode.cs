using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class NonIntellegentMode:PlayMode
    {
        private Cell[,] board_nonIN = new Cell[8, 8];

        //Initiallize board
        public Cell[,] Initialize()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    board_nonIN[x, y] = new Cell(x, y, 0);
                }
            }
            return board_nonIN;
        }
        //check possible route and return as arraylist
        public ArrayList PossibleRoutes(int x, int y)
        {
            ArrayList list = new ArrayList();

            int X = x + 2;
            int Y = y + 1;
            if (checkCellValid(X, Y) == true)
                list.Add(new Cell(X, Y));

            X = x + 2;
            Y = y - 1;
            if (checkCellValid(X, Y) == true)
                list.Add(new Cell(X, Y));

            X = x - 2;
            Y = y + 1;
            if (checkCellValid(X, Y) == true)
                list.Add(new Cell(X, Y));

            X = x - 2;
            Y = y - 1;
            if (checkCellValid(X, Y) == true)
                list.Add(new Cell(X, Y));



            X = x + 1;
            Y = y + 2;
            if (checkCellValid(X, Y) == true)
                list.Add(new Cell(X, Y));

            X = x + 1;
            Y = y - 2;
            if (checkCellValid(X, Y) == true)
                list.Add(new Cell(X, Y));

            X = x - 1;
            Y = y + 2;
            if (checkCellValid(X, Y) == true)
                list.Add(new Cell(X, Y));


            X = x - 1;
            Y = y - 2;
            if (checkCellValid(X, Y) == true)
                list.Add(new Cell(X, Y));


            return list;

        }

        public bool checkCellValid(int x, int y)
        {
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7 && board_nonIN[x, y].value == 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
