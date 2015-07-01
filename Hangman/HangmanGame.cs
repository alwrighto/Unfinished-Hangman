using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class HangmanGame
    {
        ///////////////////////////////////////////////////////////
        // Constants
        ///////////////////////////////////////////////////////////
        
        public const int GuessLimit = 5;

        ///////////////////////////////////////////////////////////
        // Public Properties
        ///////////////////////////////////////////////////////////
        
        public string CurrentGameWord { get; set; }

        // TODO: What is a HashSet?
        public HashSet<char> GuessedLetters { get; set; }

        ///////////////////////////////////////////////////////////
        // Utility Methods
        ///////////////////////////////////////////////////////////
        
        public void Play()
        {
            GuessedLetters = new HashSet<char>();
            CurrentGameWord = GetGameWord();

            var incorrectGuesses = 0;

            // TODO: Do something if player wins
            // TODO: Do something if player runs out of guesses

            while (incorrectGuesses < GuessLimit)
            {
                var clue = GetClue(CurrentGameWord);
                Console.WriteLine(clue);

                var guess = GetGuessFromPlayer();
                
                GuessedLetters.Add(guess);

                if (!IsGoodGuess(guess, CurrentGameWord))
                {
                    incorrectGuesses++;
                }

                PrintHangman(GuessLimit - incorrectGuesses);
            }
        }

        public string GetGameWord()
        {
            // TODO: This is hardcoded as "Goose", it should come randomly from a textfile dictionary of word (or similar)
            return "Goose";
        }

        public string[] GetHangmanDrawing(int livesLeft)
        {
            // TODO: this is always a losing drawing, what if they haven't lost yet?
            return new[]
            {
                "  ------  ",
                "  |    |  ",
                "  |    o  ",
                "  |   -|- ",
                "  |   / \\",  // \ is a special character, so we have to escape it
                "  |_____  "
            };
        }

        public void PrintHangman(int guessCount)
        {
            Console.WriteLine("Current life status");
            foreach (var line in GetHangmanDrawing(guessCount))
            {
                Console.WriteLine(line);
            }
        }

        public string GetClue(string rawWord)
        {
            var sb = new StringBuilder();
            {
                foreach (var letter in rawWord)
                {
                    // TODO: We always show an underscore, show already guessed letters
                    // use the hashset?
                    sb.AppendFormat("_ ");
                }
            }
            return sb.ToString();
        }

        public char GetGuessFromPlayer()
        {
            // TODO: this should be a validated guess from the player.
            return ' ';
        }

        public bool IsGoodGuess(char guess, string gameWord)
        {
            // We are saying that the guess is always wrong
            // TODO: validate the guess properly
            return false;
        }
    }
}
