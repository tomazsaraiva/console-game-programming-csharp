using System;

class MainClass {

	enum HandType
	{
			Rock,
			Paper,
			Scissors
	}

  public static void Main (string[] args) {

		GamePrint.Box("ROCK, PAPER, SCISSORS");

		int userWinCount = 0;
		int computerWinCount = 0;

		GamePrint.Input("What's your name?");
		string userName = GameInput.Text();

		while (userWinCount < 2 && computerWinCount < 2)
		{
				GamePrint.Input(userName + " choose your hand:\n1.Rock\n2.Paper\n3.Scissors");

				int userInput = GameInput.Number(1, 2, 3);
				
				HandType userHand = (HandType)(userInput - 1);
				HandType computerHand = (HandType)GameRandom.Number(0, 3);

				GamePrint.Message(userName + ": " + userHand);
				GamePrint.Message("Computer: " + computerHand);

				if (userHand == computerHand)
				{
						GamePrint.Message("It's a TIE. Play Again!");
				}
				else if ((userHand == HandType.Rock && computerHand == HandType.Scissors) ||
									(userHand == HandType.Paper && computerHand == HandType.Rock) ||
									(userHand == HandType.Scissors && computerHand == HandType.Paper))
				{
						userWinCount++;

						GamePrint.Message(userHand + " beats " + computerHand);
						GamePrint.Success(userName + " WINS");
				}
				else
				{
						computerWinCount++;

						GamePrint.Message(computerHand + " beats " + userHand);
						GamePrint.Error("Computer WINS");
				}
		}

		if(userWinCount > computerWinCount)
		{
			GamePrint.Success("User is the game winner!");
		}
		else 
		{
			GamePrint.Error("Computer is the game winner!");
		}

		GamePrint.Box("GAME OVER");
	}
}