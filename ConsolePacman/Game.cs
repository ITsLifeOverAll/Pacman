namespace ConsolePacman;

public class Game
{
    private readonly World _world;
    private readonly Pacman _pacman;
    private readonly Ghosts _ghosts;

    public Game(int ghostCount=4)
    {
        _world = new World();
        _pacman = new Pacman(_world);
        _ghosts = new Ghosts(_world, ghostCount);
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
        _world.ShowTextReady();
        Console.SetCursorPosition(0, 24);
        Console.WriteLine("Press [Enter] to play, [Escape] to quit.");
        
        var key = ConsoleKey.NoName;
        while (key != ConsoleKey.Enter && key != ConsoleKey.Escape) key = Console.ReadKey(true).Key;
        
        Console.SetCursorPosition(0, 24);
        Console.WriteLine();
        _world.EraseTextReady();
        
        return (key is ConsoleKey.Enter);
    }

    private void ShowWorldGetReady()
    {
        _world.ShowWorld();
        _world.ShowDots();
        _world.ShowPacman(_pacman);
        _ghosts.Members.ForEach(ghost => _world.ShowGhost(ghost));
    }
}