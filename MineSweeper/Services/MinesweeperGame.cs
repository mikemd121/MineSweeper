using MineSweeper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Services
{
   public class MinesweeperGame : IMinesweeperGame
    {
        private readonly int gridSize;
        private readonly int mineCount;
        private readonly IGrid grid;
        private bool gameOver;

        public MinesweeperGame(int gridSize, int mineCount)
        {
            this.gridSize = gridSize;
            this.mineCount = mineCount;
            grid = new Grid(gridSize, mineCount);
        }

        public void Play()
        {
            while (!gameOver)
            {
                grid.Print();
                Console.Write("Select a square to reveal (e.g. A1): ");
                string input = Console.ReadLine();

                if (!UserInputManager.TryParseCoordinates(input, gridSize, out int x, out int y))
                {
                    Console.WriteLine("Incorrect input.");
                    continue;
                }

                gameOver = grid.Reveal(x, y);

                if (gameOver)
                {
                    grid.Print();
                    Console.WriteLine("Oh no, you detonated a mine! Game over.");
                }
                else if (grid.CheckWin())
                {
                    grid.Print();
                    Console.WriteLine("Congratulations, you have won the game!");
                    gameOver = true;
                }
            }
        }
    }
}
