// ReSharper disable once CheckNamespace
namespace Advent23
{
	internal class Day14 : IDay
	{
		public void Star1()
		{
			var input = File.ReadAllLines("Day14/day14input.txt");
			long result = 0;

			var matrix = new List<List<char>>();

			foreach (var line in input)
			{
				matrix.Add(line.ToCharArray().ToList());
			}

			var height = input.Length;

			for (int i = 0; i < height; i++)
			{
				var sum = 0;
				var lastHashPosition = -1;

				for (int j = 0; j < height; j++)
				{
					switch (matrix[j][i])
					{
						case '.':
							continue;
						case 'O':
							sum += height - (lastHashPosition + 1);
							lastHashPosition++;
							break;
						case '#':
							lastHashPosition = j;
							break;
					}
				}

				result += sum;
			}

			Console.WriteLine(result); //106648
		}

		public void Star2()
		{
			var input = File.ReadAllLines("Day14/day14input.txt");
			long result = 0;

			int matchingMemoryMatrix = 0;
			int memoryLoopLength = 0;

			var matrix = new List<List<char>>();

			foreach (var line in input)
			{
				matrix.Add(line.ToCharArray().ToList());
			}

			var memoryMatrixList = new List<List<List<char>>>();

			var memoryMatrix = new List<List<char>>();
			foreach (var m in matrix)
				memoryMatrix.Add(new List<char>(m));

			memoryMatrixList.Add(memoryMatrix);

			var height = input.Length;

			for (var k = 1; k <= 1000000000; k++)
			{
				for (int i = 0; i < height; i++)
				{
					var lastHashPosition = -1;

					for (int j = 0; j < input[0].Length; j++)
					{
						switch (matrix[j][i])
						{
							case '.':
								continue;
							case 'O':
								if (matrix[lastHashPosition + 1][i] != 'O')
								{
									matrix[lastHashPosition + 1][i] = 'O';
									matrix[j][i] = '.';
								}

								lastHashPosition++;
								break;
							case '#':
								lastHashPosition = j;
								break;
						}
					}
				}

				for (int j = 0; j < input[0].Length; j++)
				{
					var lastHashPosition = -1;

					for (int i = 0; i < input.Length; i++)
					{
						switch (matrix[j][i])
						{
							case '.':
								continue;
							case 'O':
								if (matrix[j][lastHashPosition + 1] != 'O')
								{
									matrix[j][lastHashPosition + 1] = 'O';
									matrix[j][i] = '.';
								}

								lastHashPosition++;
								break;
							case '#':
								lastHashPosition = i;
								break;
						}
					}
				}

				for (int i = height - 1; i >= 0; i--)
				{
					var lastHashPosition = height;

					for (int j = height - 1; j >= 0; j--)
					{
						switch (matrix[j][i])
						{
							case '.':
								continue;
							case 'O':
								if (matrix[lastHashPosition - 1][i] != 'O')
								{
									matrix[lastHashPosition - 1][i] = 'O';
									matrix[j][i] = '.';
								}

								lastHashPosition--;
								break;
							case '#':
								lastHashPosition = j;
								break;
						}
					}
				}


				for (int j = height - 1; j >= 0; j--)
				{
					var lastHashPosition = height;

					for (int i = height - 1; i >= 0; i--)
					{
						switch (matrix[j][i])
						{
							case '.':
								continue;
							case 'O':
								if (matrix[j][lastHashPosition - 1] != 'O')
								{
									matrix[j][lastHashPosition - 1] = 'O';
									matrix[j][i] = '.';
								}

								lastHashPosition--;
								break;
							case '#':
								lastHashPosition = i;
								break;
						}
					}
				}


				var match = true;

				for (int x = 0; x < memoryMatrixList.Count; x++)
				{
					match = true;

					for (int i = 0; i < height; i++)
					{
						for (int j = 0; j < height; j++)
						{
							if (matrix[i][j] != memoryMatrixList[x][i][j])
							{
								match = false;
								break;
							}
						}

						if (!match)
							break;
					}

					if (match)
					{
						matchingMemoryMatrix = x;
						memoryLoopLength = k - x;
						break;
					}
				}

				if (!match)
				{
					memoryMatrix = new List<List<char>>();
					foreach (var m in matrix)
						memoryMatrix.Add(new List<char>(m));

					memoryMatrixList.Add(memoryMatrix);
				}
				else
				{
					break;
				}
				//foreach (var line in matrix)
				//	Console.WriteLine(new string(line.ToArray()));
			}

			var matrixNum = ((1000000000 - matchingMemoryMatrix) % (memoryLoopLength)) + matchingMemoryMatrix;

			for (int i = 0; i < height; i++)
			{
				var sum = 0;

				for (int j = 0; j < height; j++)
				{
					switch (memoryMatrixList[matrixNum][j][i])
					{
						case '.':
							continue;
						case 'O':
							sum += height - j;
							break;
						case '#':
							break;
					}
				}

				result += sum;
			}


			Console.WriteLine(result); //87700
		}
	}
}
