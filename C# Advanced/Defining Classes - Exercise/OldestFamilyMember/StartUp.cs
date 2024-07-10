namespace OldestFamilyMember
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < inputCount; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                family.AddMember(new Person(name, age));
            }

            Person oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}