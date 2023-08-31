/* Author: André V. Wildberger *
 * Date: August 2023           */
namespace game2048
{
    internal class GameScreens
    {
        static readonly string[] two =  {   " .----------------. ",
                                            "| .--------------. |",
                                            "| |    _____     | |",
                                            "| |   / ___ `.   | |",
                                            "| |  |_/___) |   | |",
                                            "| |   .'____.'   | |",
                                            "| |  / /____     | |",
                                            "| |  |_______|   | |",
                                            "| |              | |",
                                            "| '--------------' |",
                                            " '----------------' "};

        static readonly string[] zero = {   " .----------------. ",
                                            "| .--------------. |",
                                            "| |     ____     | |",
                                            "| |   .'    '.   | |",
                                            "| |  |  .--.  |  | |",
                                            "| |  | |    | |  | |",
                                            "| |  |  `--'  |  | |",
                                            "| |   '.____.'   | |",
                                            "| |              | |",
                                            "| '--------------' |",
                                            " '----------------' " };

        static readonly string[] four = {   " .----------------. ",
                                            "| .--------------. |",
                                            "| |   _    _     | |",
                                            "| |  | |  | |    | |",
                                            "| |  | |__| |_   | |",
                                            "| |  |____   _|  | |",
                                            "| |      _| |_   | |",
                                            "| |     |_____|  | |",
                                            "| |              | |",
                                            "| '--------------' |",
                                            " '----------------' " };

        static readonly string[] eight ={   " .----------------. ",
                                            "| .--------------. |",
                                            "| |     ____     | |",
                                            "| |   .' __ '.   | |",
                                            "| |   | (__) |   | |",
                                            "| |   .`____'.   | |",
                                            "| |  | (____) |  | |",
                                            "| |  `.______.'  | |",
                                            "| |              | |",
                                            "| '--------------' |",
                                            " '----------------'" };

        static readonly string[] goal = {    @"   ___                             _              _     _   __  __ _ _ _ _         ___ ",
                                             @"  / __|__ _ _ _    _  _ ___ _  _  | |__  ___ __ _| |_  / | |  \/  (_) | (_)___ _ _|__ \",
                                             @" | (__/ _` | ' \  | || / _ \ || | | '_ \/ -_) _` |  _| | | | |\/| | | | | / _ \ ' \ /_/",
                                             @"  \___\__,_|_||_|  \_, \___/\_,_| |_.__/\___\__,_|\__| |_| |_|  |_|_|_|_|_\___/_||_(_) ",
                                             @"                   |__/                                                                " };

        /// <summary>
        /// Prints the start screen.
        /// </summary>
        public void StartScreen()
        {
            Console.Clear();

            int waitTime = 750;

            for (int i = 0; i < two.Length; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(two[i]);
            }

            Thread.Sleep(waitTime);

            for (int i = 0; i < zero.Length; i++)
            {
                Console.SetCursorPosition(22, i);
                Console.WriteLine(zero[i]);
            }

            Thread.Sleep(waitTime);

            for (int i = 0; i < four.Length; i++)
            {
                Console.SetCursorPosition(44, i);
                Console.WriteLine(four[i]);
            }

            Thread.Sleep(waitTime);

            for (int i = 0; i < eight.Length; i++)
            {
                Console.SetCursorPosition(66, i);
                Console.WriteLine(eight[i]);
            }

            Thread.Sleep(waitTime);

            Console.WriteLine();

            for (int i = 0; i < goal.Length; i++)
            {
                Console.WriteLine(goal[i]);
            }

            Thread.Sleep(waitTime * 2);
        }

        static readonly string[] losingText = {     @" _        _    _                       _                    _  __",
                                                    @"| |   ___(_)__| |___ _ _  __ _____ _ _| |___ _ _ ___ _ _   (_)/ /",
                                                    @"| |__/ -_) / _` / -_) '_| \ V / -_) '_| / _ \ '_/ -_) ' \   _| | ",
                                                    @"|____\___|_\__,_\___|_|    \_/\___|_| |_\___/_| \___|_||_| (_) | ",
                                                    @"                                                              \_\" };

        static readonly string[] winningText = {    @"  ___                                   _   ___  ",
                                                    @" / __|_____ __ _____ _ _  _ _  ___ _ _ | | (_) \ ",
                                                    @"| (_ / -_) V  V / _ \ ' \| ' \/ -_) ' \|_|  _ | |",
                                                    @" \___\___|\_/\_/\___/_||_|_||_\___|_||_(_) (_)| |",
                                                    @"                                             /_/ " };

        static readonly string[] retryText = {      @"   ___                   _                            _            ___ ",
                                                    @"  | __|_ _ _ _  ___ _  _| |_  __ _____ _ _ ____  _ __| |_  ___ _ _|__ \",
                                                    @"  | _|| '_| ' \/ -_) || |  _| \ V / -_) '_(_-< || / _| ' \/ -_) ' \ /_/",
                                                    @"  |___|_| |_||_\___|\_,_|\__|  \_/\___|_| /__/\_,_\__|_||_\___|_||_(_) ",
                                                    @"                                                                       " };

        static readonly string[] Y_N = { @"  __  __   __    __  _  _   __ ",
                                         @" | _| \ \ / /   / / | \| | |_ |",
                                         @" | |   \ V /   / /  | .` |  | |",
                                         @" | |    |_|   /_/   |_|\_|  | |",
                                         @" |__|                      |__|" };

        /// <summary>
        /// prints the end screen
        /// </summary>
        /// <param name="state">0: player has lost | 1: player has won</param>
        public void EndScreen(byte state)
        {
            string[] text = { "Error: CS0165" };
            bool error = false;

            if (state == 0)
            {
                text = losingText;
            }
            else if (state == 1)
            {
                text = winningText;
            }
            else
            {
                error = true;
                Console.Clear();
                Console.WriteLine("Error: Wrong Argument");
            }

            if (!error)
            {
                Console.Clear();

                for (int col = 0; col < text[0].Length; col++)
                {
                    for (int row = 0; row < text.Length; row++)
                    {
                        Console.SetCursorPosition(col, row);

                        Console.WriteLine(text[row][col]);
                    }

                    Thread.Sleep(7);
                }

                Thread.Sleep(2500);
                Console.Clear();

                for (int col = 0; col < retryText[0].Length; col++)
                {
                    for (int row = 0; row < retryText.Length; row++)
                    {
                        Console.SetCursorPosition(col, row);

                        Console.WriteLine(retryText[row][col]);
                    }

                    Thread.Sleep(7);
                }

                for (int col = 0; col < Y_N[0].Length; col++)
                {
                    for (int row = 0; row < Y_N.Length; row++)
                    {
                        Console.SetCursorPosition(col, row + retryText.Length + 1);

                        Console.WriteLine(Y_N[row][col]);
                    }

                    Thread.Sleep(7);
                }
            }
        }
    }
}
