namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;
        private Person[] people;
        private Person person;
        private const string validUserName = "pesho123";
        private const long validId = 100001;
        private const int edgeCaseNumberOfPeople = 17;
        private const int maxNumberOfPeople = 16;

        [SetUp]
        public void SetUp()
        {
            person = new Person(validId, validUserName);
            people = new Person[1] { person };
            db = new Database(people);
            //Person person = new Person(validId, validUsername);
            //Person[] people = new Person[] { person };
        }

        [Test]
        public void NewPerson_ConstructorShouldWork()
        {
            long actualId = person.Id;
            long expectedId = validId;

            string actualUserName = person.UserName;
            string expectedUserName = validUserName;

            Assert.AreEqual(actualId, expectedId,
                "Person Id not set correctly.");
            Assert.AreEqual(actualUserName, expectedUserName,
                "Person Username not set correctly.");
        }

        [Test]
        public void NewDB_EmptyConstructor_ShouldWork()
        {
            Database testDb = new Database();
            people = new Person[0];

            int actualPeopleCount = testDb.Count;
            int expectedPeopleCount = people.Length;

            Assert.That(db, Is.Not.Null);
            Assert.That(actualPeopleCount, Is.EqualTo(expectedPeopleCount));
        }

        [Test]
        public void NewDB_Constructor_ShouldWork()
        {
            int actualPeopleCount = db.Count;
            int expectedPeopleCount = people.Length;

            Assert.That(db, Is.Not.Null);
            Assert.That(actualPeopleCount, Is.EqualTo(expectedPeopleCount));
        }

        [Test]
        public void DB_ExceededCapacity_ShouldThrowError()
        {
            people = new Person[edgeCaseNumberOfPeople];

            for (int i = 0; i < edgeCaseNumberOfPeople; i++)
            {
                people[i] = new Person(validId + i, $"{validId}{i}");
            }

            Assert.Throws<ArgumentException>(() =>
            {
                Database testDb = new Database(people);
            }, "Array's capacity must be exactly 16 integers.");
        }

        [Test]
        public void DB_Add_ShouldWork()
        {
            Database testDb = new Database();
            testDb.Add(person);

            int actualPeopleCount = testDb.Count;
            int expectedPeopleCount = people.Length;

            Assert.That(actualPeopleCount, Is.EqualTo(expectedPeopleCount));
        }

        [Test]
        public void DB_Add_ExceededCapacity_ShouldThrowError()
        {
            for (int i = db.Count; i < maxNumberOfPeople; i++)
            {
                db.Add(new Person(1000000 + i, $"Gosho{i}"));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(3333333, "Petkan"));
            }, "Array's capacity must be exactly 16 integers.");
        }

        [Test]
        public void DB_Add_ExistingUserName_ShouldThrowError()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(3333333, validUserName));
            }, "There is already user with this username.");
        }

        [Test]
        public void DB_Add_ExistingId_ShouldThrowError()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(validId, "Milen"));
            }, "There is already user with this Id.");
        }

        [Test]
        public void DB_FindByUserName_ShouldWork()
        {

            Person personFound = db.FindByUsername(validUserName);

            string actualUserName = personFound.UserName;
            string expectedUserName = validUserName;

            long actualId = personFound.Id;
            long expectedId = validId;

            Assert.That(personFound, Is.Not.Null);
            Assert.That(actualUserName, Is.EqualTo(expectedUserName));
            Assert.That(actualId, Is.EqualTo(expectedId));
        }


        [TestCase(null)]
        public void DB_FindByUserName_Null_ShouldThrowError(string invalidUserName)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(invalidUserName);
            }, "Username can't be null.");
        }

        [TestCase(" ")]
        public void DB_FindByUserName_WhiteSpace_ShouldThrowError(string invalidUserName)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername(invalidUserName);
            }, "Username can't be a white space.");
        }

        [TestCase("adsakblaik")]
        public void DB_FindByUserName_NotPresent_ShouldThrowError(string invalidUserName)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername(invalidUserName);
            }, "No user is present by this username.");
        }


        [Test]
        public void DB_FindById_ShouldWork()
        {

            Person personFound = db.FindById(validId);

            string actualUserName = personFound.UserName;
            string expectedUserName = validUserName;

            long actualId = personFound.Id;
            long expectedId = validId;

            Assert.That(personFound, Is.Not.Null);
            Assert.That(actualUserName, Is.EqualTo(expectedUserName));
            Assert.That(actualId, Is.EqualTo(expectedId));
        }

        [TestCase(-1)]
        public void DB_FindById_Negative_ShouldThrowError(long invalidId)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(invalidId);
            }, "Id can't be a negative integer.");
        }


        [TestCase(123)]
        public void Db_FindById_NotPresent_ShouldThrowError(long invalidId)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(invalidId);
            }, "No user is present by this id.");
        }

        [Test]
        public void DB_Remove_ShouldWork()
        {
            db.Remove();

            int actualCount = db.Count;
            int expectedCount = 0;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void DB_RemoveWhenEmpty_ShouldThrowError()
        {
            db.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            }, "Can't remove a person from an empty DB.");
        }
    }
}