namespace FightingArena.Tests
{
	using System;
	using NUnit.Framework;

	[TestFixture]
	public class WarriorTests
	{
		private const string validName = "Igor";
		private const int validDamage = 5;
		private const int validHP = 50;

		private const string nonValidName = "";
		private const int nonValidDamage = -1;
		private const int nonValidHP = -1;

		private const int MIN_ATTACK_HP = 30;

		private Warrior warrior1;
		private Warrior warrior2;

		[SetUp]
		public void SetUp()
		{
			warrior1 = new Warrior(validName, validDamage, validHP);
			warrior2 = new Warrior(validName + "1", validDamage, validHP);
		}

		[Test]
		public void Ctor_ShouldWork()
		{
			Assert.That(warrior1.Name == validName);
			Assert.That(warrior1.Damage == validDamage);
			Assert.That(warrior1.HP == validHP);
		}

		[Test]
		public void NameProp_Validation_ShouldThrowAnException()
		{
			Assert.Throws<ArgumentException>(() => warrior1 = new Warrior(nonValidName, validDamage, validHP));
		}

		[Test]
		public void DamageProp_Validation_ShouldThrowAnException()
		{
			Assert.Throws<ArgumentException>(() => warrior1 = new Warrior(validName, nonValidDamage, validHP));
		}

		[Test]
		public void HPProp_Validation_ShouldThrowAnException()
		{
			Assert.Throws<ArgumentException>(() => warrior1 = new Warrior(validName, validDamage, nonValidHP));
		}

		[Test]
		public void AttackMethod_AtackingWarriorHPLessThanMinATKHP_ShouldThrow()
		{
			warrior1 = new Warrior(validName, validDamage, MIN_ATTACK_HP - 1);
			Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
		}

		[Test]
		public void AttackMethod_AtackedWarriorHPLessThanMinATKHP_ShouldThrow()
		{
			warrior2 = new Warrior(validName, validDamage, MIN_ATTACK_HP - 1);
			Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
		}

		[Test]
		public void AttackMethod_AtackingWarriorHasLessHpThanAttackedWarriorDMG_ShouldThrow()
		{
			warrior1 = new Warrior(validName, validDamage, validHP);
			warrior2 = new Warrior(validName, validHP + 1, validHP);
			Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
		}

		[Test]
		public void AttackMethod_DMGIsMoreThanHP()
		{
			warrior1 = new Warrior(validName, 300, validHP);
			warrior2 = new Warrior(validName, validDamage, 300 - 1);
			warrior1.Attack(warrior2);
			Assert.IsTrue(warrior2.HP == 0);
		}

		[Test]
		public void AttackMethod_ReduceHP()
		{
			warrior1 = new Warrior(validName, validDamage, validHP);
			warrior2 = new Warrior(validName, validDamage, validHP);
			warrior1.Attack(warrior2);
			Assert.IsTrue(warrior2.HP == validHP - validDamage);
		}
	}
}