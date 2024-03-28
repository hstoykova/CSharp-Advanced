namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorCheck()
        {
            RailwayStation station = new("Varna");
            string name = "Varna";
            Assert.AreEqual(name, station.Name);
        }

        [Test]
        public void NameCheck() 
        {
            string stationName = string.Empty;

            var ex = Assert.Throws<ArgumentException>(() => new RailwayStation (stationName));

            Assert.AreEqual("Name cannot be null or empty!", ex.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => new RailwayStation(null));

            Assert.AreEqual("Name cannot be null or empty!", ex2.Message);
        }

        [Test]
        public void NewArrivalOnBoardShouldWorkCorrectly()
        {
            string stationName = "Varna";
            RailwayStation station = new(stationName);
            station.NewArrivalOnBoard("karnobat-varna");
            Assert.AreEqual(1, station.ArrivalTrains.Count);
        }

        [Test]
        public void TrainHasArrivedCheck()
        {
            string stationName = "Varna";
            RailwayStation station = new(stationName);
            station.NewArrivalOnBoard("karnobat-varna");
            string message = station.TrainHasArrived("karnobat-burgas");
            Assert.AreEqual("There are other trains to arrive before karnobat-burgas.", message);

            string anotherMessage = station.TrainHasArrived("karnobat-varna");
            Assert.AreEqual(1, station.DepartureTrains.Count);
            Assert.AreEqual(0, station.ArrivalTrains.Count);
            Assert.AreEqual("karnobat-varna is on the platform and will leave in 5 minutes.", anotherMessage);
        }

        [Test]
        public void TrainHasLeftCheck()
        {
            RailwayStation station = new("Varna");
            station.NewArrivalOnBoard("karnobat-varna");
            station.TrainHasArrived("karnobat-varna");
            //station.TrainHasArrived("karnobat-ruse");

            Assert.IsTrue(station.TrainHasLeft("karnobat-varna"));
            Assert.AreEqual(true, station.DepartureTrains.Count == 0);

            station.NewArrivalOnBoard("karnobat-varna");
            station.TrainHasArrived("karnobat-varna");
            Assert.IsFalse(station.TrainHasLeft("karnobat-ruse"));
        }

    }
}