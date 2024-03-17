namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]

        public void ConstructorStoresArrayOfIntegers()
        {
            int[] data = new[] { 1, 2, 3 };
            Database database = new(data);
            var result = database.Fetch();
            Assert.AreEqual(data, result);
        }

        [Test]
        public void ConstructorCheckIfArrayLengthIsGreaterThan16()
        {
            int[] data = new int[17];
            for (int i = 0; i < 17; i++)
            {
                data[i] = i;
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new(data);
            });
        }

        [Test]
        public void AddIncrementsCount()
        {
            Database database = new(new int[] { });
            Assert.AreEqual(0, database.Count);
            database.Add(1);
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void AddElementThrowsError()
        {
            int[] data = new int[16];
            for (int i = 0; i < 16; i++)
            {
                data[i] = i;
            }

                var database = new Database(data);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(5);
            });

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void RemoveDecrementsCount()
        {
            Database database = new(new int[] {1 });
            Assert.AreEqual(1, database.Count);
            database.Remove();
            Assert.AreEqual(0, database.Count);
        }

        [Test]
        public void RemoveElementThrowsError()
        {
            Database database = new(new int[] { });

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });

            Assert.AreEqual("The collection is empty!", exception.Message);
        }
    }
}
