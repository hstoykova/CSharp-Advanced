﻿using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories;

public class SupplementRepository : IRepository<ISupplement>
{
    private List<ISupplement> supplements;

    public SupplementRepository()
    {
        supplements = new List<ISupplement>();
    }


    public IReadOnlyCollection<ISupplement> Models()
    {
        return supplements.AsReadOnly();
    }

    public void AddNew(ISupplement model)
    {
        supplements.Add(model);
    }

    public bool RemoveByName(string typeName)
    {
        var result = supplements.FirstOrDefault(s => s.GetType().Name == typeName);

        if (result is null)
        {
            return false;
        }

        supplements.Remove(result);
        return true;
    }
    public ISupplement FindByStandard(int interfaceStandard)
    {
        return supplements.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
    }
    
}
