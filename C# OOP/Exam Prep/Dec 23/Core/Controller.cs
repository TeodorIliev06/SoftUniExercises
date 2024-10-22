namespace NauticalCatchChallenge.Core
{
    using NauticalCatchChallenge.Core.Contracts;
    using NauticalCatchChallenge.Models;
    using NauticalCatchChallenge.Models.Contracts;
    using NauticalCatchChallenge.Repositories;
    using NauticalCatchChallenge.Repositories.Contracts;
    using NauticalCatchChallenge.Utilities.Messages;
    using System.Text;
    public class Controller : IController
    {
        private IRepository<IDiver> divers;
        private IRepository<IFish> fishes;
        private HashSet<string> diverTypes;
        private HashSet<string> fishTypes;
        public Controller()
        {
            this.divers = new DiverRepository();
            this.fishes = new FishRepository();
            this.diverTypes = new HashSet<string>()
            {
	            nameof(ScubaDiver),
	            nameof(FreeDiver)
            };
            this.fishTypes = new HashSet<string>()
			{
	            nameof(ReefFish),
	            nameof(PredatoryFish),
	            nameof(DeepSeaFish)
			};
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky) //Edited
		{
            if (divers.GetModel(diverName) == null)
            {
                return String.Format(OutputMessages.DiverNotFound, nameof(DiverRepository), diverName);
            }
            if (fishes.GetModel(fishName) == null)
            {
                return String.Format(OutputMessages.FishNotAllowed, fishName);
            }

            IDiver diver = divers.GetModel(diverName);
            if (diver.HasHealthIssues)
            {
                return String.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            IFish currFish = fishes.GetModel(fishName);
			if (diver.OxygenLevel < currFish.TimeToCatch ||
			    (diver.OxygenLevel == currFish.TimeToCatch && !isLucky))
			{
				diver.Miss(currFish.TimeToCatch);

				if (diver.OxygenLevel == 0)
				{
					diver.UpdateHealthStatus();
				}
				return String.Format(OutputMessages.DiverMisses, diverName, fishName);
			}

			diver.Hit(currFish);
			if (diver.OxygenLevel == 0)
			{
				diver.UpdateHealthStatus();
			}
			return String.Format(OutputMessages.DiverHitsFish, diverName, currFish.Points, fishName);
        }

        public string CompetitionStatistics()
        {
	        List<IDiver> diversToReport = divers.Models
		        .Where(d => d.HasHealthIssues == false)
		        .OrderByDescending(d => d.CompetitionPoints)
		        .ThenByDescending(d => d.Catch.Count)
		        .ThenBy(d => d.Name)
		        .ToList();

			StringBuilder sb = new StringBuilder();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var d in diversToReport)
            {
                sb.AppendLine(d.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string DiveIntoCompetition(string diverType, string diverName) //Edited
        {
	        if (!diverTypes.Contains(diverType))
            {
                return String.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

	        if (divers.GetModel(diverName) != null)
	        {
		        return String.Format(OutputMessages.DiverNameDuplication, diverName, nameof(DiverRepository));
	        }

	        IDiver diver = null;
	        if (diverType == nameof(FreeDiver))
	        {
		        diver = new FreeDiver(diverName);
	        }
	        else
	        {
		        diver = new ScubaDiver(diverName);
	        }

	        divers.AddModel(diver);
	        return String.Format(OutputMessages.DiverRegistered, diverName, nameof(DiverRepository));
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");

            foreach (var fishName in diver.Catch)
            {
                IFish currFish = fishes.GetModel(fishName);
                sb.AppendLine(currFish.ToString());
            }

            return sb.ToString().Trim();
        }

        public string HealthRecovery()
        {
            List<IDiver> healthIssueDivers = this.divers.Models
	            .Where(x => x.HasHealthIssues == true)
				.ToList();

            int counter = 0;
            foreach (var d in healthIssueDivers)
            {
                counter++;
                d.UpdateHealthStatus();
                d.RenewOxy();
            }

            return String.Format(OutputMessages.DiversRecovered, counter);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points) //Edited
		{
			if (!fishTypes.Contains(fishType))
			{
				return String.Format(OutputMessages.FishTypeNotPresented, fishType);
			}

			if (fishes.GetModel(fishName) != null)
            {
	            return String.Format(OutputMessages.FishNameDuplication, fishName, nameof(FishRepository));
            }

            IFish newFish = null;
            if (fishType == nameof(ReefFish))
            {
	            newFish = new ReefFish(fishName, points);
            }
            else if (fishType == nameof(PredatoryFish))
            {
	            newFish = new PredatoryFish(fishName, points);
            }
            else
            {
	            newFish = new DeepSeaFish(fishName, points);
            }

            fishes.AddModel(newFish);
            return String.Format(OutputMessages.FishCreated, fishName);
        } 
    }
}
