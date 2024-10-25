namespace FootballManager.Models
{
	using Models.Contracts;
	using static Utilities.Messages.ExceptionMessages;

	public abstract class Manager : IManager
	{
		private string name;
		private double ranking;

		public string Name
		{
			get => name;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ManagerNameNull);
				}
				name = value;
			}
		}

		public double Ranking
		{
			get => ranking;
			protected set
			{
				if (value < 0.00)
				{
					ranking = 0.00;
				}
				else if (value > 100.00)
				{
					ranking = 100.00;
				}
				else
				{
					ranking = value;
				}
			}
		}

		protected Manager(string name, double initialRanking)
		{
			Name = name;
			Ranking = initialRanking;
		}

		public abstract void RankingUpdate(double updateValue);

		public override string ToString()
		{
			return $"{Name} - {this.GetType().Name} (Ranking: {Ranking:F2})";
		}
	}
}
