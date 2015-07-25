using System;

namespace Hangman
{
    public class Program
    {

        public static void Main()

        {
            String playAgainString = "Z";
            ConsoleKeyInfo playAgain;

            var game = new HangmanGame();

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   /\\  /\\ __ _  _ __    __ _  _ __ ___    __ _  _ __  ");
            Console.WriteLine("  / /_/ // _` || '_ \\  / _` || '_ ` _ \\  / _` || '_ \\ ");
            Console.WriteLine(" / __  /| (_| || | | || (_| || | | | | || (_| || | | |");
            Console.WriteLine(" \\/ /_/  \\__,_||_| |_| \\__, ||_| |_| |_| \\__,_||_| |_|");
            Console.WriteLine("                       |___/                          ");
            Console.ResetColor();

            while (true)
            {
                playAgainString = "Z";
                Console.WriteLine();
                Console.WriteLine("Press N to begin a new game.");
                Console.WriteLine();
                Console.WriteLine("Press E to Exit");


                while (true)
                {
                    if (playAgainString == "X")
                    {
                        break;
                    }
                    else
                    {
                        ConsoleKeyInfo startGame = Console.ReadKey(true);
                        if (startGame.KeyChar.ToString().ToUpper() == "E")
                        {
                            return;
                        }

                        else if (startGame.KeyChar.ToString().ToUpper() == "N")
                        {
                            while (true)
                            {
                                game.Play();
                                Console.WriteLine();
                                Console.WriteLine("Would you like to play again? Y/N?");
                                Console.WriteLine();
                                playAgain = Console.ReadKey(true);
                                playAgainString = playAgain.KeyChar.ToString().ToUpper();

                                while (playAgainString != "Y" && playAgainString != "N")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Invalid Input. Would you like to play again? Y/N?");
                                    Console.WriteLine();
                                    playAgain = Console.ReadKey(true);
                                    playAgainString = playAgain.KeyChar.ToString().ToUpper();
                                }

                                if (playAgainString == "N")
                                {
                                    playAgainString = "X";
                                    break;
                                }
                            }


                        }

                        else
                        {
                            break;
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
}

