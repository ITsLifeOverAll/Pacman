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
        => Members[ghost.Index] = new Ghost(World, ghost.Index);

    public void GhostsMove(Pacman pacman)
    {
        foreach (var ghost in Members)
        {
            World.ShowGhost(ghost);
            
            ghost.StepFrame = ++ghost.StepFrame % ghost.MaxStepFrame;
            if (ghost.StepFrame != 0) continue;

            if (ghost.Weak) continue;

            // var direction = World.GetRandomDirection(ghost.Position);
            var direction = World.GhostAlgorithmDirection(ghost, pacman);
            
            var newPosition = World.GetPosition(ghost.Position, direction);
            World.ClearGhost(ghost);
            ghost.Position = newPosition;
            World.ShowGhost(ghost);
        }
    }
}

public class Ghost(World world, int index)
{
    public int Index = index;
    public Position Position = world.GhostStartPositions[index];
    public Direction Direction = Direction.None;
    public ConsoleColor Color = Ghosts.Colors[index];
    public bool Weak { get; set; }
    public int StepFrame;
    public int MaxStepFrame = 4;
    public Position? FirstDestination = world.GhostFirstDestinations[index];
}