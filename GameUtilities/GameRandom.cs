//
//  GameRandom.cs
//
//  Author:
//       Tomaz Saraiva <tomaz.saraiva@gmail.com>
//
//  Copyright (c) 2020 Tomaz Saraiva
using System;

public static class GameRandom
{
		private static Random Random
		{
			get
			{
				if (_random == null)
				{
					_random = new Random();
				}

				return _random;
			}
		}
		private static Random _random;

		/*
			Returns a random number between the given min and max.
		*/
		public static int Number(int min, int max)
		{
			return Random.Next(min, max + 1);
		}

		public static bool Event(double probability = 0.5)
		{
			return DecimalNumber() <= probability;
		}

		public static double DecimalNumber() // between 0 - 1
		{
			return Random.NextDouble();
		}

		public static double DecimalNumber(double min, double max)
		{
			double random = Random.NextDouble();
			return min + (random * (max - min));
		}
}