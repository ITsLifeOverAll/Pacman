namespace ConsolePacman;

public class Pacman
{
    #region ASCII
    private readonly string[] _pacManAnimations =
    [
        "\"' '\"",
        "n. .n",
        ")>- ->",
        "(<- -<",
    ];
    #endregion

    private readonly World _world;
    public Direction Direction { get; set; }
    public Position Position { get; set; }
    
    public int StepFrame; 
    public const int MaxStepFrame = 1;
    public const int MaxPowerTimes = 100;
    public const int TailPowerTimes = 30;
    public int PowerTimes { get; set; }
    private int _faceFrame;
    
    
    public Pacman(World world)
    {
        _world = world;
        Position = _world.PacmanStartPosition;
        Direction = Direction.None;
    }

    public void Move()
    {
        if (!StepMovable()) return;
        
        var newDirectin = TakeDirection();

        if (_world.IsMovable(Position, newDirectin))
        {
            Direction = newDirectin;
            Position = StepWayTo(newDirectin);
        }
        else if (_world.IsMovable(Position, Direction))
        {
            Position = StepWayTo(Direction);
        }
        // no move 
    }

    private bool StepMovable()
    {
        StepFrame = ++StepFrame % MaxStepFrame;
        if (StepFrame == 0) return true;
        return false;
    }

    private Position StepWayTo(Direction direction)
    {
        _world.ClearPacman(Position);
        var newPosition = _world.GetPosition(Position, direction);
        _world.ShowPacman(this, newPosition, direction);
        return newPosition;
    }

    private Direction TakeDirection()
    {
        if (_world.Directions.Count == 0) return Direction;
        return _world.Directions.Dequeue();
    }

    public (ConsoleColor foregroundColor, ConsoleColor backgroundColor) GetStateColor()
    {
        return PowerTimes switch
        {
            <= 0 => (ConsoleColor.Black, ConsoleColor.Yellow),
            < TailPowerTimes => (ConsoleColor.Black, ConsoleColor.Magenta),
            _ => (ConsoleColor.Black, ConsoleColor.Cyan)
        };
    }

    public char GetFrameFace(Direction direction)
    {
        var faceRow = Convert.ToInt32(direction);
        if (faceRow < 0 || faceRow >= _pacManAnimations.Length) faceRow = 0;
        
        _faceFrame = Direction == direction
            ? ++_faceFrame % _pacManAnimations[faceRow].Length
            : 0;
        return _pacManAnimations[faceRow][_faceFrame];
    }
}

