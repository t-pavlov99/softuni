namespace Television.Tests
{
    using System;
    using System.Security.Cryptography;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice tv;

        [SetUp]
        public void Setup()
        {
            tv = new TelevisionDevice("LG", 1000.00, 60, 40);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.Multiple(() =>
            {
                Assert.That(tv.Brand, Is.EqualTo("LG"));
                Assert.That(tv.Price, Is.EqualTo(1000.00));
                Assert.That(tv.ScreenWidth, Is.EqualTo(60));
                Assert.That(tv.ScreenHeigth, Is.EqualTo(40));
                Assert.That(tv.CurrentChannel, Is.EqualTo(0));
                Assert.That(tv.Volume, Is.EqualTo(13));
                Assert.That(tv.IsMuted, Is.False);
            }
            );
        }

        [Test]
        public void TestSwitchOn()
        {
            Assert.That(tv.SwitchOn(), Is.EqualTo("Cahnnel 0 - Volume 13 - Sound On"));
        }

        [Test]
        public void TestChangeInvalidChannel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                tv.ChangeChannel(-5);
            }, "Invalid key!");
        }

        [Test]
        public void TestChangeValidChannel()
        {
            tv.ChangeChannel(8);
            Assert.That(tv.CurrentChannel, Is.EqualTo(8));
        }

        [Test]
        public void TestVolumeUp()
        {
            tv.VolumeChange("UP", 5);
            Assert.That(tv.Volume, Is.EqualTo(18));
        }

        [Test]
        public void TestVolumeDown()
        {
            tv.VolumeChange("DOWN", 6);
            Assert.That(tv.Volume, Is.EqualTo(7));
        }

        [Test]
        public void TestVolumeChangeMessage()
        {
            string result = tv.VolumeChange("UP", 5);
            Assert.That(result, Is.EqualTo("Volume: 18"));
            result = tv.VolumeChange("DOWN", 6);
            Assert.That(result, Is.EqualTo("Volume: 12"));
        }

        [Test]
        public void TestBigVolumeChange()
        {
            tv.VolumeChange("UP", 500);
            Assert.That(tv.Volume, Is.EqualTo(100));
            tv.VolumeChange("DOWN", 5000);
            Assert.That(tv.Volume, Is.EqualTo(0));
        }
        [Test]
        public void TestMuteWhenMuted()
        {

            tv.MuteDevice();
            Assert.That(tv.IsMuted, Is.True);
        }

        [Test]
        public void TestMuteWhenNotMuted()
        {
            tv.MuteDevice();
            tv.MuteDevice();
            Assert.That(tv.IsMuted, Is.False);

        }

        [Test]
        public void TestToString()
        {
            Assert.That(tv.ToString(), Is.EqualTo("TV Device: LG, Screen Resolution: 60x40, Price 1000$"));
        }


    }
}