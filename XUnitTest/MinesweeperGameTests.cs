using MineSweeper.Services;
using Xunit;

namespace Minesweeper.Tests
{
    public class MinesweeperGameTests
    {
        [Fact]
        public void Play_GameOverOnMineReveal()
        {
            int gridSize = 5;
            int mineCount = 1;
            var game = new MinesweeperGame(gridSize, mineCount);

            // Directly access the grid to set up a predictable test case
            Grid grid = game.GetType().GetField("grid", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(game) as Grid;

            int mineX = -1, mineY = -1;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (grid.Cells[i, j].IsMine)
                    {
                        mineX = i;
                        mineY = j;
                        break;
                    }
                }
                if (mineX != -1) break;
            }

            game.Play();
            grid.Reveal(mineX, mineY);

            Assert.True((bool)game.GetType().GetField("gameOver", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(game));
        }
    }
}
