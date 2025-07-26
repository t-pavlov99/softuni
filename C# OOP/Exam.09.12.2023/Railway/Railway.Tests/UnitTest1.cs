namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        private RailwayStation rs;

        [SetUp]
        public void Setup()
        {
            rs = new RailwayStation("Central");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void TestNullOrEmptyName(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new RailwayStation(name);
            });
        }
        [Test]
        public void TestConstructor()
        {
            Assert.Multiple(() =>
            {

                Assert.That(rs.Name, Is.EqualTo("Central"));
                Assert.That(rs.ArrivalTrains, Is.Not.Null);
                Assert.That(rs.DepartureTrains, Is.Not.Null);
                Assert.That(rs.ArrivalTrains, Has.Count.EqualTo(0));
                Assert.That(rs.DepartureTrains, Has.Count.EqualTo(0));
            });
        }

        [Test]
        public void TestNewArrival()
        {
            rs.NewArrivalOnBoard("train");
            Assert.That(rs.ArrivalTrains, Has.Count.EqualTo(1));
            Assert.That(rs.ArrivalTrains.Peek(), Is.EqualTo("train"));
        }

        [Test]
        public void TestOutOfOrderArrival()
        {
            rs.NewArrivalOnBoard("train");
            Assert.That(rs.TrainHasArrived("fake"), Is.EqualTo("There are other trains to arrive before fake."));
        }

        [Test]
        public void TestCorrectArrival()
        {
            rs.NewArrivalOnBoard("train");
            string result = rs.TrainHasArrived("train");
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo("train is on the platform and will leave in 5 minutes."));
                Assert.That(rs.DepartureTrains, Has.Count.EqualTo(1));
                Assert.That(rs.ArrivalTrains, Has.Count.EqualTo(0));
                Assert.That(rs.DepartureTrains.Peek(), Is.EqualTo("train"));
            });
        }

        [Test]
        public void TestTrainHasLeft()
        {
            rs.NewArrivalOnBoard("train");
            rs.NewArrivalOnBoard("dog");
            rs.TrainHasArrived("train");
            Assert.That(rs.TrainHasLeft("dog"), Is.False);
            Assert.That(rs.TrainHasLeft("train"), Is.True);
            Assert.That(rs.DepartureTrains, Has.Count.EqualTo(0));
        }
    }
}