using System;
using System.Collections.Generic;
using System.Linq;

public class Olympics : IOlympics
{
    private IDictionary<int, Competitor> competitorsById;
    private IDictionary<int, Competition> competitionsById;

    public Olympics()
    {
        this.competitionsById = new Dictionary<int, Competition>();
        this.competitorsById = new Dictionary<int, Competitor>();
    }

    public void AddCompetition(int id, string name, int participantsLimit)
    {
        if (this.competitionsById.ContainsKey(id))
        {
            throw new ArgumentException(nameof(id));
        }

        this.competitionsById.Add(id, new Competition(name, id, participantsLimit));
    }

    public void AddCompetitor(int id, string name)
    {
        if (this.competitorsById.ContainsKey(id))
        {
            throw new ArgumentException(nameof(id));
        }

        var competitorToAdd = new Competitor(id, name);
        this.competitorsById.Add(id, competitorToAdd);
    }

    public void Compete(int competitorId, int competitionId)
    {
        if (!this.competitionsById.ContainsKey(competitionId) ||
            !this.competitorsById.ContainsKey(competitorId))
        {
            throw new ArgumentException(nameof(competitionId));
        }

        var competitorToAdd = this.competitorsById[competitorId];
        var competition = this.competitionsById[competitionId];

        competition.Competitors.Add(competitorToAdd);
        competitorToAdd.TotalScore += competition.Score;
    }

    public int CompetitionsCount() => this.competitionsById.Count;

    public int CompetitorsCount() => this.competitorsById.Count;

    public bool Contains(int competitionId, Competitor comp)
    {
        if (!this.competitionsById.ContainsKey(competitionId))
        {
            throw new ArgumentException(nameof(competitionId));
        }

        return this.competitionsById[competitionId].Competitors.Contains(comp);
    }

    public void Disqualify(int competitionId, int competitorId)
    {
        if (!this.competitionsById.ContainsKey(competitionId) ||
            !this.competitorsById.ContainsKey(competitorId) ||
            !this.competitionsById[competitionId].Competitors
                .Contains(this.competitorsById[competitorId]))
        {
            throw new ArgumentException(nameof(competitionId));
        }

        var competitorToRemove = this.competitorsById[competitorId];
        var competition = this.competitionsById[competitionId];

        competition.Competitors.Remove(competitorToRemove);
        competitorToRemove.TotalScore -= competition.Score;
    }

    public IEnumerable<Competitor> FindCompetitorsInRange(long min, long max)
        => this.competitorsById.Values.Where(c => c.TotalScore > min && c.TotalScore <= max)
            .OrderBy(c => c);

    public IEnumerable<Competitor> GetByName(string name)
    {
        var result = new List<Competitor>();
        foreach (var searchedCompetitor in this.competitorsById.Values)
        {
            if (searchedCompetitor.Name.Equals(name))
            {
                result.Add(searchedCompetitor);
            }
        }

        if (result.Count == 0)
        {
            throw new ArgumentException(nameof(name));
        }

        return result.OrderBy(c => c.Id);
    }

    public Competition GetCompetition(int id)
    {
        if (!this.competitionsById.ContainsKey(id))
        {
            throw new ArgumentException(nameof(id));
        }

        return this.competitionsById[id];
    }

    public IEnumerable<Competitor> SearchWithNameLength(int min, int max)
    {
        var result = new List<Competitor>();
        foreach (var competitor in this.competitorsById.Values)
        {
            if (competitor.Name.Length >= min && competitor.Name.Length <= max)
            {
                result.Add(competitor);
            }
        }

        return result.OrderBy(c => c.Id);
    }
}