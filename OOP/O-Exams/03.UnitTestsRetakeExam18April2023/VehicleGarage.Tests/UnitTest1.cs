using NUnit.Framework;
using System;
using System.Linq;

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
            Assert.IsTrue(garage.Vehicles.All(v => v.BatteryLevel == 100));
        }

        [Test]
        public void ChargeVehiclesReturnZero()
        {
            Garage garage = new(5);
            Vehicle vehicle = new("VW", "Polo", "SFG123");
            vehicle.BatteryLevel = 50;
            garage.AddVehicle(vehicle);
            Assert.AreEqual(0, garage.ChargeVehicles(20));
            //Assert.IsTrue(garage.Vehicles.All(v => v.BatteryLevel == 100));
        }

        [Test]
        public void DriveVehicleCheckBatteryLevelChange()
        {
            Garage garage = new(5);
            Vehicle vehicle = new("VW", "Polo", "SFG123");
            vehicle.BatteryLevel = 100;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("SFG123", 20, false);

            Assert.AreEqual(80, vehicle.BatteryLevel);
            Assert.IsFalse(vehicle.IsDamaged);
        }

        [Test]
        public void DriveVehicleCheckIsDamagedChange()
        {
            Garage garage = new(5);
            Vehicle vehicle = new("VW", "Polo", "SFG123");
            vehicle.BatteryLevel = 100;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("SFG123", 20, true);

            Assert.AreEqual(80, vehicle.BatteryLevel);
            Assert.IsTrue(vehicle.IsDamaged);
        }

        [Test]
        public void DriveVehicleCheck1()
        {
            Garage garage = new(5);
            Vehicle vehicle = new("VW", "Polo", "SFG123");
            vehicle.BatteryLevel = 100;
            vehicle.IsDamaged = true;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("SFG123", 20, false);

            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.IsTrue(vehicle.IsDamaged);
        }

        [Test]
        public void DriveVehicleCheck2()
        {
            Garage garage = new(5);
            Vehicle vehicle = new("VW", "Polo", "SFG123");
            vehicle.BatteryLevel = 100;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("SFG123", 120, false);

            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.IsFalse(vehicle.IsDamaged);
        }

        [Test]
        public void DriveVehicleCheck3()
        {
            Garage garage = new(5);
            Vehicle vehicle = new("VW", "Polo", "SFG123");
            vehicle.BatteryLevel = 10;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("SFG123", 20, false);

            Assert.AreEqual(10, vehicle.BatteryLevel);
            Assert.IsFalse(vehicle.IsDamaged);
        }

        [Test]
        public void DriveVehicleCheck4()
        {
            Garage garage = new(5);
            Assert.Throws<NullReferenceException>(() => garage.DriveVehicle("SFG123", 20, false));
        }

        [Test]
        public void RepairVehiclesCheck()
        {
            Garage garage = new(5);
            Vehicle vehicle = new("VW", "Polo", "SFG123");
            vehicle.IsDamaged = true;
            garage.AddVehicle(vehicle);

            Vehicle vehicle1 = new("VW", "Polo", "kkk123");
            vehicle1.IsDamaged = true;
            garage.AddVehicle(vehicle1);

            Vehicle vehicle2 = new("VW", "Polo", "888888");
            garage.AddVehicle(vehicle2);

            string result = garage.RepairVehicles();

            Assert.AreEqual("Vehicles repaired: 2", result);
            Assert.IsTrue(garage.Vehicles.All(v => !v.IsDamaged));
        }
    }
}