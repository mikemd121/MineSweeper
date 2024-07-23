using System;

namespace MineSweeper
{
    public static class UserInputManager
    {
        public static int GetBoardSize()
        {
            int boardSize;
            while (true)
            {
                Console.Write("Enter the size of the board (e.g. 4 for a 4x4 grid ): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out boardSize) && boardSize >= 2 && boardSize <= 10)
                    break;
                if (boardSize < 2)
                    Console.WriteLine("Minimum size of grid  is 2.");
                else if (boardSize > 10)
                    Console.WriteLine("Maximum size of grid  is 10.");
                else
                    Console.WriteLine("Incorrect input.");
            }
            return boardSize;
        }

        public static int GetNumberOfMines(int boardSize)
        {
            int maxMines = (int)(boardSize * boardSize * 0.35);
            int numberOfMines;
            while (true)
            {
                Console.Write($"Enter the number of mines to place on the grid  (maximum is {maxMines}): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out numberOfMines) && numberOfMines >= 1 && numberOfMines <= maxMines)
                    break;
                if (numberOfMines < 1)
                    Console.WriteLine("There must be at least 1 mine.");
                else if (numberOfMines > maxMines)
                    Console.WriteLine($"Maximum number is {maxMines}.");
                else
                    Console.WriteLine("Incorrect input.");
            }
            return numberOfMines;
        }

        public static bool TryParseCoordinates(string input, int boardSize, out int row, out int column)
        {
            row = -1;
            column = -1;
            if (input.Length < 2)
                return false;

            char rowChar = input[0];
            if (rowChar < 'A' || rowChar >= 'A' + boardSize)
                return false;

            if (!int.TryParse(input.Substring(1), out column) || column < 1 || column > boardSize)
                return false;

            row = rowChar - 'A';
            column -= 1;

            return true;
        }
    }
}
