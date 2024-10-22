namespace Railway.Tests
{
	using NUnit.Framework;
	using System;

	public class Tests
	{
		private RailwayStation station;

		[SetUp]
		public void Setup()
		{
			station = new RailwayStation("Central Station");
		}

		[Test]
		public void Constructor_ShouldInitializeCorrectly()
		{
			Assert.AreEqual("Central Station", station.Name);
			Assert.IsEmpty(station.ArrivalTrains);
			Assert.IsEmpty(station.DepartureTrains);
		}

		[Test]
		public void Name_ShouldThrowArgumentException_WhenNullOrEmpty()
		{
			Assert.Throws<ArgumentException>(() => new RailwayStation(null));
			Assert.Throws<ArgumentException>(() => new RailwayStation(""));
		}

		[Test]
		public void NewArrivalOnBoard_ShouldAddTrainToArrivalQueue()
		{
			station.NewArrivalOnBoard("Train 1");
			Assert.AreEqual(1, station.ArrivalTrains.Count);
			Assert.AreEqual("Train 1", station.ArrivalTrains.Peek());
		}

		[Test]
		public void TrainHasArrived_ShouldMoveTrainToDepartureQueue()
		{
			station.NewArrivalOnBoard("Train 1");
			var result = station.TrainHasArrived("Train 1");
			Assert.AreEqual("Train 1 is on the platform and will leave in 5 minutes.", result);
			Assert.AreEqual(0, station.ArrivalTrains.Count);
			Assert.AreEqual(1, station.DepartureTrains.Count);
			Assert.AreEqual("Train 1", station.DepartureTrains.Peek());
		}

		[Test]
		public void TrainHasArrived_ShouldReturnErrorMessage_WhenTrainNotFirstInQueue()
		{
			station.NewArrivalOnBoard("Train 1");
			station.NewArrivalOnBoard("Train 2");
			var result = station.TrainHasArrived("Train 2");
			Assert.AreEqual("There are other trains to arrive before Train 2.", result);
		}

		[Test]
		public void TrainHasLeft_ShouldRemoveTrainFromDepartureQueue()
		{
			station.NewArrivalOnBoard("Train 1");
			station.TrainHasArrived("Train 1");
			var result = station.TrainHasLeft("Train 1");
			Assert.IsTrue(result);
			Assert.AreEqual(0, station.DepartureTrains.Count);
		}

		[Test]
		public void TrainHasLeft_ShouldReturnFalse_WhenTrainNotFirstInQueue()
		{
			station.NewArrivalOnBoard("Train 1");
			station.TrainHasArrived("Train 1");
			station.NewArrivalOnBoard("Train 2");
			station.TrainHasArrived("Train 2");
			var result = station.TrainHasLeft("Train 2");
			Assert.IsFalse(result);
		}
	}
}