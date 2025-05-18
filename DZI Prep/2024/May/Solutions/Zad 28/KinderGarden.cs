namespace Zad_28
{
    internal class KinderGarden
    {
        public KinderGarden()
        {
            this.KidList = new List<Kid>();
        }

        public ICollection<Kid> KidList { get; set; }

        public void EnrollKid(Kid kid)
        {
            this.KidList.Add(kid);

            Console.WriteLine($"The child {kid.FirstName} {kid.LastName} is enrolled.");
        }

        public void ReleaseKid(string id) 
        {
            var kidToRemove = this.KidList
                .FirstOrDefault(k => k.Id == id);

            if (kidToRemove != null) 
            { 
                this.KidList.Remove(kidToRemove);

                Console.WriteLine($"The child {kidToRemove.FirstName} {kidToRemove.LastName} has been unsubscribed.");
                return;
            }

            Console.WriteLine($"Unsubscribe failed - invalid identifier {id}");
        }

        public void GroupInfo(string group)
        {
            var kidsByGroup = this.KidList
                .Where(k => k.Group == group)
                .OrderBy(k => k.FirstName)
                .ThenBy(k => k.LastName);

            Console.WriteLine($"{group} - {kidsByGroup.Count()} children");

            foreach (var kid in kidsByGroup)
            {
                Console.WriteLine(kid);
            }
        }
    }
}
