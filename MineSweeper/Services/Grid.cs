using MineSweeper.Entity;
using MineSweeper.Interfaces;

public class Grid : IGrid
{
    private readonly int gridSize;
    private readonly int mineCount;
    private readonly Cell[,] cells;
    private readonly bool[,] revealed;

    public Cell[,] Cells => cells;  // Correctly expose the cells array
    public bool[,] Revealed => revealed;  // Expose revealed array

    public Grid(int gridSize, int mineCount)
    {
        this.gridSize = gridSize;
        this.mineCount = mineCount;
        cells = new Cell[gridSize, gridSize];
        revealed = new bool[gridSize, gridSize];
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                cells[i, j] = new Cell();
            }
        }

        Random random = new Random();
        int minesPlaced = 0;
        while (minesPlaced < mineCount)
        {
            int x = random.Next(gridSize);
            int y = random.Next(gridSize);
            if (!cells[x, y].IsMine)
            {
                cells[x, y].IsMine = true;
                minesPlaced++;
            }
        }

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if (!cells[i, j].IsMine)
                {
                    cells[i, j].AdjacentMines = CountAdjacentMines(i, j);
                }
            }
        }
    }

    private int CountAdjacentMines(int x, int y)
    {
        int count = 0;
        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (i >= 0 && i < gridSize && j >= 0 && j < gridSize && cells[i, j].IsMine)
                {
                    count++;
                }
            }
        }
        return count;
    }

    public void Print()
    {
        Console.WriteLine("Here is your minefield:");
        Console.Write("  ");
        for (int i = 1; i <= gridSize; i++)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();

        for (int i = 0; i < gridSize; i++)
        {
            Console.Write($"{(char)('A' + i)} ");
            for (int j = 0; j < gridSize; j++)
            {
                if (revealed[i, j])
                {
                    if (cells[i, j].IsMine)
                        Console.Write("* ");
                    else
                        Console.Write($"{cells[i, j].AdjacentMines} ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
            Console.WriteLine();
        }
    }

    public bool Reveal(int x, int y)
    {
        if (revealed[x, y])
            return false;

        revealed[x, y] = true;
        if (cells[x, y].IsMine)
        {
            return true;
        }

        if (cells[x, y].AdjacentMines == 0)
        {
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i < gridSize && j >= 0 && j < gridSize)
                    {
                        Reveal(i, j);
                    }
                }
            }
        }
        return false;
    }

    public bool CheckWin()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if (!cells[i, j].IsMine && !revealed[i, j])
                    return false;
            }
        }
        return true;
    }
}
