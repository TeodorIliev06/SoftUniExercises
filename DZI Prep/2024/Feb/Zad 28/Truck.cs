namespace Zad_28
{
    internal class Truck : Car
    {
        public Truck(string brand, int year, int mileage, decimal value, int tonnage)
            : base(brand, year, mileage, value)
        {
            Tonnage = tonnage;
        }

        public int Tonnage { get; set; }

        public override decimal Price()
        {
            var yearDifference = DateTime.UtcNow.Year - this.Year;

            if (yearDifference <= 5)
            {
                this.Value *= 1m;
            }
            else if (this.Tonnage <= 5)
            {
                this.Value *= 0.3m;
            }
            else if (this.Tonnage <= 10)
            {
                this.Value *= 0.6m;
            }
            else if (this.Tonnage > 10)
            {
                this.Value *= 0.8m;
            }

            return this.Value;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
