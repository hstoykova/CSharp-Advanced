namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private const string make = "Alfa Romeo";
        private const string model = "Giulia";
        private const double consumption = 7;
        private const double fuelCapacity = 50;
        private Car alfa;

        [SetUp]
        public void Setup()
        {
            alfa = new Car(make, model, consumption, fuelCapacity);
        }

        [Test]
        public void ConstructorCorrectParametersCreatesNewInstance()
        {
            Car alfa = new Car(make, model, consumption, fuelCapacity);
            Assert.That(alfa, Is.Not.Null);
            Assert.That(alfa.Make, Is.EqualTo(make));
            Assert.That(alfa.Model, Is.EqualTo(model));
            Assert.That(alfa.FuelConsumption, Is.EqualTo(consumption));
            Assert.That(alfa.FuelCapacity, Is.EqualTo(fuelCapacity));
            Assert.That(alfa.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void MakeNullThrowsError()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            new Car(null, model, consumption, fuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void MakeEmptyThrowsError()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            new Car(string.Empty, model, consumption, fuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void ModelNullThrowsError()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            new Car(make, null, consumption, fuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void ModelEmptyThrowsError()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            new Car(make, string.Empty, consumption, fuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void FuelConsumptionZeroThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            new Car(make, model, 0, fuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void FuelCapacityZeroThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            new Car(make, model, consumption, 0));
            Assert.That(ex.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void RefuelShouldAddFuelToTank()
        {
            double amountOfFuel = fuelCapacity - 1;
            alfa.Refuel(amountOfFuel);
            Assert.That(alfa.FuelAmount, Is.EqualTo(amountOfFuel));
        }

        [Test]
        public void RefuelReturnZeroOrLess()
        {
            Assert.Throws<ArgumentException>(() => alfa.Refuel(0));
            Assert.Throws<ArgumentException>(() => alfa.Refuel(-1));
        }

        [Test]
        public void TankOverflow()
        {
            double amountOfFuel = fuelCapacity + 1;
            alfa.Refuel(amountOfFuel);
            Assert.That(alfa.FuelAmount, Is.EqualTo(fuelCapacity));
        }

        [Test]
        public void DriveReducesFuelAmount()
        {
            double distance = 20;
            alfa.Refuel(fuelCapacity);
            double fuelNeeded = (distance / 100) * consumption;
            double expectedFuelAmount = alfa.FuelAmount - fuelNeeded;
            alfa.Drive(distance);
            Assert.That(alfa.FuelAmount, Is.EqualTo(expectedFuelAmount));
        }

        [Test]
        public void DriveNotEnoughFuelReducesFuelAmount()
        {
            double distance = 20;
            double fuelNeeded = (distance / 100) * consumption;
            double expectedFuelAmount = alfa.FuelAmount - fuelNeeded;
            var exception =  Assert.Throws<InvalidOperationException>(()=> alfa.Drive(distance));
            Assert.That(exception.Message, Is.EqualTo("You don't have enough fuel to drive!"));
        }
    }
}