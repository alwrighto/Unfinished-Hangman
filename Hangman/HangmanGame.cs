using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hangman
{
    public class HangmanGame
    {
        ///////////////////////////////////////////////////////////
        // Constants
        ///////////////////////////////////////////////////////////

        /// <summary>
        /// The maximum number of guesses before game over
        /// </summary>
        public const int GuessLimit = 8;

        ///////////////////////////////////////////////////////////
        // Public Properties
        ///////////////////////////////////////////////////////////

        /// <summary>
        /// The current game word which the player is attempting to guess
        /// </summary>
        public string CurrentGameWord { get; set; }

        // TODO: What is a HashSet?
        /// <summary>
        /// A set of the currently guessed letters.
        /// </summary>
        public HashSet<char> GuessedLetters { get; set; }

        static string Alphabetise(string output)
        { 
        char[] sorter = output.ToArray();
        Array.Sort(sorter);
        return new string(sorter);
        }

        ///////////////////////////////////////////////////////////
        // Utility Methods
        ///////////////////////////////////////////////////////////
        
        /// <summary>
        /// Starts a new game of hangman. 
        /// e.g. resets number of gueses, chooses new word etc.
        /// </summary>
        public void Play()
        {
            GuessedLetters = new HashSet<char>();
            CurrentGameWord = GetGameWord();

            var incorrectGuesses = 0;

            while (incorrectGuesses < GuessLimit)
            {

                var clue = GetClue(CurrentGameWord, GuessedLetters);

                var winCheck = clue.Replace(" ", "");

                if (winCheck.Equals(CurrentGameWord))
                {
                    Console.WriteLine();                    
                    Console.Write("The word was: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(CurrentGameWord);
                    Console.WriteLine();
                    Console.WriteLine("_____.___.               __      __.__      ._.");
                    Console.WriteLine("\\__  |   | ____  __ __  /  \\    /  \\__| ____| |");
                    Console.WriteLine(" /   |   |/  _ \\|  |  \\ \\   \\/\\/   /  |/    \\ |");
                    Console.WriteLine(" \\____   (  <_> )  |  /  \\        /|  |   |  \\|");
                    Console.WriteLine(" / ______|\\____/|____/    \\__/\\  / |__|___|  /_");
                    Console.WriteLine(" \\/                            \\/          \\/\\/");
                    Console.ResetColor();
                    return;
                }




                Console.WriteLine();
                Console.WriteLine(clue);
                Console.WriteLine();

                var guess = GetGuessFromPlayer();
                
                GuessedLetters.Add(guess);

                if (!IsGoodGuess(guess, CurrentGameWord))
                {
                    incorrectGuesses++;
                }

                if ( GuessLimit == incorrectGuesses)
                {
                    Console.WriteLine();
                    PrintHangman(GuessLimit - incorrectGuesses);
                    Console.WriteLine();
                    Console.Write("The word was: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(CurrentGameWord);
                    Console.WriteLine();
                    Console.WriteLine("_____.___.              ________  .__           .___._.");
                    Console.WriteLine("\\__  |   | ____  __ __  \\______ \\ |__| ____   __| _/| |");
                    Console.WriteLine(" /   |   |/  _ \\|  |  \\  |  | |  \\|  |/ __ \\ / __ | | |");
                    Console.WriteLine(" \\____   (  <_> )  |  /  |  |_|   \\  \\  ___// /_/ |  \\|");
                    Console.WriteLine(" / ______|\\____/|____/  /_______  /__|\\___  >____ |  __");
                    Console.WriteLine(" \\/                             \\/        \\/     \\/  \\/");
                    Console.WriteLine();
                    Console.ResetColor();
                    return;
                }

                PrintHangman(GuessLimit - incorrectGuesses);
                Console.WriteLine();
                string output = string.Join("", GuessedLetters);
                string sorter = Alphabetise(output);
                var sb = new StringBuilder();
                {
                    foreach (var letter in sorter)
                        sb.Append(letter + " ");
                }
                string arranged = sb.ToString();
                Console.WriteLine("The letters you have guessed so far are - " + arranged.ToUpper());
                Console.WriteLine();


            }


            

        }

        /// <summary>
        /// Gets a new word for the player to guess
        /// </summary>
        /// <returns>A string that represents the word the user should attempt to guess</returns>
        /// <remarks>Broken, needs fixing</remarks>
        public string GetGameWord()
        {
            string[] allLines = File.ReadAllLines(Properties.Settings.Default.DictionaryFile);
            Random rnd1 = new Random();
            string wordFromFile = (allLines[rnd1.Next(allLines.Length)]);
            return wordFromFile;                     
        }



        /// <summary>
        /// Gets a drawing of the current state of the game
        /// </summary>
        /// <param name="livesLeft">The number of lives remaining before game over</param>
        /// <returns>A string array that represents the state of the game</returns>
        /// <remarks>Broken, needs fixing. Considder the following: If else, Switch, Dictionary&lt;int,List&lt;string&gt;&gt;</remarks>
        ///TODO: investigate this thing? Dictionary<int, string> rttt = new Dictionary<int, string>();
        /// TODO: this is always a losing drawing, what if they haven't lost yet?
        public string[] GetHangmanDrawing(int livesLeft)
        {

            string[] eightLives = new string[]
            {
            "   _____",
            "  |     ",
            "  |     ",
            "  |    ",
            "  |     ",
            "  |    ",
            "  |",
            "__|__"
            };
            string[] sevenLives = new string[]
            {
            "   _____",
            "  |     |",
            "  |     ",
            "  |    ",
            "  |     ",
            "  |    ",
            "  |",
            "__|__"
            };
            string[] sixLives = new string[]
            {
            "   _____",
            "  |     |",
            "  |     o",
            "  |    ",
            "  |     ",
            "  |    ",
            "  |",
            "__|__"
            };
            string[] fiveLives = new string[]
            {
            "   _____",
            "  |     |",
            "  |     o",
            "  |     |",
            "  |     ",
            "  |    ",
            "  |",
            "__|__"
            };
            string[] fourLives = new string[]
            {
            "   _____",
            "  |     |",
            "  |     o",
            "  |    \\|",
            "  |     ",
            "  |    ",
            "  |",
            "__|__"
            };
            string[] threeLives = new string[]
            {
            "   _____",
            "  |     |",
            "  |     o",
            "  |    \\|/",
            "  |     ",
            "  |    ",
            "  |",
            "__|__"
            };
            string[] twoLives = new string[]
            {
            "   _____",
            "  |     |",
            "  |     o",
            "  |    \\|/",
            "  |     |",
            "  |    ",
            "  |",
            "__|__"
            };
            string[] oneLives = new string[]
            {
            "   _____",
            "  |     |",
            "  |     o",
            "  |    \\|/",
            "  |     |",
            "  |    / ",
            "  |",
            "__|__"
            };
            string[] zeroLives = new string[]
            {
            "   _____",
            "  |     |",
            "  |     o",
            "  |    \\|/",
            "  |     |",
            "  |    / \\",
            "  |",
            "__|__"
            };

            
            Dictionary<int, string[]> hangmanDiagrams = new Dictionary<int, string[]>();

            hangmanDiagrams.Add(8, eightLives);
            hangmanDiagrams.Add(7, sevenLives);
            hangmanDiagrams.Add(6, sixLives);
            hangmanDiagrams.Add(5, fiveLives);
            hangmanDiagrams.Add(4, fourLives);
            hangmanDiagrams.Add(3, threeLives);
            hangmanDiagrams.Add(2, twoLives);
            hangmanDiagrams.Add(1, oneLives);
            hangmanDiagrams.Add(0, zeroLives);
            
            string[] getDiagram;
            if (hangmanDiagrams.TryGetValue(livesLeft, out getDiagram))
            {
                return getDiagram;
            }
            else
                return new[] { "ERROR" };
        }


        /// <summary>
        /// Prints the current state of the game to the console.
        /// </summary>
        /// <param name="livesLeft">The number of lives remaining before game over</param>
        public void PrintHangman(int livesLeft)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("                                                                                ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Current life status");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (var line in GetHangmanDrawing(livesLeft))
            {
                Console.WriteLine(line);
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Gets a clue based on the number of known letters
        /// </summary>
        /// <param name="rawWord">The raw game word</param>
        /// <returns>The game word with unknowns replaced by _ </returns>
        public string GetClue(string rawWord, HashSet<char> guessedLetters)
        {
            var sb = new StringBuilder();
            {
                foreach (var letter in rawWord)
                {
                    if (guessedLetters.Contains(letter))
                    {                       
                        sb.Append(letter + " ");
                    }
                    else
                    {
                        sb.AppendFormat("_ ");
                    }              
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Gets a guess from a user, should repeat if input was invalid (e.g. if they enter multiple characters)
        /// </summary>
        /// <returns>The character entered by the user</returns>
        public char GetGuessFromPlayer()
        {
            bool validInput = false;
            Console.WriteLine();
            Console.WriteLine("Please enter your guess.");
            Console.WriteLine();


            while (true)
            {
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                string guess = userInput.KeyChar.ToString();
                Console.WriteLine();
                bool result = guess.Any(x => !char.IsLetter(x));

                while (true)
                {
                    if (GuessedLetters.Contains(Convert.ToChar(guess.ToUpper())))
                    {
                        Console.WriteLine("You have already guessed that letter. Please make another guess.");
                        break;
                    }
                    else if (validInput == true)
                        {
                        validInput = false;
                        break;
                        }
                    else
                    {
                        while (true)
                        {
                            if (result == false)
                            {
                                return Convert.ToChar(guess.ToUpper());
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter your guess in the form of a letter (A-Z) only");
                                validInput = true;
                                break;

                            }
                        }
                    }
                }


            }
        }
       
        /// <summary>
        /// Validates if a guess is good
        /// </summary>
        /// <param name="guess">The guess made by the player</param>
        /// <param name="gameWord">The game word the player is attempting to guess</param>
        /// <returns>True if good guess, otherwise false.</returns>
        /// <remarks>
        /// TODO:Could modify to also take hashset of guesses and let user know if they make same guess twice
        /// </remarks>
        public bool IsGoodGuess(char guess, string gameWord)
        {
            if (gameWord.Contains(guess))
            {
            return true;
            }
            else
            {
            return false;
            }
        }
    }
}
