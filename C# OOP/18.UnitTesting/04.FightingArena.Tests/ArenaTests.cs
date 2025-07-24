namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {

        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            arena.Enroll(new Warrior("Alf", 50, 1000));
            arena.Enroll(new Warrior("Ben", 60, 1000));
        }

        [Test]
        public void TestArenaConstructor()
        {
            Arena temp = new Arena();
            Assert.IsNotNull(temp);
            Assert.IsNotNull(temp.Warriors);
        }

        [Test]
        public void TestArenaCount()
        {
            Assert.That(arena.Count == 2);
        }
        [Test]
        public void TestDuplicateWarriors()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(new Warrior("Alf", 50, 20));
            }, "Warrior is already enrolled for the fights!");

        }

        [Test]
        public void TestCorrectEnrolling()
        {
            arena.Enroll(new Warrior("Cat", 50, 40));
            Assert.That(arena.Count == 3);
            
        }

        [Test]
        public void TestFightWithMissingAttacker()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Dog", "Alf");
            }, $"There is no fighter with name Dog enrolled for the fights!");
        }

        [Test]
        public void TestFightWithMissingDefender()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Alf", "Dog");
            }, $"There is no fighter with name Dog enrolled for the fights!");
        }

        [Test]
        public void TestSuccessfulFight()
        {
            arena.Fight("Alf", "Ben");
            Assert.That(arena.Warriors.Where(x => x.Name == "Ben").First().HP == 950);
        }
    }
}
