public class Game
{
    private readonly World _world;
    private readonly Pacman _pacman;
    private readonly Ghosts _ghosts;

    public Game(int ghostCount=4)
    {
        _world = new World();
        _pacman = new Pacman();
        _ghosts = new Ghosts(ghostCount);
    }

    public async Task<bool> RunAsync()
    {
        ShowWorldGetReady();
        if (!StartGame()) return false;

        await PlayAsync();

        return AskPlayAgain(); 
    }

    private bool AskPlayAgain()
    {
        // todo AskPlayAgain
        return false;
    }

    private async Task PlayAsync()
    {
        // todo PlayAsync
    }

    private bool StartGame()
    {
        Console.WriteLine("Press [Enter] to play, [Escape] to quit.");
        var key = ConsoleKey.NoName;
        while (key != ConsoleKey.Enter && key != ConsoleKey.Escape) key = Console.ReadKey(true).Key;
        return (key is ConsoleKey.Enter);
    }

    private void ShowWorldGetReady()
    {
        // todo ShowWorldGetReady
        _world.ShowWorld();
        _world.ShowDots();
        // _world.ShowPacman();
        // _world.ShowGhosts();
    }
}