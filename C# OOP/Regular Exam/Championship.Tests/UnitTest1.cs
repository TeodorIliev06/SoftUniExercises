using NUnit.Framework;
using System;

namespace Championship.Tests
{
	public class Tests
	{
		private League league;

		[SetUp]
		public void Setup()
		{
			this.league = new League();
		}

		[Test]
		public void TestAddTeam_Success()
		{
			var team = new Team("Team A");
			this.league.AddTeam(team);
			Assert.That(this.league.Teams.Count, Is.EqualTo(1));
			Assert.That(this.league.Teams[0].Name, Is.EqualTo("Team A"));
		}

		[Test]
		public void TestAddTeam_LeagueFull()
		{
			for (int i = 0; i < this.league.Capacity; i++)
			{
				league.AddTeam(new Team($"Team {i}"));
			}
			Assert.Throws<InvalidOperationException>(() => this.league.AddTeam(new Team("Team Extra")));
		}

		[Test]
		public void TestAddTeam_TeamAlreadyExists()
		{
			var team = new Team("Team A");
			this.league.AddTeam(team);
			Assert.Throws<InvalidOperationException>(() => this.league.AddTeam(new Team("Team A")));
		}

		[Test]
		public void TestRemoveTeam_Success()
		{
			var team = new Team("Team A");
			this.league.AddTeam(team);
			var result = this.league.RemoveTeam("Team A");
			Assert.IsTrue(result);
			Assert.That(this.league.Teams.Count, Is.EqualTo(0));
		}

		[Test]
		public void TestRemoveTeam_TeamDoesNotExist()
		{
			var result = this.league.RemoveTeam("Nonexistent Team");
			Assert.IsFalse(result);
		}

		[Test]
		public void TestPlayMatch_Draw()
		{
			var teamA = new Team("Team A");
			var teamB = new Team("Team B");
			this.league.AddTeam(teamA);
			this.league.AddTeam(teamB);
			this.league.PlayMatch("Team A", "Team B", 1, 1);
			Assert.That(teamA.Draws, Is.EqualTo(1));
			Assert.That(teamB.Draws, Is.EqualTo(1));
		}

		[Test]
		public void TestPlayMatch_HomeTeamWins()
		{
			var teamA = new Team("Team A");
			var teamB = new Team("Team B");
			this.league.AddTeam(teamA);
			this.league.AddTeam(teamB);
			this.league.PlayMatch("Team A", "Team B", 2, 1);
			Assert.That(teamA.Wins, Is.EqualTo(1));
			Assert.That(teamB.Loses, Is.EqualTo(1));
		}

		[Test]
		public void TestPlayMatch_AwayTeamWins()
		{
			var teamA = new Team("Team A");
			var teamB = new Team("Team B");
			this.league.AddTeam(teamA);
			this.league.AddTeam(teamB);
			this.league.PlayMatch("Team A", "Team B", 1, 2);
			Assert.That(teamA.Loses, Is.EqualTo(1));
			Assert.That(teamB.Wins, Is.EqualTo(1));
		}

		[Test]
		public void TestPlayMatch_TeamDoesNotExist()
		{
			var teamA = new Team("Team A");
			this.league.AddTeam(teamA);
			Assert.Throws<InvalidOperationException>(() => this.league.PlayMatch("Team A", "Nonexistent Team", 1, 1));
		}

		[Test]
		public void TestGetTeamInfo_Success()
		{
			var team = new Team("Team A");
			this.league.AddTeam(team);
			var info = this.league.GetTeamInfo("Team A");
			Assert.That(info, Is.EqualTo("Team A - 0 points (0W 0D 0L)"));
		}

		[Test]
		public void TestGetTeamInfo_TeamDoesNotExist()
		{
			Assert.Throws<InvalidOperationException>(() => this.league.GetTeamInfo("Nonexistent Team"));
		}
	}
}
