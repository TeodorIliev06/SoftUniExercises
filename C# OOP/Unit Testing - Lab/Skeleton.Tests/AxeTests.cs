using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(10, 10);
        }

        [Test]
        public void NewAxe_SouldSetDataCorrectly()
        {
            Assert.AreEqual(axe.AttackPoints, 10);
            Assert.AreEqual(axe.DurabilityPoints, 10);
        }

        [Test]
        public void Attack_ShouldDecreaseDurability()
        {
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability does't change after attack.");
        }

        [Test]
        public void Attack_WithBrokenWeapon_ShouldThrowError()
        {
            axe = new Axe(10, 0);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Didn't attack with a broken axe.");
        }

        [Test]
        public void Attack_WithNegativeDurability_ShouldThrowError()
        {
            axe = new Axe(10, -10);
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Didn't set a negative durability.");
        }

        [Test]
        //Shouldn't exist because this is an integration test.
        public void Attack_ShouldCall_TakeAttackOnTarget()
        {
            axe.Attack(dummy);
            Assert.AreEqual(dummy.Health, 0);
        }
    }
}