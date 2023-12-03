// ReSharper disable once CheckNamespace
namespace Advent23
{
	internal class Day2 : IDay
	{
		public void Star1()
		{
			var sum = 0;
			const int maxRed = 12;
			const int maxGreen = 13;
			const int maxBlue = 14;

			var input = File.ReadAllLines("Day2/day2input.txt");

			for (var i = 0; i < input.Length; i++)
			{
				var isGameOk = true;

				var game = input[i];
				var reveals = game.Split(':')[1].Split(';');

				foreach (var reveal in reveals)
				{
					var sets = reveal.Split(',');

					foreach (var set in sets)
					{
						var number = set.Split(' ')[1];
						var color = set.Split(' ')[2];

						switch (color)
						{
							case "blue":
								if (int.Parse(number) > maxBlue)
									isGameOk = false;
								break;
							case "red":
								if (int.Parse(number) > maxRed)
									isGameOk = false;
								break;
							case "green":
								if (int.Parse(number) > maxGreen)
									isGameOk = false;
								break;
						}

						if (!isGameOk)
							break;
					}

					if (!isGameOk)
						break;
				}

				if (isGameOk)
					sum += i + 1;
			}

			Console.WriteLine(sum);
		}

		public void Star2()
		{
			var sumOfPowers = 0;

			var input = File.ReadAllLines("Day2/day2input.txt");

			for (var i = 0; i < input.Length; i++)
			{
				var game = input[i];
				var reveals = game.Split(':')[1].Split(';');

				var minRed = 0;
				var minBlue = 0;
				var minGreen = 0;

				foreach (var reveal in reveals)
				{
					var sets = reveal.Split(',');

					foreach (var set in sets)
					{
						var numberStr = set.Split(' ')[1];
						var number = int.Parse(numberStr);
						var color = set.Split(' ')[2];

						switch (color)
						{
							case "blue":
								if (number > minBlue)
									minBlue = number;
								break;
							case "red":
								if (number > minRed)
									minRed = number;
								break;
							case "green":
								if (number > minGreen)
									minGreen = number;
								break;
						}
					}
				}

				sumOfPowers += minRed * minBlue * minGreen;
			}

			Console.WriteLine(sumOfPowers);
		}
	}
}