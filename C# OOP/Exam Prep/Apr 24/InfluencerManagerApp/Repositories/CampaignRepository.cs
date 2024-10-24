using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class CampaignRepository : IRepository<ICampaign>
    {
        private List<ICampaign> models;

        public CampaignRepository()
        {
            this.models = new List<ICampaign>();
        }

        public IReadOnlyCollection<ICampaign> Models => models.AsReadOnly();

        public void AddModel(ICampaign model) => this.models.Add(model);

        public bool RemoveModel(ICampaign model) => this.models.Remove(model);

        public ICampaign FindByName(string name) => this.models.FirstOrDefault(m => m.Brand == name);
    }
}
