using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System.Text;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private IRepository<IInfluencer> influencers;
        private IRepository<ICampaign> campaigns;
        private readonly ICollection<string> validInfluencerTypes;
        private readonly ICollection<string> validCampaignTypes;
        public Controller()
        {
            this.influencers = new InfluencerRepository();
            this.campaigns = new CampaignRepository();
            this.validInfluencerTypes = new HashSet<string>()
            {
                nameof(BloggerInfluencer),
                nameof(BusinessInfluencer),
                nameof(FashionInfluencer)
            };
            this.validCampaignTypes = new HashSet<string>()
            {
                nameof(ProductCampaign),
                nameof(ServiceCampaign)
            };
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (!this.validInfluencerTypes.Contains(typeName))
            {
                return String.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            if (this.influencers.Models.Any(i => i.Username == username))
            {
                return String.Format(OutputMessages.UsernameIsRegistered, username, nameof(InfluencerRepository));
            }

            IInfluencer newInfluencer = null;
            if (typeName == nameof(BloggerInfluencer))
            {
                newInfluencer = new BloggerInfluencer(username, followers);
            }
            else if (typeName == nameof(BusinessInfluencer))
            {
                newInfluencer = new BusinessInfluencer(username, followers);
            }
            else if (typeName == nameof(FashionInfluencer))
            {
                newInfluencer = new FashionInfluencer(username, followers);
            }

            this.influencers.AddModel(newInfluencer);
            return String.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }//Correct

        public string BeginCampaign(string typeName, string brand)
        {
            if (!this.validCampaignTypes.Contains(typeName))
            {
                return String.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }

            if (this.campaigns.FindByName(brand) != null)
            {
                return String.Format(OutputMessages.CampaignDuplicated, brand);
            }

            ICampaign newCampaign = null;
            if (typeName == nameof(ProductCampaign))
            {
                newCampaign = new ProductCampaign(brand);
            }
            else if (typeName == nameof(ServiceCampaign))
            {
                newCampaign = new ServiceCampaign(brand);
            }

            this.campaigns.AddModel(newCampaign);
            return String.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        } //Corrected

        public string AttractInfluencer(string brand, string username)
        {
            if (this.influencers.FindByName(username) == null)
            {
                return String.Format(OutputMessages.InfluencerNotFound, nameof(InfluencerRepository), username);
            }

            if (this.campaigns.FindByName(brand) == null)
            {
                return String.Format(OutputMessages.CampaignNotFound, brand);
            }

            IInfluencer influencer = this.influencers.FindByName(username);
            ICampaign campaign = this.campaigns.FindByName(brand);

            if (campaign.Contributors.Contains(username))
            {
                return String.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            if (campaign.GetType().Name == nameof(ProductCampaign))
            {
                if (influencer.GetType().Name == nameof(BloggerInfluencer))
                {
                    return String.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
                }
            }
            else if (campaign.GetType().Name == nameof(ServiceCampaign))
            {
                if (influencer.GetType().Name == nameof(FashionInfluencer))
                {
                    return String.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
                }
            }

            if (campaign.Budget < influencer.CalculateCampaignPrice())
            {
                return String.Format(OutputMessages.UnsufficientBudget, brand, username);
            }

            influencer.EnrollCampaign(brand);
            influencer.EarnFee(influencer.CalculateCampaignPrice());
            campaign.Engage(influencer);

            return String.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        } //Correct

        public string FundCampaign(string brand, double amount)
        {
            if (this.campaigns.FindByName(brand) == null)
            {
                return OutputMessages.InvalidCampaignToFund;
            }

            if (amount <= 0)
            {
                return OutputMessages.NotPositiveFundingAmount;
            }

            ICampaign campaign = this.campaigns.FindByName(brand);
            campaign.Gain(amount);

            return String.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string CloseCampaign(string brand)
        {
            var requiredBudged = 10_000d;
            var bonus = 2_000d;

            if (this.campaigns.FindByName(brand) == null)
            {
                return OutputMessages.InvalidCampaignToClose;
            }

            ICampaign campaign = this.campaigns.FindByName(brand);
            if (campaign.Budget <= requiredBudged)
            {
                return String.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }

            foreach (var influencerName in campaign.Contributors)
            {
                IInfluencer influencer = this.influencers.FindByName(influencerName);

                influencer.EarnFee(bonus);
                influencer.EndParticipation(brand);
            }

            campaigns.RemoveModel(campaign);
            return String.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            if (this.influencers.FindByName(username) == null)
            {
                return String.Format(OutputMessages.InfluencerNotSigned, username);
            }

            IInfluencer influencer = this.influencers.FindByName(username);
            if (influencer.Participations.Count > 0)
            {
                return String.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }

            this.influencers.RemoveModel(influencer);
            return String.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string ApplicationReport()
        {
            var sb = new StringBuilder();
            var influencersToReport = influencers.Models
                .OrderByDescending(i => i.Income)
                .ThenByDescending(i => i.Followers);

            foreach (var influencer in influencersToReport)
            {
                sb.AppendLine(influencer.ToString());
                if (influencer.Participations.Count > 0)
                {
                    sb.AppendLine("Active Campaigns:");
                    foreach (var campaign in influencer.Participations.OrderBy(p => p))
                    {
                        ICampaign currentCampaign = campaigns.FindByName(campaign);
                        sb.AppendLine($"--{currentCampaign.ToString()}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
