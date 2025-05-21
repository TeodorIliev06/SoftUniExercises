namespace Zad_28
{
    public class Cabinet : Furniture
    {
        private const double IncreaseRate = 1.15d;
        private const double HingePrice = 4.50d;

        public Cabinet(string typeProduct, double productionPrice, int numberOfHinges) 
            : base(typeProduct, productionPrice)
        {
            this.NumberOfHinges = numberOfHinges;
        }

        public int NumberOfHinges { get; set; }

        public override double PriceClient()
        {
            return this.ProductionPrice * IncreaseRate + this.NumberOfHinges * HingePrice;
        }

        public override string ToString()
        {
            return $"The cabinet costs {Math.Round(this.PriceClient(), 2, MidpointRounding.AwayFromZero):F2} lv.";
        }
    }
}
