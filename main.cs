using System;

class MainClass {

  private const string MARK_NOUGHT = "O";
  private const string MARK_CROSS = "X";

	enum PlayerType
	{
		Human,
		Computer
	}

  enum MarkType
  {
    CROSS,
    NOUGHT
  }

  public static void Main (string[] args) {

		GamePrint.Box("Tic, Tac, Toe");

    // Create the first player.
		PlayerType player1Type = GetPlayerType();
		string player1Name = GetPlayerName(player1Type);

    // Create the second player.
		PlayerType player2Type = GetPlayerType();
		string player2Name = GetPlayerName(player2Type);

    // Assign the players mark types.
    MarkType player1Mark = MarkType.CROSS;
    MarkType player2Mark = MarkType.NOUGHT;

    if(GameRandom.Event())
    {
      player1Mark = MarkType.NOUGHT;
      player2Mark = MarkType.CROSS;
    }

    GamePrint.Message(player1Name + ": " + player1Mark);
    GamePrint.Message(player2Name + ": " + player2Mark);

    // Create game board.
    string[] cells = new string[9];

    // Game loop.
    int roundNumber = 0;
    while(roundNumber < 9) 
    {
      ShowBoard(cells);

      roundNumber++;
    }
  }

	private static PlayerType GetPlayerType()
	{
		GamePrint.Input("New Player\n1.Human\n2.Computer");
		int playerType = GameInput.Number(new int[] { 1, 2 });
		return (PlayerType)(playerType - 1);
	}
	private static string GetPlayerName(PlayerType playerType)
	{
		if(playerType == PlayerType.Computer)
		{
			return "Computer";
		}
		
		GamePrint.Input("What's your name?");
		string playerName = GameInput.Text();
		return playerName;
	}

  private static void ShowBoard(string[] cells)
  {
    Console.Write("\n\n");
    
      for (int i = 0; i < cells.Length; i++)
      {
        Console.Write(" ");

        string cell = cells[i];
        if(cell == null)
        {
          Console.ForegroundColor = ConsoleColor.Gray;
          Console.Write(i.ToString());
        }
        else 
        {
          Console.ForegroundColor = cell == MARK_CROSS ? ConsoleColor.Red : ConsoleColor.Blue;
          Console.Write(cells[i]);
        }

        Console.Write(" ");
        Console.ForegroundColor = ConsoleColor.Gray;

        if((i + 1) % 3 != 0)
        {
          Console.Write("|");
        }
        else if(i < 8)
        {
          Console.ForegroundColor = ConsoleColor.DarkGray;
          Console.Write("\n---+---+---\n");
        }
      }

      Console.Write("\n");
  }
}