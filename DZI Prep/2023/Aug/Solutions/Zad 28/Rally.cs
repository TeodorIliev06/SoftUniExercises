namespace Zad_28
{
    public class Rally
    {
        public Rally(string name, int year)
        {
            this.Name = name;
            this.Year = year;
            this.Pilots = new List<Pilot>();
        }

        public string Name { get; set; }

        public int Year { get; set; }

        public List<Pilot> Pilots { get; set; }

        public void AddPilot(Pilot pilot)
        {
            if (pilot != null)
            {
                this.Pilots.Add(pilot);
                return;
            }

            Console.WriteLine("Please enter a valid pilot");
        }

        public void PrintRallyInformation()
        {
            Console.WriteLine($"Rally: {this.Name} - {this.Year}");
            foreach (var pilot in this.Pilots)
            {
                Console.WriteLine(pilot);
            }
        }
    }
}
