namespace Constructing_A_Car
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    #region Tests

    [TestFixture]
    public class Car1ExampleTests
    {
        [Test]
        public void TestMotorStartAndStop()
        {
            var car = new Car();

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");

            car.EngineStart();

            Assert.IsTrue(car.EngineIsRunning, "Engine should be running.");

            car.EngineStop();

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");
        }

        [Test]
        public void TestFuelConsumptionOnIdle()
        {
            var car = new Car(1);

            car.EngineStart();

            Enumerable.Range(0, 3000).ToList().ForEach(s => car.RunningIdle());

            Assert.AreEqual(0.10, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }

        [Test]
        public void TestFuelTankDisplayIsComplete()
        {
            var car = new Car(60);

            Assert.IsTrue(car.fuelTankDisplay.IsComplete, "Fuel tank must be complete!");
        }

        [Test]
        public void TestFuelTankDisplayIsOnReserve()
        {
            var car = new Car(4);

            Assert.IsTrue(car.fuelTankDisplay.IsOnReserve, "Fuel tank must be on reserve!");
        }

        [Test]
        public void TestRefuel()
        {
            var car = new Car(5);

            car.Refuel(40);

            Assert.AreEqual(45, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }



    }

    #endregion

    #region TestMotorAndFuel

    [TestFixture]
    public class TestMotorAndFuel
    {
        [Test]
        public void TestMotorStartAndStop()
        {
            var car = new Car();

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");

            car.EngineStart();

            Assert.IsTrue(car.EngineIsRunning, "Engine should be running.");

            car.EngineStop();

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");
        }

        [Test]
        public void TestFuelConsumptionOnIdle()
        {
            var car = new Car(1);

            car.EngineStart();

            Enumerable.Range(0, 3000).ToList().ForEach(s => car.RunningIdle());

            Assert.AreEqual(0.10, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }

        [Test]
        public void TestFuelTankDisplayIsComplete()
        {
            var car = new Car(60);

            Assert.IsTrue(car.fuelTankDisplay.IsComplete, "Fuel tank must be complete!");
        }

        [Test]

        public void TestFuelTankDisplayIsOnReserve()
        {
            var car = new Car(4);

            Assert.IsTrue(car.fuelTankDisplay.IsOnReserve, "Fuel tank must be on reserve!");
        }

        [Test]
        public void TestRefuel()
        {
            var car = new Car(5);

            car.Refuel(40);

            Assert.AreEqual(45, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }

        [Test]
        public void TestMotorStartAgainAndStopAgain()
        {
            var car = new Car();

            car.EngineStart();

            car.EngineStart();

            Assert.IsTrue(car.EngineIsRunning, "Engine should be running.");

            car.EngineStop();

            car.EngineStop();

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");
        }

        [Test]
        public void TestMotorDoesntStartWithEmptyFuelTank()
        {
            var car = new Car(0);

            car.EngineStart();

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");
        }

        [Test]
        public void TestEngineStopsCauseOfNoFuelExactly()
        {
            var car = new Car(6);

            car.EngineStart();

            Enumerable.Range(0, 20000).ToList().ForEach(s => car.RunningIdle());

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");
        }

        [Test]
        public void TestEngineStopsCauseOfNoFuelOver()
        {
            var car = new Car(1);

            car.EngineStart();

            Enumerable.Range(0, 10000).ToList().ForEach(s => car.RunningIdle());

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");
        }

        [Test]
        public void TestNoConsumptionWhenEngineNotRunning()
        {
            var car = new Car(1);

            Enumerable.Range(0, 1000).ToList().ForEach(s => car.RunningIdle());

            Assert.AreEqual(1, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }

        [Test]
        public void TestFuelTankDisplayIsNotComplete()
        {
            var car = new Car();

            Assert.IsFalse(car.fuelTankDisplay.IsComplete, "Fuel tank must be not complete!");
        }

        [Test]
        public void TestFuelTankDisplayIsNotOnReserve()
        {
            var car = new Car();

            Assert.IsFalse(car.fuelTankDisplay.IsOnReserve, "Fuel tank must be not on reserve!");
        }

        [Test]
        public void TestRefuelOverMaximum()
        {
            var car = new Car(5);

            car.Refuel(80);

            Assert.AreEqual(60, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }

        [Test]
        public void TestNoNegativeFuelLevelAllowed()
        {
            var car = new Car(-5);

            Assert.AreEqual(0, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }

        [Test]
        public void TestFuelLevelAllowedUpTo60()
        {
            var car = new Car(65);

            Assert.AreEqual(60, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }

        [Test]
        public void Car1RandomTests()
        {
            var rand = new Random();

            for (int i = 0; i < 20; i++)
            {
                var car1 = new Car(5);

                var refuelLiter = rand.Next(60);

                car1.Refuel(refuelLiter);

                double expectedFuelLevel = Math.Min(5 + refuelLiter, 60);
                Assert.AreEqual(expectedFuelLevel, car1.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");

                var car2 = new Car(5);
                car2.EngineStart();

                var runningIdleSeconds = rand.Next(7);

                Enumerable.Range(0, runningIdleSeconds * 10001 / 3).ToList().ForEach(s => { car2.RunningIdle(); });

                expectedFuelLevel = Math.Max(5 - runningIdleSeconds, 0);

                Assert.AreEqual(expectedFuelLevel, car2.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
                if (expectedFuelLevel == 0)
                {
                    Assert.IsFalse(car2.EngineIsRunning, "Engine could not be running.");
                }
            }
        }
    }

    #endregion

    #region Solution    using System;
    public class Car : ICar
    {
        public IFuelTankDisplay fuelTankDisplay;
        private IEngine engine;
        private IFuelTank fuelTank;

        public Car()
        {
            fuelTank = new FuelTank(20);
            engine = new Engine(fuelTank);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine.Stop();
        }
        public Car(double fillLevel)
        {
            fuelTank = new FuelTank(fillLevel);
            engine = new Engine(fuelTank);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine.Stop();
        }
        public bool EngineIsRunning => engine.IsRunning;
        public void EngineStart() => engine.Start();
        public void EngineStop() => engine.Stop();
        public void Refuel(double liters) => fuelTank.Refuel(liters);
        public void RunningIdle() => engine.Consume(0.0003);
    }

    public class Engine : IEngine
    {
        private IFuelTank fuelTank;
        public Engine(IFuelTank fuelTank) => this.fuelTank = fuelTank;

        public bool running;
        public bool IsRunning => running;

        public void Consume(double liters)
        {
            if (running) fuelTank.Consume(liters);
            running &= fuelTank.FillLevel > 0;
        }
        public void Start() => running = fuelTank.FillLevel > 0;
        public void Stop() => running = false;
    }

    public class FuelTank : IFuelTank
    {
        private double level = 0;
        public double FillLevel => level;
        public bool IsOnReserve => level < 5;
        public bool IsComplete => level == 60;

        public FuelTank(double fillLevel)
        {
            level = fillLevel;
            if (level < 0) level = 0;
            if (level > 60) level = 60;
        }
        public void Consume(double liters)
        {
            level = Math.Round(level - liters, 10);
            if (level < 0) level = 0;
        }
        public void Refuel(double liters)
        {
            level += liters;
            if (level > 60) level = 60;
        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        private IFuelTank fuelTank;
        public FuelTankDisplay(IFuelTank fuelTank) => this.fuelTank = fuelTank;

        public double FillLevel => Math.Round(fuelTank.FillLevel, 2);
        public bool IsOnReserve => fuelTank.IsOnReserve;
        public bool IsComplete => fuelTank.IsComplete;
    }
    #endregion

    #region Interface

    public interface ICar
    {
        bool EngineIsRunning { get; }

        void EngineStart();

        void EngineStop();

        void Refuel(double liters);

        void RunningIdle();
    }

    public interface IEngine
    {
        bool IsRunning { get; }

        void Consume(double liters);

        void Start();

        void Stop();
    }

    public interface IFuelTank
    {
        double FillLevel { get; }

        bool IsOnReserve { get; }

        bool IsComplete { get; }

        void Consume(double liters);

        void Refuel(double liters);
    }

    public interface IFuelTankDisplay
    {
        double FillLevel { get; }

        bool IsOnReserve { get; }

        bool IsComplete { get; }
    }

    #endregion

}
