namespace Hangman
{
    public class Program
    {
        static void Main()
        {
            var game = new HangmanGame();

            while (true) // play forever
            {
                game.Play();

                // TODO: Let user choose whether to play again
            }
        }


        // TODO: Extension ideas

        // 1. Implement a high scores screen
        // 2. Allow users to add new words to the word dictionary through the program.
        // 3. Anything else you think will be fun or help you reinforce ideas. 

        // Happy hacking.
    }
}
