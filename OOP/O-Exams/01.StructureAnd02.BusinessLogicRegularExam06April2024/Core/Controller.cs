using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Core;

public class Controller : IController
{
    InfluencerRepository influencersRepo;
    CampaignRepository campaignsRepo;

    public Controller()
    {
        influencersRepo = new();
        campaignsRepo = new();
    }

    public string RegisterInfluencer(string typeName, string username, int followers)
    {
        string[] validInfluencer = new[] { "BusinessInfluencer", "FashionInfluencer", "BloggerInfluencer" };

        if (!validInfluencer.Contains(typeName))
        {
            return string.Format(OutputMessages.InfluencerInvalidType, typeName);
        }

        if (influencersRepo.FindByName(username) is not null)
        {
            // possible mistake
            return string.Format(OutputMessages.UsernameIsRegistered, username, nameof(InfluencerRepository));
        }

        IInfluencer influencer;

        if (typeName == "BusinessInfluencer")
        {
            influencer = new BusinessInfluencer(username, followers);
        }
        else if (typeName == "FashionInfluencer")
        {
            influencer = new FashionInfluencer(username, followers);

        }
        else //BloggerInfluencer
        {
            influencer = new BloggerInfluencer(username, followers);

        }

        influencersRepo.AddModel(influencer);
        return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
    }

    public string BeginCampaign(string typeName, string brand)
    {
        string[] validCamp = new[] { "ProductCampaign", "ServiceCampaign"};

        if (!validCamp.Contains(typeName))
        {
            return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
        }

        if (campaignsRepo.FindByName(brand) is not null)
        {
   
            return string.Format(OutputMessages.CampaignDuplicated, brand);
        }

        ICampaign campaign;

        if (typeName == "ProductCampaign")
        {
            campaign = new ProductCampaign(brand);
        }
        else //ServiceCampaign
        {
            campaign = new ServiceCampaign(brand);

        }

        campaignsRepo.AddModel(campaign);
        return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
    }

    public string AttractInfluencer(string brand, string username)
    {
        var influencer = influencersRepo.FindByName(username);

        if (influencer is null)
        {
            return string.Format(OutputMessages.InfluencerNotFound, nameof(InfluencerRepository), username);
        }

        var camp = campaignsRepo.FindByName(brand);

        if (camp is null)
        {
            return string.Format(OutputMessages.CampaignNotFound, brand);
        }

        if (camp.Contributors.Contains(influencer.Username))       
        {
            return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
        }

        string infType = influencer.GetType().Name;
        string campType = camp.GetType().Name;

        if ((campType == "ProductCampaign" && !(infType == "BusinessInfluencer" || infType == "FashionInfluencer")) ||
            (campType == "ServiceCampaign" && !(infType == "BusinessInfluencer" || infType == "BloggerInfluencer")))
        {
            return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
        }

        var price = influencer.CalculateCampaignPrice();
        if (camp.Budget <= price)
        {
            return string.Format(OutputMessages.UnsufficientBudget, brand, username);

        }

        camp.Engage(influencer);
        influencer.EarnFee(price);
        influencer.EnrollCampaign(brand);

        return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
    }

    public string FundCampaign(string brand, double amount)
    {
        var camp = campaignsRepo.FindByName(brand);

        if (camp is null)
        {
            return string.Format(OutputMessages.InvalidCampaignToFund);
        }

        if (amount <= 0)
        {
            return string.Format(OutputMessages.NotPositiveFundingAmount);

        }

        camp.Gain(amount);
        // possible mistake Math Round
        return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, Math.Round(amount, 2));
    }

    public string CloseCampaign(string brand)
    {
        var camp = campaignsRepo.FindByName(brand);

        if (camp is null)
        {
            return string.Format(OutputMessages.InvalidCampaignToClose);
        }

        if (camp.Budget < 10000.0)
        {
            return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
        }

        foreach (var inf in camp.Contributors)
        {
            IInfluencer i = influencersRepo.FindByName(inf);
            i.EarnFee(2000);
            i.EndParticipation(brand);
        }

        campaignsRepo.RemoveModel(camp);
        return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);

    }

    public string ConcludeAppContract(string username)
    {
        var influencer = influencersRepo.FindByName(username);

        if (influencer is null)
        {
            return string.Format(OutputMessages.InfluencerNotSigned, username);
        }

        if (influencer.Participations.Any())
        {
            return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);

        }

        influencersRepo.RemoveModel(influencer);
        return string.Format(OutputMessages.ContractConcludedSuccessfully, username);

    }

    public string ApplicationReport()
    {
        StringBuilder sb = new();

        var ordered = influencersRepo.Models.OrderByDescending(i => i.Income).ThenByDescending(i => i.Followers).ToList();

        foreach (var influencer in ordered)
        {
            sb.AppendLine(influencer.ToString());

            if (influencer.Participations.Any())
            {
                sb.AppendLine("Active Campaigns:");
                var camps = influencer.Participations.Select(campaignsRepo.FindByName).OrderBy(c => c.Brand);

                foreach (var campaign in camps)
                {
                    sb.AppendLine($"--{campaign.ToString()}");
                }
            }
        }

        return sb.ToString().Trim();
    }
    
}
