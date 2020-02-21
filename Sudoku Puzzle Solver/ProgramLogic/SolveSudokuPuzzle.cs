using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku_Puzzle_Solver.ProgramLogic
{
    public static class SolveSudokuPuzzle
    {
        private static int [,] userEnteredSudokuPuzzle;
        private static Stack <int> spotsLeftToVisitRowLocations, spotsLeftToVisitColumnLocations;
        private static Stack <int> spotsThatWeHaveVisitedRowLocations, spotsThatWeHaveVisitedColumnLocations;
        private static int currentSpotRowLocation, currentSpotColumnLocation;
        private static int digitAtCurrentSpot;


        public static void SolvePuzzleWithBacktrackingAlgorithm(int [,] userEnteredSudokuPuzzle)
        {
            SetUpByInitializingClassFields(userEnteredSudokuPuzzle);
            RecordAllEmptySpotLocationsThatWeMustEventuallyVisit();
            while (AreThereStillSpotsLeftToVisit())
            {
                MoveToNextSpotThatWeMustVisit();
                IncrementCurrentSpotUntilValidOr10();
                if (digitAtCurrentSpot == 10)
                    BackTrackBySettingPreviouslyVisitedSpotAsNextSpotToVisit();
                else
                    RecordCurrentSpotLocationThatWeJustVisited();
            }
        }


        private static void SetUpByInitializingClassFields(int [,] userEnteredSudokuPuzzle)
        {
            SolveSudokuPuzzle.userEnteredSudokuPuzzle = userEnteredSudokuPuzzle;
            spotsLeftToVisitRowLocations = new Stack <int>();
            spotsLeftToVisitColumnLocations = new Stack <int>();
            spotsThatWeHaveVisitedRowLocations = new Stack <int>();
            spotsThatWeHaveVisitedColumnLocations = new Stack <int>();
            currentSpotRowLocation = 0;
            currentSpotColumnLocation = 0;
            digitAtCurrentSpot = 0;
        }


        private static void RecordAllEmptySpotLocationsThatWeMustEventuallyVisit()
        {
            for (int currentRow = 8; currentRow >= 0; --currentRow)
            {
                for (int currentColumn = 8; currentColumn >= 0; --currentColumn)
                {
                    int digitAtCurrentSpot = userEnteredSudokuPuzzle [currentRow, currentColumn];
                    if (digitAtCurrentSpot == 0)
                    {
                        spotsLeftToVisitRowLocations.Push(currentRow);
                        spotsLeftToVisitColumnLocations.Push(currentColumn);
                    }
                }
            }
        }


        private static bool AreThereStillSpotsLeftToVisit()
        {
            return spotsLeftToVisitRowLocations.Count != 0 && spotsLeftToVisitColumnLocations.Count != 0;
        }


        private static void MoveToNextSpotThatWeMustVisit()
        {
            currentSpotRowLocation = spotsLeftToVisitRowLocations.Pop();
            currentSpotColumnLocation = spotsLeftToVisitColumnLocations.Pop();
        }


        private static void IncrementCurrentSpotUntilValidOr10()
        {
            do
            {
                ++userEnteredSudokuPuzzle [currentSpotRowLocation, currentSpotColumnLocation];
                digitAtCurrentSpot = userEnteredSudokuPuzzle [currentSpotRowLocation, currentSpotColumnLocation];
            }
            while (!CheckValidity.IsThisDigitInAValidLocation(currentSpotRowLocation, currentSpotColumnLocation, digitAtCurrentSpot) && digitAtCurrentSpot < 10);
        }


        private static void BackTrackBySettingPreviouslyVisitedSpotAsNextSpotToVisit()
        {
            userEnteredSudokuPuzzle [currentSpotRowLocation, currentSpotColumnLocation] = 0;
            RecordCurrentSpotLocationThatWeMustRevisit();
            int previousSpotWeHaveVisitedRowLocation = spotsThatWeHaveVisitedRowLocations.Pop();
            int previousSpotWeHaveVisitedColumnLocation = spotsThatWeHaveVisitedColumnLocations.Pop();
            spotsLeftToVisitRowLocations.Push(previousSpotWeHaveVisitedRowLocation);
            spotsLeftToVisitColumnLocations.Push(previousSpotWeHaveVisitedColumnLocation);
        }


        private static void RecordCurrentSpotLocationThatWeMustRevisit()
        {
            spotsLeftToVisitRowLocations.Push(currentSpotRowLocation);
            spotsLeftToVisitColumnLocations.Push(currentSpotColumnLocation);
        }


        private static void RecordCurrentSpotLocationThatWeJustVisited()
        {
            spotsThatWeHaveVisitedRowLocations.Push(currentSpotRowLocation);
            spotsThatWeHaveVisitedColumnLocations.Push(currentSpotColumnLocation);
        }
    }
}
