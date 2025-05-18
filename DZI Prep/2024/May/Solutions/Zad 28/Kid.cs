namespace Zad_28
{
    internal class Kid : Person
    {
        public Kid(string firstName, string lastName, string id,
            int age, string parentLastName,
            string parentGSM) : base(firstName, lastName, id)
        {
            this.Age = age;
            this.ParentLastName = parentLastName;
            this.ParentGSM = parentGSM;

            switch (this.Age)
            {
                case 3:
                    this.Group = "I";
                    break;
                case 4:
                    this.Group = "II";
                    break;
                case 5:
                    this.Group = "III";
                    break;
                case 6:
                    this.Group = "IV";
                    break;
                default:
                    throw new IOException($"The child {this.FirstName} {this.LastName} age is invalid - {this.Age}");
            }
        }

        public int Age { get; set; }
        public string Group { get; set; }
        public string ParentLastName { get; set; }
        public string ParentGSM { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}, {this.Age}, {this.ParentGSM} ({this.ParentLastName})";
        }
    }
}
