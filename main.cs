using System;
using System.Text;

class MainClass {

  private const string MARK_NOUGHT = "O";
  private const string MARK_CROSS = "X";

  private const ConsoleColor COLOR_NOUGHT = ConsoleColor.Blue;
  private const ConsoleColor COLOR_CROSS = ConsoleColor.Red;

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
    bool player1Even = false;
    if(GameRandom.Event())
    {
      player1Even = true;
    }

    int roundNumber = 0;
    while(roundNumber < 9) 
    {
      ShowBoard(cells);

      int[] emptyCells = GetEmptyCells(cells);
      int targetCell = -1;

      MarkType markType = MarkType.CROSS;

      bool evenRound = roundNumber % 2 == 0;
      if(evenRound == player1Even)
      {
        targetCell = GetPlayerInput(player1Name, player1Type, emptyCells);
        markType = player1Mark;
      }
      else
      {
        targetCell = GetPlayerInput(player2Name, player2Type, emptyCells);
        markType = player2Mark;
      }

      Console.ForegroundColor = markType == MarkType.CROSS ? COLOR_CROSS : COLOR_NOUGHT;
      cells[targetCell] = markType == MarkType.CROSS ? MARK_CROSS : MARK_NOUGHT;

      roundNumber++;
    }
  }

  // Create players
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
  
  // Round
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
          Console.ForegroundColor = cell == MARK_CROSS ? COLOR_CROSS : COLOR_NOUGHT;
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
  private static int[] GetEmptyCells(string[] cells)
  {
    int count = 0;
    
    for (int i = 0; i < cells.Length; i++)
    {
      if(cells[i] != null)
      {
        continue;
      }
      count++;
    }

    int[] emptyCells = new int[count];
    int current = 0;
    for (int i = 0; i < emptyCells.Length; i++)
    {
      if(cells[i] != null)
      {
        continue;
      }

      emptyCells[current] = i;
      current++;
    }

    return emptyCells;
  }

  private static int GetPlayerInput(string playerName, PlayerType playerType, int[] emptyCells)
  {
    StringBuilder builder = new StringBuilder();
    for (int i = 0; i < emptyCells.Length; i++)
    {
        builder.AppendLine(emptyCells[i].ToString());
    }

    int cellNumber = -1;
    switch(playerType)
    {
      case PlayerType.Human:
      GamePrint.Input(playerName + " pick where to place your mark:" + builder.ToString());
      cellNumber = GameInput.Number(emptyCells);
      break;

      case PlayerType.Computer:
      cellNumber = emptyCells[GameRandom.Number(0, emptyCells.Length)];
      break;
    }

    GamePrint.Message(playerName + " picked cell number " + cellNumber);
    return cellNumber;
  }
}