namespace FootballManager.Models
{
	using Models.Contracts;
	using static Utilities.Messages.ExceptionMessages;

	public class Team : ITeam
	{
		private string name;
		private int championshipPoints;
		private IManager teamManager;

		public string Name
		{
			get => name;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(TeamNameNull);
				}
				name = value;
			}
		}

		public int ChampionshipPoints
		{
			get => championshipPoints;
			private set => championshipPoints = value;
		}

		public IManager TeamManager
		{
			get => teamManager;
			private set => teamManager = value;
		}

		public int PresentCondition
		{
			get
			{
				if (TeamManager == null)
				{
					return 0;
				}
				if (ChampionshipPoints == 0)
				{
					return (int)Math.Floor(TeamManager.Ranking);
				}
				return (int)Math.Floor(ChampionshipPoints * TeamManager.Ranking);
			}
		}

		public Team(string name)
		{
			Name = name;
			ChampionshipPoints = 0;
		}

		public void SignWith(IManager manager)
		{
			TeamManager = manager;
		}

		public void GainPoints(int points)
		{
			ChampionshipPoints += points;
		}

		public void ResetPoints()
		{
			ChampionshipPoints = 0;
		}

		public override string ToString() => $"Team: {Name} Points: {ChampionshipPoints}";
	}
}
