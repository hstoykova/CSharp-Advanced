using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]

        public void SetUp()
        {
            axe = new Axe(3, 2);
            dummy = new Dummy(5, 2);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            var healthBefore = dummy.Health;
            dummy.TakeAttack(axe.AttackPoints);
            var healthAfter = dummy.Health;

            Assert.That(healthAfter, Is.LessThan(healthBefore));
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Dummy dummy = new(0, 5);
            Assert.IsTrue(dummy.IsDead());
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(axe.AttackPoints);
            });
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new(0, 5);
            Assert.IsTrue(dummy.IsDead());
            Assert.AreEqual(dummy.GiveExperience(), 5);
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Assert.IsFalse(dummy.IsDead());
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}