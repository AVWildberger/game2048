/* Author: André V. Wildberger *
 * Date: August 2023           */
namespace game2048
{
    internal class Themes
    {
        /// <summary>
        /// Sets the theme of the game.
        /// </summary>
        /// <param name="theme">red, green, blue, magenta | default: empty</param>
        public void SetTheme(string theme = "")
        {
            switch (theme)
            {
                case "red":
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "green":
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case "blue":
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "magenta":
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }
    }
}
