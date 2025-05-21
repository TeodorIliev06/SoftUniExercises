namespace Zad_28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var members = new List<ClubMember>();
            using var reader = new StreamReader("input.txt");

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var memberInfo = line.Split(',');
                var memberType = memberInfo[0];

                var firstName = memberInfo[1];
                var lastName = memberInfo[2];
                var age = int.Parse(memberInfo[3]);
                var salary = double.Parse(memberInfo[4]);

                ClubMember member = null!;
                int contractLength;
                switch (memberType)
                {
                    case nameof(FootballPlayer):
                        var position = memberInfo[5];
                        contractLength = int.Parse(memberInfo[6]);
                        int matches = int.Parse(memberInfo[7]);
                        int goals = int.Parse(memberInfo[8]);
                        int assists = int.Parse(memberInfo[9]);

                        member = new FootballPlayer(firstName, lastName, age, salary,
                            position, contractLength, matches, goals, assists);
                        break;
                    case nameof(Coach):
                        var coachType = memberInfo[5];
                        contractLength = int.Parse(memberInfo[6]);

                        member = new Coach(firstName, lastName, age,
                            salary, coachType, contractLength);
                        break;
                    case nameof(Director):
                        var directorType = memberInfo[5];

                        member = new Director(firstName, lastName, age, salary, directorType);
                        break;
                }

                members.Add(member);
            }

            members = members.OrderBy(m => m.Age).ToList();

            foreach (var member in members)
            {
                member.Info();
                Console.WriteLine(new string('*', 20));
            }

            var highestPaidMember = members.MaxBy(m => m.Salary);

            if (highestPaidMember != null)
            {
                Console.WriteLine($"The person with the highest salary is {highestPaidMember.FirstName} {highestPaidMember.LastName} with {highestPaidMember.Salary} lv salary.");
            }

            //var topScorer = members
            //    .Where(m => m is FootballPlayer)
            //    .Select(m => m as FootballPlayer)
            //    .MaxBy(m => m.Goals);

            //Filter and cast in one step
            var topScorer = members
                .OfType<FootballPlayer>()
                .MaxBy(m => m.Goals);

            if (topScorer != null)
            {
                Console.WriteLine($"The team's top scorer is {topScorer.FirstName} {topScorer.LastName} with {topScorer.Goals} goals.");
            }
        }
    }
}
