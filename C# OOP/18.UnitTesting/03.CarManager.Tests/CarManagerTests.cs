namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class CarManagerTests
    {
        private List<Car> cars;
        private double car0FConsumption = 9.8, car1FConsumption = 8.9, car0FCapacity = 48.5, car1FCapacity = 55;

        [SetUp]
        public void SetUp()
        {
            cars = new List<Car>();
            cars.Add(new Car("Red", "Audi", car0FConsumption, car0FCapacity));
            cars.Add(new Car("Blue", "Mercedes", car1FConsumption, car1FCapacity));
        }

        [Test]
        public void TestConstructorCreatesEmptyTank()
        {
            Assert.That(cars[0].FuelAmount == 0);
        }

        [Test]
        public void TestGetters()
        {
            Assert.That(cars[0].Model == "Audi");
            Assert.That(cars[1].Make == "Blue");
            Assert.That(cars[1].FuelConsumption == car1FConsumption);
            Assert.That(cars[0].FuelCapacity == car0FCapacity);
        }

        
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void TestMakeSetter(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car c = new Car(make, "a", 1, 2);
            }, "Make cannot be null or empty!");
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void TestModelSetter(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car c = new Car("a", model, 1, 2);
            }, "Model cannot be null or empty!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-2.5)]
        public void TestFuelConsumptionSetter(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car c = new Car("a", "b", fuelConsumption, 5);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-2.5)]
        public void TestFuelCapacity(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car c = new Car("a", "b", 5, fuelCapacity);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-2.5)]
        public void TestRefuelingWithNonpositiveFuel(double fuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                cars[0].Refuel(fuel);
            }, "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void TestRefuelToTop()
        {
            cars[0].Refuel(car0FCapacity);
            cars[1].Refuel(car1FCapacity + 1);
            Assert.That(cars[0].FuelAmount, Is.EqualTo(car0FCapacity));
            Assert.That(cars[1].FuelAmount, Is.EqualTo(car1FCapacity));
        }

        [Test]
        public void TestRefuelToBelowCapacity()
        {
            cars[0].Refuel(10);
            cars[0].Refuel(10);
            Assert.That(cars[0].FuelAmount == 20);
        }

        [Test]
        [TestCase(500)]
        [TestCase(600)]
        public void TestDrivesThatAreTooLong(double distance)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                cars[0].Drive(distance);
            }, "You don't have enough fuel to drive!");
        }

        [Test]
        [TestCase(90)]
        [TestCase(400)]
        public void TestPossibleDrives(double distance)
        {
            cars[0].Refuel(car0FCapacity);
            cars[1].Refuel(car1FCapacity);
            cars[0].Drive(distance);
            cars[1].Drive(distance);
            Assert.That(cars[0].FuelAmount, Is.EqualTo(car0FCapacity - car0FConsumption * distance / 100));
            Assert.That(cars[1].FuelAmount, Is.EqualTo(car1FCapacity - car1FConsumption * distance / 100));
        }

    }
}