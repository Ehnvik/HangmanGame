namespace HangmanGame;

internal class HangmanGame
{

    private static void Main()
    {
        var game = new GameLogic(new Words());
        game.StartGame();

    }


}
