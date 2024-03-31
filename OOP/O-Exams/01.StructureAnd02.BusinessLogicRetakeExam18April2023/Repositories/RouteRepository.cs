using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories;

public class RouteRepository : IRepository<IRoute>
{
    private List<IRoute> routes;

    public RouteRepository()
    {
        routes = new List<IRoute>();
    }

    public void AddModel(IRoute model)
    {
        routes.Add(model);
    }

    public bool RemoveById(string identifier)
    {
        var route = FindById(identifier);
        if (route is null)
        {
            return false;
        }
        return routes.Remove(route);
    }

    public IRoute FindById(string identifier)
    {
        return routes.FirstOrDefault(u => u.RouteId == int.Parse(identifier));
    }

    public IReadOnlyCollection<IRoute> GetAll()
    {
        return routes.AsReadOnly();
    }    
}
