/* Author: André V. Wildberger *
 * Date: August 2023           */
namespace game2048
{
    internal class Board
    {
        int[,] _board;

        /// <summary>
        /// Sets size of the board.
        /// </summary>
        /// <param name="row">the rows of the board.</param>
        /// <param name="col">the cols of the board.</param>
        public void SetSize(int row, int col)
        {
            _board = new int[row, col];
        }

        /// <summary>
        /// Gets the length of the board.
        /// </summary>
        /// <returns>length of the dimension</returns>
        public int GetLength(byte dimension)
        {
            return _board.GetLength(dimension);
        }

        /// <summary>
        /// Gets the number of a certain point on the board.
        /// </summary>
        /// <param name="row">row where the number is.</param>
        /// <param name="col">col where the number is.</param>
        /// <returns>number at row, col.</returns>
        public int GetNumber(int row, int col)
        {
            return _board[row, col];
        }

        /// <summary>
        /// Sets the number at a certain point on the board.
        /// </summary>
        /// <param name="number">number to set.</param>
        /// <param name="row">row where the number should be.</param>
        /// <param name="col">col where the number should be.</param>
        public void SetNumber(int number, int row, int col)
        {
            _board[row, col] = number;
        }

        /// <summary>
        /// Checks if the Board is full of numbers.
        /// </summary>
        /// <returns>if the board is full of numbers</returns>
        public bool IsFull()
        {
            bool isFull = true;

            for (int row = 0; row < _board.GetLength(0); row++)
            {
                for (int col = 0; col < _board.GetLength(1); col++)
                {
                    if (_board[row, col] == 0)
                    {
                        isFull = false;
                    }
                }
            }

            return isFull;
        }

        /// <summary>
        /// Moves & merges all numbers to the left.
        /// </summary>
        public void Left()
        {
            for (int row = 0; row < _board.GetLength(1); row++)
            {
                int currentCol = _board.GetLength(1) - 1;

                //Merge
                do
                {
                    int col = currentCol;

                    do
                    {
                        currentCol--;

                        if (GetNumber(row, col) == GetNumber(row, currentCol))
                        {
                            SetNumber(0, row, col);
                            SetNumber(GetNumber(row, currentCol) * 2, row, currentCol);
                        }
                    } while (_board[row, currentCol] == 0 && currentCol != 0);
                } while (currentCol != 0);


                //Move
                for (int i = 0; i < _board.GetLength(0); i++)
                {
                    for (int col = _board.GetLength(0) - 1; col > 0; col--)
                    {
                        if (GetNumber(row, col - 1) == 0)
                        {
                            SetNumber(GetNumber(row, col), row, col - 1);
                            SetNumber(0, row, col);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Moves & merges all numbers to the right.
        /// </summary>
        public void Right()
        {
            for (int row = 0; row < _board.GetLength(1); row++)
            {
                int currentCol = 0;

                //Merge
                do
                {
                    int col = currentCol;

                    do
                    {
                        currentCol++;

                        if (GetNumber(row, col) == GetNumber(row, currentCol))
                        {
                            SetNumber(0, row, col);
                            SetNumber(GetNumber(row, currentCol) * 2, row, currentCol);
                        }
                    } while (_board[row, currentCol] == 0 && currentCol != _board.GetLength(0) - 1);
                } while (currentCol != _board.GetLength(0) - 1);

                //Move
                for (int i = 0; i < _board.GetLength(0); i++)
                {
                    for (int col = 0; col < _board.GetLength(0) - 1; col++)
                    {
                        if (GetNumber(row, col + 1) == 0)
                        {
                            SetNumber(GetNumber(row, col), row, col + 1);
                            SetNumber(0, row, col);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Moves & merges all numbers to the bottom.
        /// </summary>
        public void Down()
        {
            for (int col = 0; col < _board.GetLength(0); col++)
            {
                int currentRow = 0;

                //Merge
                do
                {
                    int row = currentRow;

                    do
                    {
                        currentRow++;

                        if (GetNumber(row, col) == GetNumber(currentRow, col))
                        {
                            SetNumber(0, row, col);
                            SetNumber(GetNumber(currentRow, col) * 2, currentRow, col);
                        }
                    } while (_board[currentRow, col] == 0 && currentRow != _board.GetLength(1) - 1);
                } while (currentRow != _board.GetLength(1) - 1);

                //Move
                for (int i = 0; i < _board.GetLength(1); i++)
                {
                    for (int row = 0; row < _board.GetLength(1) - 1; row++)
                    {
                        if (GetNumber(row + 1, col) == 0)
                        {
                            SetNumber(GetNumber(row, col), row + 1, col);
                            SetNumber(0, row, col);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Moves & merges all numbers to the top.
        /// </summary>
        public void Up()
        {
            for (int col = _board.GetLength(0) - 1; col >= 0; col--)
            {
                int currentRow = _board.GetLength(1) - 1;

                //Merge
                do
                {
                    int row = currentRow;

                    do
                    {
                        currentRow--;

                        if (GetNumber(row, col) == GetNumber(currentRow, col))
                        {
                            SetNumber(0, row, col);
                            SetNumber(GetNumber(currentRow, col) * 2, currentRow, col);
                        }
                    } while (_board[currentRow, col] == 0 && currentRow != 0);
                } while (currentRow != 0);

                //Move
                for (int i = 0; i < _board.GetLength(1); i++)
                {
                    for (int row = _board.GetLength(1) - 1; row > 0; row--)
                    {
                        if (GetNumber(row - 1, col) == 0)
                        {
                            SetNumber(GetNumber(row, col), row - 1, col);
                            SetNumber(0, row, col);
                        }
                    }
                }
            }
        }
    }
}
