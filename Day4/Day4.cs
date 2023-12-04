// ReSharper disable once CheckNamespace
namespace Advent23
{
	internal class Day4: IDay
	{
		public void Star1()
		{
			var input = File.ReadAllLines("Day4/day4input.txt");
			var result = 0;

			foreach (var line in input)
			{
				var points = 0;

				var inputSplitted = line.Split(':', '|');
				var myNumbers = inputSplitted[1].Split(' ', 
						StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse).ToList();
				var winningNumbers = inputSplitted[2].Split(' ', 
						StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse).ToList();

				foreach (var number in myNumbers)
				{
					foreach (var winningNumber in winningNumbers)
					{
						if (number == winningNumber)
						{
							if (points == 0)
								points = 1;
							else
								points *= 2;
						}
					}
				}

				result += points;
			}

			Console.WriteLine(result);
		}

		public void Star2()
		{
			var input = File.ReadAllLines("Day4/day4input.txt");
			var totalCards = 0;
			var numberOfCards = input.Select(_ => 1).ToList();

			for (int i = 0; i < input.Length; i++)
			{
				var winningNumbersCount = 0;

				var inputSplitted = input[i].Split(':', '|');
				var myNumbers = inputSplitted[1].Split(' ',
						StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse).ToList();
				var winningNumbers = inputSplitted[2].Split(' ',
						StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse).ToList();

				foreach (var number in myNumbers)
				{
					foreach (var winningNumber in winningNumbers)
					{
						if (number == winningNumber)
						{
							winningNumbersCount++;
						}
					}
				}

				for (int j = 1; j <= winningNumbersCount; j++)
				{
					if (i + j < input.Length)
						numberOfCards[i+j] += numberOfCards[i];
				}
			}

			foreach (var cardNumber in numberOfCards)
				totalCards += cardNumber;

			Console.WriteLine(totalCards);
		}
	}
}
