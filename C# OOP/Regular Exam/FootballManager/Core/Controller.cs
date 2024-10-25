namespace FootballManager.Core
{
	using System.Text;

	using Models;
	using Repositories;
	using Core.Contracts;
	using Models.Contracts;
	using Repositories.Contracts;

	using static Utilities.Messages.OutputMessages;

	public class Controller : IController
	{
		private readonly IRepository<ITeam> championship;
		private static readonly HashSet<string> validManagerTypes = new HashSet<string>
		{
			nameof(AmateurManager),
			nameof(SeniorManager),
			nameof(ProfessionalManager)
		};

		public Controller()
		{
			this.championship = new TeamRepository();
		}

		public string JoinChampionship(string teamName)
		{
			if (championship.Models.Count >= championship.Capacity)
			{
				return ChampionshipFull;
			}

			if (championship.Exists(teamName))
			{
				return String.Format(TeamWithSameNameExisting, teamName);
			}

			ITeam team = new Team(teamName);
			championship.Add(team);

			return String.Format(TeamSuccessfullyJoined, teamName);
		}

		public string SignManager(string teamName, string managerTypeName, string managerName)
		{
			ITeam team = championship.Get(teamName);
			if (team == null)
			{
				return String.Format(TeamDoesNotTakePart, teamName);
			}

			if (team.TeamManager != null)
			{
				return String.Format(TeamSignedWithAnotherManager, teamName, team.TeamManager.Name);
			}

			if (championship.Models.Any(t => t.TeamManager != null && t.TeamManager.Name == managerName))
			{
				return String.Format(ManagerAssignedToAnotherTeam, managerName);
			}

			if (!validManagerTypes.Contains(managerTypeName))
			{
				return String.Format(ManagerTypeNotPresented, managerTypeName);
			}

			IManager manager = managerTypeName switch
			{
				nameof(AmateurManager) => new AmateurManager(managerName),
				nameof(SeniorManager) => new SeniorManager(managerName),
				nameof(ProfessionalManager) => new ProfessionalManager(managerName)
			};

			team.SignWith(manager);
			return String.Format(TeamSuccessfullySignedWithManager, managerName, teamName);
		}

		public string MatchBetween(string teamOneName, string teamTwoName)
		{
			ITeam teamOne = championship.Get(teamOneName);
			ITeam teamTwo = championship.Get(teamTwoName);

			if (teamOne == null || teamTwo == null)
			{
				return OneOfTheTeamDoesNotExist;
			}

			int teamOneCondition = teamOne.PresentCondition;
			int teamTwoCondition = teamTwo.PresentCondition;

			if (teamOneCondition > teamTwoCondition)
			{
				teamOne.GainPoints(3);

				if (teamOne.TeamManager != null)
				{
					teamOne.TeamManager.RankingUpdate(5);
				}

				if (teamTwo.TeamManager != null)
				{
					teamTwo.TeamManager.RankingUpdate(-5);
				}

				return String.Format(TeamWinsMatch, teamOneName, teamTwoName);
			}
			else if (teamOneCondition < teamTwoCondition)
			{
				teamTwo.GainPoints(3);

				if (teamTwo.TeamManager != null)
				{
					teamTwo.TeamManager.RankingUpdate(5);
				}

				if (teamOne.TeamManager != null)
				{
					teamOne.TeamManager.RankingUpdate(-5);
				}

				return String.Format(TeamWinsMatch, teamTwoName, teamOneName);
			}
			else
			{
				teamOne.GainPoints(1);
				teamTwo.GainPoints(1);

				return String.Format(MatchIsDraw, teamOneName, teamTwoName);
			}
		}

		public string PromoteTeam(string droppingTeamName, string promotingTeamName,
			string managerTypeName, string managerName)
		{
			if (!championship.Exists(droppingTeamName))
			{
				return String.Format(DroppingTeamDoesNotExist, droppingTeamName);
			}

			if (championship.Exists(promotingTeamName))
			{
				return String.Format(TeamWithSameNameExisting, promotingTeamName);
			}

			ITeam newTeam = new Team(promotingTeamName);

			if (championship.Models.Any(t => t.TeamManager != null && t.TeamManager.Name == managerName))
			{
				// Intentional: Leave the team without a manager
			}
			else if (validManagerTypes.Contains(managerTypeName))
			{
				IManager manager = managerTypeName switch
				{
					nameof(AmateurManager) => new AmateurManager(managerName),
					nameof(SeniorManager) => new SeniorManager(managerName),
					nameof(ProfessionalManager) => new ProfessionalManager(managerName),
					_ => null
				};

				if (manager != null)
				{
					newTeam.SignWith(manager);
				}
			}

			// Reset ChampionshipPoints for all teams
			foreach (var team in championship.Models)
			{
				team.ResetPoints();
			}

			championship.Remove(droppingTeamName);
			championship.Add(newTeam);

			return String.Format(TeamHasBeenPromoted, newTeam.Name);
		}

		public string ChampionshipRankings()
		{
			var sortedTeams = championship.Models
				.OrderByDescending(t => t.ChampionshipPoints)
				.ThenByDescending(t => t.PresentCondition)
				.ToList();

			var sb = new StringBuilder();
			sb.AppendLine("***Ranking Table***");

			int position = 1;
			foreach (var team in sortedTeams)
			{
				sb.AppendLine($"{position++}. {team}/{team.TeamManager}");
			}

			return sb.ToString().TrimEnd();
		}
	}
}
