namespace InfluencerManagerApp.Models
{
    public class BloggerInfluencer : Influencer
    {
        private const double EngagementRate = 2.0d;
        private const double Factor = 0.2d;
        public BloggerInfluencer(string username, int followers)
            : base(username, followers, EngagementRate)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return (int)Math.Floor(Followers * base.EngagementRate * Factor);
        }
    }
}
