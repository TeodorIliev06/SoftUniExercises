namespace FootballManager.Models
{
	public class AmateurManager : Manager
	{
		private const double InitialRanking = 15.0;

		public AmateurManager(string name) 
			: base(name, InitialRanking)
		{
		}

		public override void RankingUpdate(double updateValue)
		{
			double adjustedValue = updateValue * 0.75;
			Ranking += adjustedValue;
		}
	}
}
