using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories;

public class PlayerRepository : IRepository<IPlayer>
{
    private List<IPlayer> models;

    public IReadOnlyCollection<IPlayer> Models
    {
        get { return models; }
    }

    public void AddModel(IPlayer model)
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

    public IPlayer GetModel(string name)
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
