using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RecourceCloud.Tests
{
    public class Tests
    {
        public DepartmentCloud dc;

        [SetUp]
        public void Setup()
        {
            dc = new DepartmentCloud();
        }

        [Test]
        public void TestConstructor()
        {
            Assert.Multiple(() =>
            {
                Assert.That(dc.Tasks, Is.Not.Null);
                Assert.That(dc.Resources, Is.Not.Null);
                Assert.That(dc.Tasks, Is.Empty);
                Assert.That(dc.Resources, Is.Empty);
            });
        }

        [Test]
        [TestCase("a", "b", null)]
        [TestCase("a", null, "b")]
        [TestCase(null, "a", "b")]
        public void TestLogTaskWithNullArguments(params string[] args)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                dc.LogTask(args);
            }, "Arguments values cannot be null.");
        }

        [Test]
        [TestCase()]
        [TestCase("a")]
        [TestCase("a", "b")]
        [TestCase("a", "b", "c", "d")]
        public void TestLogTaskWithBadArguments(params string[] args)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                dc.LogTask(args);
            }, "All arguments are required.");
        }

        [Test]
        public void TestLogTaskWithExistingTask()
        {
            dc.LogTask(new string[] { "2", "a", "name" });
            string ret = dc.LogTask(new string[] { "4", "b", "name" });
            Assert.Multiple(() =>
            {
                Assert.That(ret, Is.EqualTo("name is already logged."));
                Assert.That(dc.Tasks, Has.Count.EqualTo(1));
            });
        }
        [Test]
        public void TestLogTaskWorksSuccessfully()
        {
            string ret = dc.LogTask(new string[] { "2", "a", "name" });
            Task task = dc.Tasks.First();
            Assert.Multiple(() =>
            {
                Assert.That(ret, Is.EqualTo("Task logged successfully."));
                Assert.That(task.Label, Is.EqualTo("a"));
                Assert.That(task.ResourceName, Is.EqualTo("name"));
                Assert.That(task.Priority, Is.EqualTo(2));
                Assert.That(dc.Tasks, Has.Count.EqualTo(1));
            });
        }
        [Test]
        public void TestCreateResourceFromEmptyTaskList()
        {
            bool ret = dc.CreateResource();
            Assert.That(ret, Is.False);
        }
        [Test]
        public void TestCreateResource()
        {
            dc.LogTask(new string[] { "2", "a", "name" });
            bool ret = dc.CreateResource();
            Assert.Multiple(() =>
            {
                Assert.That(ret, Is.True);
                Resource r = new Resource("name", "a");
                Assert.That(dc.Resources, Has.Count.EqualTo(1));
                Assert.That(dc.Resources.First().Name, Is.EqualTo(r.Name));
                Assert.That(dc.Resources.First().ResourceType, Is.EqualTo(r.ResourceType));
                Assert.That(r.IsTested, Is.False);
            });
        }


        [Test]
        public void TestResourceTesterWithMissingResource()
        {
            Resource? r = dc.TestResource("blah");
            Assert.That(r, Is.Null);
        }

        [Test]
        public void TestResourceTester()
        {
            dc.LogTask(new string[] { "2", "a", "name" });
            bool ret = dc.CreateResource();
            Resource? r = dc.TestResource("name");
            Assert.Multiple(() =>
            {
                Assert.That(ret, Is.True);
                Assert.That(r, Is.Not.Null);
                Assert.That(r.IsTested, Is.True);
            });
        }

        [Test]
        public void TestResourceTester()
        {
            dc.LogTask(new string[] { "2", "a", "name" });
            bool ret = dc.CreateResource();
            Assert.Multiple(() =>
            {
                Assert.That(ret, Is.True);
                Resource? r = dc.TestResource("name");
                Assert.That(r, Is.Not.Null);
                Assert.That(r.Name, Is.EqualTo("name"));
                Assert.That(r.IsTested, Is.EqualTo(true));
            });
        }

        [Test]
        public void TestResourceCreatorFromHighestPriority()
        {
            dc.LogTask(new string[] { "2", "a", "name" });
            dc.LogTask(new string[] { "1", "b", "dog" });
            bool ret = dc.CreateResource();
            Assert.Multiple(() =>
            {
                Assert.That(dc.Resources, Has.Count.EqualTo(1));
                Assert.That(dc.Tasks, Has.Count.EqualTo(1));
                Assert.That(dc.Resources.First().Name, Is.EqualTo("dog"));
                Assert.That(dc.Tasks.First().ResourceName, Is.EqualTo("name"));
                Assert.That(dc.Resources.First().ResourceType, Is.EqualTo("b"));
            });
        }


    }
}