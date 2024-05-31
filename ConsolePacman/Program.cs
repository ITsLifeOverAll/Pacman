
bool playAgain;
do
{
    var game = new Game();
    var gameTask = game.RunAsync();
    playAgain = await gameTask;
} while (playAgain);