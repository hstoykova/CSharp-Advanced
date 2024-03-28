﻿using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories;

public class PeakRepository : IRepository<IPeak>
{
    private List<IPeak> peaks;

    public PeakRepository()
    {
         peaks = new List<IPeak>();
    }
    public IReadOnlyCollection<IPeak> All
    {
        get { return peaks.AsReadOnly(); }
        //set { peaks = value; }
    }

    public void Add(IPeak peak)
    {
        peaks.Add(peak);
    }

    public IPeak Get(string name)
    {
        return peaks.FirstOrDefault(p => p.Name == name);
    }
}
