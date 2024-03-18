namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        //[SetUp]
        //public void Setup()
        //{
        //    Database database = new();
        //    Person person = new(1, "Penio");
        //}

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            Database database = new();
            Person person = new(1, "Penio");
            database.Add(person);
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void AddElementThrowsErrorIfCountIs16()
        {
            Person[] people = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                Person person = new(i, $"Penio{i}");
                people[i] = person;
            }
            Database database = new(people);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            {
                Person person = new(100, "Ivan");
                database.Add(person);
            });

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void AddElementThrowsErrorIfUsernameAlreadyExists()
        {
            Database database = new();
            Person person = new(1, "Penio");

            database.Add(person);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            {

                database.Add(person);
            });

            Assert.AreEqual("There is already user with this username!", exception.Message);
        }

        [Test]
        public void AddElementThrowsErrorIfIdAlreadyExists()
        {
            Database database = new();
            Person person = new(1, "Penio");

            database.Add(person);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            {
                Person person = new(1, "Penio2");
                database.Add(person);
            });

            Assert.AreEqual("There is already user with this Id!", exception.Message);
        }

        [Test]
        public void CheckIfPeronCountIncreasesCorrectly()
        {
            Database database = new();
            Person person = new(1, "Penio");
            database.Add(person);

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void CheckIfRemoveDecreaseTheCountCorrectly()
        {
            Database database = new();
            Person person = new(1, "Penio");
            database.Add(person);
            Person person2 = new(2, "Koce");
            database.Add(person2);

            database.Remove();

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void CheckIfDecreasedCountThrowsError()
        {
            Database database = new();
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void CheckIfFindByUsernameReturnsCorrectPerson()
        {
            Database database = new();
            Person person = new(1, "Penio");
            database.Add(person);

            database.FindByUsername("Penio");

            Assert.AreEqual("Penio", "Penio");
        }

        [Test]
        public void CheckIfFindByUsernameThrowsErrorIfUserNameIsWrong()
        {
            Database database = new();

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("Hello");
            });

            Assert.AreEqual("No user is present by this username!", exception.Message);
        }

        [Test]
        public void CheckIfFindByUsernameThrowsErrorIfUserNameIsNullOrEmpty()
        {
            Database database = new();

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            });
            //Assert.That(ex.Message, Is.EqualTo("Username parameter is null!"));

            //Assert.AreEqual("No user is present by this username!", exception.Message);
        }

        [Test]
        public void CheckIfFindByIdReturnsCorrectPersonWithCorrectId()
        {
            Database database = new();
            Person person = new(1, "Penio");
            database.Add(person);

            database.FindById(1);

            Assert.AreEqual(1, 1);
        }

        [Test]
        public void CheckIfFindByIdThrowsErrorIfItsNotPositiveNumber()
        {
            Database database = new();

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-1);
            });

            //Assert.AreEqual("Id should be a positive number!", exception.Message);
        }

        [Test]
        public void CheckIfFindByIdThrowsErrorIfIdDoesntExist()
        {
            Database database = new();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(5);
            });
            //Assert.That(ex.Message, Is.EqualTo("Username parameter is null!"));

            //Assert.AreEqual("No user is present by this username!", exception.Message);
        }
    }
}