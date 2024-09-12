using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp8
{
    public partial class MainWindow : Window
    {
        private Minesweeper _game;
        private Button[,] _buttons;
        private const int Rows = 5;
        private const int Cols = 10;
        private const int MinesCount = 3;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            _game = new Minesweeper();
            var grid = _game.CreateGrid(Rows, Cols, MinesCount);
            _buttons = new Button[Rows, Cols];

            GridContainer.Children.Clear();
            GridContainer.RowDefinitions.Clear();
            GridContainer.ColumnDefinitions.Clear();

            for (int i = 0; i < Rows; i++)
            {
                GridContainer.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < Cols; i++)
            {
                GridContainer.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int row = 0; row < Rows; row++)
            {

                for (int col = 0; col < Cols; col++)
                {

             
                    var currentRow = row;
                    var currentCol = col;

                    var button = new Button
                    {
                        Width = 50,
                        Height = 50,
                        Margin = new Thickness(2)
                    };
                   

                    button.Click += (sender, e) => OnTileClicked(currentRow, currentCol);
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    _buttons[row, col] = button;
                    GridContainer.Children.Add(button);
                }
            }

            UpdateGrid();
        }

        private void OnTileClicked(int row, int col)
        {
            var tile = _game.Grid[row, col];
            tile.Reveal();
            UpdateGrid();

            if (tile.RevealAction == (Action)_game.MineTileReveal)
            {
                MessageBox.Show("Boom! You're dead");
                
            }
            else if (CheckWin())
            {
                MessageBox.Show("Congratulations! You've revealed all tiles!");
                
            }
        }

        private void UpdateGrid()
        {
            for (int row = 0; row < Rows; row++)
            {

                for (int col = 0; col < Cols; col++)
                {

                    var tile = _game.Grid[row, col];
                    var button = _buttons[row, col];
                    button.Content = tile.ToString();
                }
            }
        }

        private bool CheckWin()
        {
            foreach (var tile in _game.Grid)
            {

                if (!tile.IsRevealed && tile.RevealAction != (Action)_game.MineTileReveal)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
