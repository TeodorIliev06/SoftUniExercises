namespace FootballManager.Repositories
{
	using Models.Contracts;
	using Repositories.Contracts;
	public class TeamRepository : IRepository<ITeam>
	{
		private readonly List<ITeam> teams;
		private const int MaxCapacity = 10;

		public TeamRepository()
		{
			teams = new List<ITeam>();
		}

		public IReadOnlyCollection<ITeam> Models => teams.AsReadOnly();

		public int Capacity => MaxCapacity;

		public void Add(ITeam team)
		{
			if (teams.Count >= MaxCapacity)
			{
				// Capacity exceeded, abort the operation
				return;
			}
			teams.Add(team);
		}

		public bool Remove(string name)
		{
			var team = teams.FirstOrDefault(t => t.Name == name);
			if (team != null)
			{
				teams.Remove(team);
				return true;
			}
			return false;
		}

		public bool Exists(string name)
		{
			return teams.Any(t => t.Name == name);
		}

		public ITeam Get(string name)
		{
			return teams.FirstOrDefault(t => t.Name == name);
		}
	}
}
