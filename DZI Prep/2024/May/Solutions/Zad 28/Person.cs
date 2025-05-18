namespace Zad_28
{
    internal class Person
    {
        public Person(string firstName, string lastName, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            if (id.Length != 10)
            {
                throw new IOException($"{this.FirstName} {this.LastName} - invalid identifier!");
            }
            this.Id = id;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
    }
}
