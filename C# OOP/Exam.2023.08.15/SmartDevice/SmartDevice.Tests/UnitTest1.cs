namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection.Emit;
    using System.Text;

    public class Tests
    {
        private Device dev;

        [SetUp]
        public void Setup()
        {
            dev = new Device(1000);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.Multiple(() =>
            {
                Assert.That(dev, Is.Not.Null);
                Assert.That(dev.MemoryCapacity, Is.EqualTo(1000));
                Assert.That(dev.AvailableMemory, Is.EqualTo(1000));
                Assert.That(dev.Photos, Is.EqualTo(0));
                Assert.That(dev.Applications, Is.Not.Null);
                Assert.That(dev.Applications, Has.Count.EqualTo(0));
            }
            );
        }

        [Test]
        public void TestTakeLargePhoto()
        {
            Assert.That(dev.TakePhoto(5000), Is.False);
        }

        [Test]
        public void TestTakeSmallPhoto()
        {
            Assert.Multiple(() =>
            {
                Assert.That(dev.TakePhoto(400), Is.True);
                Assert.That(dev.Photos, Is.EqualTo(1));
                Assert.That(dev.AvailableMemory, Is.EqualTo(600));
            });
        }
        [Test]
        public void TestInstallingBigApp()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dev.InstallApp("app", 5000);
            }, "Not enough available memory to install the app.");
        }

        [Test]
        public void TestInstallSmallApp()
        {
            Assert.Multiple(() =>
            {
                Assert.That(dev.InstallApp("app", 300), Is.EqualTo("app is installed successfully. Run application?"));
                Assert.That(dev.Applications, Has.Count.EqualTo(1));
                Assert.That(dev.AvailableMemory, Is.EqualTo(700));
                Assert.That(dev.Applications.First(), Is.EqualTo("app"));
            }
            );
        }

        [Test]
        public void TestFormatDevice()
        {
            dev.FormatDevice();
            Assert.Multiple(() =>
            {
                Assert.That(dev.Photos, Is.EqualTo(0));
                Assert.That(dev.Applications, Is.Not.Null);
                Assert.That(dev.Applications, Is.Empty);
                Assert.That(dev.AvailableMemory, Is.EqualTo(dev.MemoryCapacity));
                Assert.That(dev.MemoryCapacity, Is.EqualTo(1000));
            });
        }

        [Test]
        [TestCase("app")]
        [TestCase("app", "ppa")]
        [TestCase(null)]
        public void TestDeviceStatus(params string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    dev.TakePhoto(50);
                }
                TestDeviceStatusWithPhotos(i, args);
                TestFormatDevice();
            }
        }

        private void TestDeviceStatusWithPhotos(int photoCount, params string[] args)
        {
            int am = 1000, ct = 0;

            foreach (string s in args)
            {
                dev.InstallApp(s, 150);
                am -= 150;
                ct++;
            }

            string apps = args == null ? "" : string.Join(", ", args);
            am -= 50 * photoCount;
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Memory Capacity: 1000 MB, Available Memory: {am} MB");
            stringBuilder.AppendLine($"Photos Count: {photoCount}");
            stringBuilder.AppendLine($"Applications Installed: {apps}");
            Assert.That(dev.GetDeviceStatus(), Is.EqualTo(stringBuilder.ToString().TrimEnd()));
        }


    }
}
