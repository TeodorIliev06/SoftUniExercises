using System.Text;

namespace SharkTaxonomy;

public class Classifier
{
    public Classifier(int capacity)
    {
        Capacity = capacity;
        Species = new();
    }

    public int Capacity { get; set; }
    public List<Shark> Species { get; set; }
    public int GetCount => Species.Count;
    public void AddShark(Shark shark)
    {
        if(Capacity > GetCount && !Species.Contains(shark))
        {
            Species.Add(shark);
        }
    }
    public bool RemoveShark(string kind)
    {
        return Species.Remove(Species.FirstOrDefault(s => s.Kind == kind));
    }
    public string GetLargestShark() 
    {
        return Species.OrderByDescending(s => s.Length).FirstOrDefault().ToString();
    }
    public double GetAverageLength()
    {
        return Species.Average(s => s.Length);
    }
    public string Report()
    {
        StringBuilder sb = new();
        sb.AppendLine($"{GetCount} sharks classified:");
        foreach(Shark shark in Species)
        {
            sb.AppendLine(shark.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}