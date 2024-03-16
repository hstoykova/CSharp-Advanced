using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
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
        public void NewAxeShouldSetDataCorrectly()
        {
            Assert.AreEqual(axe.AttackPoints, 3);
            Assert.AreEqual(axe.DurabilityPoints, 2);
        }

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change");
        }

        [Test]
        public void AttackShouldDecreaseDurabilityPoints()
        {
            axe.Attack(dummy);

            Assert.AreEqual(axe.DurabilityPoints, 1);
        }

        [Test]
        public void AttackWithBrokenWeaponShouldThrowError()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() =>
                {
                    axe.Attack(dummy);
                });
        }

        [Test]
        public void AttackWithBNegativeDurabilityShouldThrowError()
        {
            axe = new Axe(5, -50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }

        [Test]
        public void AttackShouldCallTakeAttackOnTarget()
        {
            axe.Attack(dummy);

            Assert.AreEqual(dummy.Health, 2);
        }
    }
}