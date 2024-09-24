using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(10, 10);
        }

        [Test]
        public void NewDummy_SouldSetDataCorrectly()
        {
            Assert.AreEqual(dummy.Health, 10);
        }

        [Test]
        public void TakeAttack_ShouldLowerHelath()
        {
            dummy.TakeAttack(5);
            Assert.AreEqual(dummy.Health, 5);
        }

        [Test]
        public void TakeAttack_WhenDead()
        {
            dummy.TakeAttack(20);
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10), "Attacking alive dummy.");
        }

        [Test]
        public void GiveExperience_WhenNotDead()
        {
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Dummy is dead.");
        }

        [Test]
        public void GiveExperience_WhenDead_ShouldWork()
        {
            dummy.TakeAttack(10);
            Assert.AreEqual(dummy.GiveExperience(), 10);
        }
    }
}