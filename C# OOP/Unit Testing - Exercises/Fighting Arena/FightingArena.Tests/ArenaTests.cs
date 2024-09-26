namespace FightingArena.Tests
{
	using System;
	using NUnit.Framework;

	[TestFixture]
	public class ArenaTests
	{
		private const string validName = "Igor";
		private const int validDamage = 5;
		private const int validHP = 50;

		private Arena arena;
		private Warrior warrior1;
		private Warrior warrior2;

		[SetUp]
		public void SetUp()
		{
			arena = new Arena();
		}

		[Test]
		public void TestCtor()
		{
			Assert.That(arena, Is.Not.Null);
			Assert.That(arena.Warriors, Is.Not.Null);
			Assert.That(arena.Warriors.Count, Is.Not.Null);
		}

		[Test]
		public void EnrollMethod_DuplicatingNames_ShouldThrow()
		{
			warrior1 = new Warrior(validName, validDamage, validHP);
			warrior2 = new Warrior(validName, validDamage + 1, validHP + 1);
			arena.Enroll(warrior1);
			Assert.That(arena.Count == 1);
			Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior2));
		}

		[Test]
		public void FightMethod_NullNames_ShouldThrow()
		{
			warrior1 = new Warrior(validName, validDamage, validHP);
			warrior2 = new Warrior(validName + "1", validDamage + 1, validHP + 1);
			arena.Enroll(warrior1);
			arena.Enroll(warrior2);

			Assert.Throws<InvalidOperationException>(() => arena.Fight(validName, validName + "2"));
		}

		[Test]
		public void FightMethod_WorksCorrectly()
		{
			warrior1 = new Warrior(validName, validDamage, validHP);
			warrior2 = new Warrior(validName + "1", validDamage + 1, validHP + 1);
			arena.Enroll(warrior1);
			arena.Enroll(warrior2);

			arena.Fight(validName, validName + "1");
			Assert.IsTrue(warrior2.HP == (validHP + 1) - warrior1.Damage);
		}
	}
}