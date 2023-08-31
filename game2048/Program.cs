/* Author: André V. Wildberger *
 * Date: August 2023           */
namespace game2048
{
    internal class Program
    {
        static void Main()
        {
            bool shouldRetry;

            Themes themes = new();
            GameScreens gameScreen = new();

            themes.SetTheme(Settings.theme);
            gameScreen.StartScreen();

            do
            {
                if (Settings.fieldSize > 1 && Settings.fieldSize > 1)
                {
                    Board board = new();

                    Console.CursorVisible = false;
                    board.SetSize(Settings.fieldSize, Settings.fieldSize);
                    SpawnBlock(board, 2);
                    bool hasLost;
                    bool hasWon;

                    do
                    {
                        hasWon = CheckIfHasWon(board);
                        hasLost = !IsAnyMovePossible(board);

                        if (!hasLost && !hasWon)
                        {
                            Console.Clear();
                            PrintBoard(board);
                            GetDirectionAndMove(board);

                            if (!board.IsFull())
                            {
                                SpawnBlock(board);
                            }
                        }
                    } while (!hasLost && !hasWon);

                    if (hasWon)
                    {
                        gameScreen.EndScreen(1);
                    }
                    else
                    {
                        gameScreen.EndScreen(0);
                    }

                    shouldRetry = CheckIfShouldRetry();
                }
                else
                {
                    shouldRetry = false;
                    Console.WriteLine("Error: Settings.cs | WindowSize");
                }
            } while (shouldRetry);
        }

        /// <summary>
        /// Prints the board and the numbers
        /// </summary>
        /// <param name="board">game board</param>
        static void PrintBoard(Board board)
        {
            Walls walls = new();

            walls.PrintUpperWalls(board);

            for (int row = 0; row < board.GetLength(1) - 1; row++)
            {
                for (int times = 0; times < 3; times++)
                {
                    if (times == 1)
                    {
                        walls.PrintHorizontalWalls(board, row);
                    }
                    else
                    {
                        walls.PrintHorizontalWalls(board);
                    }
                }

                walls.PrintMiddleWalls(board);
            }

            for (int times = 0; times < 3; times++)
            {
                if (times == 1)
                {
                    walls.PrintHorizontalWalls(board, board.GetLength(1) - 1);
                }
                else
                {
                    walls.PrintHorizontalWalls(board);
                }
            }

            walls.PrintLowerWalls(board);
        }

        /// <summary>
        /// Waits for users interaction and then moves
        /// </summary>
        /// <param name="board">game board</param>
        static void GetDirectionAndMove(Board board)
        {
            bool isValid;

            do
            {
                isValid = true;
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        board.Up();
                        break;

                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        board.Left();
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        board.Down();
                        break;

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        board.Right();
                        break;

                    default:
                        isValid = false;
                        break;
                }
            } while (!isValid);
        }

        /// <summary>
        /// Spawns new blocks
        /// </summary>
        /// <param name="board">game board</param>
        /// <param name="repetitions">how many new blocks should be spawned</param>
        static void SpawnBlock(Board board, int repetitions = 1)
        {
            Random rndm = new();
            int randomRow;
            int randomCol;

            for (int i = 0; i < repetitions; i++)
            {
                do
                {
                    randomRow = rndm.Next(board.GetLength(0));
                    randomCol = rndm.Next(board.GetLength(1));
                } while (board.GetNumber(randomRow, randomCol) != 0);

                if (rndm.Next(1, 11) == 10)
                    board.SetNumber(4, randomRow, randomCol);
                else
                    board.SetNumber(2, randomRow, randomCol);
            }
        }

        /// <summary>
        /// Checks if any move is possible
        /// </summary>
        /// <param name="board">game board</param>
        /// <returns>if any move is possible</returns>
        static bool IsAnyMovePossible(Board board)
        {
            Board board2 = new();
            board2.SetSize(board.GetLength(0), board.GetLength(1));

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board2.SetNumber(board.GetNumber(row, col), row, col);
                }
            }

            bool isAnyMovePossible = true;

            if (board2.IsFull())
            {
                board2.Up();
                board2.Left();
                board2.Down();
                board2.Right();

                isAnyMovePossible = false;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board2.GetNumber(row, col) != board.GetNumber(row, col))
                        {
                            isAnyMovePossible = true;
                        }
                    }
                }
            }

            return isAnyMovePossible;
        }

        /// <summary>
        /// Checks if the player has won
        /// </summary>
        /// <param name="board">game board</param>
        /// <returns>if the player has won</returns>
        static bool CheckIfHasWon(Board board)
        {
            bool hasWon = false;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board.GetNumber(row, col) == 1048576)
                    {
                        hasWon = true;
                    }
                }
            }

            return hasWon;
        }

        /// <summary>
        /// Waits for user if he wants to retry
        /// </summary>
        /// <returns>if the user wants to retry</returns>
        static bool CheckIfShouldRetry()
        {
            bool? shouldRetry = null;

            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Y:
                    case ConsoleKey.J:
                        shouldRetry = true;
                        break;

                    case ConsoleKey.N:
                        shouldRetry = false;
                        break;
                }
            } while (shouldRetry == null);

            return Convert.ToBoolean(shouldRetry);
        }
    }
}