using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorTest()
        {
            var repo = new InfluencerRepository();
            Assert.IsFalse(repo.Influencers.Any());
        }

        [Test]
        public void RegisterInfluencerTest1()
        {
            var repo = new InfluencerRepository();
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                repo.RegisterInfluencer(null);
            });
            Assert.AreEqual("Influencer is null (Parameter 'influencer')", ex.Message);
        }

        [Test]
        public void RegisterInfluencerTest2()
        {
            var repo = new InfluencerRepository();
            var influencer = new Influencer("Name", 10);
            var message = repo.RegisterInfluencer(influencer);

            Assert.AreEqual("Successfully added influencer Name with 10", message);
            Assert.AreEqual(1, repo.Influencers.Count);
        }

        [Test]
        public void RegisterInfluencerTest3()
        {
            var repo = new InfluencerRepository();
            var influencer = new Influencer("Name", 10);
            repo.RegisterInfluencer(influencer);

            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                repo.RegisterInfluencer(influencer);
            });
            Assert.AreEqual("Influencer with username Name already exists", ex.Message);
        }

        [Test]
        public void RemoveInfluencerTest1()
        {
            var repo = new InfluencerRepository();
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                repo.RemoveInfluencer(null);
            });
            Assert.AreEqual("Username cannot be null (Parameter 'username')", ex.Message);
        }

        [Test]
        public void RemoveInfluencerTest2()
        {
            var repo = new InfluencerRepository();
            Assert.IsFalse(repo.RemoveInfluencer("Name"));
        }

        [Test]
        public void RemoveInfluencerTest3()
        {
            var repo = new InfluencerRepository();
            var influencer = new Influencer("Name", 10);
            repo.RegisterInfluencer(influencer);
            
            Assert.IsTrue(repo.RemoveInfluencer("Name"));
        }

        [Test]
        public void GetInfluencerWithMostFollowersTest1()
        {
            var repo = new InfluencerRepository();
            var influencer = new Influencer("Name", 10);
            repo.RegisterInfluencer(influencer);
            var influencer02 = new Influencer("Name02", 20);
            repo.RegisterInfluencer(influencer02);
            var influencer03 = new Influencer("Name03", 30);
            repo.RegisterInfluencer(influencer03);

            Assert.AreSame(influencer03, repo.GetInfluencerWithMostFollowers());
        }

        [Test]
        public void GetInfluencerWithMostFollowersTest2()
        {
            var repo = new InfluencerRepository();
            // IndexOutOfRangeException
            //Assert.AreSame(influencer03, repo.GetInfluencerWithMostFollowers());
           //repo.GetInfluencerWithMostFollowers();

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                repo.GetInfluencerWithMostFollowers();
            });
        }

        [Test]
        public void GetInfluencerTest1()
        {
            var repo = new InfluencerRepository();
            var influencer = new Influencer("Name", 10);
            repo.RegisterInfluencer(influencer);

            Assert.AreSame(influencer, repo.GetInfluencer("Name"));
        }

        [Test]
        public void GetInfluencerTest2()
        {
            var repo = new InfluencerRepository();

            Assert.IsNull(repo.GetInfluencer("Name"));
        }

        [Test]
        public void GetInfluencerTest3()
        {
            var repo = new InfluencerRepository();

            Assert.IsNull(repo.GetInfluencer(null));
        }
    }
}