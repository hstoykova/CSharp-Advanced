using System.Text;

namespace SharkTaxonomy;

public class Classifier
{
    public Classifier(int capacity)
    {
        Capacity = capacity;
        Species = new List<Shark>();
    }

    public int Capacity { get; set; }

    public List<Shark> Species { get; set; }

    public int GetCount
    {
        get { return Species.Count; }
    }

    public void AddShark(Shark shark)
    {
        if (Capacity > GetCount)
        {
            Shark? findShark = Species.Find(s => s.Kind == shark.Kind);

            if (findShark == null)
            {
                Species.Add(shark);
            }
        }
    }

    public bool RemoveShark(string kind)
    {
        Shark? findShark = Species.Find(s => s.Kind == kind);

        if (findShark == null)
        {
            return false;
        }

        Species.Remove(findShark);
        return true;
    }

    public string GetLargestShark()
    {
        return Species.OrderByDescending(s => s.Length).First().ToString();
    }

    public double GetAverageLength()
    {
        return Species.Select(s => s.Length).Average();
    }

    public string Report()
    {
        StringBuilder sb = new();
        sb.AppendLine($"{GetCount} sharks classified:");

        foreach (var shark in Species)
        {
            sb.AppendLine(shark.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}
