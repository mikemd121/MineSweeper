using MineSweeper.Services;
using Xunit;

namespace Minesweeper.Tests
{
    public class GridTests
    {
        [Fact]
        public void Grid_ShouldPlaceCorrectNumberOfMines()
        {
            int gridSize = 5;
            int mineCount = 5;
            Grid grid = new Grid(gridSize, mineCount);

            int actualMineCount = 0;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (grid.Cells[i, j].IsMine)
                    {
                        actualMineCount++;
                    }
                }
            }

            Assert.Equal(mineCount, actualMineCount);
        }

        [Fact]
        public void Reveal_ShouldRevealCell()
        {
            int gridSize = 5;
            int mineCount = 5;
            Grid grid = new Grid(gridSize, mineCount);

            int x = 0;
            int y = 0;

            bool gameOver = grid.Reveal(x, y);

            Assert.True(grid.Revealed[x, y]);
            Assert.False(gameOver);
        }

        [Fact]
        public void Reveal_OnMine_ShouldEndGame()
        {
            int gridSize = 5;
            int mineCount = 1;
            Grid grid = new Grid(gridSize, mineCount);

            // Find the mine position
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

            bool gameOver = grid.Reveal(mineX, mineY);

            Assert.True(gameOver);
        }

        [Fact]
        public void CheckWin_ShouldReturnTrueWhenAllNonMinesRevealed()
        {
            int gridSize = 5;
            int mineCount = 1;
            Grid grid = new Grid(gridSize, mineCount);

            // Reveal all non-mine cells
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (!grid.Cells[i, j].IsMine)
                    {
                        grid.Reveal(i, j);
                    }
                }
            }

            Assert.True(grid.CheckWin());
        }
    }
}
