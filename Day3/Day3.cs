

// ReSharper disable once CheckNamespace
namespace Advent23
{
	internal class Day3 : IDay
	{
		public void Star1()
		{
			var input = File.ReadAllLines("Day3/day3input.txt");
			var result = 0;

			var specialChars = new HashSet<char>();

			foreach (var line in input)
			{
				foreach (var c in line.Where(c => c != '.' && (c < '0' || c > '9')))
				{
					specialChars.Add(c);
				}
			}

			var numbers = new List<Number>();
			var specialCharsAndDot = new HashSet<char>(specialChars) {'.'};


			for (var i = 0; i < input.Length; i++)
			{
				var numbersInLine = input[i].Split(specialCharsAndDot.ToArray(), StringSplitOptions.RemoveEmptyEntries);
				var position = 0;
				foreach (var number in numbersInLine)
				{
					var indexOf = input[i].IndexOf(number, position, StringComparison.Ordinal);

					numbers.Add(new Number {Column = indexOf, Length = number.Length, Row = i, Value = int.Parse(number)});

					position = indexOf + number.Length;
				}

			}

			foreach (var number in numbers)
			{
				var numberIsPart = false;
				for (int i = number.Row - 1; i <= number.Row + 1; i++)
				{
					if (i < 0 || i >= input.Length)
						continue;

					var wordBegin = number.Column - 1;
					var wordEnd = number.Column + number.Length;
					for (int j = wordBegin; j <= wordEnd; j++)
					{
						if (j < 0 || j >= input[0].Length)
							continue;

						if (specialChars.Contains(input[i][j]))
							numberIsPart = true;
					}
				}
				//Console.WriteLine($"{number} is part: {numberIsPart}");

				if (numberIsPart)
					result += number.Value;
			}

			Console.WriteLine(result);
		}

		public void Star2()
		{
			var input = File.ReadAllLines("Day3/day3input.txt");
			var result = 0;

			var specialChars = new HashSet<char>();

			foreach (var line in input)
			{
				foreach (var c in line.Where(c => c != '.' && (c < '0' || c > '9')))
				{
					specialChars.Add(c);
				}
			}

			var numbers = new List<Number>();
			var gears = new List<Gear>();
			var specialCharsAndDot = new HashSet<char>(specialChars) { '.' };

			for (var i = 0; i < input.Length; i++)
			{
				var numbersInLine = input[i].Split(specialCharsAndDot.ToArray(), StringSplitOptions.RemoveEmptyEntries);
				var position = 0;
				foreach (var number in numbersInLine)
				{
					var indexOf = input[i].IndexOf(number, position, StringComparison.Ordinal);

					numbers.Add(new Number { Column = indexOf, Length = number.Length, Row = i, Value = int.Parse(number) });

					position = indexOf + number.Length;
				}

			}

			foreach (var number in numbers)
			{
				var numberIsPart = false;
				for (int i = number.Row - 1; i <= number.Row + 1; i++)
				{
					if (i < 0 || i >= input.Length)
						continue;

					var wordBegin = number.Column - 1;
					var wordEnd = number.Column + number.Length;
					for (int j = wordBegin; j <= wordEnd; j++)
					{
						if (j < 0 || j >= input[0].Length)
							continue;

						if (specialChars.Contains(input[i][j]))
							numberIsPart = true;
					}
				}

				if (numberIsPart)
				{
					for (int i = number.Row - 1; i <= number.Row + 1; i++)
					{
						if (i < 0 || i >= input.Length)
							continue;

						var wordBegin = number.Column - 1;
						var wordEnd = number.Column + number.Length;
						for (int j = wordBegin; j <= wordEnd; j++)
						{
							if (j < 0 || j >= input[0].Length)
								continue;

							if (input[i][j] == '*')
							{
								var gear = gears.FirstOrDefault(gear => gear.Row == i && gear.Column == j);
								if (gear == null)
								{
									gears.Add(new Gear { AdjacentNumbers = 1, Column = j, Row = i, Value = number.Value});
								}
								else
								{
									if (gear.AdjacentNumbers < 2)
									{
										gear.Value *= number.Value;
										gear.AdjacentNumbers++;
									}
									else
									{
										gear.Value = 0;
										gear.AdjacentNumbers++;
									}
								}
							}
						}
					}
				}
			}

			foreach (var gear in gears)
			{
				if (gear.AdjacentNumbers == 2)
				{
					result += gear.Value;
				}
			}

			Console.WriteLine(result);
		}

	}

	class Number
	{
		public int Value { get; set; }

		public int Row { get; set; }

		public int Column { get; set; }

		public int Length { get; set; }

		public override string ToString()
		{
			return $"{Value} -> {Row}:{Column}";
		}
	}

	class Gear
	{
		public int AdjacentNumbers { get; set; } = 0;

		public int Row { get; set; }

		public int Column { get; set; }

		public int Value { get; set; } = 1;
	}
}