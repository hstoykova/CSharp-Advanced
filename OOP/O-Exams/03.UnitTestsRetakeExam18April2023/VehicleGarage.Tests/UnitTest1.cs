using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorCheck()
        {
            int capacity = 5;
            Garage garage = new(capacity);
            Assert.AreEqual(capacity, garage.Capacity);

            Assert.AreEqual(0, garage.Vehicles.Count);
        }
        [Test]
        public void AddVehicleReturnsFalseWhenCapacityIsReached() 
        {
            Garage garage = new(0);
            Vehicle vehicle = new("VW", "Polo", "SFG123");
            Assert.IsFalse(garage.AddVehicle(vehicle));
        }

        [Test]
        public void AddVehicleReturnsFalseWhenVehicleExists()
        {
            Garage garage = new(5);
            Vehicle vehicle = new("VW", "Polo", "SFG123");
            Assert.IsTrue(garage.AddVehicle(vehicle));
            Assert.IsFalse(garage.AddVehicle(vehicle));
        }

        [Test]
        public void AddVehicleReturnsTrue()
        {
            Garage garage = new(5);
            Vehicle vehicle = new("VW", "Polo", "SFG123");
            Assert.IsTrue(garage.AddVehicle(vehicle));
            Assert.AreEqual(1, garage.Vehicles.Count);
        }

        [Test]
        public void ChargeVehiclesTest()
        {
            Garage garage = new(5);
            Vehicle vehicle = new("VW", "Polo", "SFG123");
            vehicle.BatteryLevel = 10;
            garage.AddVehicle(vehicle);
            Assert.AreEqual(1, garage.ChargeVehicles(20));
            Assert.AreEqual(100, vehicle.BatteryLevel);
        }
    }
}