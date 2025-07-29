using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework.Internal;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private InfluencerRepository repo;
        private Influencer influencer1;
        [SetUp]
        public void Setup()
        {
            repo = new InfluencerRepository();
            influencer1 = new Influencer("Name", 7);
        }

        [Test]
        public void Constructor()
        {
            Assert.Multiple(() =>
            {
                Assert.That(repo.Influencers, Is.Not.Null);
                Assert.That(repo.Influencers, Has.Count.EqualTo(0));
            });
        }

        [Test]
        public void TestRegisteringNullInfluencer()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                repo.RegisterInfluencer(null);
            }, "Influencer is null");
        }

        [Test]
        public void TestRegisteringDuplicateInfluencer()
        {
            repo.RegisterInfluencer(influencer1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                repo.RegisterInfluencer(influencer1);
            }, "Influencer with username Name already exists");
        }

        [Test]
        public void TestRegisteringInfluencersSuccessfully()
        {
            string result = repo.RegisterInfluencer(influencer1);
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo($"Successfully added influencer {influencer1.Username} with {influencer1.Followers}"));
                Assert.That(repo.Influencers, Has.Count.EqualTo(1));
                Influencer influencer = repo.GetInfluencer("Name");
                Assert.That(influencer.Username, Is.EqualTo(influencer1.Username));
                Assert.That(influencer.Followers, Is.EqualTo(influencer1.Followers));
            });
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        [TestCase(null)]
        public void TestRemovingInvalidUsername(string arg)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                repo.RemoveInfluencer(arg);
            }, "Username cannot be null");
        }

        [Test]
        public void TestRemovingCorrectUsername()
        {
            repo.RegisterInfluencer(influencer1);
            repo.RegisterInfluencer(new Influencer("Fake", 6));
            bool result = repo.RemoveInfluencer(influencer1.Username);
            
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repo.Influencers, Has.Count.EqualTo(1));
                Influencer influencer = repo.GetInfluencer("Fake");
                Assert.That(influencer.Username, Is.EqualTo("Fake"));
                Assert.That(influencer.Followers, Is.EqualTo(6));
                Assert.That(repo.Influencers.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void TestGetInfluencerWithMostFollowers()
        {
            repo.RegisterInfluencer(influencer1);
            repo.RegisterInfluencer(new Influencer("Fake", 6));
            Influencer influencer = repo.GetInfluencerWithMostFollowers();
            Assert.That(influencer.Username, Is.EqualTo("Name"));
        }

        [Test]
        public void TestGetInfluencer()
        {
            repo.RegisterInfluencer(influencer1);
            repo.RegisterInfluencer(new Influencer("Fake", 6));
            Influencer influencer = repo.GetInfluencer("Fake");
            Assert.That(influencer.Username, Is.EqualTo("Fake"));
            Assert.That(influencer.Followers, Is.EqualTo(6));
        }

    }
}