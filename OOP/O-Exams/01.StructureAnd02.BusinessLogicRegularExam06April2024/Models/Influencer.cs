using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models;

public abstract class Influencer : IInfluencer
{
    private string username;
    private int followers;
    private double engagementRate;
    private double income;
    private List<string> participations;

    protected Influencer(string username, int followers, double engagementRate)
    {
        Username = username;
        Followers = followers;
        EngagementRate = engagementRate;

        Income = 0;
        participations = new();
    }

    public string Username
    {
        get { return username; }
        private set 
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
            }
            username = value; 
        }
    }

    

    public int Followers
    {
        get { return followers; }
        private set 
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
            }
            followers = value; 
        }
    }

    

    public double EngagementRate
    {
        get { return engagementRate; }
        private set { engagementRate = value; }
    }


    public double Income
    {
        get { return income; }
        private set { income = value; }
    }


    public IReadOnlyCollection<string> Participations
    {
        get { return participations.AsReadOnly(); }
        //set { myVar = value; }
    }

    public void EarnFee(double amount)
    {
        Income += amount;
    }

    public void EnrollCampaign(string brand)
    {
        participations.Add(brand);
    }

    public void EndParticipation(string brand)
    {
        participations.Remove(brand);
    }

    public abstract int CalculateCampaignPrice();

    

    public override string ToString()
    {
        return $"{Username} - Followers: {Followers}, Total Income: {Income}";
    }
}
