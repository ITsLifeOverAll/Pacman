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

	public void ShowWorld()
	{
		Console.Clear();
		Console.ForegroundColor = ConsoleColor.Blue;
		Console.BackgroundColor = ConsoleColor.Black;

		for (int row = 0; row < WallsString.Length; row++)
		{
			for (int col = 0; col < WallsString[0].Length; col++)
			{
				Console.SetCursorPosition(col, row);
				Console.Write(WallsString[row][col]);
			}
		}
	}

	public void ShowDots()
	{
		Console.ForegroundColor = ConsoleColor.Blue;
		Console.BackgroundColor = ConsoleColor.Black;

		for (int row = 0; row < DotsString.Length; row++)
		{
			for (int col = 0; col < DotsString[0].Length; col++)
			{
				Console.SetCursorPosition(col, row);
				if (DotsString[row][col] is not ' ')
					Console.Write(DotsString[row][col]);
			}
		}
	}
}