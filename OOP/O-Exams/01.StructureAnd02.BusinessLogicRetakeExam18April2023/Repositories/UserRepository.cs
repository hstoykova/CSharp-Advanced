using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories;

public class UserRepository : IRepository<IUser>
{
    private List<IUser> users;

    public UserRepository()
    {
        users = new(); 
    }

    public void AddModel(IUser model)
    {
        users.Add(model);
    }

    public bool RemoveById(string identifier)
    {
        var user = FindById(identifier);
        if (user is null)
        {
            return false;
        }
        return users.Remove(user);
    }

    public IUser FindById(string identifier)
    {
        return users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);
    }

    public IReadOnlyCollection<IUser> GetAll()
    {
        return users.AsReadOnly();
    }
}
