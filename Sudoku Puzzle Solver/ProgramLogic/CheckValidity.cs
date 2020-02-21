using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku_Puzzle_Solver.ProgramLogic
{
    class CheckValidity
    {
        private static int [,] userEnteredSudokuPuzzle;
        private static int currentDigitRowLocation, currentDigitColumnLocation;
        private static int currentDigit;


        public static bool IsEnteredPuzzleValid(int [,] userEnteredSudokuPuzzle)
        {
            CheckValidity.userEnteredSudokuPuzzle = userEnteredSudokuPuzzle;
            for (int currentRow = 0; currentRow < 9; ++currentRow)
            {
                for (int currentColumn = 0; currentColumn < 9; ++currentColumn)
                {
                    int digitAtCurrentSpot = userEnteredSudokuPuzzle[currentRow, currentColumn];
                    if (digitAtCurrentSpot != 0 && !CheckValidity.IsThisDigitInAValidLocation(currentRow, currentColumn, digitAtCurrentSpot))
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public static bool IsThisDigitInAValidLocation(int currentDigitRowLocation, int currentDigitColumnLocation, int currentDigit)
        {
            CheckValidity.currentDigitRowLocation = currentDigitRowLocation;
            CheckValidity.currentDigitColumnLocation = currentDigitColumnLocation;
            CheckValidity.currentDigit = currentDigit;
            return IsThisDigitValidInItsRow() && IsThisDigitValidInItsColumn() && IsThisDigitValidInItsSquare();
        }


        private static bool IsThisDigitValidInItsRow()
        {
            for (int currentColumnBeingChecked = 0; currentColumnBeingChecked < 9; ++currentColumnBeingChecked)
            {
                int currentDigitBeingChecked = userEnteredSudokuPuzzle [currentDigitRowLocation, currentColumnBeingChecked];
                if (currentDigitBeingChecked == currentDigit && currentColumnBeingChecked != currentDigitColumnLocation)
                {
                    return false;
                }
            }
            return true;
        }


        private static bool IsThisDigitValidInItsColumn()
        {
            for (int currentRowBeingChecked = 0; currentRowBeingChecked < 9; ++currentRowBeingChecked)
            {
                int currentDigitBeingChecked = userEnteredSudokuPuzzle [currentRowBeingChecked, currentDigitColumnLocation];
                if (currentDigitBeingChecked == currentDigit && currentRowBeingChecked != currentDigitRowLocation)
                {
                    return false;
                }
            }
            return true;
        }


        private static bool IsThisDigitValidInItsSquare()
        {
            int currentSquareTopLeftCornerRowLocation = DetermineCurrentSquareTopLeftCornerRowLocation();
            int currentSquareTopLeftCornerColumnLocation = DetermineCurrentSquareTopLeftCornerColumnLocation();
            for (int currentRowBeingChecked = currentSquareTopLeftCornerRowLocation; currentRowBeingChecked < currentSquareTopLeftCornerRowLocation + 3; ++currentRowBeingChecked)
            {
                for (int currentColumnBeingChecked = currentSquareTopLeftCornerColumnLocation; currentColumnBeingChecked < currentSquareTopLeftCornerColumnLocation + 3; ++currentColumnBeingChecked)
                {
                    int currentDigitBeingChecked = userEnteredSudokuPuzzle [currentRowBeingChecked, currentColumnBeingChecked];
                    if (currentDigitBeingChecked == currentDigit && currentRowBeingChecked != currentDigitRowLocation && currentColumnBeingChecked != currentDigitColumnLocation)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        private static int DetermineCurrentSquareTopLeftCornerRowLocation()
        {
            if (currentDigitRowLocation < 3)
                return 0;
            if (currentDigitRowLocation < 6)
                return 3;
            // else currentDigitRowLocation < 9
            return 6;
        }


        private static int DetermineCurrentSquareTopLeftCornerColumnLocation()
        {
            if (currentDigitColumnLocation < 3)
                return 0;
            if (currentDigitColumnLocation < 6)
                return 3;
            // else currentDigitColumnLocation < 9
            return 6;
        }
    }
}
