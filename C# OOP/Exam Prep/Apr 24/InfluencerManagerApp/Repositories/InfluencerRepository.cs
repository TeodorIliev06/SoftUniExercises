using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Repositories
{
    public class InfluencerRepository : IRepository<IInfluencer>
    {
        private List<IInfluencer> models;

        public InfluencerRepository()
        {
            this.models = new List<IInfluencer>();
        }

        public IReadOnlyCollection<IInfluencer> Models => this.models.AsReadOnly();
        public void AddModel(IInfluencer model) => this.models.Add(model);

        public bool RemoveModel(IInfluencer model) => this.models.Remove(model);

        public IInfluencer FindByName(string name) => this.models.FirstOrDefault(m => m.Username == name);
    }
}
