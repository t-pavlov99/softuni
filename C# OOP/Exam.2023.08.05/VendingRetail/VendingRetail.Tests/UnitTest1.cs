using NUnit.Framework;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private CoffeeMat cm;

        [SetUp]
        public void Setup()
        {
            cm = new CoffeeMat(1000, 5);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.Multiple(() =>
            {
                Assert.That(cm.WaterCapacity, Is.EqualTo(1000));
                Assert.That(cm.ButtonsCount, Is.EqualTo(5));
                Assert.That(cm.Income, Is.EqualTo(0));
            });
        }
        [Test]
        public void TestFillWhenFull()
        {
            cm.FillWaterTank();
            Assert.That(cm.FillWaterTank(), Is.EqualTo("Water tank is already full!"));
        }

        [Test]
        public void TestFillWater()
        {
            Assert.That(cm.FillWaterTank(), Is.EqualTo("Water tank is filled with 1000ml"));

        }

        [Test]
        public void TestAddDrinkSuccessfully()
        {

            Assert.Multiple(() =>
            {

                for (int i = 0; i < 5; i++)
                {
                    Assert.That(cm.AddDrink($"{i}", i + 2), Is.True);
                }
            });
        }

        [Test]
        public void TestMaxDrinkCapacity()
        {
            Assert.Multiple(() =>
            {

                for (int i = 0; i < 5; i++)
                {
                    Assert.That(cm.AddDrink($"{i}", i + 2), Is.True);
                }
                Assert.That(cm.AddDrink("cap", 3), Is.False);
            });
        }

        [Test]
        public void TextAddingExistingDrink()
        {
            cm.AddDrink("cap", 8);
            Assert.That(cm.AddDrink("cap", 5), Is.False);
        }

        [Test]
        public void TestBuyWhenLowWater()
        {
            Assert.That(cm.BuyDrink("cap"), Is.EqualTo("CoffeeMat is out of water!"));
        }

        [Test]
        public void TestBuyNonExistingDrink()
        {
            cm.FillWaterTank();

            cm.AddDrink("decaf", 8);
            Assert.That(cm.BuyDrink("cap"), Is.EqualTo("cap is not available!"));
        }

        [Test]
        public void TestBuyDrinkSuccessfully()
        {
            cm.FillWaterTank();
            cm.AddDrink("cap", 8);

            cm.AddDrink("decaf", 6);
            Assert.That(cm.BuyDrink("cap"), Is.EqualTo("Your bill is 8.00$"));
        }

        [Test]
        public void TestCorrectWaterDecreaase()
        {
            cm.FillWaterTank();
            cm.AddDrink("cap", 8);
            Assert.Multiple(() =>
            {
                for (int i = 0; i < 12; i++)
                {
                    Assert.That(cm.BuyDrink("cap"), Is.EqualTo("Your bill is 8.00$"));
                }
                Assert.That(cm.BuyDrink("cap"), Is.EqualTo("CoffeeMat is out of water!"));

            });
        }

        [Test]
        public void TestCorrectIncomeDecrease()
        {
            cm.FillWaterTank();
            cm.AddDrink("cap", 8);
            double income = 0;
            Assert.Multiple(() =>
            {
                for (int i = 0; i < 12; i++)
                {
                    cm.BuyDrink("cap");
                    income += 8;
                    Assert.That(cm.Income, Is.EqualTo(income));
                }

            });
        }
        [Test]
        public void TestCollectIncome()
        {
            TestCorrectWaterDecreaase();
            Assert.That(cm.CollectIncome(), Is.EqualTo(12 * 8));
            Assert.That(cm.Income, Is.EqualTo(0));
            Assert.That(cm.CollectIncome(), Is.EqualTo(0));
        }

    }
}