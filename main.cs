using System;

class MainClass {

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

		PlayerType player1Type = GetPlayerType();
		string player1Name = GetPlayerName(player1Type);

		PlayerType player2Type = GetPlayerType();
		string player2Name = GetPlayerName(player2Type);

    MarkType player1Mark = MarkType.CROSS;
    MarkType player2Mark = MarkType.NOUGHT;

    if(GameRandom.Event())
    {
      player1Mark = MarkType.NOUGHT;
      player2Mark = MarkType.CROSS;
    }

    GamePrint.Message(player1Name + ": " + player1Mark);
    GamePrint.Message(player2Name + ": " + player2Mark);

    
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
}