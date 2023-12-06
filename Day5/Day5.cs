// ReSharper disable once CheckNamespace
namespace Advent23
{
	internal class Day5 : IDay
	{
		public void Star1()
		{
			var input = File.ReadAllLines("Day5/day5input.txt");

			var seeds = input[0].Split(':')[1]
				.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			var maps = new List<List<List<long>>>();

			var mapNumber = -1;
			for (int i = 1; i < input.Length; i++)
			{
				if (input[i] == "")
					continue;
				if (input[i].Contains("map"))
				{
					mapNumber++;
					maps.Add(new List<List<long>>());
				}
				else
				{
					maps[mapNumber].Add(input[i].Split(" ",
						StringSplitOptions.RemoveEmptyEntries).ToList().Select(long.Parse).ToList());
				}
			}

			var lowest = long.MaxValue;

			foreach (var seed in seeds)
			{
				var number = long.Parse(seed);
				foreach (var map in maps)
				{
					foreach (var converter in map)
					{
						if (number >= converter[1] && number <= converter[1] + converter[2])
						{
							number = converter[0] + (number - converter[1]);
							break;
						}
					}
				}

				if (number < lowest)
					lowest = number;
			}

			Console.WriteLine(lowest); //382895070
		}

		public void Star2()
		{
			var input = File.ReadAllLines("Day5/day5input.txt");

			var seedNumbers = input[0].Split(':')[1]
				.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			var maps = new List<List<List<long>>>();

			var mapNumber = -1;
			for (int i = 1; i < input.Length; i++)
			{
				if (input[i] == "")
					continue;
				if (input[i].Contains("map"))
				{
					mapNumber++;
					maps.Add(new List<List<long>>());
				}
				else
				{
					maps[mapNumber].Add(input[i].Split(" ",
						StringSplitOptions.RemoveEmptyEntries).ToList().Select(long.Parse).ToList());
				}
			}

			var lowest = long.MaxValue;

			for (int i = 0; i < seedNumbers.Length; i += 2)
			{
				var seed = long.Parse(seedNumbers[i]);
				var seedRange = long.Parse(seedNumbers[i + 1]);

				var numbers = new List<long> { seed };
				var ranges = new List<long> { seedRange };

				foreach (var map in maps)
				{
					var localNumbers = new List<long>();
					var localRanges = new List<long>();

					while (numbers.Count > 0)
					{
						long number = numbers[0];
						long range = ranges[0];
						bool isMatched = false;

						foreach (var converter in map)
						{
							if (number < converter[1])
							{
								// 
								//	RRR
								//		MMMM	
								//
								if (number + range <= converter[1])
									continue;

								//else if (number + range >= converter[1])

								localNumbers.Add(converter[0]);

								//
								//	RRRR
								//	  MMMM
								//
								if (converter[2] >= number + range - converter[1])
								{
									localRanges.Add(number + range - converter[1]);

									numbers.Add(number);
									ranges.Add(converter[1] - number);
								}
								//
								//	RRRRRRR
								//	  MMM
								//
								else
								{
									localRanges.Add(converter[2]);

									numbers.Add(number);
									ranges.Add(converter[1] - number);

									numbers.Add(converter[1] + converter[2]); 
									ranges.Add(number + range - (converter[1] + converter[2]));
								}

								numbers.RemoveAt(0);
								ranges.RemoveAt(0);
								isMatched = true;
								break;
							}
							else //if (number >= converter[1])
							{
								//
								//		RRR
								//	MMM
								//
								if (number >= converter[1] + converter[2])
									continue;

								localNumbers.Add(converter[0] + (number - converter[1]));

								//
								//	  RRRR
								//	MMMM
								//
								if (converter[1] + converter[2] < number + range)
								{
									localRanges.Add(converter[1] + converter[2] - number);

									numbers.Add(converter[1] + converter[2]);
									ranges.Add(number + range - (converter[1] + converter[2]));
								}
								//
								//	  RRR
								//	MMMMMMM
								//
								else
								{
									localRanges.Add(range);
								}

								numbers.RemoveAt(0);
								ranges.RemoveAt(0);
								isMatched = true;
								break;
							}
						}

						if (!isMatched)
						{
							localNumbers.Add(number);
							localRanges.Add(range);
							numbers.RemoveAt(0);
							ranges.RemoveAt(0);
						}
					}

					// should be trying to merge the subarrays here
					// but probably that doesnt save as much time

					numbers = localNumbers;
					ranges = localRanges;
				}

				for (int y = 0; y < numbers.Count; y++)
				{
					for (int x = 0; x < ranges[y]; x++)
					{
						if (numbers[y]+x < lowest)
							lowest = numbers[y]+x;
					}
				}
			}

			Console.WriteLine(lowest); //17729182
		}
	}

	internal class Range
	{
		private int Beginning { get; set; }

		private int End { get; set; }
	}
}
