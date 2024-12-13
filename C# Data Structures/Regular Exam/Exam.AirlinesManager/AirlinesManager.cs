using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class AirlinesManager : IAirlinesManager
    {
        private IDictionary<string, Airline> airlinesById;
        private IDictionary<string, Flight> flightsById;

        public AirlinesManager()
        {
            this.airlinesById = new Dictionary<string, Airline>();
            this.flightsById = new Dictionary<string, Flight>();
        }

        public void AddAirline(Airline airline)
        {
            if (this.airlinesById.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }

            this.airlinesById.Add(airline.Id, airline);
        }

        public void AddFlight(Airline airline, Flight flight)
        {
            if (!this.airlinesById.ContainsKey(airline.Id) ||
                this.flightsById.ContainsKey(flight.Id))
            {
                throw new ArgumentException();
            }

            this.flightsById.Add(flight.Id, flight);
            this.airlinesById[airline.Id].Flights.Add(flight);
        }

        public bool Contains(Airline airline) => this.airlinesById.ContainsKey(airline.Id);

        public bool Contains(Flight flight) => this.flightsById.ContainsKey(flight.Id);

        public void DeleteAirline(Airline airline)
        {
            if (!this.airlinesById.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }

            var airlineToRemove = this.airlinesById[airline.Id];
            this.airlinesById.Remove(airlineToRemove.Id);

            foreach (var flight in airlineToRemove.Flights)
            {
                this.flightsById.Remove(flight.Id);
            }
        }

        public IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName()
            => this.airlinesById.Values
                .OrderByDescending(a => a.Rating)
                .ThenByDescending(a => a.Flights.Count)
                .ThenBy(a => a.Name);

        public IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination)
            => this.airlinesById.Values
                .Where(a =>
                    a.Flights.Any(f =>
                        f.IsCompleted is false &&
                        f.Origin == origin &&
                        f.Destination == destination));

        public IEnumerable<Flight> GetAllFlights() => this.flightsById.Values;

        public IEnumerable<Flight> GetCompletedFlights()
            => this.GetAllFlights()
                .Where(f => f.IsCompleted is true);

        //Ordering by completion - false values (0) come before true ones (1)
        public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber()
            => this.GetAllFlights()
                .OrderBy(f => f.IsCompleted is true)
                .ThenBy(f => f.Number);

        public Flight PerformFlight(Airline airline, Flight flight)
        {
            if (!this.airlinesById.ContainsKey(airline.Id) ||
                !this.flightsById.ContainsKey(flight.Id))
            {
                throw new ArgumentException();
            }

            var flightToPerform = this.flightsById[flight.Id];
            flightToPerform.IsCompleted = true;

            return flightToPerform;
        }
    }
}
