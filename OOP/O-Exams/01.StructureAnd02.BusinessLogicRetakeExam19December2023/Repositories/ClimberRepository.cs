using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories;

public class ClimberRepository : IRepository<IClimber>
{
    private List<IClimber> climbers;

    public ClimberRepository()
    {
          climbers = new List<IClimber>();
    }
    public IReadOnlyCollection<IClimber> All
    {
        get { return climbers.AsReadOnly(); }
        //set { climbers = value; }
    }

    public void Add(IClimber climber)
    {
        climbers.Add(climber);
    }

    public IClimber Get(string name)
    {
        return climbers.FirstOrDefault(p => p.Name == name);
    }
}
