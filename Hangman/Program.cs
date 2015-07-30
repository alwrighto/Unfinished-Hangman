using System;
using System.IO;
using System.Linq;

namespace Hangman
{
    public class Program
    {
        public static void DisplayIntroText()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   /\\  /\\ __ _  _ __    __ _  _ __ ___    __ _  _ __  ");
            Console.WriteLine("  / /_/ // _` || '_ \\  / _` || '_ ` _ \\  / _` || '_ \\ ");
            Console.WriteLine(" / __  /| (_| || | | || (_| || | | | | || (_| || | | |");
            Console.WriteLine(" \\/ /_/  \\__,_||_| |_| \\__, ||_| |_| |_| \\__,_||_| |_|");
            Console.WriteLine("                       |___/                          ");
            Console.ResetColor();
        }

        public static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Press N to begin a new game.");
            Console.WriteLine();
            Console.WriteLine("Press W to add a new word to the dictionary.");
            Console.WriteLine();
            Console.WriteLine("Press X to Quit");
        }


        public static void Main()
        {

            DisplayIntroText();

            ShowMenu();

            String playAgainString = "Z";
            
            ConsoleKeyInfo playAgain;

            var game = new HangmanGame();

            while (true)
            {
                playAgainString = "Z";



                while (true)
                {
                    if (playAgainString == "X")
                    {
                        break;
                    }
                    else
                    {
                        ConsoleKeyInfo startGame = Console.ReadKey(true);
                        if (startGame.KeyChar.ToString().ToUpper() == "X")
                        {
                            return;
                        }

                        else if (startGame.KeyChar.ToString().ToUpper() == "N")
                        {
                            while (true)
                            {
                                if (playAgainString == "X")
                                {
                                    break;
                                }
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
                        else if (startGame.KeyChar.ToString().ToUpper() == "W")
                        {
                            while (true)
                            {
                                if (playAgainString == "X")
                                {
                                    break;
                                }
                                Console.WriteLine();
                                Console.WriteLine("Type the word you wish to add and press enter.");
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                string addWord = Console.ReadLine();
                                Console.ResetColor();
                                addWord = addWord.ToUpper();
                                bool result = addWord.Any(x => !char.IsLetter(x));

                                while (true)
                                {
                                    if (playAgainString == "X")
                                    {
                                        break;
                                    }
                                    if (result == true)
                                    {
                                        Console.WriteLine("Invalid Input. Please enter using only the characters A-Z.");
                                        break;
                                    }
                                    if (File.ReadAllLines(@"C:\Users\Alex\Documents\Visual Studio 2015\Projects\Hangman\Hangman\WordList.txt")
                                        .Contains(addWord))
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Error. This word already exists in the dictionary.");
                                        break;
                                    }

                                    Console.WriteLine();
                                    Console.Write("The word you typed was: ");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine(addWord);
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    Console.WriteLine("Is this correct?");
                                    Console.WriteLine();
                                    Console.WriteLine("Press Y to accept and save.");
                                    Console.WriteLine("Press N to re-type the word.");
                                    Console.WriteLine("Press M to return to the menu.");
                                    Console.WriteLine("Press X to quit.");
                                    ConsoleKeyInfo wordEntry = Console.ReadKey(true);
                                    String wordEntryString = wordEntry.KeyChar.ToString().ToUpper();
                                    Console.WriteLine();

  
                                    if (wordEntryString == "N")
                                    {
                                        break;
                                    }
                                    else if (wordEntryString == "Y")
                                    {
                                        File.AppendAllText(@"C:\Users\Alex\Documents\Visual Studio 2015\Projects\Hangman\Hangman\WordList.txt", 
                                            addWord + Environment.NewLine);
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Word successfully added!");
                                        Console.ResetColor();
                                        Console.WriteLine();
                                        playAgainString = "X";
                                        break;
                                    }
                                    else if (wordEntryString == "M")
                                    {
                                        playAgainString = "X";
                                        break;
                                    }
                                    else if (wordEntryString == "X")
                                    {
                                        return;
                                    }
                                    
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

