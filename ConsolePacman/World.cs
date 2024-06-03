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
	
	public readonly Position[] GhostStartPositions = [
		new Position(10, 16),
		new Position(10, 24),
		new Position(10, 18),
		new Position(10, 22),
		new Position(10, 20),
	];

	public readonly Position[] GhostFirstDestinations = [
		new(3, 2),
		new(3, 38),
		new(17, 2),
		new(17, 38),
		new(13, 20),
	];

	public readonly Position PacmanStartPosition = new Position(17, 20);
	public Queue<Direction> Directions { get; set; } = new();

	private const char PowerBall = '+';
	private const char Dot = '·';
	private char[,] _dots;
	private int _score;
	private const int BridgeRow = 10;

	public World()
	{
		_dots = CreateDots();
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

	public void ShowPacman(Pacman pacman, Position position)
	{
		UsingColor(ConsoleColor.Black, ConsoleColor.Yellow, () =>
		{
			Console.SetCursorPosition(position.Col, position.Row);
			Console.Write('P');
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

	public void ClearPacman(Position position)
	{
		Console.SetCursorPosition(position.Col, position.Row);
		UsingColor(ConsoleColor.White, ConsoleColor.Black, () =>
		{
			Console.Write(' ');
		});
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="pacman"></param>
	/// <param name="ghosts"></param>
	/// <returns>true for game over</returns>
	public bool UpdateBy(Pacman pacman, Ghosts ghosts)
	{
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
				PacmanPowerd(pacman, ghosts);
				break;
		}
		
		// todo if meet ghosts
		if (HasMet(pacman, ghosts)) isGameOver = Fight(pacman, ghosts);

		ShowScore();
		return isGameOver;
	}

	private void ShowScore()
	{
		Console.SetCursorPosition(0, 23);
		UsingColor(ConsoleColor.White, ConsoleColor.Black, () =>
		{
			Console.WriteLine($"Score: {_score,8}");
		});
		
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="pacman"></param>
	/// <param name="ghosts"></param>
	/// <returns>true for game over</returns>
	private bool Fight(Pacman pacman, Ghosts ghosts)
	{
		var ghost = ghosts.Members.FirstOrDefault(ghost => ghost.Position == pacman.Position);
		if (ghost is null) return false;

		if (ghost.Weak)
		{
			_score += 10;
			ghosts.Reborn(ghost);
			return false;
		}

		return true;
	}

	private bool HasMet(Pacman pacman, Ghosts ghosts) 
		=> ghosts.Members.Any(ghost => ghost.Position == pacman.Position);

	private void PacmanPowerd(Pacman pacman, Ghosts ghosts)
	{
		pacman.PowerTimes = Pacman.MaxPowerTimes;
		ghosts.Members.ForEach(ghost => ghost.Weak = true);
	}
}


