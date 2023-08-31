/* Author: André V. Wildberger *
 * Date: August 2023           */
namespace game2048
{
    internal class Walls
    {
        /// <summary>
        /// Prints the horizontal walls with the value
        /// </summary>
        /// <param name="board">game board</param>
        /// <param name="row">row where the horizontal lines are printed</param>
        public void PrintHorizontalWalls(Board board, int row = -1) // │   │
        {
            string spaceBeforeValue;
            string spaceAfterValue;

            for (int col = 0; col <= board.GetLength(0); col++)
            {
                if (col == board.GetLength(0))
                {
                    Console.WriteLine("│");
                }
                else if (row > -1 && col > -1)
                {
                    spaceBeforeValue = new string(' ', (7 - board.GetNumber(row, col).ToString().Length) / 2);
                    spaceAfterValue = new string(' ', 7 - board.GetNumber(row, col).ToString().Length - spaceBeforeValue.Length);

                    Console.Write($"│{spaceBeforeValue}");
                    Console.Write(board.GetNumber(row, col) != 0 ? board.GetNumber(row, col) : " ");
                    Console.Write(spaceAfterValue);
                }
                else
                {
                    Console.Write("│       ");
                }
            }
        }

        /// <summary>
        /// Prints the middle walls
        /// </summary>
        /// <param name="board">game board</param>
        public void PrintMiddleWalls(Board board) // ├─┼─┤
        {
            for (int i = 0; i <= board.GetLength(0); i++)
            {
                if (i == 0)
                {
                    Console.Write("├───────");
                }
                else if (i == board.GetLength(0))
                {
                    Console.WriteLine("┤");
                }
                else
                {
                    Console.Write("┼───────");
                }
            }
        }

        /// <summary>
        /// Prints the upper walls
        /// </summary>
        /// <param name="board">game board</param>
        public void PrintUpperWalls(Board board) //┌─┬─┐
        {
            for (int i = 0; i <= board.GetLength(0); i++)
            {
                if (i == 0)
                {
                    Console.Write("┌───────");
                }
                else if (i == board.GetLength(0))
                {
                    Console.WriteLine("┐");
                }
                else
                {
                    Console.Write("┬───────");
                }
            }
        }

        /// <summary>
        /// prints the lower walls
        /// </summary>
        /// <param name="board">game board</param>
        public void PrintLowerWalls(Board board) //└─┴─┘
        {
            for (int i = 0; i <= board.GetLength(0); i++)
            {
                if (i == 0)
                {
                    Console.Write("└───────");
                }
                else if (i == board.GetLength(0))
                {
                    Console.WriteLine("┘");
                }
                else
                {
                    Console.Write("┴───────");
                }
            }
        }
    }
}
