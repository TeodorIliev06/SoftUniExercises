namespace P10_The_Party_Reservation_Filter_Module
{
    public class Program
    {
        public class Filter
        {
            public Filter(string filterType, string filterParameter)
            {
                Type = filterType;
                Parameter = filterParameter;

            }
            public string Type { get; set; }

            public string Parameter { get; set; }
        }

        static void Main()
        {
            List<string> invitations = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<Filter> filters = new List<Filter>();
            string commandSeq;

            while ((commandSeq = Console.ReadLine()) != "Print")
            {
                string[] commandInfo = commandSeq.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = commandInfo[0];
                string filterType = commandInfo[1];
                string filterParameter = commandInfo[2];

                Filter currFilter = new Filter(filterType, filterParameter);

                switch (command)
                {
                    case "Add filter":
                        filters.Add(currFilter);
                        break;
                    case "Remove filter":
                        filters.RemoveAll(filter =>
                            filter.Type == filterType &&
                            filter.Parameter == filterParameter);
                        break;
                }
            }

            invitations = RemovePeople(filters, invitations);
            Console.WriteLine(string.Join(' ', invitations));
        }

        public static List<string> RemovePeople(List<Filter> filters, List<string> invitations)
        {

            foreach (var filter in filters)
            {
                switch (filter.Type)
                {
                    case "Starts with":
                        invitations.RemoveAll(name => name.StartsWith(filter.Parameter));
                        break;
                    case "Ends with":
                        invitations.RemoveAll(name => name.EndsWith(filter.Parameter));
                        break;
                    case "Length":
                        invitations.RemoveAll(name => name.Length == int.Parse(filter.Parameter));
                        break;
                    case "Contains":
                        invitations.RemoveAll(name => name.Contains(filter.Parameter));
                        break;
                }
            }

            return invitations;
        }
    }

}