using System;

namespace WpfApp8
{
    public class Minesweeper
    {
        public Tile[,]? Grid { get; private set; }

        public Tile[,] CreateGrid(int rows, int cols, int minesCount)
        {
            var grid = new Tile[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    grid[row, col] = new Tile(NormalTileReveal);
                }
            }
            PlaceMines(grid, minesCount);
            Grid = grid;
            return grid;
        }

        private void NormalTileReveal()
        {
            // No action needed for normal tile reveal in this example
        }

        public void MineTileReveal()
        {
            // No action needed for mine tile reveal in this example
        }

        private void PlaceMines(Tile[,] grid, int minesCount)
        {
            var random = new Random();
            int placedMines = 0;

            while (placedMines < minesCount)
            {
                int row = random.Next(grid.GetLength(0));
                int col = random.Next(grid.GetLength(1));

                if (grid[row, col].RevealAction != (Action)MineTileReveal)
                {
                    grid[row, col].RevealAction = (Action)MineTileReveal;
                    placedMines++;
                }
            }
        }
    }
}