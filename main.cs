using System;

class MainClass {
  public static void Main (string[] args) {

	GamePrint.Box("Odds and Evens");

	int userWinCount = 0;
	int computerWinCount = 0;

	GamePrint.Input("What's your name?");
	string userName = GameInput.Text();

	/*  Step 1.
	User chooses to play with odds or evens.
	*/

	// Odds is 1
	// Evens is 2
	GamePrint.Input("Choose your side:\n1. Odds\n2. Evens");
	int userNumberType = GameInput.Number(1, 2);

	if(userNumberType == 1)
	{
		GamePrint.Message(userName + " is Odds");
		GamePrint.Message("Computer is Evens");
	}
	else 
	{
		GamePrint.Message(userName + " is Evens");
		GamePrint.Message("Computer is Odds");
	}
	
	/* Step 6.
	Repeat until one of the players wins two rounds.
	*/

	while(userWinCount < 2 && computerWinCount < 2)
	{
		/* Step 2.
		Each player chooses the number 1 or number 2.
		*/

		GamePrint.Input("Choose a number between 1 and 2:");
		int userNumber = GameInput.Number(1, 2);
		int computerNumber = GameRandom.Number(1, 2);

		GamePrint.Message(userName + " chooses " + userNumber);
		GamePrint.Message("Computer chooses " + computerNumber);

		/* Step 3.
		Sum both numbers.
		*/

		int sumResult = userNumber + computerNumber;

		/* Step 4.
		Check if the sum is odd or even.
		*/

		// sumResult mod 2 equals 0, then it's even
		bool resultIsEven = sumResult % 2 == 0;

		/* Step 5.
		The player assigned to the corresponding odds or evens wins the round.
		*/

		if(resultIsEven)
		{
			GamePrint.Message("Result is Even");
		}
		else 
		{
			GamePrint.Message("Result is Odd");
		}	

		bool userIsEven = userNumberType == 2;

		if(resultIsEven == userIsEven)
		{
			GamePrint.Success(userName + " wins the round");
			userWinCount++;
		}
		else 
		{
			GamePrint.Error("Computer wins the round");
			computerWinCount++;	
		}
	}

	/* Step 7.
	Declare the game winner.
	*/

	if(userWinCount > computerWinCount)
	{
		GamePrint.Success(userName + " is the winner!");
	}
	else 
	{
		GamePrint.Error("Computer is the winner!");
	}

	GamePrint.Box("Game Over");
	}
}