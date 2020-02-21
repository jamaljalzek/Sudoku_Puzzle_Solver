using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku_Puzzle_Solver.ProgramLogic
{
    /// <summary>
    /// The point of this class is to provide a customized implemention of a stack, which aims to perform faster than C#'s standard Stack implementation.
    /// </summary>
    class FastStack
    {
        private int [] rowLocationsStack, columnLocationsStack;
        private int topOfRowLocationsStack, topOfColumnLocationsStack;


        public FastStack()
        {
            rowLocationsStack = new int [81];
            columnLocationsStack = new int [81];
            topOfRowLocationsStack = 0;
            topOfColumnLocationsStack = 0;
        }


        public void PushRowLocation(int rowLocation)
        {
            rowLocationsStack [topOfRowLocationsStack] = rowLocation;
            ++topOfRowLocationsStack;
        }


        public void PushColumnLocation(int columnLocation)
        {
            columnLocationsStack [topOfColumnLocationsStack] = columnLocation;
            ++topOfColumnLocationsStack;
        }


        public int PopNextRowLocation()
        {
            --topOfRowLocationsStack;
            return rowLocationsStack [topOfRowLocationsStack];
        }


        public int PopNextColumnLocation()
        {
            --topOfColumnLocationsStack;
            return columnLocationsStack [topOfColumnLocationsStack];
        }
    }
}
