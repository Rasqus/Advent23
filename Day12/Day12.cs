// ReSharper disable once CheckNamespace
namespace Advent23
{
	internal class Day12 : IDay
	{
		public void Star1()
		{
			var input = File.ReadAllLines("Day12/day12input.txt");
			long result = 0;

			foreach (var line in input)
			{
				var record = line.Split(" ")[0];
				var groups = line.Split(" ")[1].Split(",");

				var recordList = record.ToCharArray().ToList();
				var groupsList = groups.Select(int.Parse).ToList();

				dict = new Dictionary<string, long>();

				long count = FindCombinations(recordList, groupsList);
				result += count;
			}

			Console.WriteLine(result); // 8419
		}

		public void Star2()
		{
			var input = File.ReadAllLines("Day12/day12input.txt");
			long result = 0;

			foreach (var line in input)
			{
				var record = line.Split(" ")[0];
				var groups = line.Split(" ")[1].Split(",");

				var recordList = record.ToCharArray().ToList();
				var groupsList = groups.Select(int.Parse).ToList();

				var originalRecordList = new List<char>(recordList);
				var originalGroupsList = new List<int>(groupsList);

				for (int i = 0; i < 4; i++)
				{
					recordList.Add('?');
					recordList.AddRange(originalRecordList);

					groupsList.AddRange(originalGroupsList);
				}

				//memory of starting sequences
				dict = new Dictionary<string, long>();
				
				long count = FindCombinations(recordList, groupsList);
				result += count;
			}

			Console.WriteLine(result); // 160500973317706
		}

		private static Dictionary<string, long> dict = new();

		private static long FindCombinations(List<char> line, List<int> expected)
		{
			line = RemoveUnnecessary(new string(line.ToArray()));
			var s = new string(line.ToArray());
			if (!dict.ContainsKey(s))
			{
				dict[s] = InnerFind(line, expected);
			}
			return dict[s];
		}

		private static long InnerFind(List<char> line, List<int> expected)
		{
			List<int> p;
			if (!line.Contains('?'))
			{
				p = GetGroupsFromLine(new string(line.ToArray()));
				return p.SequenceEqual(expected) ? 1 : 0;
			}

			var indexOfUnknown = line.IndexOf('?');
			p = GetGroupsFromLine(new string(line.GetRange(0, indexOfUnknown).ToArray()));

			var endOfSubP = Math.Max(0, p.Count - 1);
			var subP = p.GetRange(0, endOfSubP);
			var endOfSubExpected = Math.Min(endOfSubP, expected.Count - 1);
			var subExpected = expected.GetRange(0, endOfSubExpected);

			if (!subP.SequenceEqual(subExpected))
				return 0;

			// partial line has a group at the end that's larger than allowed
			if (p.Count > 0 && p[p.Count - 1] > expected[endOfSubExpected])
				return 0;

			line[indexOfUnknown] = '#';
			var a = FindCombinations(line, expected);
			line[indexOfUnknown] = '.';
			var b = FindCombinations(line, expected);
			line[indexOfUnknown] = '?';
			return a + b;
		}

		private static List<int> GetGroupsFromLine(string line)
		{
			var current = 0;
			var actual = new List<int>();
			foreach (var c in line)
			{
				if (c == '.' && current > 0)
				{
					actual.Add(current);
					current = 0;
				}
				if (c == '#')
				{
					current += 1;
				}
			}
			if (current > 0) 
				actual.Add(current);
			return actual;
		}

		private static List<char> RemoveUnnecessary(string line)
		{
			var s = new List<char> { line[0] };
			for (var i = 1; i < line.Length; i++)
			{
				if (line[i] != '.' || line[i-1] != '.')
					s.Add(line[i]);
			}
			return s;
		}

	}
}
