namespace Zad_28
{
    public class Pilot
    {
        public Pilot(string name, int age, Car car, string category)
        {
            this.Name = name;
            this.Age = age;
            this.Car = car;
            this.Category = category;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public Car Car { get; set; }

        public string Category { get; set; }

        public override string ToString()
        {
            return $"{this.Name},{this.Age},{this.Category},{this.Car.Brand},{this.Car.HPower}";
        }
    }
}
