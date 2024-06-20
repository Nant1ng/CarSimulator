using SimulatorLibrary.Services;

namespace CarSimulator.Test.Services
{
    [TestClass]
    public class DriverServiceTest
    {
        [TestMethod]
        public async Task Generate_Vaild_Random_Driver()
        {
            // Arrange
            var service = new DriverService();

            // Act
            var driver = await service.GetRandomDriver();

            // Assert 
            Assert.IsNotNull(driver);
            Assert.IsFalse(string.IsNullOrEmpty(driver.Title));
            Assert.IsFalse(string.IsNullOrEmpty(driver.Name));
            Assert.IsFalse(string.IsNullOrEmpty(driver.Gender));
        }
    }
}
