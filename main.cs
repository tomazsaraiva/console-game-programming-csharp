using System;

class MainClass {

	enum PlayerType
	{
		Human,
		Computer
	}

  public static void Main (string[] args) {

		GamePrint.Box("Tic, Tac, Toe");

		PlayerType player1Type = GetPlayerType();
		string player1Name = GetPlayerName(player1Type);

		PlayerType player2Type = GetPlayerType();
		string player2Name = GetPlayerName(player2Type);
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