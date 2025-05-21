namespace Zad_28
{
    public class Table : Furniture
    {
        private const double IncreaseRate = 1.2d;
        public Table(string typeProduct, double productionPrice) 
            : base(typeProduct, productionPrice)
        {
        }

        public override double PriceClient()
        {
            return this.ProductionPrice * IncreaseRate;
        }

        public override string ToString()
        {
            return $"The table costs {this.PriceClient():F2} lv.";
        }
    }
}
