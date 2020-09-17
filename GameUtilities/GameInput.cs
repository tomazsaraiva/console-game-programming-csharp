//
//  GameInput.cs
//
//  Author:
//       Tomaz Saraiva <tomaz.saraiva@gmail.com>
//
//  Copyright (c) 2020 Tomaz Saraiva
using System;

public static class GameInput
{
	private const ConsoleColor INPUT_COLOR = ConsoleColor.Cyan;

	/* 
		Waits for the player input;
		Validates the input according to the given numbers;
	*/
	public static int Number(params int[] numbers)
	{
		Console.ForegroundColor = INPUT_COLOR;

		var valid = false;
		var number = 0;
		while (!valid)
		{
			var input = Console.ReadLine();
			if (int.TryParse(input, out number))
			{
				if (numbers == null)
				{
					valid = true;
					break;
				}

				for (int i = 0; i < numbers.Length; i++)
				{
					if (number == numbers[i])
					{
						valid = true;
						break;
					}
				}
			}

			if (!valid)
			{
				GamePrint.Error("Enter a valid number");
				Console.ForegroundColor = INPUT_COLOR;
			}
		}

		Console.Write("\n");
		Console.ForegroundColor = ConsoleColor.White;
		return number;
	}
	public static string Text(int maxLength = -1)
	{
		Console.ForegroundColor = INPUT_COLOR;

		string text = null;
		while (true)
		{
			text = Console.ReadLine();
			if (string.IsNullOrEmpty(text))
			{
				GamePrint.Error("Enter a valid text");
				Console.ForegroundColor = INPUT_COLOR;
			}
      else if(maxLength != -1 && text.Length > maxLength)
      {
        GamePrint.Error("Enter a valid text (max length: " + maxLength + ")");
				Console.ForegroundColor = INPUT_COLOR;
      }
			else break;
		}

		Console.Write("\n");
		Console.ForegroundColor = ConsoleColor.White;
		return text;
	}
}