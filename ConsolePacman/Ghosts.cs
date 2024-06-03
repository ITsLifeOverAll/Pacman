using System.IO.MemoryMappedFiles;

namespace ConsolePacman;

public class Ghosts
{
    public List<Ghost> Members { get; set; }
    public World World { get; set; }
    public static ConsoleColor[] Colors =
        [ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Magenta];

    public Ghosts(World world, int ghostCount)
    {
        World = world;
        Members = new List<Ghost>();
        for (int i = 0; i < ghostCount; i++)
        {
            Members.Add(new Ghost(World, i));
        }
    }


    public void Reborn(Ghost ghost) 
        => Members[ghost.index] = new Ghost(World, ghost.index);
}

public class Ghost(World world, int index)
{
    public int index;
    public Position Position = world.GhostStartPositions[index];
    public Direction Direction = Direction.None;
    public ConsoleColor Color = Ghosts.Colors[index];
    public bool Weak { get; set; }
}