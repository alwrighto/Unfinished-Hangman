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
            Assert.AreEqual(expected, game.GetClue(game.CurrentGameWord));
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
            Assert.AreEqual(expected, game.GetClue(game.CurrentGameWord));
        }

        // TODO: Write more tests
    }
}
