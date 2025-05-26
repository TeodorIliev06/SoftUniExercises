namespace Zad_28
{
    public class Car
    {
        public Car(string brand, int hPower)
        {
            this.Brand = brand;
            this.HPower = hPower;
        }

        public string Brand { get; set; }

        public int HPower { get; set; }

        public override string ToString()
        {
            return $"{this.Brand},{this.HPower}";
        }
    }
}
