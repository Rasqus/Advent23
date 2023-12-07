// ReSharper disable once CheckNamespace
namespace Advent23
{
	internal class Day7 : IDay
	{
		public void Star1()
		{
			var input = File.ReadAllLines("Day7/day7input.txt");

			var hands = new List<Hand>();

			foreach (var line in input)
			{
				var split = line.Split(' ');
				List<int> cards = new List<int>();
				foreach (var card in split[0])
				{
					switch (card)
					{
						case 'A':
							cards.Add(14);
							break;
						case 'K':
							cards.Add(13);
							break;
						case 'Q':
							cards.Add(12);
							break;
						case 'J':
							cards.Add(11);
							break;
						case 'T':
							cards.Add(10);
							break;
						default:
							cards.Add(card - '0');
							break;
					}
				}

				var dict = new Dictionary<int, int>();

				foreach (var card in cards)
				{
					if (dict.ContainsKey(card))
					{
						dict[card]++;
					}
					else
					{
						dict.Add(card, 1);
					}
				}

				var type = 0;

				foreach (var key in dict.Keys)
				{
					if (dict.ContainsValue(5))
						type = 7;
					else if (dict.ContainsValue(4))
						type = 6;
					else if (dict.ContainsValue(3) && dict.ContainsValue(2))
						type = 5;
					else if (dict.ContainsValue(3))
						type = 4;
					else if (dict.Values.Where(v => v == 2).ToList().Count == 2)
						type = 3;
					else if (dict.Values.Where(v => v == 2).ToList().Count == 1)
						type = 2;
					else
						type = 1;
				}

				hands.Add(new Hand(cards, type, int.Parse(split[1])));
			}

			hands.Sort();
			hands.Reverse();

			var total = 0;
			for (int i = 0; i < hands.Count; i++)
			{
				total += hands[i].Bid * (i+1);

			}
			Console.WriteLine(total); //250058342
		}

		public void Star2()
		{
			var input = File.ReadAllLines("Day7/day7input.txt");

			var hands = new List<Hand>();

			foreach (var line in input)
			{
				var split = line.Split(' ');
				List<int> cards = new List<int>();
				foreach (var card in split[0])
				{
					switch (card)
					{
						case 'A':
							cards.Add(14);
							break;
						case 'K':
							cards.Add(13);
							break;
						case 'Q':
							cards.Add(12);
							break;
						case 'J':
							cards.Add(1);
							break;
						case 'T':
							cards.Add(10);
							break;
						default:
							cards.Add(card - '0');
							break;
					}
				}

				var dict = new Dictionary<int, int>();

				foreach (var card in cards)
				{
					if (dict.ContainsKey(card))
					{
						dict[card]++;
					}
					else
					{
						dict.Add(card, 1);
					}
				}

				var type = 0;

				foreach (var key in dict.Keys)
				{
					if (dict.ContainsValue(5))
						type = 7;
					else if (dict.ContainsValue(4))
					{
						type = 6;
						if (dict.ContainsKey(1))
							type = 7;
					}
					else if (dict.ContainsValue(3) && dict.ContainsValue(2))
					{
						type = 5;
						if (dict.ContainsKey(1)) 
							type = 7;
					}
					else if (dict.ContainsValue(3))
					{
						type = 4;
						if (dict.ContainsKey(1)) 
							type = 6;
					}
					else if (dict.Values.Where(v => v == 2).ToList().Count == 2)
					{
						type = 3;
						if (dict.ContainsKey(1))
						{
							if (dict[1] == 2)
								type = 6;
							else if (dict[1] == 1)
								type = 5;
						}
					}
					else if (dict.Values.Where(v => v == 2).ToList().Count == 1)
					{
						type = 2;
						if (dict.ContainsKey(1))
							type = 4;
					}
					else
					{
						type = 1;
						if (dict.ContainsKey(1))
							type = 2;
					}
				}

				hands.Add(new Hand(cards, type, int.Parse(split[1])));
			}

			hands.Sort();
			hands.Reverse();

			var total = 0;
			for (int i = 0; i < hands.Count; i++)
			{
				total += hands[i].Bid * (i + 1);

			}
			Console.WriteLine(total); //250506580
		}
	}

	internal class Hand : IComparable<Hand>
	{
		public List<int> Cards { get; set; }

		public int Type { get; set; }

		public int Bid { get; set; }

		public Hand(List<int> cards, int type, int bid)
		{
			Cards = cards;
			Type = type;
			Bid = bid;
		}

		public int CompareTo(Hand? other)
		{
			if (other == null) 
				return -1;

			if (Type != other.Type)
			{
				return Type > other.Type ? -1 : 1;
			}
			else if (Cards[0] != other.Cards[0])
			{
				return Cards[0] > other.Cards[0] ? -1 : 1;
			}
			else if (Cards[1] != other.Cards[1])
			{
				return Cards[1] > other.Cards[1] ? -1 : 1;
			}
			else if (Cards[2] != other.Cards[2])
			{
				return Cards[2] > other.Cards[2] ? -1 : 1;
			}
			else if (Cards[3] != other.Cards[3])
			{
				return Cards[3] > other.Cards[3] ? -1 : 1;
			}
			else if (Cards[4] != other.Cards[4])
			{
				return Cards[4] > other.Cards[4] ? -1 : 1;
			}
			else
				return 0;
		}

		public override string ToString()
		{
			return $"Cards: {string.Join(",", Cards)} Type: {Type}, Bid: {Bid}";
		}
	}
}
