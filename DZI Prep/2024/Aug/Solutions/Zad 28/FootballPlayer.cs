namespace Zad_28
{
    internal class FootballPlayer : ClubMember
    {
        public FootballPlayer(string firstName, string lastName, int age, double salary,
            string position, int contractLength, int matches, int goals, int assists) 
            : base(firstName, lastName, age, salary)
        {
            this.Position = position;
            this.ContractLength = contractLength;
            this.Matches = matches;
            this.Goals = goals;
            this.Assists = assists;
        }

        public string Position { get; set; }
        public int ContractLength { get; set; }
        public int Matches { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }

        public void Info()
        {
            Console.WriteLine($"{this.FirstName} {this.LastName} - {this.Position}");
            Console.WriteLine($"salary: {this.Salary:F2} lv");
            Console.WriteLine($"age: {this.Age} years");
            Console.WriteLine($"{this.Goals} goals and {this.Assists} assists in {this.Matches} matches");
        }
    }
}
