using System;
using System.Collections.Generic;
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
        public const int GuessLimit = 3;

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

            // TODO: Do something if player wins
            // TODO: Do something if player runs out of guesses

            while (incorrectGuesses < GuessLimit)
            {

                var clue = GetClue(CurrentGameWord, GuessedLetters);
                Console.WriteLine();
                Console.WriteLine(clue);
                Console.WriteLine();

                var guess = GetGuessFromPlayer();
                
                GuessedLetters.Add(guess);

                if (!IsGoodGuess(guess, CurrentGameWord))
                {
                    incorrectGuesses++;
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

                if (clue == CurrentGameWord)
                {
                    Console.WriteLine("YOU WIN!");
                    break;
                }

            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("YOU DIED!");
            Console.WriteLine();
            Console.ResetColor();

        }

        /// <summary>
        /// Gets a new word for the player to guess
        /// </summary>
        /// <returns>A string that represents the word the user should attempt to guess</returns>
        /// <remarks>Broken, needs fixing</remarks>
        public string GetGameWord()
        {
            // TODO: This is hardcoded as "Goose", it should come randomly from a textfile dictionary of word (or similar)
            return "GOOSE";
        }

        /// <summary>
        /// Gets a drawing of the current state of the game
        /// </summary>
        /// <param name="livesLeft">The number of lives remaining before game over</param>
        /// <returns>A string array that represents the state of the game</returns>
        /// <remarks>Broken, needs fixing. Considder the following: If else, Switch, Dictionary&lt;int,List&lt;string&gt;&gt;</remarks>
        public string[] GetHangmanDrawing(int livesLeft)
        {
            //TODO: investigate this thing? Dictionary<int, string> rttt = new Dictionary<int, string>();
            // TODO: this is always a losing drawing, what if they haven't lost yet?

            return new[]
            {

                "  ------  ",
                "  |    |  ",
                "  |    o  ",
                "  |   -|- ",
                "  |   / \\",
                "  |_____  "
            };
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
            Console.ForegroundColor = ConsoleColor.Green;
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

                    // We are doing this, but it doesnm't work if case was wrong
                    // TODO: Ignore case!
                    if (guessedLetters.Contains(letter))
                    {                       
                        sb.Append(letter + " ");
                    }
                    else
                    {
                        sb.AppendFormat("_ ");
                    }

                    //sb.AppendFormat("{0} ", guessedLetters.Contains(letter) ? letter : '_');                 
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
                    if (result == false)
                    {
                        return Convert.ToChar(guess.ToUpper());
                    }
                    else 
                    {
                        Console.WriteLine("Invalid input. Please enter your guess in the form of a letter (A-Z) only");
                        break;
                        
                    }
                }
            }
        }


        


            
            

            // TODO: this should be a validated guess from the player.

        

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
            // We are saying that the guess is always wrong
            // TODO: validate the guess properly
        }
    }
}
