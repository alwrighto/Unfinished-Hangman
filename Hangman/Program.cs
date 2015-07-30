using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hangman
{
    public class Program
    {
        public static void Main()
        {
            var game = new HangmanGame();

            while (true)
            {
                DisplayIntroText();

                var opt = GetMenuSelection();

                switch (opt)
                {
                    case 'X':
                        return; // Quit game
                    case 'N':
                        game.Play();
                        break;
                    default:
                        AddWordToDictionary();
                        break;
                }
            }
        }

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

        public static HashSet<char> ValidMenuOptions
        {
            get
            {
                return new HashSet<char>
                {
                    'N',
                    'W',
                    'X'
                };
            }
        }

        public static char GetMenuSelection()
        {
            while (true)
            {
                ShowMenu();

                var option = char.ToUpper(Console.ReadKey(true).KeyChar);

                if (ValidMenuOptions.Contains(option)) 
                {
                    // if it's in the list of valid options we return it for use elsewhere.
                    return option;
                }

                // if it's not a good option we loop again
                Console.WriteLine("\r\nInvalid Selection\r\n");
            }
        }




        public static void AddWordToDictionary()
        {
            Console.WriteLine();
            Console.WriteLine("Type the word you wish to add and press enter.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string addWord = Console.ReadLine();
            Console.ResetColor();
            addWord = addWord.ToUpper();
            bool result = addWord.Any(x => !char.IsLetter(x)); // heh linq, cool

            while (true)
            {
                if (result == true)
                {
                    Console.WriteLine("Invalid Input. Please enter using only the characters A-Z.");
                    break;
                }
                if (File.ReadAllLines(Properties.Settings.Default.DictionaryFile)
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
                    File.AppendAllText(Properties.Settings.Default.DictionaryFile,
                        addWord + Environment.NewLine);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Word successfully added!");
                    Console.ResetColor();
                    Console.WriteLine();
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

