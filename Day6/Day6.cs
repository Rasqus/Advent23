// ReSharper disable once CheckNamespace
namespace Advent23
{
	internal class Day6 : IDay
	{
		public void Star1()
		{
			var input = File.ReadAllLines("Day6/day6input.txt");

			var times = input[0].Split(':')[1].Split(' ', 
				StringSplitOptions.RemoveEmptyEntries);
			var distances = input[1].Split(':')[1].Split(' ',
				StringSplitOptions.RemoveEmptyEntries);

			var waysToWin = new List<int>();

			for (int i = 0; i < times.Length; i++)
			{
				var winningStrategies = 0;
				var time = int.Parse(times[i]);
				for (int t = 1; t <= time; t++)
				{
					var curDistance = (time - t) * t;

					if (curDistance > int.Parse(distances[i]))
						winningStrategies++;
				}

				waysToWin.Add(winningStrategies);
			}

			var result = 1;
			foreach (var way in waysToWin)
			{
				result *= way;
			}

			Console.WriteLine(result); //1083852

		}

		public void Star2()
		{
			var input = File.ReadAllLines("Day6/day6input.txt");

			var times = input[0].Split(':')[1].Replace(" ", "");
			var distances = input[1].Split(':')[1].Replace(" ", "");

			var waysToWin = 0;

			var time = long.Parse(times);
			for (int t = 1; t <= time; t++)
			{
				var curDistance = (time - t) * t;

				if (curDistance > long.Parse(distances))
					waysToWin++;
			}
			
			Console.WriteLine(waysToWin); //23501589
		}
	}
}
