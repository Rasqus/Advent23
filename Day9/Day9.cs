// ReSharper disable once CheckNamespace
namespace Advent23
{
	internal class Day9 : IDay
	{
		public void Star1()
		{
			var input = File.ReadAllLines("Day9/day9input.txt");
			var result = 0;

			foreach (var line in input)
			{
				var sequences = new List<List<int>>();
				var numbers = line.Split(' ').Select(int.Parse).ToList();

				sequences.Add(numbers);

				var allNotZero = true;

				while (allNotZero)
				{
					var difference = new List<int>();
					for (int i = 1; i < numbers.Count; i++)
					{
						difference.Add(numbers[i] - numbers[i-1]);
					}

					if (difference.All(num => num == 0))
						allNotZero = false;

					sequences.Add(difference);

					numbers = difference;
				}

				sequences.Last().Add(0);

				for (int i = sequences.Count - 1; i > 0; i--)
				{
					sequences[i-1].Add(sequences[i].Last() + sequences[i-1].Last());
				}

				result += sequences[0].Last();
			}

			Console.WriteLine(result); //1681758908
		}

		public void Star2()
		{
			var input = File.ReadAllLines("Day9/day9input.txt");
			var result = 0;

			foreach (var line in input)
			{
				var differences = new List<List<int>>();
				var numbers = line.Split(' ').Select(int.Parse).ToList();

				differences.Add(numbers);

				var allNotZero = true;

				while (allNotZero)
				{
					var difference = new List<int>();
					for (int i = 1; i < numbers.Count; i++)
					{
						difference.Add(numbers[i] - numbers[i - 1]);
					}

					if (difference.All(num => num == 0))
						allNotZero = false;

					differences.Add(difference);

					numbers = difference;
				}

				foreach (var difference in differences)
					difference.Reverse();

				differences.Last().Add(0);

				for (int i = differences.Count - 1; i > 0; i--)
				{
					differences[i - 1].Add(differences[i - 1].Last() - differences[i].Last());
				}

				result += differences[0].Last();
			}

			Console.WriteLine(result); //803
		}
	}
}
