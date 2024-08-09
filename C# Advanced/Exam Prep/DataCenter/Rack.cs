using System.Text;

namespace DataCenter
{
    public class Rack
    {
        private Dictionary<string, Server> serversBySerialNumber;
        public Rack(int slots)
        {
            Slots = slots;
            Servers = new List<Server>();
            this.serversBySerialNumber = new Dictionary<string, Server>();
        }
        public int Slots { get; set; }
        public List<Server> Servers { get; set; }
        public int GetCount => Servers.Count;

        public void AddServer(Server server)
        {
            if (this.GetCount < this.Slots && !this.serversBySerialNumber.ContainsKey(server.SerialNumber))
            {
                this.Servers.Add(server);
                this.serversBySerialNumber.Add(server.SerialNumber, server);
            }
        }

        public bool RemoveServer(string serialNumber)
            // => this.Servers.Remove(this.Servers.FirstOrDefault(s => s.SerialNumber == serialNumber));
        {
            if (this.serversBySerialNumber.ContainsKey(serialNumber))
            {
                var serverToRemove = this.serversBySerialNumber[serialNumber];

                this.Servers.Remove(serverToRemove);
                this.serversBySerialNumber.Remove(serialNumber);

                return true;
            }

            return false;
        }

        public string GetHighestPowerUsage()
            => this.Servers.OrderByDescending(s => s.PowerUsage)
                .FirstOrDefault().ToString();

        public int GetTotalCapacity() => this.Servers.Sum(s => s.Capacity);

        public string DeviceManager()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Servers.Count} servers operating:");

            foreach (var server in this.Servers)
            {
                sb.AppendLine(server.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
