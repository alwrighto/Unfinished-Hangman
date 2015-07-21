using System;

namespace Hangman
{
    public class Program
    {

        public static void Main()

        {
            var game = new HangmanGame();

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   /\\  /\\ __ _  _ __    __ _  _ __ ___    __ _  _ __  ");
            Console.WriteLine("  / /_/ // _` || '_ \\  / _` || '_ ` _ \\  / _` || '_ \\ ");
            Console.WriteLine(" / __  /| (_| || | | || (_| || | | | | || (_| || | | |");
            Console.WriteLine(" \\/ /_/  \\__,_||_| |_| \\__, ||_| |_| |_| \\__,_||_| |_|");
            Console.WriteLine("                       |___/                          ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Press N to begin a new game.");
            Console.WriteLine();


            while (true)
            {
                ConsoleKeyInfo startGame = Console.ReadKey(true);
                if (startGame.KeyChar.ToString().ToUpper() != "N")
                {
                    Console.WriteLine("Press N to begin a new game.");
                    Console.WriteLine();
                }

                else
                {
                    while (true) // play forever
                    {
                        game.Play();
                        ConsoleKeyInfo playAgain = Console.ReadKey(true);
                        Console.WriteLine();
                        Console.WriteLine("Would you like to play again? Y/N?");
                        Console.WriteLine();

                        while (playAgain.KeyChar.ToString().ToUpper() != "Y" && playAgain.KeyChar.ToString().ToUpper() != "N")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Invalid Input. Would you like to play again? Y/N?");
                            Console.WriteLine();
                            playAgain = Console.ReadKey(true);
                        }

                        if (playAgain.KeyChar.ToString().ToUpper() == "N")
                        {
                            return;
                        }
                    }


                }
            }


            // TODO: Extension ideas

            // 1. Implement a high scores screen
            // 2. Allow users to add new words to the word dictionary through the program.
            // 3. Anything else you think will be fun or help you reinforce ideas. 

            // Happy hacking.
        }
    }
}

