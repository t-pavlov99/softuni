namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Xml.Linq;

    [TestFixture]
    public class WarriorTests
    {
        private int MIN_ATTACK_HP;

        [Test]
        public void TestWarriorConstructor()
        {
            Warrior w = new Warrior("Alf", 50, 60);
            Assert.That(w.HP == 60);
            Assert.That(w.Damage == 50);
            Assert.That(w.Name == "Alf");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void TestBadNames(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior w = new Warrior(name, 50, 50);
            }, "Name should not be empty or whitespace!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-4)]
        public void TestBadDamage(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior w = new Warrior("dog", damage, 50);
            }, "Damage value should be positive!");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-4)]
        public void TestBadHP(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior w = new Warrior("dog",40, hp);
            }, "HP should not be negative!");
        }

        [Test]
        [TestCase(1)]
        [TestCase(29)]
        public void TestAttackWhenAttackerIsWeak(int hp)
        {
            Warrior attacker = new Warrior("a", 50, hp);
            Warrior defender = new Warrior("b", 50, 100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        [TestCase(1)]
        [TestCase(29)]
        public void TestAttackWhenDefenderIsWeak(int hp)
        {

            
            Warrior attacker = new Warrior("a", 50, 100);
            Warrior defender = new Warrior("b", 50, hp);
            MIN_ATTACK_HP = (int)attacker.GetType().GetField("MIN_ATTACK_HP", System.Reflection.BindingFlags.NonPublic | BindingFlags.Static).GetValue(attacker);
            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }

        [Test]
        public void TestAttackWhenAttackerIsWeakerThanDefender()
        {
            Warrior attacker = new Warrior("a", 50, 100);
            Warrior defender = new Warrior("b", 101, 120);
            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, $"You are trying to attack too strong enemy");
        }

        [Test]
        public void TestSuccessfulAttack()
        {
            Warrior attacker = new Warrior("a", 50, 1000);
            Warrior defender = new Warrior("b", 60, 1000);
            attacker.Attack(defender);
            Assert.That(defender.HP == 950);
            attacker.Attack(defender);
            Assert.That(defender.HP == 900);
            defender.Attack(attacker);
            Assert.That(attacker.HP == 820);
        }

        [Test]
        public void TestKill()
        {
            Warrior attacker = new Warrior("a", 60, 1000);
            Warrior defender = new Warrior("b", 50, 50);
            attacker.Attack(defender);
            Assert.That(defender.HP == 0);
        }
    }
}