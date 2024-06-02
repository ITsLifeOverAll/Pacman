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

	#region Show/Hide/Clear 
	
	public void ShowWorld()
	{
		Console.Clear();
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

	public void ShowPacman(Pacman pacman)
	{
		UsingColor(ConsoleColor.Black, ConsoleColor.Yellow, () =>
		{
			Console.SetCursorPosition(pacman.Position.Col, pacman.Position.Row);
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
	
	
}