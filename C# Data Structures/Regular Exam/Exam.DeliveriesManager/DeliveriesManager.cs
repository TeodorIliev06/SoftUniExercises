using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class DeliveriesManager : IDeliveriesManager
    {
        private IDictionary<string, Deliverer> deliverersById;
        private IDictionary<string, Package> packagesById;

        public DeliveriesManager()
        {
            this.deliverersById = new Dictionary<string, Deliverer>();
            this.packagesById = new Dictionary<string, Package>();
        }

        public void AddDeliverer(Deliverer deliverer)
        {
            if (this.deliverersById.ContainsKey(deliverer.Id))
            {
                throw new ArgumentException();
            }

            this.deliverersById.Add(deliverer.Id, deliverer);
        }

        public void AddPackage(Package package)
        {
            if (this.packagesById.ContainsKey(package.Id))
            {
                throw new ArgumentException();
            }

            this.packagesById.Add(package.Id, package);
        }

        public void AssignPackage(Deliverer deliverer, Package package)
        {
            if (!this.packagesById.ContainsKey(package.Id) ||
                !this.deliverersById.ContainsKey(deliverer.Id))
            {
                throw new ArgumentException();
            }

            this.deliverersById[deliverer.Id].Packages.Add(package);
            this.packagesById[package.Id].Deliverer = deliverer;
        }

        public bool Contains(Deliverer deliverer) => this.deliverersById.ContainsKey(deliverer.Id);

        public bool Contains(Package package) => this.packagesById.ContainsKey(package.Id);

        public IEnumerable<Deliverer> GetDeliverers() => this.deliverersById.Values;

        public IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName()
            => this.GetDeliverers()
                .OrderByDescending(d => d.Packages.Count)
                .ThenBy(d => d.Name);

        public IEnumerable<Package> GetPackages() => this.packagesById.Values;

        public IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver()
            => this.GetPackages()
                .OrderByDescending(p => p.Weight)
                .ThenBy(p => p.Receiver);

        public IEnumerable<Package> GetUnassignedPackages()
            => this.GetPackages()
                .Where(p => p.Deliverer is null);
    }
}
