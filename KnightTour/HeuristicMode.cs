using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class HeuristicMode:PlayMode
    {

       private Cell[,] board_IN = new Cell[8, 8];

        //initialize borad with Heuristic value + 100
        //add 100, It will help to divide passed cell and unpassed cell
        public Cell[,] Initialize()
        {
            for (int x = 0; x < 8; x++)
            {
                if (x == 0 || x == 7)
                {
                    board_IN[x, 0] = new Cell(x, 0, 102);
                    board_IN[x, 1] = new Cell(x, 1, 103);
                    board_IN[x, 2] = new Cell(x, 2, 104);
                    board_IN[x, 3] = new Cell(x, 3, 104);
                    board_IN[x, 4] = new Cell(x, 4, 104);
                    board_IN[x, 5] = new Cell(x, 5, 104);
                    board_IN[x, 6] = new Cell(x, 6, 103);
                    board_IN[x, 7] = new Cell(x, 7, 102);

                }
                else if (x == 1 || x == 6)
                {
                    board_IN[x, 0] = new Cell(x, 0, 103);
                    board_IN[x, 1] = new Cell(x, 1, 104);
                    board_IN[x, 2] = new Cell(x, 2, 106);
                    board_IN[x, 3] = new Cell(x, 3, 106);
                    board_IN[x, 4] = new Cell(x, 4, 106);
                    board_IN[x, 5] = new Cell(x, 5, 106);
                    board_IN[x, 6] = new Cell(x, 6, 104);
                    board_IN[x, 7] = new Cell(x, 7, 103);

                }
                else
                {
                    board_IN[x, 0] = new Cell(x, 0, 104);
                    board_IN[x, 1] = new Cell(x, 1, 106);
                    board_IN[x, 2] = new Cell(x, 2, 108);
                    board_IN[x, 3] = new Cell(x, 3, 108);
                    board_IN[x, 4] = new Cell(x, 4, 108);
                    board_IN[x, 5] = new Cell(x, 5, 108);
                    board_IN[x, 6] = new Cell(x, 6, 106);
                    board_IN[x, 7] = new Cell(x, 7, 104);

                }

            }
            return board_IN;
        }
        public ArrayList PossibleRoutes(int x, int y)
        {
            //list for possible route
            ArrayList list = new ArrayList();

            //filtered list for intelligent way
            ArrayList filteredList = new ArrayList();

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

            //find the lowest value of cell. It will be next cell
            int low = 1000;
            for (int i = 0; i < list.Count; i++)
            {
                Cell c = (Cell)list[i];

                int candidate = board_IN[c.X, c.Y].value;

                if (candidate < low)
                    low = candidate;
            }

            //match the lowest value with cell position and return filtered list
            for (int i = 0; i < list.Count; i++)
            {
                Cell c1 = (Cell)list[i];


                if (low == board_IN[c1.X, c1.Y].value)
                    filteredList.Add(new Cell(c1.X, c1.Y));
            }
            return filteredList;
        }

        //check next cell is valid or not
        public bool checkCellValid(int x, int y)
        {
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7 && board_IN[x, y].value > 100)
            {
                return true;
            }
            else
                return false;
        }
    }
}
