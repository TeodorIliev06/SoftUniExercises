using System.Text;
using System.Text.RegularExpressions;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> participantNames = Console.ReadLine()
                .Split(", ")
                .ToList();
            List<Participant> participants = new List<Participant>();

            foreach (string name in participantNames)
            {
                participants.Add(new Participant(name));
            }

            string lettersRegex = @"[A-Za-z]";
            string digitsRegex = @"\d";
            string input;

            while ((input = Console.ReadLine()) != "end of race")
            {
                StringBuilder sb= new();
                foreach (Match match in Regex.Matches(input, lettersRegex))
                {
                    sb.Append(match.Value);
                }

                int distance = 0;
                foreach (Match match in Regex.Matches(input, digitsRegex))
                {
                    distance += int.Parse(match.Value);
                }

                Participant foundParticipant = participants.FirstOrDefault(p => p.Name == sb.ToString());
                if (foundParticipant != null)
                {
                    foundParticipant.Distance += distance;
                }
            }

            participants = participants.OrderByDescending(p => p.Distance).Take(3).ToList();

            Console.WriteLine($"1st place: {participants[0].Name}");
            Console.WriteLine($"2nd place: {participants[1].Name}");
            Console.WriteLine($"3rd place: {participants[2].Name}");
        }
    }
    class Participant
    {
        public Participant(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Distance { get; set; }
    }
}