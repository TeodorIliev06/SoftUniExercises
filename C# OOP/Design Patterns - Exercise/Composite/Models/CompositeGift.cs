using Composite.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Models
{
    public class CompositeGift : BaseGift, IGiftOperations
    {
        private List<BaseGift> _gifts;

        public CompositeGift(string name, int price) 
            : base(name, price)
        {
            _gifts = new List<BaseGift>();
            TotalPrice = 0;
        }

        public int TotalPrice { get; set; }

        public void Add(BaseGift gift) => _gifts.Add(gift);     

        public void Remove(BaseGift gift) => _gifts.Remove(gift); 

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{Name} contains the following products with prices:");

            foreach (var gift in _gifts)
            {
                TotalPrice += gift.CalculateTotalPrice();
            }

            return TotalPrice;
        }
    }
}
