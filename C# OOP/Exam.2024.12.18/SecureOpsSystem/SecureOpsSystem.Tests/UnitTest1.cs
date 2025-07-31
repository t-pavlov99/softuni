using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace SecureOpsSystem.Tests
{
    [TestFixture]
    public class SecureHubTests
    {
        private SecureHub sh;
        private List<SecurityTool> tools = new List<SecurityTool>();

        [SetUp]
        public void Setup()
        {
            sh = new SecureHub(10);
            for (int i = 0; i < 20; i++)
            {
                tools.Add(new SecurityTool($"tool{i}", $"cat{i}", i + 4));
            }
        }

        [Test]
        public void TestConstructor()
        {
            Assert.That(sh.Capacity, Is.EqualTo(10));
            Assert.That(sh.Tools, Is.Not.Null);
            Assert.That(sh.Tools.Count, Is.EqualTo(0));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void TestNegativeCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                SecureHub s = new SecureHub(capacity);
            }, "Capacity must be greater than 0.");
        }

        [Test]
        public void TestAddingToolSuccessfully()
        {
            for (int i = 0; i < 5; i++)
            {

                Assert.That(sh.AddTool(tools[i]), Is.EqualTo($"Security Tool {tools[i].Name} added successfully."));
                Assert.That(sh.Tools, Has.Count.EqualTo(1+i));
                Assert.That(sh.Tools.Last(), Is.EqualTo(tools[i]));
            }
        }

        [Test]
        public void TestAddingOverLimit()
        {
            for (int i = 0; i < 10; i++)
            {
                Assert.That(sh.AddTool(tools[i]), Contains.Substring("successfully"));
            }
            Assert.That(sh.AddTool(tools[10]), Is.EqualTo("Secure Hub is at full capacity."));
            Assert.That(sh.Tools, Has.Count.EqualTo(10));
        }

        [Test]
        public void TestAddingExisting()
        {
            sh.AddTool(tools[0]);
            Assert.That(sh.AddTool(tools[0]), Is.EqualTo($"Security Tool {tools[0].Name} already exists in the hub."));
            Assert.That(sh.Tools, Has.Count.EqualTo(1));
        }

        [Test]
        public void TestRemovingToolFromEmpty()
        {
            Assert.That(sh.RemoveTool(tools[0]), Is.False);
            Assert.That(sh.Tools, Has.Count.EqualTo(0));
        }

        [Test]
        public void TestRemovingNonExisting()
        {
            sh.AddTool(tools[0]);
            sh.AddTool(tools[1]);
            Assert.That(sh.RemoveTool(tools[2]), Is.False);
            Assert.That(sh.Tools, Has.Count.EqualTo(2));
            Assert.That(sh.Tools, Contains.Item(tools[0]));
            Assert.That(sh.Tools, Contains.Item(tools[1]));
        }

        [Test]
        public void TestRemovingItem()
        {
            sh.AddTool(tools[0]);
            sh.AddTool(tools[1]);
            Assert.That(sh.RemoveTool(tools[1]), Is.True);
            Assert.That(sh.Tools, Has.Count.EqualTo(1));
            Assert.That(sh.Tools, Contains.Item(tools[0]));
        }

        [Test]
        public void TestDeployFromEmpty()
        {

            Assert.That(sh.DeployTool(tools[1].Name), Is.Null);
            Assert.That(sh.Tools, Has.Count.EqualTo(0));
        }

        [Test]
        public void TestDeployNonExisting()
        {
            sh.AddTool(tools[0]);
            Assert.That(sh.DeployTool(tools[1].Name), Is.Null);
            Assert.That(sh.Tools, Has.Count.EqualTo(1));
            Assert.That(sh.Tools, Contains.Item(tools[0]));
        }

        [Test]
        public void TestDeployExisting()
        {
            sh.AddTool(tools[0]);
            sh.AddTool(tools[1]);
            Assert.That(sh.DeployTool(tools[1].Name), Is.EqualTo(tools[1]));
            Assert.That(sh.Tools, Has.Count.EqualTo(1));
            Assert.That(sh.Tools, Contains.Item(tools[0]));
        }

        [Test]
        [TestCase(0)]
        [TestCase(2)]
        [TestCase(5)]
        public void TestSystemReport(int count)
        {
            for (int i = 0; i < count; i++)
            {
                sh.AddTool(tools[i]);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Secure Hub Report:");
            sb.AppendLine($"Available Tools: {count}");
            foreach (var tool in tools.Take(count).OrderByDescending(t => t.Effectiveness))
            {
                sb.AppendLine(tool.ToString());
            }

            Assert.That(sh.SystemReport(), Is.EqualTo(sb.ToString().TrimEnd()));
        }
    }
}
