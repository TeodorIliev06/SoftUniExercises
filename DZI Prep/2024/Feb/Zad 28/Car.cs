using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_28
{
    internal class Car
    {
        public Car(string brand, int year, int mileage, decimal value)
        {
            Brand = brand;
            Year = year;
            Mileage = mileage;
            Value = value;
        }

        public string Brand { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public decimal Value { get; set; }

        public virtual decimal Price()
        {
            var yearDifference = DateTime.UtcNow.Year - this.Year;

            if (yearDifference <= 3)
            {
                this.Value *= 0.8m;
            }
            else if (yearDifference <= 6)
            {
                this.Value *= 0.6m;
            }
            else
            {
                this.Value *= 0.3m;
            }

            return this.Value;
        }

        public override string ToString() 
            => $"{this.Brand}: {this.Mileage} km, {this.Price():F2}";
    }
}
