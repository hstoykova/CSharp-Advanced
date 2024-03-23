using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories;

public class TeamRepository : IRepository<ITeam>
{
    private List<ITeam> models;

    public IReadOnlyCollection<ITeam> Models
    {
        get { return models; }
        //set { models = value; }
    }

    public void AddModel(ITeam model)
    {
        models.Add(model);
    }

    public bool ExistsModel(string name)
    {
        var model = models.Find(x => x.Name == name);

        if (model is null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public ITeam GetModel(string name)
    {
        return models.Find(x => x.Name == name);
        // return null not implemented
    }

    public bool RemoveModel(string name)
    {
        var model = models.Find(x => x.Name == name);

        if (model is null)
        {
            return false;
        }
        else
        {
            models.Remove(model);
            return true;
        }
    }
}
