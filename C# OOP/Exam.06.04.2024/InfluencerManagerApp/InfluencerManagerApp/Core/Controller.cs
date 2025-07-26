using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Core
{
    internal class Controller : IController
    {
        public Controller()
        {
            _influencers = new InfluencerRepository();
            _campaigns = new CampaignRepository();
        }

        private IRepository<IInfluencer> _influencers;
        private IRepository<ICampaign> _campaigns;
        private const double CLOSURE_TARGET = 10000;
        private const double BONUS_FEE = 2000;
        private static bool ValidInfluencerType(string type)
        {
            return type == "BusinessInfluencer" || type == "FashionInfluencer" || type == "BloggerInfluencer";
        }
        private static IInfluencer? CreateInfluencer(string typeName, string username, int followers)
        {
            switch (typeName)
            {
                case "BusinessInfluencer":
                    return new BusinessInfluencer(username, followers);
                case "FashionInfluencer":
                    return new FashionInfluencer(username, followers);
                case "BloggerInfluencer":
                    return new BloggerInfluencer(username, followers);
                default:
                    return null;
            }
        }
        private static bool ValidCampaignType(string type)
        {
            return type == "ProductCampaign" || type == "ServiceCampaign";
        }
        private static ICampaign? CreateCampaign(string typeName, string brand)
        {
            switch (typeName)
            {
                case "ProductCampaign": return new ProductCampaign(brand);
                case "ServiceCampaign": return new ServiceCampaign(brand);
                default: return null;
            }
        }
        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IInfluencer influencer in _influencers.Models.OrderByDescending(x => x.Income)
                                                                  .ThenByDescending(x => x.Followers))
            {
                sb.AppendLine(influencer.ToString());
                if (influencer.Participations.Count > 0)
                {
                    sb.AppendLine("Active Campaigns:");
                    foreach (string campaignName in influencer.Participations.OrderBy(x => x))
                    {
                        sb.AppendLine($"--{_campaigns.FindByName(campaignName).ToString()}");
                    }
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string AttractInfluencer(string brand, string username)
        {
            IInfluencer influencer = _influencers.FindByName(username);
            if (influencer == null)
            {
                return string.Format(OutputMessages.InfluencerNotFound, _influencers.GetType().Name, username);
            }
            ICampaign campaign = _campaigns.FindByName(brand);
            if (campaign == null)
            {
                return string.Format(OutputMessages.CampaignNotFound, brand);
            }
            if (campaign.Contributors.Contains(username))
            {
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }
            List<string> allowedTypes = new List<string> { "BusinessInfluencer" };
            switch (campaign.GetType().Name)
            {
                case "ProductCampaign":
                    allowedTypes.Add("FashionInfluencer");
                    break;
                case "ServiceCampaign":
                    allowedTypes.Add("BloggerInfluencer");
                    break;
                default:
                    break;
            }
            if (!allowedTypes.Contains(influencer.GetType().Name))
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }
            double campaignPrice = influencer.CalculateCampaignPrice();
            if (campaign.Budget < campaignPrice)
            {
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);
            }
            influencer.EarnFee(campaignPrice);
            influencer.EnrollCampaign(brand);
            campaign.Engage(influencer);
            return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            if (!ValidCampaignType(typeName))
            {
                return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }
            if (_campaigns.FindByName(brand) != null)
            {
                return string.Format(OutputMessages.CampaignDuplicated, brand);
            }
            _campaigns.AddModel(CreateCampaign(typeName, brand));
            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string CloseCampaign(string brand)
        {
            ICampaign campaign = _campaigns.FindByName(brand);
            if (campaign == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToClose);
            }
            if (campaign.Budget <= CLOSURE_TARGET)
            {
                return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }
            foreach (string name in campaign.Contributors)
            {
                IInfluencer influencer = _influencers.FindByName(name);
                influencer.EarnFee(BONUS_FEE);
                influencer.EndParticipation(brand);
            }
            _campaigns.RemoveModel(campaign);
            return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer influencer = _influencers.FindByName(username);
            if (influencer == null)
            {
                return string.Format(OutputMessages.InfluencerNotSigned, username);
            }
            if (influencer.Participations.Count > 0)
            {
                return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }
            _influencers.RemoveModel(influencer);
            return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string FundCampaign(string brand, double amount)
        {
            ICampaign campaign = _campaigns.FindByName(brand);
            if (campaign == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToFund);
            }
            if (amount <= 0)
            {
                return string.Format(OutputMessages.NotPositiveFundingAmount);
            }
            campaign.Gain(amount);
            return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (!ValidInfluencerType(typeName))
            {
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);
            }
            if (_influencers.Models.Any(x => x.Username == username))
            {
                return string.Format(OutputMessages.UsernameIsRegistered, username, _influencers.GetType().Name);
            }
            _influencers.AddModel(CreateInfluencer(typeName, username, followers));
            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }
    }
}
