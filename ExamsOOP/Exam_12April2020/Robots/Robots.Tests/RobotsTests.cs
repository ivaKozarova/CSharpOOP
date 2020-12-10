namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;
       
        [SetUp]
        public void Setup()
        {
            this.robot = new Robot("Pesho", 100);
            this.robotManager = new RobotManager(10);
            

        }

        [Test]
        public void DoesConstructorWorkCorrect()
        {
            Assert.AreEqual("Pesho", robot.Name);
            Assert.AreEqual(100, this.robot.MaximumBattery);
            Assert.AreEqual(100, this.robot.Battery);
        }

        [Test]
        public void DoesRobotManagerWorkCorrect()
        {
            Assert.AreEqual(10, this.robotManager.Capacity);
        }

        [Test]
        public void DoesNegativeCapacityThrowException()        
        {
            Assert.Throws<ArgumentException>(() =>
              {
                  robotManager = new RobotManager(-5);
              });
        }

        [Test]
        public void DoesCountReturnCountOfRobots()
        {
            var expected = 0;
            var actual = this.robotManager.Count;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DoesAddIncreaceCountOfRobots()
        {
            var expected = 2;
            this.robotManager.Add(new Robot("Test", 20));
            this.robotManager.Add(robot);

            Assert.AreEqual(expected, this.robotManager.Count);
        }

        [Test]
        public void DoesAddThrowExceptionIfTryToAddRobotWithSameName()
        {
            this.robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(()=>
            {
                this.robotManager.Add(robot);
               
            });
        }
        [Test]
        public void DoesAddThrowExceptionIfWeTryToAddMoreRobotsThanCapacity()
        {
            var robots = new RobotManager(2);
            robots.Add(this.robot);
            robots.Add(new Robot("test", 20));

            Assert.Throws<InvalidOperationException>(() =>
            {
                robots.Add(new Robot("Pip", 20));
            });
        }
        [Test]
        public void DoeRemoveDecreaseCountOfRobots()
        {
            this.robotManager.Add(robot);
            this.robotManager.Add(new Robot("mars", 50));

            var expected = 1;

            this.robotManager.Remove("mars");
            Assert.AreEqual(expected, this.robotManager.Count);
        }

        [Test]
        public void DoesRemoveThrowExceptionIfTryToRemoveNoExistingRobot()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Remove(null);
            });
        }
        [Test]
        public void DoesWorkThrowExceptionIfRobotbatteryIsNotEnough()
        {
            Robot robot = new Robot("Tester", 20);
            this.robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
                {
                    this.robotManager.Work("Tester", "Clean", 50);
                });
        }

        [Test]
        public void DoesWorkThrowExceptionIfRobotIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Work("Noname", "Clean", 100);
            });
        }
        [Test]
        public void DoesWorkCommandIsWorkingCorrect()
        {
            var expectedResult = this.robot.Battery - 20;
            this.robotManager.Add(robot);
            this.robotManager.Work("Pesho", "Clean", 20);

            Assert.AreEqual(expectedResult, this.robot.Battery);
        }

        [Test]
        public void DoesChargeThrowExceptionIfRobotNameIsNotFound()
        {
            this.robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Charge("Gosho");
            });
        }
        [Test]
        public void DoesChargeIncreaseRobotBatteryToMaxWhenWorksCorrect()
        {
            this.robotManager.Add(robot);
            this.robotManager.Work("Pesho", "Clean", 50);

            var expected = 100;

            this.robotManager.Charge("Pesho");

            Assert.AreEqual(expected, this.robot.Battery);
        }
    }
}
