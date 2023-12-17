// ReSharper disable once CheckNamespace
namespace Advent23
{
	internal class Day13 : IDay
	{
		public void Star1()
		{
			var input = File.ReadAllLines("Day13/day13input.txt");
			long result = 0;

			var matrix = new List<List<char>>();

			foreach (var line in input)
			{
				if (line.Length < 1)
				{
					var checkMatrixVertically = CheckMatrixVertically(matrix);
					result += checkMatrixVertically;
					var checkMatrixHorizontally = CheckMatrixHorizontally(matrix);
					result += checkMatrixHorizontally;

					matrix = new List<List<char>>();
				}
				else
				{
					matrix.Add(line.ToCharArray().ToList());
				}
			}

			Console.WriteLine(result); //33520
		}

		public void Star2()
		{
			var input = File.ReadAllLines("Day13/day13input.txt");
			long result = 0;

			var matrix = new List<List<char>>();

			foreach (var line in input)
			{
				if (line.Length < 1)
				{
					var checkMatrixVertically = CheckMatrixVertically2(matrix);
					result += checkMatrixVertically;

					if (checkMatrixVertically == 0)
					{
						var checkMatrixHorizontally = CheckMatrixHorizontally2(matrix);
						result += checkMatrixHorizontally;
					}

					matrix = new List<List<char>>();
				}
				else
				{
					matrix.Add(line.ToCharArray().ToList());
				}
			}

			Console.WriteLine(result); //34824
		}

		private static int CheckMatrixVertically(List<List<char>> matrix)
		{
			for (int i = 0; i < matrix[0].Count - 1; i++)
			{
				var isMatching = true;

				for (int k = 0; k < matrix.Count; k++)
				{
					if (matrix[k][i] != matrix[k][i + 1])
					{
						isMatching = false;
						break;
					}
				}

				if (isMatching)
				{
					if (IsReflectionVertically(matrix, i, i + 1))
						return i + 1;
				}
			}

			return 0;
		}

		private static int CheckMatrixHorizontally(List<List<char>> matrix)
		{
			for (int i = 0; i < matrix.Count - 1; i++)
			{
				var isMatching = true;

				for (int k = 0; k < matrix[0].Count; k++)
				{
					if (matrix[i][k] != matrix[i + 1][k])
					{
						isMatching = false;
						break;
					}
				}

				if (isMatching)
				{
					if (IsReflectionHorizontally(matrix, i, i + 1))
						return (i + 1) * 100;
				}
			}

			return 0;
		}

		private static bool IsReflectionVertically(List<List<char>> matrix, int i, int j)
		{
			while (i >= 0 && j < matrix[0].Count)
			{
				var isMatching = true;

				for (int k = 0; k < matrix.Count; k++)
				{
					if (matrix[k][i] != matrix[k][j])
					{
						isMatching = false;
						break;
					}
				}

				if (!isMatching)
					return false;

				i--;
				j++;
			}

			return true;
		}

		private static bool IsReflectionHorizontally(List<List<char>> matrix, int i, int j)
		{
			while (i >= 0 && j < matrix.Count)
			{
				var isMatching = true;

				for (int k = 0; k < matrix[0].Count; k++)
				{
					if (matrix[i][k] != matrix[j][k])
					{
						isMatching = false;
						break;
					}
				}

				if (!isMatching)
					return false;

				i--;
				j++;
			}

			return true;
		}

		private static int CheckMatrixVertically2(List<List<char>> matrix)
		{
			for (int i = 0; i < matrix[0].Count - 1; i++)
			{
				var isMatching = 0;

				for (int k = 0; k < matrix.Count; k++)
				{
					if (matrix[k][i] != matrix[k][i + 1])
					{
						isMatching++;
					}
				}

				if (isMatching == 1 || isMatching == 0)
				{
					if (IsReflectionVertically2(matrix, i, i + 1))
						return i + 1;
				}
			}

			return 0;
		}

		private static int CheckMatrixHorizontally2(List<List<char>> matrix)
		{
			for (int i = 0; i < matrix.Count - 1; i++)
			{
				var isMatching = 0;

				for (int k = 0; k < matrix[0].Count; k++)
				{
					if (matrix[i][k] != matrix[i + 1][k])
					{
						isMatching++;
					}
				}

				if (isMatching == 1 || isMatching == 0)
				{
					if (IsReflectionHorizontally2(matrix, i, i + 1))
						return (i + 1) * 100;
				}
			}

			return 0;
		}

		private static bool IsReflectionVertically2(List<List<char>> matrix, int i, int j)
		{
			int smudgeCount = 0;

			while (i >= 0 && j < matrix[0].Count)
			{
				var isMatching = 0;

				for (int k = 0; k < matrix.Count; k++)
				{
					if (matrix[k][i] != matrix[k][j])
					{
						isMatching++;
						smudgeCount++;
					}
				}

				if (isMatching > 1)
				{
					return false;
				}

				i--;
				j++;
			}

			if (smudgeCount == 1)
				return true;
			else
			{
				return false;
			}
		}

		private static bool IsReflectionHorizontally2(List<List<char>> matrix, int i, int j)
		{
			int smudgeCount = 0;

			while (i >= 0 && j < matrix.Count)
			{
				var isMatching = 0;

				for (int k = 0; k < matrix[0].Count; k++)
				{
					if (matrix[i][k] != matrix[j][k])
					{
						isMatching++;
						smudgeCount++;
					}
				}

				if (isMatching > 1)
				{
					return false;
				}

				i--;
				j++;
			}

			if (smudgeCount == 1)
				return true;
			else
			{
				return false;
			}
		}
	}
}
