namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class DatabaseTests
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void TestCapacity()
        {
            Database database = new Database(2, 4, 7);
            var type = database.GetType();
            var field = type.GetField("data", BindingFlags.NonPublic | BindingFlags.Instance);
            var data = field.GetValue(database);
            Assert.That(data.GetType().IsInstanceOfType(new int[16]));
            Assert.That(((int[])data).Length == 16);
        }
        [Test]
        public void TestAdditionWhenSpaceIsNotAvailable()
        {
            Database db = new Database(1);
            for (int i = 0; i < 15; i++)
                db.Add(1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(1);
            }, "Array's capacity must be exactly 16 integers!");
            
        }

        [Test]
        public void TestStackPushLikeStructure()
        {
            Database db = new Database(1);
            int[] arr = new int[16];
            arr[0] = 1;
            for (int i = 2; i < 17; i++)
            {
                arr[i - 1] = i;
                db.Add(i);
            }
            Assert.That(db.GetType().GetField("data", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(db), Is.EqualTo(arr));
        }
        
        [Test]
        public void TestRemovalFromEmptyDatabase()
        {
            Database db = new Database(1);
            db.Remove();
            Assert.Throws<InvalidOperationException>( () =>
            {
                db.Remove();
            });
        }

        [Test]

        public void TestStackPopLikeStructure()
        {
            Database db = new Database(1, 2, 3, 4);
            db.Remove();
            db.Remove();
            Assert.That(db.Fetch(), Is.EqualTo(new int[] { 1, 2 }));
        }

        [Test]
        public void TestConstructorOnlyTakesOnIntegers()
        {
            //Assert.Throws<>
        }

        [Test]
        public void TestFetchReturnsArray()
        {
            Assert.That(new Database(1, 2).Fetch(), Is.InstanceOf<int[]>());
        }

        [Test]
        public void TestCount()
        {
            Database db = new Database(1);

            for (int i = 1; i < 16; i++)
            {
                db.Add(i);
                Assert.That(db.Count == i + 1);
            }

           
        }
    }
}
