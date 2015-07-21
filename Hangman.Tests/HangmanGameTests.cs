using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman.Tests
{
    /*
     *  This is a unit test project, we can use this to test our code works without having to
     *  run the software ourselves  
     */

    [TestClass]
    public class HangmanGameTests
    {
        [TestMethod]
        public void test_GetClue_blank_when_no_guesses()
        {
            var game = new HangmanGame()
            {
                CurrentGameWord = "Test",
                GuessedLetters = new HashSet<char>()
            };

            const string expected = "_ _ _ _ ";
            Assert.AreEqual(expected, game.GetClue(game.CurrentGameWord, game.GuessedLetters));
        }

        // TODO: This fails, stop it failing!
        [TestMethod]
        public void test_GetClue_includes_guessess()
        {
            var game = new HangmanGame()
            {
                CurrentGameWord = "Test",
                GuessedLetters = new HashSet<char>()
            };

            game.GuessedLetters.Add('e');
            const string expected = "_ e _ _ ";
            Assert.AreEqual(expected, game.GetClue(game.CurrentGameWord, game.GuessedLetters));
        }

        // TODO: This fails, stop it failing!
        [TestMethod]
        public void test_GetClue_includes_guessess_ignoring_case()
        {
            var game = new HangmanGame()
            {
                CurrentGameWord = "Test",
                GuessedLetters = new HashSet<char>()
            };

            game.GuessedLetters.Add('E');
            const string expected = "_ e_ _ ";
            Assert.AreEqual(expected, game.GetClue(game.CurrentGameWord, game.GuessedLetters));
        }

        // TODO: This fails, stop it failing!
        [TestMethod]
        public void test_IsGoodGuess_returns_true_when_guess_is_correct()
        {
            var game = new HangmanGame()
            {
                CurrentGameWord = "Test",
                GuessedLetters = new HashSet<char>()
            };

            Assert.IsTrue(game.IsGoodGuess('a', "abc"));
        }


        // TODO: This fails, stop it failing!
        [TestMethod]
        public void test_IsGoodGuess_returns_false_when_guess_is_incorrect()
        {
            var game = new HangmanGame()
            {
                CurrentGameWord = "Test",
                GuessedLetters = new HashSet<char>()
            };

            Assert.IsFalse(game.IsGoodGuess('a', "zbc"));
        }
        // TODO: Write more tests
    }


}
