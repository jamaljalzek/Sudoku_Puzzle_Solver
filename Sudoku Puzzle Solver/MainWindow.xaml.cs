using Sudoku_Puzzle_Solver.ProgramLogic;
using System.Windows;
using System.Windows.Controls;


namespace Sudoku_Puzzle_Solver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsUserInputValid())
            {
                return;
            }
            int [,] userEnteredSudokuPuzzle = ExtractUserEnteredSudokuPuzzle();
            if (!CheckValidity.IsEnteredPuzzleValid(userEnteredSudokuPuzzle))
            {
                MessageBox.Show("ERROR, the entered puzzle is NOT a valid puzzle!");
                return;
            }
            //int [,] userEnteredSudokuPuzzle = TestSudokuPuzzles.SetUpTestPuzzle1();
            //int [,] userEnteredSudokuPuzzle = TestSudokuPuzzles.SetUpTestPuzzle2();
            //int [,] userEnteredSudokuPuzzle = TestSudokuPuzzles.SetUpTestPuzzle3();
            SolveSudokuPuzzle.SolvePuzzleWithBacktrackingAlgorithm(userEnteredSudokuPuzzle);
            DisplaySolvedSudokuPuzzle(userEnteredSudokuPuzzle);
        }


        private bool IsUserInputValid()
        {
            UIElementCollection displayedTextBoxes = sudokuGrid.Children;
            int currentTextBoxNumber = 0;
            foreach (TextBox currentTextBox in displayedTextBoxes)
            {
                if (currentTextBox.Text.Length == 0)
                {
                    ++currentTextBoxNumber;
                    continue;
                }
                if (!char.IsDigit(currentTextBox.Text[0]))
                {
                    MessageBox.Show("ERROR, the entered puzzle contains a non numeric value!");
                    return false;
                }
                ++currentTextBoxNumber;
            }
            return true;
        }


        private int [,] ExtractUserEnteredSudokuPuzzle()
        {
            int [,] userEnteredSudokuPuzzle = new int [9, 9];
            UIElementCollection displayedTextBoxes = sudokuGrid.Children;
            int currentTextBoxNumber = 0;
            foreach (TextBox currentTextBox in displayedTextBoxes)
            {
                int currentTextBoxRow = CalculateTextBoxRowLocation(currentTextBoxNumber);
                int currentTextBoxColumn = CalculateColumnLocation(currentTextBoxNumber);
                userEnteredSudokuPuzzle[currentTextBoxRow, currentTextBoxColumn] = ExtractEnteredNumberFromTextBox(currentTextBox);
                ++currentTextBoxNumber;
            }
            return userEnteredSudokuPuzzle;
        }


        private int CalculateTextBoxRowLocation(int textBoxNumber)
        {
            return textBoxNumber / 9;
        }


        private int CalculateColumnLocation(int textBoxNumber)
        {
            return textBoxNumber % 9;
        }


        private int ExtractEnteredNumberFromTextBox(TextBox currentTextBox)
        {
            if (string.IsNullOrEmpty(currentTextBox.Text))
            {
                return 0;
            }
            return currentTextBox.Text[0] - '0';
        }


        private void DisplaySolvedSudokuPuzzle(int [,] userEnteredSudokuPuzzle)
        {
            UIElementCollection displayedTextBoxes = sudokuGrid.Children;
            int currentTextBoxNumber = 0;
            foreach (TextBox currentTextBox in displayedTextBoxes)
            {
                int currentTextBoxRow = CalculateTextBoxRowLocation(currentTextBoxNumber);
                int currentTextBoxColumn = CalculateColumnLocation(currentTextBoxNumber);
                currentTextBox.Text = "" + userEnteredSudokuPuzzle [currentTextBoxRow, currentTextBoxColumn];
                ++currentTextBoxNumber;
            }
        }
    }
}
