using HighwayToPeak.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models;

public class BaseCamp : IBaseCamp
{
    private List<string> residents;

    public BaseCamp()
    {
        residents = new();
    }

    public IReadOnlyCollection<string> Residents
    {
        get { return residents.OrderBy(r => r).ToList().AsReadOnly(); }
        //set { residents = value; }
    }
    public void ArriveAtCamp(string climberName)
    {
        residents.Add(climberName);
    }

    public void LeaveCamp(string climberName)
    {
        residents.Remove(climberName);
    }
}
