using NUnit.Framework;
using System.Xml.Linq;

namespace VendingRetail.Tests
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
            int waterCapacity = 20;
            int buttonsCount = 10;

            CoffeeMat mat = new(waterCapacity, buttonsCount);

            Assert.AreEqual(waterCapacity, mat.WaterCapacity);
            Assert.AreEqual(buttonsCount, mat.ButtonsCount);
            Assert.AreEqual(0, mat.Income);
        }

        [Test]
        public void FillWaterTankCheck()
        {
            int waterCapacity = 20;
            int buttonsCount = 10;

            CoffeeMat mat = new(waterCapacity, buttonsCount);
            string result = mat.FillWaterTank();
            Assert.AreEqual($"Water tank is filled with {waterCapacity}ml", result);

            string result2 = mat.FillWaterTank();
            Assert.AreEqual("Water tank is already full!", result2);
        }

        [Test]
        public void AddDrinkCheck()
        {
            int waterCapacity = 20;
            int buttonsCount = 1;

            CoffeeMat mat = new(waterCapacity, buttonsCount);

            Assert.IsTrue(mat.AddDrink("coffee", 0.60));
            Assert.IsFalse(mat.AddDrink("coffee", 0.70));
            Assert.IsFalse(mat.AddDrink("cofe", 0.70));

        }

        [Test]
        public void BuyDrinkCheck()
        {
            int waterCapacity = 120;
            int buttonsCount = 10;

            CoffeeMat mat = new(waterCapacity, buttonsCount);
            Assert.AreEqual("CoffeeMat is out of water!", mat.BuyDrink("beer"));

            mat.FillWaterTank();
            mat.AddDrink("tea", 0.45);
            string message = mat.BuyDrink("tea");
            mat.FillWaterTank();

            Assert.AreEqual($"Your bill is {0.45:f2}$", message);
            Assert.AreEqual(0.45, mat.Income);

            Assert.AreEqual("Milk is not available!", mat.BuyDrink("Milk"));
        }

        [Test]
        public void CollectIncomeCheck()
        {
            int waterCapacity = 120;
            int buttonsCount = 10;

            CoffeeMat mat = new(waterCapacity, buttonsCount);
            mat.FillWaterTank();
            mat.AddDrink("tea", 0.45);
            mat.BuyDrink("tea");

            Assert.AreEqual(0.45, mat.CollectIncome());
            Assert.AreEqual(0, mat.Income);
        }
        [Test]
        public void CheckWaterConsuming() 
        {
            int waterCapacity = 120;
            int buttonsCount = 10;
            CoffeeMat mat = new(waterCapacity, buttonsCount);
            mat.FillWaterTank();

            mat.AddDrink("Milk", 0.90);
            mat.AddDrink("Tea", 0.60);

            mat.BuyDrink("Tea");

            Assert.AreEqual("CoffeeMat is out of water!", mat.BuyDrink("Tea"));
        }
    }
}