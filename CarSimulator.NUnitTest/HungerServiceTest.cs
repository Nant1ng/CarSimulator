using Moq;
using SimulatorLibrary.Interfaces;

namespace CarSimulator.NUnitTest
{
    [TestFixture]
    public class HungerServiceTest
    {
        private Mock<IHunger> _mockHunger;
        private int _hungerLevel;

        [SetUp]
        public void Setup()
        {
            _mockHunger = new Mock<IHunger>();
            _hungerLevel = 0;
        }
        private void PerformAction()
        {
            _hungerLevel += 2;
        }
        private void Eat()
        {
            _hungerLevel = 0;
        }

        [Test]
        public void Test_Hunger_Full()
        {
            // Arrange
            _hungerLevel = 5;
            _mockHunger.Setup(h => h.GetHungerStatus(It.IsAny<int>()))
                .Returns((int hungerLevel) => hungerLevel <= 5 ? HungerStatus.Full
                : (hungerLevel <= 10 ? HungerStatus.Hungry : HungerStatus.Starving));
            var expected = HungerStatus.Full;

            // Act 
            var result = _mockHunger.Object.GetHungerStatus(_hungerLevel);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Hunger_Hungry()
        {
            // Arrange
            _hungerLevel = 10;
            _mockHunger.Setup(h => h.GetHungerStatus(It.IsAny<int>()))
                .Returns((int hungerLevel) => hungerLevel <= 5 ? HungerStatus.Full
                : (hungerLevel <= 10 ? HungerStatus.Hungry : HungerStatus.Starving));
            var expected = HungerStatus.Hungry;

            // Act 
            var result = _mockHunger.Object.GetHungerStatus(_hungerLevel);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Hunger_Starving()
        {
            // Arrange
            _hungerLevel = 15;
            _mockHunger.Setup(h => h.GetHungerStatus(It.IsAny<int>()))
                .Returns((int hungerLevel) => hungerLevel <= 5 ? HungerStatus.Full
                : (hungerLevel <= 10 ? HungerStatus.Hungry : HungerStatus.Starving));
            var expected = HungerStatus.Starving;

            // Act 
            var result = _mockHunger.Object.GetHungerStatus(_hungerLevel);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Perform_Action_Increases_Hunger_Level()
        {
            // Arrange 
            var expected = 2;

            // Act
            PerformAction();
            var result = _hungerLevel;

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Eat_Resets_Hunger_Level()
        {
            // Arrange
            _hungerLevel = 15;
            var expected = 0;

            // Act
            Eat();
            var result = _hungerLevel;

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Perform_Action_Increases_Hunger_To_Hungry()
        {
            // Arrange
            _hungerLevel = 4;
            _mockHunger.Setup(hs => hs.GetHungerStatus(It.IsAny<int>()))
                .Returns((int hungerLevel) => hungerLevel <= 5 ? HungerStatus.Full : (hungerLevel <= 10 ? HungerStatus.Hungry : HungerStatus.Starving));
            var expected = HungerStatus.Hungry;

            // Act
            PerformAction();
            var result = _mockHunger.Object.GetHungerStatus(_hungerLevel);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Perform_Action_Increases_Hunger_To_Starving()
        {
            // Arrange
            _hungerLevel = 10;
            _mockHunger.Setup(hs => hs.GetHungerStatus(It.IsAny<int>()))
                .Returns((int hungerLevel) => hungerLevel <= 5 ? HungerStatus.Full : (hungerLevel <= 10 ? HungerStatus.Hungry : HungerStatus.Starving));
            var expected = HungerStatus.Starving;

            // Act
            PerformAction();
            var result = _mockHunger.Object.GetHungerStatus(_hungerLevel);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Eat_Resets_Hunger_To_Full()
        {
            // Arrange
            _hungerLevel = 15;
            _mockHunger.Setup(hs => hs.GetHungerStatus(It.IsAny<int>()))
                .Returns((int hungerLevel) => hungerLevel <= 5 ? HungerStatus.Full : (hungerLevel <= 10 ? HungerStatus.Hungry : HungerStatus.Starving));
            var expected = HungerStatus.Full;

            // Act
            Eat();
            var result = _mockHunger.Object.GetHungerStatus(_hungerLevel);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_HungerService_GameOver()
        {
            // Arrange
            _hungerLevel = 16;
            _mockHunger.Setup(hs => hs.GetHungerStatus(It.IsAny<int>()))
                .Returns((int hungerLevel) => hungerLevel <= 5 ? HungerStatus.Full : (hungerLevel <= 10 ? HungerStatus.Hungry : HungerStatus.Starving));

            // Act
            var result = _mockHunger.Object.GetHungerStatus(_hungerLevel);

            // Assert
            Assert.IsTrue(_hungerLevel >= 16, "Game Over: Driver died of starvation");
        }
    }
}
