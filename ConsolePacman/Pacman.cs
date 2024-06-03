namespace ConsolePacman;

public class Pacman
{
    private readonly World _world;
    public Direction Direction { get; set; }
    public Position Position { get; set; }
    
    public int StepFrame; 
    public const int MaxStepFrame = 1;
    public const int MaxPowerTimes = 100;
    public const int TailPowerTimes = 30;
    public int PowerTimes { get; set; }
    
    public Pacman(World world)
    {
        _world = world;
        Position = _world.PacmanStartPosition;
        Direction = Direction.None;
    }

    public void PacmanMove()
    {
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

    private Position StepWayTo(Direction direction)
    {
        _world.ClearPacman(Position);
        var newPosition = _world.GetPosition(Position, direction);
        _world.ShowPacman(this, newPosition);
        return newPosition;
    }

    private Direction TakeDirection()
    {
        if (_world.Directions.Count == 0) return Direction;
        return _world.Directions.Dequeue();
    }
}

