using MineSweeper.Interfaces;
using MineSweeper.Services;
using MineSweeper;

while (true)
{
    Console.WriteLine("Welcome to Minesweeper!");

    int gridSize = UserInputManager.GetBoardSize();
    int mineCount = UserInputManager.GetNumberOfMines(gridSize);

    IMinesweeperGame game = new MinesweeperGame(gridSize, mineCount);
    game.Play();

    Console.WriteLine("Press any key to play again...");
    Console.ReadKey();
    Console.Clear();
}