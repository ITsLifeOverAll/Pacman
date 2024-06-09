using System.Transactions;

namespace ConsolePacman;

public class World
{
	#region Ascii

// 00 ╔═══════════════════╦═══════════════════╗
// 01 ║ · · · · · · · · · ║ · · · · · · · · · ║
// 02 ║ · ╔═╗ · ╔═════╗ · ║ · ╔═════╗ · ╔═╗ · ║
// 03 ║ + ╚═╝ · ╚═════╝ · ╨ · ╚═════╝ · ╚═╝ + ║
// 04 ║ · · · · · · · · · · · · · · · · · · · ║
// 05 ║ · ═══ · ╥ · ══════╦══════ · ╥ · ═══ · ║
// 06 ║ · · · · ║ · · · · ║ · · · · ║ · · · · ║
// 07 ╚═════╗ · ╠══════   ╨   ══════╣ · ╔═════╝
// 08       ║ · ║                   ║ · ║
// 09 ══════╝ · ╨   ╔════---════╗   ╨ · ╚══════
// 10         ·     ║ █ █   █ █ ║     ·        
// 11 ══════╗ · ╥   ║           ║   ╥ · ╔══════
// 12       ║ · ║   ╚═══════════╝   ║ · ║
// 13       ║ · ║       READY       ║ · ║
// 14 ╔═════╝ · ╨   ══════╦══════   ╨ · ╚═════╗
// 15 ║ · · · · · · · · · ║ · · · · · · · · · ║
// 16 ║ · ══╗ · ═══════ · ╨ · ═══════ · ╔══ · ║
// 17 ║ + · ║ · · · · · · █ · · · · · · ║ · + ║
// 18 ╠══ · ╨ · ╥ · ══════╦══════ · ╥ · ╨ · ══╣
// 19 ║ · · · · ║ · · · · ║ · · · · ║ · · · · ║
// 20 ║ · ══════╩══════ · ╨ · ══════╩══════ · ║
// 21 ║ · · · · · · · · · · · · · · · · · · · ║
// 22 ╚═══════════════════════════════════════╝

	private static readonly string[] WallsString = [
		"╔═══════════════════╦═══════════════════╗",
		"║                   ║                   ║",
		"║   ╔═╗   ╔═════╗   ║   ╔═════╗   ╔═╗   ║",
		"║   ╚═╝   ╚═════╝   ╨   ╚═════╝   ╚═╝   ║",
		"║                                       ║",
		"║   ═══   ╥   ══════╦══════   ╥   ═══   ║",
		"║         ║         ║         ║         ║",
		"╚═════╗   ╠══════   ╨   ══════╣   ╔═════╝",
		"      ║   ║                   ║   ║      ",
		"══════╝   ╨   ╔════   ════╗   ╨   ╚══════",
		"              ║           ║              ",
		"══════╗   ╥   ║           ║   ╥   ╔══════",
		"      ║   ║   ╚═══════════╝   ║   ║      ",
		"      ║   ║                   ║   ║      ",
		"╔═════╝   ╨   ══════╦══════   ╨   ╚═════╗",
		"║                   ║                   ║",
		"║   ══╗   ═══════   ╨   ═══════   ╔══   ║",
		"║     ║                           ║     ║",
		"╠══   ╨   ╥   ══════╦══════   ╥   ╨   ══╣",
		"║         ║         ║         ║         ║",
		"║   ══════╩══════   ╨   ══════╩══════   ║",
		"║                                       ║",
		"╚═══════════════════════════════════════╝",];

	public	static readonly string[] GhostWallsString = [
		"╔═══════════════════╦═══════════════════╗",
		"║█                 █║█                 █║",
		"║█ █╔═╗█ █╔═════╗█ █║█ █╔═════╗█ █╔═╗█ █║",
		"║█ █╚═╝█ █╚═════╝█ █╨█ █╚═════╝█ █╚═╝█ █║",
		"║█                                     █║",
		"║█ █═══█ █╥█ █══════╦══════█ █╥█ █═══█ █║",
		"║█       █║█       █║█       █║█       █║",
		"╚═════╗█ █╠══════█ █╨█ █══════╣█ █╔═════╝",
		"██████║█ █║█                 █║█ █║██████",
		"══════╝█ █╨█ █╔════█ █════╗█ █╨█ █╚══════",
		"             █║█         █║█             ",
		"══════╗█ █╥█ █║███████████║█ █╥█ █╔══════",
		"██████║█ █║█ █╚═══════════╝█ █║█ █║██████",
		"██████║█ █║█                 █║█ █║██████",
		"╔═════╝█ █╨█ █══════╦══════█ █╨█ █╚═════╗",
		"║█                 █║█                 █║",
		"║█ █══╗█ █═══════█ █╨█ █═══════█ █╔══█ █║",
		"║█   █║█                         █║█   █║",
		"╠══█ █╨█ █╥█ █══════╦══════█ █╥█ █╨█ █══╣",
		"║█       █║█       █║█       █║█       █║",
		"║█ █══════╩══════█ █╨█ █══════╩══════█ █║",
		"║█                                     █║",
		"╚═══════════════════════════════════════╝",];

	private static readonly string[] DotsString = [
		"                                         ",
		"  · · · · · · · · ·   · · · · · · · · ·  ",
		"  ·     ·         ·   ·         ·     ·  ",
		"  +     ·         ·   ·         ·     +  ",
		"  · · · · · · · · · · · · · · · · · · ·  ",
		"  ·     ·   ·               ·   ·     ·  ",
		"  · · · ·   · · · ·   · · · ·   · · · ·  ",
		"        ·                       ·        ",
		"        ·                       ·        ",
		"        ·                       ·        ",
		"        ·                       ·        ",
		"        ·                       ·        ",
		"        ·                       ·        ",
		"        ·                       ·        ",
		"        ·                       ·        ",
		"  · · · · · · · · ·   · · · · · · · · ·  ",
		"  ·     ·         ·   ·         ·     ·  ",
		"  + ·   · · · · · ·   · · · · · ·   · +  ",
		"    ·   ·   ·               ·   ·   ·    ",
		"  · · · ·   · · · ·   · · · ·   · · · ·  ",
		"  ·               ·   ·               ·  ",
		"  · · · · · · · · · · · · · · · · · · ·  ",
		"                                         ",];
	#endregion
	
	public static readonly Position[] GhostStartPositions = [
		new Position(10, 16),
		new Position(10, 24),
		new Position(10, 18),
		new Position(10, 22),
		new Position(10, 20),
	];

	public static readonly Position[] GhostFirstDestinations = [
		new(3, 2),
		new(3, 38),
		new(17, 2),
		new(17, 38),
		new(13, 20),
	];

	public readonly Position PacmanStartPosition = new Position(17, 20);
	public Queue<Direction> Directions { get; set; } = new();

	// Magic Numbers
	private const char PowerBall = '+';
	private const char Dot = '·';
	private char[,] _dots;
	private int _score;
	private readonly Bfs _bfs;
	private const int BridgeRow = 10;

	public World()
	{
		_dots = CreateDots();
		_bfs = new Bfs(GetAllEdges());
	}

	private IEnumerable<Edge> GetAllEdges()
	{
		HashSet<Edge> edges = new();
		Direction[] directions = [Direction.Up, Direction.Down, Direction.Left, Direction.Right];

		for (int row = 0; row < GhostWallsString.Length; row++)
		{
			for (int col = 0; col < GhostWallsString[0].Length; col++)
			{
				if (GhostWallsString[row][col] != ' ') continue;

				foreach (var direction in directions)
				{
					var from = new Position(row, col);
					if (IsMovable(from, direction))
					{
						var to = GetPosition(from, direction);
						edges.Add(new Edge(from, to));
					}
				}
			}
		}

		return edges.ToList();
	}

	private char[,] CreateDots()
	{
		var dots = new char[DotsString.Length, DotsString[0].Length];
		for (int row = 0; row < DotsString.Length; row++)
		{
			for (int col = 0; col < DotsString[0].Length; col++)
			{
				dots[row, col] = DotsString[row][col];
			}
		}

		return dots;
	}

	#region Show/Hide/Clear 
	
	public void ShowWorld()
	{
		Console.Clear();
		Console.CursorVisible = false;
		UsingColor(ConsoleColor.Blue, ConsoleColor.Black, () =>
		{
			for (int row = 0; row < WallsString.Length; row++)
			{
				for (int col = 0; col < WallsString[0].Length; col++)
				{
					Console.SetCursorPosition(col, row);
					Console.Write(WallsString[row][col]);
				}
			}	
		});
	}

	public void ShowDots()
	{
		UsingColor(ConsoleColor.Blue, ConsoleColor.Black, () =>
		{
			for (int row = 0; row < DotsString.Length; row++)
			{
				for (int col = 0; col < DotsString[0].Length; col++)
				{
					Console.SetCursorPosition(col, row);
					if (DotsString[row][col] is not ' ')
						Console.Write(DotsString[row][col]);
				}
			}	
		});
	}

	public void UsingColor(ConsoleColor foregroundColor, ConsoleColor backgroundColor, Action action)
	{
		var originalForegroundColor = Console.ForegroundColor;
		var originalBackgroundColor = Console.BackgroundColor;
		Console.ForegroundColor = foregroundColor;
		Console.BackgroundColor = backgroundColor;

		action(); 
		
		Console.ForegroundColor = originalForegroundColor;
		Console.BackgroundColor = originalBackgroundColor;
	}

	public void ShowPacman(Pacman pacman, Position position, Direction direction)
	{
		var (foregroundColor, backgroundColor) = pacman.GetStateColor();
		UsingColor(foregroundColor, backgroundColor, () =>
		{
			Console.SetCursorPosition(position.Col, position.Row);
			var c = pacman.GetFrameFace(direction); 
			Console.Write(c);
		});
	}

	public void ShowTextReady()
	{
		UsingColor(ConsoleColor.White, ConsoleColor.Black, () =>
		{
			Console.SetCursorPosition(18, 13);
			Console.WriteLine("READY");
		});
	}
	
	public void EraseTextReady()
	{
		UsingColor(ConsoleColor.White, ConsoleColor.Black, () =>
		{
			Console.SetCursorPosition(18, 13);
			Console.WriteLine("     ");
		});
	}

	public void ShowGhost(Ghost ghost)
	{
		UsingColor(ConsoleColor.Black,ghost.Color, () =>
		{
			Console.SetCursorPosition(ghost.Position.Col, ghost.Position.Row);
			Console.Write('G');
		});
	}
	
	private void ShowScore()
	{
		Console.SetCursorPosition(0, 23);
		UsingColor(ConsoleColor.White, ConsoleColor.Black, () =>
		{
			Console.WriteLine($"Score: {_score,8}");
		});
		
	}

	public void ShowGameOver(CancellationToken token)
	{
		Console.SetCursorPosition(0, 23);
		Console.WriteLine($"Score: {_score,8} ");
		
		if (token.IsCancellationRequested)
			Console.WriteLine("Game Cancelled.");
		else if (!HasDots())
			Console.WriteLine("You Win.");
		else
			Console.WriteLine("You Lose.");
		Console.WriteLine("Game Over.");
		
	}

	public void ClearPacman(Position position)
	{
		Console.SetCursorPosition(position.Col, position.Row);
		UsingColor(ConsoleColor.White, ConsoleColor.Black, () =>
		{
			Console.Write(' ');
		});
	}
	
	public void ClearGhost(Ghost ghost)
	{
		var (row, col) = ghost.Position;
		var c = _dots[row, col];
		Console.SetCursorPosition(col, row);
		
		if (c != ' ')
			UsingColor(ConsoleColor.Blue,ConsoleColor.Black, () =>
			{
				Console.Write(c);
			});
		else 
			UsingColor(ConsoleColor.White, ConsoleColor.Black, () =>
			{
				Console.Write(' ');
			});
	}


	#endregion

	public bool IsMovable(Position position, Direction direction)
	{
		var newPosition = GetPosition(position, direction);
		var (row, col) = newPosition;

		var c = GhostWallsString[row][col];
		return c is ' '; 
	}

	public Position GetPosition(Position position, Direction direction)
	{
		var newPosition = direction switch
		{
			Direction.Up => new Position(position.Row - 1, position.Col),
			Direction.Down => new Position(position.Row + 1, position.Col),
			Direction.Left => new Position(position.Row, position.Col - 1),
			Direction.Right => new Position(position.Row, position.Col + 1),
			_ => position,
		};
		
		var rowBound = GhostWallsString.Length;
		var colBound = GhostWallsString[0].Length;

		var (row, col) = newPosition switch
		{
			var (y, x) when y < 0 => (rowBound - 1, x),
			var (y, x) when y >= rowBound => (0, x),

			var (y, x) when x < 0 => (y, colBound - 1),
			var (y, x) when x >= colBound => (y, 0),

			var (y, x) => (y, x),
		};
		return new Position(row, col);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="pacman"></param>
	/// <param name="ghosts"></param>
	/// <returns>true for game over</returns>
	public bool UpdateBy(Pacman pacman, Ghosts ghosts)
	{
		PacmanPowerDecrease(pacman, ghosts);
		
		var (row, col) = pacman.Position;
		var c = _dots[row, col];
		var isGameOver = false;

		switch (c)
		{
			case Dot:
				_score++;
				_dots[row, col] = ' ';
				break;
			case PowerBall:
				_score += 5;
				_dots[row, col] = ' ';
				PacmanPowered(pacman, ghosts);
				break;
		}

		if (!HasDots()) return true;
		if (HasMet(pacman, ghosts)) isGameOver = Fight(pacman, ghosts);

		ShowScore();
		return isGameOver;
	}

	private void PacmanPowerDecrease(Pacman pacman, Ghosts ghosts)
	{
		pacman.PowerTimes--;
		if (pacman.PowerTimes == 0) ghosts.Members.ForEach(ghost => ghost.Weak = false);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="pacman"></param>
	/// <param name="ghosts"></param>
	/// <returns>true for game over</returns>
	private bool Fight(Pacman pacman, Ghosts ghosts)
	{
		var isGameOver = false;
		var metGhosts = ghosts.Members.Where(ghost => ghost.Position == pacman.Position)
			.ToArray();
		if (metGhosts.Length ==0) return false;

		foreach (var ghost in metGhosts)
		{
			if (ghost.Weak)
			{
				_score += 10;
				ghosts.Reborn(ghost);
			}
			else
				isGameOver = true;
		}

		return isGameOver;
	}

	private bool HasMet(Pacman pacman, Ghosts ghosts) 
		=> ghosts.Members.Any(ghost => ghost.Position == pacman.Position);

	private void PacmanPowered(Pacman pacman, Ghosts ghosts)
	{
		pacman.PowerTimes = Pacman.MaxPowerTimes;
		ghosts.Members.ForEach(ghost => ghost.Weak = true);
	}

	public Direction GetRandomDirection(Position position)
	{
		Direction[] directions = [Direction.Up, Direction.Down, Direction.Left, Direction.Right];
		var newDirections = new List<Direction>();

		foreach (var direction in directions)
		{
			if (IsMovable(position, direction)) newDirections.Add(direction);
		}

		if (newDirections.Count == 0) return Direction.None;
		return newDirections[Random.Shared.Next(newDirections.Count)];
	}
	
	/// <summary>
	/// 
	/// </summary>
	/// <param name="ghosts"></param>
	/// <param name="pacman"></param>
	/// <returns>true for game over</returns>
	public bool UpdateBy(Ghosts ghosts, Pacman pacman)
	{
		if (HasMet(pacman, ghosts)) return Fight(pacman, ghosts);
		return false;
	}
	
	private bool HasDots()
	{
		for (int row = 0; row < _dots.GetLength(0); row++)
		{
			for (int col = 0; col < _dots.GetLength(1); col++)
			{
				if (_dots[row, col] != ' ') return true;
			}
		}
		return false;
	}

	public Direction GhostAlgorithmDirection(Ghost ghost, Pacman pacman)
	{
		if (ghost.Position == ghost.FirstDestination) ghost.FirstDestination = null; 
		var destination = ghost.FirstDestination ?? pacman.Position;

		var nextPosition = _bfs.GetNextStep(ghost.Position, destination);
		if (nextPosition == ghost.Position)
			return GetRandomDirection(ghost.Position);
		
		return GetDirection(ghost.Position, nextPosition);
	}

	private Direction GetDirection(Position start, Position end)
	{
		var row = start.Row;
		var dCol = end.Col - start.Col;   // -1: left, 1: right
		var dRow = end.Row - start.Row;   // -1: up, 1: down

		return (row, dCol, dRow) switch
		{
			(_, -1, 0) => Direction.Left,
			(_, 1, 0)  => Direction.Right,
			(_, 0, -1) => Direction.Up,
			(_, 0, 1) => Direction.Down,
			
			(BridgeRow, <0, 0) => Direction.Right,   // 39 -> 0 : right : -39 
			(BridgeRow, >0, 0) => Direction.Left,  // 0 -> 39 : left : 39
			
			_ => throw new Exception($"{start} to {end} is not a valid direction")
		};
	}
}


