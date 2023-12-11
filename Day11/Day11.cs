// ReSharper disable once CheckNamespace
namespace Advent23
{
	internal class Day11 : IDay
	{
		public void Star1()
		{
			var input = File.ReadAllLines("Day11/day11input.txt");

			var matrix = new List<List<char>>();
			int galaxyNumber = 0;

			foreach (var line in input)
			{
				var row = new List<char>();

				var originalNumber = galaxyNumber;

				foreach (var c in line)
				{
					if (c ==  '#')
					{
						row.Add(c);
						galaxyNumber++;
					}
					else
					{
						row.Add(c);
					}
				}

				matrix.Add(row);

				if (galaxyNumber == originalNumber)
					matrix.Add(row.Select(c => '|').ToList());
			}

			for (int i = 0; i < matrix[0].Count; i++)
			{
				bool galaxy = false;

				for (int j = 0; j < matrix.Count; j++)
				{
					if (matrix[j][i] == '#')
					{
						galaxy = true;
						break;
					}
				}

				if (!galaxy)
				{
					foreach (var line in matrix)
					{
						line.Insert(i, '|');
					}

					i++;
				}
			}

			var list = new List<Tuple<int, int>>();

			for (var i = 0; i < matrix.Count; i++)
			{
				var line = matrix[i];
				for (var j = 0; j < line.Count; j++)
				{
					var c = line[j];
					if (c == '#')
						list.Add(new Tuple<int, int>(i, j));
				}
			}

			//foreach (var line in matrix)
			//{
			//	Console.WriteLine(new string(line.ToArray()));
			//}

			var result = 0;

			for (int i = 0; i < galaxyNumber; i++)
			{
				for (int j = i + 1; j < galaxyNumber; j++)
				{
					var galaxy1 = list[i];
					var galaxy2 = list[j];

					var path = Math.Abs(galaxy1.Item1 - galaxy2.Item1) + Math.Abs(galaxy1.Item2 - galaxy2.Item2);

					result += path;
				}
			}

			Console.WriteLine(result); //9684228
		}

		public void Star2()
		{
			var input = File.ReadAllLines("Day11/day11input.txt");

			var matrix = new List<List<char>>();
			int galaxyNumber = 0;

			foreach (var line in input)
			{
				var row = new List<char>();

				var originalNumber = galaxyNumber;

				foreach (var c in line)
				{
					if (c == '#')
					{
						row.Add(c);
						galaxyNumber++;
					}
					else
					{
						row.Add(c);
					}
				}

				matrix.Add(row);

				if (galaxyNumber == originalNumber)
					matrix.Add(row.Select(c => '|').ToList());
			}

			for (int i = 0; i < matrix[0].Count; i++)
			{
				bool galaxy = false;

				for (int j = 0; j < matrix.Count; j++)
				{
					if (matrix[j][i] == '#')
					{
						galaxy = true;
						break;
					}
				}

				if (!galaxy)
				{
					foreach (var line in matrix)
					{
						line.Insert(i, '|');
					}

					i++;
				}
			}

			var list = new List<Tuple<int, int>>();

			for (var i = 0; i < matrix.Count; i++)
			{
				var line = matrix[i];
				for (var j = 0; j < line.Count; j++)
				{
					var c = line[j];
					if (c == '#')
						list.Add(new Tuple<int, int>(i, j));
				}
			}

			var result = 0L;

			for (var i = 0; i < galaxyNumber; i++)
			{
				for (var j = i + 1; j < galaxyNumber; j++)
				{
					var galaxy1 = list[i];
					var galaxy2 = list[j];

					var path = 0;

					var rowLower = galaxy1.Item1 > galaxy2.Item1 ? galaxy2.Item1 : galaxy1.Item1;
					var rowHigher = galaxy1.Item1 > galaxy2.Item1 ? galaxy1.Item1 : galaxy2.Item1;
					var colLower = galaxy1.Item2 > galaxy2.Item2 ? galaxy2.Item2 : galaxy1.Item2;
					var colHigher = galaxy1.Item2 > galaxy2.Item2 ? galaxy1.Item2 : galaxy2.Item2;

					for (var row = rowLower; row < rowHigher; row++)
					{
						if (matrix[row][galaxy1.Item2] == '|')
							path += 999999;
						else
							path++;
					}

					for (var col = colLower; col < colHigher; col++)
					{
						if (matrix[galaxy1.Item1][col] == '|')
							path += 999999;
						else
							path++;
					}

					result += path;
				}
			}

			Console.WriteLine(result); //483844716556
		}
	}
}
