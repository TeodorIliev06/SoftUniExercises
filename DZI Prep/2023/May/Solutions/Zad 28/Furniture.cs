using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_28
{
    public abstract class Furniture
    {
        protected Furniture(string typeProduct, double productionPrice)
        {
            if (string.IsNullOrEmpty(typeProduct))
            {
                throw new IOException("Type can not be empty!");
            }
            this.TypeProduct = typeProduct;

            if (productionPrice <= 0)
            {
                throw new IOException("Price can not be negative!");
            }
            this.ProductionPrice = productionPrice;
        }

        public string TypeProduct { get; set; }
        public double ProductionPrice { get; set; }

        public abstract double PriceClient();
    }
}
