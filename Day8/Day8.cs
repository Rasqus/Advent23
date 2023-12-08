// ReSharper disable once CheckNamespace
namespace Advent23
{
	internal class Day8 : IDay
	{
		public void Star1()
		{
			var input = File.ReadAllLines("Day8/day8input.txt");

			var turns = input[0];

			var elements = new Dictionary<string, Directions>();

			for (var i = 2; i < input.Length; i++)
			{
				var start = input[i].Substring(0, 3);
				var left = input[i].Substring(7,3);
				var right = input[i].Substring(12,3);

				elements.Add(start, new Directions(left, right));
			}

			var current = "AAA";
			var x = 0;
			var numOfSteps = 0;

			while (current != "ZZZ")
			{
				current = turns[x] == 'L' ? elements[current].Left : elements[current].Right;

				numOfSteps++;
				x++;
				if (x == turns.Length)
					x = 0;
			}

			Console.WriteLine(numOfSteps); //17141
		}

		public void Star2()
		{
			var input = File.ReadAllLines("Day8/day8input.txt");

			var turns = input[0];

			var elements = new Dictionary<string, Directions>();

			for (var i = 2; i < input.Length; i++)
			{
				var start = input[i].Substring(0, 3);
				var left = input[i].Substring(7, 3);
				var right = input[i].Substring(12, 3);

				elements.Add(start, new Directions(left, right));
			}

			var paths = new List<string>();

			foreach (var element in elements)
			{
				if (element.Key.EndsWith('A'))
					paths.Add(element.Key);
			}

			var numberOfStepsList = new List<long>();

			foreach (var path in paths)
			{
				var current = path;
				var x = 0;
				var numOfSteps = 0;

				while (!current.EndsWith('Z'))
				{
					current = turns[x] == 'L' ? elements[current].Left : elements[current].Right;

					numOfSteps++;
					x++;
					if (x == turns.Length)
						x = 0;
				}

				numberOfStepsList.Add(numOfSteps);
			}

			var result = LcmOfArray(numberOfStepsList);

			Console.WriteLine(result); // 10818234074807
		}

		private static long Gcd(long num1, long num2)
		{
			return num2 == 0 ? num1 : Gcd(num2, num1 % num2);
		}

		private static long LcmOfArray(List<long> arr)
		{
			var lcm = arr[0];
			for (int i = 1; i < arr.Count; i++)
			{
				var num1 = lcm;
				var num2 = arr[i];
				var gcdVal = Gcd(num1, num2);
				lcm = (lcm * arr[i]) / gcdVal;
			}
			return lcm;
		}
	}

	internal class Directions
	{
		public string Left { get; set; }
		public string Right { get; set; }

		public Directions(string left, string right)
		{
			Left = left;
			Right = right;
		}
	}
}
