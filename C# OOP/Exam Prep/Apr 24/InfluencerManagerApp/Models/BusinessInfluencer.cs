namespace InfluencerManagerApp.Models
{
    public class BusinessInfluencer : Influencer
    {
        private const double EngagementRate = 3.0d;
        private const double Factor = 0.15d;
        public BusinessInfluencer(string username, int followers)
            : base(username, followers, EngagementRate)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return (int)Math.Floor(Followers * base.EngagementRate * Factor);
        }
    }
}
