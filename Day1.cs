namespace Advent23
{
	internal class Day1 : IDay
	{
		public void Star1()
		{
			var number = 0;

			var input = File.ReadAllLines("day1input.txt");

			foreach (var line in input)
			{
				var firstDigit = line.First(ch => ch >= '0' && ch <= '9');
				var lastDigit = line.Last(ch => ch >= '0' && ch <= '9');
				number += int.Parse(firstDigit.ToString()) * 10 + int.Parse(lastDigit.ToString());
			}

			Console.WriteLine(number);

		}

		public void Star2()
		{
			var number = 0;

			var input = File.ReadAllLines("day1input.txt");

			foreach (var line in input)
			{
				int digit1;
				int digit2;

				var firstDigit = line.FirstOrDefault(ch => ch >= '0' && ch <= '9');
				var firstDigitIndex = firstDigit == 0 ? Int32.MaxValue : line.IndexOf(firstDigit);
				List<int> positions = new List<int>(new int[9]);
				int index;

				for (index = 1; index < 10; index++)
				{
					var digit = digitNames[index - 1];
					positions[index-1] = line.IndexOf(digit, StringComparison.Ordinal);
					if (positions[index-1] == -1)
						positions[index-1] = 500000;
				}

				var lowest = positions.Min();
				if (lowest != 500000)
				{
					if (lowest > firstDigitIndex)
						digit1 = int.Parse(firstDigit.ToString());
					else
						digit1 = positions.IndexOf(lowest) + 1;
				}
				else
					digit1 = int.Parse(firstDigit.ToString());

				var secondDigit = line.LastOrDefault(ch => ch >= '0' && ch <= '9');
				var secondDigitIndex = secondDigit == 0 ? Int32.MinValue : line.LastIndexOf(secondDigit);
				positions = new List<int>(new int[9]);

				for (index = 1; index < 10; index++)
				{
					var digit = digitNames[index - 1];
					positions[index-1] = line.LastIndexOf(digit, StringComparison.Ordinal);
				}

				var highest = positions.Max();
				if (highest != -1)
				{
					if (highest < secondDigitIndex)
						digit2 = int.Parse(secondDigit.ToString());
					else
						digit2 = positions.IndexOf(highest) + 1;
				}
				else
					digit2 = int.Parse(secondDigit.ToString());

				number += digit1 * 10 + digit2;
			}

			Console.WriteLine(number);
		}

		private static List<string> digitNames = new List<string>
		{
			"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
		};


		private static List<string> _testInput = new List<string>
		{
			//"1abc2",
			//"pqr3stu8vwx",
			//"a1b2c3d4e5f",
			//"treb7uchet",
			"two1nine",
			"eightwothree",
			"abcone2threexyz",
			"xtwone3four",
			"4nineeightseven2",
			"zoneight234",
			"7pqrstsixteen"
		};

	}

	
}
