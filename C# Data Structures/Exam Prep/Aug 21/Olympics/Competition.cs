using System;
using System.Collections.Generic;

public class Competition : IComparable<Competition>
{
    public Competition(string name, int id, int score)
    {
        this.Name = name;
        this.Id = id;
        this.Score = score;
        this.Competitors = new HashSet<Competitor>();
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public int Score { get; set; }

    public ICollection<Competitor> Competitors { get; set; }

    public int CompareTo(Competition other)
    {
        if (other == null) return 1;
        return this.Id.CompareTo(other.Id);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        Competition other = (Competition)obj;
        return this.Id == other.Id;
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}