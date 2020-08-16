//
//  GamePrint.cs
//
//  Author:
//       Tomaz Saraiva <tomaz.saraiva@gmail.com>
//
//  Copyright (c) 2020 Tomaz Saraiva
using System;
using System.Text;

public static class GamePrint
{
		private const string INPUT_FORMAT = "\n--> {0}";
		private const ConsoleColor INPUT_COLOR = ConsoleColor.Blue;

		private const string BOX_LIMIT_FORMAT = "\n+---{0}---+\n";
		private const string BOX_MESSAGE_FORMAT = "+-- {0} --+";
		private const ConsoleColor BOX_COLOR = ConsoleColor.DarkYellow;

		private const string MESSAGE_FORMAT = "# {0}";
		private const ConsoleColor MESSAGE_COLOR_DEFAULT = ConsoleColor.DarkGray;
		private const ConsoleColor MESSAGE_COLOR_SUCCESS = ConsoleColor.DarkGreen;
		private const ConsoleColor MESSAGE_COLOR_ERROR = ConsoleColor.DarkRed;

		/*
			+-----------------+
			+-- BOX MESSAGE --+
			+-----------------+
		*/
		public static void Box(string text)
		{
			var builder = new StringBuilder();
			for (int i = 0; i < text.Length; i++)
			{
				builder.Append("-");
			}

			var limit = string.Format(BOX_LIMIT_FORMAT, builder.ToString());
			Console.ForegroundColor = BOX_COLOR;
			Console.WriteLine(limit + string.Format(BOX_MESSAGE_FORMAT, text) + 
			limit);
			Reset();
		}
		/*
			--> INPUT MESSAGE:
		*/
		public static void Input(string text)
		{
			if(string.IsNullOrEmpty(text)) return;
			Console.ForegroundColor = INPUT_COLOR;
			Console.WriteLine(string.Format(INPUT_FORMAT, text));
			Reset();
		}
		/*
			## MESSAGE ##
		*/
		public static void Message(string text, ConsoleColor color)
		{
			var builder = new StringBuilder();

			if(color != MESSAGE_COLOR_DEFAULT)
			{
				builder.Append("\n");
			}

			var paragraphs = text.Split(new char[] { '\n' });
			for (int i = 0; i < paragraphs.Length; i++)
			{
				builder.AppendFormat(MESSAGE_FORMAT, paragraphs[i]);
			}
			Console.ForegroundColor = color;
			Console.WriteLine(builder.ToString());
			Reset();
		}
		public static void Message(string text)
		{
			Message(text, MESSAGE_COLOR_DEFAULT);
		}
		public static void Success(string text)
		{
			Message(text, MESSAGE_COLOR_SUCCESS);
		}
		public static void Error(string text)
		{
			Message(text, MESSAGE_COLOR_ERROR);
		}

		public static void ClearLine(int lines = 2)
		{
			Console.SetCursorPosition(0, Console.CursorTop - lines);

			var currentLineCursor = Console.CursorTop;
			Console.SetCursorPosition(0, Console.CursorTop);
			Console.Write(new string(' ', Console.WindowWidth));

			Console.SetCursorPosition(0, currentLineCursor);
		}
		private static void Reset()
		{
			Console.ForegroundColor = ConsoleColor.White;
		}
}