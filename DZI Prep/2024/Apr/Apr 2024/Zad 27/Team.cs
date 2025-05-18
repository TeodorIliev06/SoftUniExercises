namespace Zad_27
{
    using System.Text;

    internal class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();
        }

        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public int Count() => Players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) ||
                string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            if (this.OpenPositions <= 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            this.Players.Add(player);
            this.OpenPositions--;

            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(Player player)
        {
            if (player == null)
            {
                return false;
            }

            var isPlayerRemoved = this.Players.Remove(player);

            if (isPlayerRemoved) 
            {
                this.OpenPositions++;
                return true;
            }

            return false;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players competing for Team {Name} from Group {Group}:");

            foreach (var player in this.Players)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
