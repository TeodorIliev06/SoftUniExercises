using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void SetUp()
        {
            db = new Database();
        }

        // Testing the ctor with edge cases(1 -> no data, 4 -> max data) and 2 -> valid data
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void NewDB_ConstructorShouldWork(int[] elementsToAdd)
        {
            Database testDb = new Database(elementsToAdd);

            int[] actualData = testDb.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = testDb.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Data isn't initialised correctly.");
            Assert.AreEqual(expectedCount, actualCount,
                "No initial value for count field.");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void DB_ExceededCapacity_ShouldThrowError(int[] elementsToAdd)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database testDb = new Database(elementsToAdd);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void DB_Count_ShouldWork()
        {
            int[] initData = new int[] { 1, 2, 3 };
            Database testDb = new Database(initData);

            int actualCount = testDb.Count;
            int expectedCount = initData.Length;

            Assert.AreEqual(expectedCount, actualCount,
                "Count should return the count of the added elements.");
        }

        [Test]
        public void DB_CountWhenNoElements_ShouldWork()
        {
            int actualCount = db.Count;
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount,
                "Count should be zero when there are no elements in the DB.");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void DB_Add_ShouldNotExceedCapacity(int[] elementsToAdd)
        {
            foreach (int el in elementsToAdd)
            {
                db.Add(el);
            }

            int[] actualData = db.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = db.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData,
                "The elements should be added to DB");
            Assert.AreEqual(expectedCount, actualCount,
                "Count should be incremented.");
        }

        [Test]
        public void DB_Add_ExceededCapacity_ShouldThrowError()
        {
            for (int i = 1; i <= 16; i++)
            {
                db.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(17);
            }, "Array's capacity must be exactly 16 integers.");
        }

        [TestCase(new int[] { 1, 2, 3})]
        public void DB_Remove_ShouldWork(int[] initialElements)
        {
            foreach (int el in initialElements)
            {
                db.Add(el);
            }

            db.Remove();
            List<int> elements = new List<int>(initialElements);
            elements.RemoveAt(elements.Count - 1);

            int[] actualData = db.Fetch();
            int[] expectedData = elements.ToArray();

            int actualCount = db.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData,
                "The element should be removed from the DB.");
            Assert.AreEqual(expectedCount, actualCount,
                "Count should be decremented.");
        }

        [Test]
        public void DB_RemoveWhenEmpty_ShouldThrowError()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            }, "Can't remove an element from an empty DB.");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void DB_Fetch_ShouldWork(int[] initData)
        {
            foreach (int el in initData)
            {
                db.Add(el);
            }

            int[] actualResult = db.Fetch();
            int[] expectedResult = initData;

            CollectionAssert.AreEqual(expectedResult, actualResult,
                "Fetch should return a copy of DB!");
        }
    }
}