using System.Text;

namespace EstateAgency
{
    public class EstateAgency
    {
        private Dictionary<string, RealEstate> estatesByAddress;
        public EstateAgency(int capacity)
        {
            Capacity = capacity;
            this.RealEstates = new List<RealEstate>();
            this.estatesByAddress = new Dictionary<string, RealEstate>();
        }

        public int Capacity { get; set; }
        public List<RealEstate> RealEstates { get; set; }
        public int Count => this.RealEstates.Count;

        public void AddRealEstate(RealEstate realEstate)
        {
            if (this.Count < this.Capacity &&
                !this.estatesByAddress.ContainsKey(realEstate.Address))
            {
                this.estatesByAddress.Add(realEstate.Address, realEstate);
                this.RealEstates.Add(realEstate);
            }
        }

        public bool RemoveRealEstate(string address)
        {
            if (this.estatesByAddress.ContainsKey(address))
            {
                var estateToRemove = this.estatesByAddress[address];
                this.estatesByAddress.Remove(address);
                this.RealEstates.Remove(estateToRemove);

                return true;
            }

            return false;
        }

        public List<RealEstate> GetRealEstates(string postalCode)
            => this.RealEstates.Where(re => re.PostalCode == postalCode).ToList();

        public RealEstate GetCheapest()
            => this.RealEstates.OrderBy(re => re.Price).FirstOrDefault();

        public double GetLargest()
            => this.RealEstates.OrderByDescending(re => re.Size).FirstOrDefault().Size;

        public string EstateReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Real estates available:");

            foreach (var estate in this.RealEstates)
            {
                sb.AppendLine(estate.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
