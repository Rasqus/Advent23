// ReSharper disable once CheckNamespace
namespace Advent23
{
	internal class Day10 : IDay
	{
		public void Star1()
		{
			var input = File.ReadAllLines("Day10/day10input.txt");

			var matrix = new List<string>();
			int startX = 0;
			int startY = 0;

			for (int i = 0; i < input.Length; i++)
			{
				matrix.Add(input[i]);

				if (input[i].Contains('S'))
				{
					startX = i;
					startY = input[i].IndexOf('S');
				}
			}

			int X = startX;
			int Y = startY;

			int length = 0;
			string from;

			if (matrix[X][Y - 1] == '-' || matrix[X][Y - 1] == 'F' || matrix[X][Y - 1] == 'L')
			{
				Y -= 1;
				from = "right";
			}
			else if (matrix[X][Y + 1] == '-' || matrix[X][Y + 1] == 'J' || matrix[X][Y + 1] == '7')
			{
				Y += 1;
				from = "left";
			}
			else if (matrix[X + 1][Y] == '|' || matrix[X + 1][Y] == 'J' || matrix[X + 1][Y] == 'L')
			{
				X += 1;
				from = "bottom";
			}
			else
			{
				X -= 1;
				from = "top";
			}

			while (X != startX || Y != startY)
			{
				var turn = input[X][Y];

				switch (from)
				{
					case "right":
						switch (turn)
						{
							case '-':
								Y -= 1;
								from = "right";
								break;
							case 'F':
								X += 1;
								from = "top";
								break;
							case 'L':
								X -= 1;
								from = "bottom";
								break;
							default:
								Console.WriteLine("Error");
								break;
						}
						break;
					case "left":
						switch (turn)
						{
							case '-':
								Y += 1;
								from = "left";
								break;
							case '7':
								X += 1;
								from = "top";
								break;
							case 'J':
								X -= 1;
								from = "bottom";
								break;
							default:
								Console.WriteLine("Error");
								break;
						}
						break;
					case "top":
						switch (turn)
						{
							case '|':
								X += 1;
								from = "top";
								break;
							case 'L':
								Y += 1;
								from = "left";
								break;
							case 'J':
								Y -= 1;
								from = "right";
								break;
							default:
								Console.WriteLine("Error");
								break;
						}
						break;
					case "bottom":
						switch (turn)
						{
							case '|':
								X -= 1;
								from = "bottom";
								break;
							case 'F':
								Y += 1;
								from = "left";
								break;
							case '7':
								Y -= 1;
								from = "right";
								break;
							default:
								Console.WriteLine("Error");
								break;
						}
						break;
				}

				length++;
			}

			Console.WriteLine((length + 1) / 2);
		}

		public void Star2()
		{
			var input = File.ReadAllLines("Day10/day10input.txt");

			matrix = new List<List<char>>();
			loopTiles = new List<List<char>>();
			int startX = 0;
			int startY = 0;

			for (int i = 0; i < input.Length; i++)
			{
				var line = new List<char>();
				for (int j = 0; j < input[i].Length; j++)
				{
					line.Add(input[i][j]);

					if (j != input[i].Length - 1)
						line.Add('X');
				}

				if (line.Contains('S'))
				{
					startX = matrix.Count;
					startY = line.IndexOf('S');
				}

				matrix.Add(line);

				if (i != input.Length - 1 )
					matrix.Add(line.Select(c => 'X').ToList());
			}

			foreach (var line in matrix)
			{
				loopTiles.Add(new List<char>(line));
			}


			int X = startX;
			int Y = startY;

			int enclosed = 0;
			string from;

			if (matrix[X][Y - 2] == '-' || matrix[X][Y - 2] == 'F' || matrix[X][Y - 2] == 'L')
			{
				loopTiles[X][Y] = '*';
				loopTiles[X][Y - 1] = '*';
				loopTiles[X][Y - 2] = '*';
				Y -= 2;
				from = "right";
			}
			else if (matrix[X][Y + 2] == '-' || matrix[X][Y + 2] == 'J' || matrix[X][Y + 2] == '7')
			{
				loopTiles[X][Y] = '*';
				loopTiles[X][Y + 1] = '*';
				loopTiles[X][Y + 2] = '*';
				Y += 2;
				from = "left";
			}
			else if (matrix[X + 2][Y] == '|' || matrix[X + 2][Y] == 'J' || matrix[X + 2][Y] == 'L')
			{
				loopTiles[X][Y] = '*';
				loopTiles[X + 1][Y] = '*';
				loopTiles[X + 2][Y] = '*';
				X += 2;
				from = "bottom";
			}
			else
			{
				loopTiles[X][Y] = '*';
				loopTiles[X - 1][Y] = '*';
				loopTiles[X - 2][Y] = '*';
				X -= 2;
				from = "top";
			}

			while (X != startX || Y != startY)
			{
				var turn = matrix[X][Y];

				switch (from)
				{
					case "right":
						switch (turn)
						{
							case '-':
								loopTiles[X][Y - 1] = '*';
								Y -= 2;
								from = "right";
								break;
							case 'F':
								loopTiles[X + 1][Y] = '*';
								X += 2;
								from = "top";
								break;
							case 'L':
								loopTiles[X - 1][Y] = '*';
								X -= 2;
								from = "bottom";
								break;
							default:
								Console.WriteLine("Error");
								break;
						}
						break;
					case "left":
						switch (turn)
						{
							case '-':
								loopTiles[X][Y + 1] = '*';
								Y += 2;
								from = "left";
								break;
							case '7':
								loopTiles[X + 1][Y] = '*';
								X += 2;
								from = "top";
								break;
							case 'J':
								loopTiles[X - 1][Y] = '*';
								X -= 2;
								from = "bottom";
								break;
							default:
								Console.WriteLine("Error");
								break;
						}
						break;
					case "top":
						switch (turn)
						{
							case '|':
								loopTiles[X + 1][Y] = '*';
								X += 2;
								from = "top";
								break;
							case 'L':
								loopTiles[X][Y + 1] = '*';
								Y += 2;
								from = "left";
								break;
							case 'J':
								loopTiles[X][Y - 1] = '*';
								Y -= 2;
								from = "right";
								break;
							default:
								Console.WriteLine("Error");
								break;
						}
						break;
					case "bottom":
						switch (turn)
						{
							case '|':
								loopTiles[X - 1][Y] = '*';
								X -= 2;
								from = "bottom";
								break;
							case 'F':
								loopTiles[X][Y + 1] = '*';
								Y += 2;
								from = "left";
								break;
							case '7':
								loopTiles[X][Y - 1] = '*';
								Y -= 2;
								from = "right";
								break;
							default:
								Console.WriteLine("Error");
								break;
						}
						break;
				}

				loopTiles[X][Y] = '*';
			}

			for (int i = 0; i < matrix.Count; i++)
			{
				if (loopTiles[i][0] != '*')
				{
					queue.Enqueue(new Tuple<int, int>(i, 0));

					while (queue.Count > 0)
					{
						var x = queue.Dequeue();
						Check(x.Item1, x.Item2);
					}
				}

				if (loopTiles[i][matrix[0].Count - 1] != '*')
				{
					queue.Enqueue(new Tuple<int, int>(i, matrix[0].Count - 1));

					while (queue.Count > 0)
					{
						var x = queue.Dequeue();
						Check(x.Item1, x.Item2);
					}
				}
			}

			for (int i = 0; i < matrix[0].Count; i++)
			{
				if (loopTiles[0][i] != '*')
				{
					queue.Enqueue(new Tuple<int, int>(0, i));

					while (queue.Count > 0)
					{
						var x = queue.Dequeue();
						Check(x.Item1, x.Item2);
					}
				}

				if (loopTiles[matrix.Count - 1][i] != '*')
				{
					queue.Enqueue(new Tuple<int, int>(matrix.Count - 1, i));

					while (queue.Count > 0)
					{
						var x = queue.Dequeue();
						Check(x.Item1, x.Item2);
					}
				}
			}

			//foreach (var x in loopTiles)
			//	Console.WriteLine(new string(x.ToArray()));
			//foreach (var x in matrix)
			//	Console.WriteLine(new string(x.ToArray()));

			for (int i = 0; i < loopTiles.Count; i++)
			{
				for (int j = 0; j < loopTiles[i].Count; j++)
				{
					if (loopTiles[i][j] != 'M' && matrix[i][j] != 'X' && loopTiles[i][j] != '*')
					{
						loopTiles[i][j] = 'O';
						enclosed++;
					}
					else if (loopTiles[i][j] != '*')
					{
						loopTiles[i][j] = '.';
					}
				}
			}

			//foreach (var x in loopTiles)
			//	Console.WriteLine(new string(x.ToArray()));

			Console.WriteLine(enclosed); //567
		}

		public void Check(int x, int y)
		{
			if (loopTiles[x][y] == '*' || loopTiles[x][y] == 'M')
				return;

			loopTiles[x][y] = 'M';

			// left
			if (y > 0)
				queue.Enqueue(new Tuple<int, int>(x, y-1));

			//right
			if (y < matrix[0].Count - 1)
				queue.Enqueue(new Tuple<int, int>(x, y + 1));

			//top
			if (x > 0)
				queue.Enqueue(new Tuple<int, int>(x - 1, y));

			//bottom
			if (x < matrix.Count - 1)
				queue.Enqueue(new Tuple<int, int>(x + 1, y));
		}

		private List<List<char>> matrix;
		private List<List<char>> loopTiles;

		private Queue<Tuple<int, int>> queue = new();
	}
}
