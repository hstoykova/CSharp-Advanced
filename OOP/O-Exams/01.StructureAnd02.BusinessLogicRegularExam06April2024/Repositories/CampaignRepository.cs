using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Repositories;

public class CampaignRepository : IRepository<ICampaign>
{
    private List<ICampaign> campaigns;

    public CampaignRepository()
    {
        campaigns = new();
    }

    public IReadOnlyCollection<ICampaign> Models
    {
        get { return campaigns.AsReadOnly(); }
        //set { influencers = value; }
    }


    public void AddModel(ICampaign model)
    {
        campaigns.Add(model);
    }
    public bool RemoveModel(ICampaign model)
    {
        return campaigns.Remove(model);
    }

    public ICampaign FindByName(string name)
    {
        return campaigns.FirstOrDefault(i => i.Brand == name);
    }

    //public IReadOnlyCollection<ICampaign> Models => throw new NotImplementedException();

    //public void AddModel(ICampaign model)
    //{
    //    throw new NotImplementedException();
    //}

    //public ICampaign FindByName(string name)
    //{
    //    throw new NotImplementedException();
    //}

    //public bool RemoveModel(ICampaign model)
    //{
    //    throw new NotImplementedException();
    //}
}
