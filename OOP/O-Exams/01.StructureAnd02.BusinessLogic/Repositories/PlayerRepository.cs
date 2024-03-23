using Handball.Models;
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

    public PlayerRepository()
    {
        models = new List<IPlayer>();
    }

    public IReadOnlyCollection<IPlayer> Models
    {
        get { return models.AsReadOnly(); }
    }

    public void AddModel(IPlayer model)
    {
        models.Add(model);
    }

    public bool ExistsModel(string name)
    {
        return models.Any(x => x.Name == name);
    }

    public IPlayer GetModel(string name)
    {
        return models.FirstOrDefault(x => x.Name == name);
        // return null not implemented
    }

    public bool RemoveModel(string name)
    {
        IPlayer player = GetModel(name);

        return models.Remove(player);
    }
}
