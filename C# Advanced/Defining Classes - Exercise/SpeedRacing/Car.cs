namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.travelledDistance = 0;
        }

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }


        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }


        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public void Drive(int kilometers)
        {
            if (this.fuelAmount >= this.fuelConsumptionPerKilometer * kilometers)
            {
                this.fuelAmount -= this.fuelConsumptionPerKilometer * kilometers;
                this.travelledDistance += kilometers;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{model} {fuelAmount:f2} {travelledDistance}";
        }
    }
}
