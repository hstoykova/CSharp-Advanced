using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Repositories;

public class FishRepository : IRepository<IFish>
{
    private List<IFish> fishList;
    public FishRepository()
    {
        fishList = new List<IFish>();
    }

    public IReadOnlyCollection<IFish> Models
    {
        get { return fishList.AsReadOnly(); }
        //set { fish = value; }
    }
    public void AddModel(IFish fish)
    {
        fishList.Add(fish);
    }

    public IFish GetModel(string name)
    {
        return fishList.FirstOrDefault(p => p.Name == name);
    }
}
