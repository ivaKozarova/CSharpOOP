using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar car;
        private UnitDriver unitDriver;
        private RaceEntry drivers;
        [SetUp]
        public void Setup()
        {
            this.car = new UnitCar("Porshe", 200, 120.5);
            this.unitDriver = new UnitDriver("Gosho", this.car);
            this.drivers = new RaceEntry();
        }

        [Test]
        public void DoesConstructorWorkCorrect()
        {
            RaceEntry drivers = new RaceEntry();

            Assert.IsNotNull(drivers);
        }
        [Test]
        public void AddShouldThrowExceptionIfDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
                {
                    this.drivers.AddDriver(null);
                });
        }
        [Test]
        public void AddSouldIncreaceCountWhenAddIsDone()
        {
            var expectedCount = 1;
            this.drivers.AddDriver(this.unitDriver);

            var actualCount = this.drivers.Counter;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void AddShouldThrowExceptionIfAddRacerWithSameNames()
        {
            this.drivers.AddDriver(this.unitDriver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.drivers.AddDriver(unitDriver);
            });
        }

        [Test]

        public void CalculateAverageHorsePowerShouldThrowExeptionIfCountOfDriversIsLessThanTwo()
        {
            this.drivers.AddDriver(this.unitDriver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.drivers.CalculateAverageHorsePower();
            });

        }
        [Test]
        public void DoesCalculateAverageHPWorkCorrect()
        {
            this.drivers.AddDriver(this.unitDriver);
            this.drivers.AddDriver(new UnitDriver("name", new UnitCar("model", 100, 25.5)));

            var expectedAverageHp = 150;

            var acrualResult = this.drivers.CalculateAverageHorsePower();

            Assert.AreEqual(expectedAverageHp, acrualResult);
        }
    }
   
}