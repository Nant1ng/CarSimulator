using SimulatorLibrary.Interfaces;
using SimulatorLibrary.Services;

namespace CarSimulator.Test.Services
{
    [TestClass]
    public class DriveSimTest
    {
        private readonly IDriveSim _sut;

        public DriveSimTest()
        {
            _sut = new DriveSim();
        }

        [TestMethod]
        [DataRow(18, StatusCode.Ok)]
        [DataRow(17, StatusCode.Ok)]
        [DataRow(16, StatusCode.Ok)]
        [DataRow(15, StatusCode.Ok)]
        [DataRow(14, StatusCode.Ok)]
        [DataRow(13, StatusCode.Ok)]
        public void Test_Ok_Status_From_EvaluateTirednessLevel(int tired, StatusCode expected)
        {
            // Act
            StatusCode result = _sut.EvaluateTirednessLevel(tired);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(0, StatusCode.Ok)]
        [DataRow(1, StatusCode.Ok)]
        [DataRow(2, StatusCode.Ok)]
        [DataRow(3, StatusCode.Ok)]
        [DataRow(4, StatusCode.Ok)]
        [DataRow(5, StatusCode.Ok)]
        [DataRow(6, StatusCode.Ok)]
        public void Test_Not_Ok_Status_From_EvaluateTirednessLevel(int tired, StatusCode expected)
        {
            // Act
            StatusCode result = _sut.EvaluateTirednessLevel(tired);

            // Assert
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        [DataRow(12, StatusCode.Warning)]
        [DataRow(11, StatusCode.Warning)]
        [DataRow(10, StatusCode.Warning)]
        [DataRow(9, StatusCode.Warning)]
        [DataRow(8, StatusCode.Warning)]
        [DataRow(7, StatusCode.Warning)]
        [DataRow(6, StatusCode.Warning)]
        public void Test_Warning_Status_From_EvaluateTirednessLevel(int tired, StatusCode expected)
        {
            // Act
            StatusCode result = _sut.EvaluateTirednessLevel(tired);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(18, StatusCode.Warning)]
        [DataRow(17, StatusCode.Warning)]
        [DataRow(16, StatusCode.Warning)]
        [DataRow(15, StatusCode.Warning)]
        [DataRow(14, StatusCode.Warning)]
        [DataRow(13, StatusCode.Warning)]
        public void Test_Not_Warning_Status_From_EvaluateTirednessLevel(int tired, StatusCode expected)
        {
            // Act
            StatusCode result = _sut.EvaluateTirednessLevel(tired);

            // Assert
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        [DataRow(5, StatusCode.Error)]
        [DataRow(4, StatusCode.Error)]
        [DataRow(3, StatusCode.Error)]
        [DataRow(2, StatusCode.Error)]
        [DataRow(1, StatusCode.Error)]
        [DataRow(0, StatusCode.Error)]
        public void Test_Error_Status_From_EvaluateTirednessLevel(int tired, StatusCode expected)
        {
            // Act
            StatusCode result = _sut.EvaluateTirednessLevel(tired);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(18, StatusCode.Error)]
        [DataRow(17, StatusCode.Error)]
        [DataRow(16, StatusCode.Error)]
        [DataRow(15, StatusCode.Error)]
        [DataRow(14, StatusCode.Error)]
        [DataRow(13, StatusCode.Error)]
        public void Test_Not_Error_Status_From_EvaluateTirednessLevel(int tired, StatusCode expected)
        {
            // Act
            StatusCode result = _sut.EvaluateTirednessLevel(tired);

            // Assert
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void Test_Arrow_Up_From_UpdateArrowDirection()
        {
            // Arrange
            int currentDirection = 0;
            string expected = "↑";

            // Act
            string result = _sut.UpdateArrowDirection(currentDirection);

            // Act 
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_Arrow_Up_Is_Not_Right_From_UpdateArrowDirection()
        {
            // Arrange
            int currentDirection = 0;
            string expected = "→";

            // Act
            string result = _sut.UpdateArrowDirection(currentDirection);

            // Assert
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void Test_Arrow_Up_Is_Not_Down_From_UpdateArrowDirection()
        {
            // Arrange
            int currentDirection = 0;
            string expected = "↓";

            // Act
            string result = _sut.UpdateArrowDirection(currentDirection);

            // Assert
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void Test_Arrow_Up_Is_Not_Left_From_UpdateArrowDirection()
        {
            // Arrange
            int currentDirection = 0;
            string expected = "←";

            // Act
            string result = _sut.UpdateArrowDirection(currentDirection);

            // Assert
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void Test_Arrow_Right_From_UpdateArrowDirection()
        {
            // Arrange
            int currentDirection = 1;
            string expected = "→";

            // Act
            string result = _sut.UpdateArrowDirection(currentDirection);

            // Act 
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_Arrow_Right_Is_Not_Up_From_UpdateArrowDirection()
        {
            // Arrange
            int currentDirection = 1;
            string expected = "↑";

            // Act
            string result = _sut.UpdateArrowDirection(currentDirection);

            // Assert
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void Test_Arrow_Right_Is_Not_Down_From_UpdateArrowDirection()
        {
            // Arrange
            int currentDirection = 1;
            string expected = "↓";

            // Act
            string result = _sut.UpdateArrowDirection(currentDirection);

            // Assert
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void Test_Arrow_Right_Is_Not_Left_From_UpdateArrowDirection()
        {
            // Arrange
            int currentDirection = 1;
            string expected = "←";

            // Act
            string result = _sut.UpdateArrowDirection(currentDirection);

            // Assert
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void Test_Arrow_Down_From_UpdateArrowDirection()
        {
            // Arrange
            int currentDirection = 2;
            string expected = "↓";

            // Act
            string result = _sut.UpdateArrowDirection(currentDirection);

            // Act 
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_Arrow_Left_From_UpdateArrowDirection()
        {
            // Arrange
            int currentDirection = 3;
            string expected = "←";

            // Act
            string result = _sut.UpdateArrowDirection(currentDirection);

            // Act 
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_Arrow_Left_Is_Not_Up_From_UpdateArrowDirection()
        {
            // Arrange
            int currentDirection = 3;
            string expected = "↑";

            // Act
            string result = _sut.UpdateArrowDirection(currentDirection);

            // Assert
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void Test_Arrow_Left_Is_Not_Right_From_UpdateArrowDirection()
        {
            // Arrange
            int currentDirection = 3;
            string expected = "→";

            // Act
            string result = _sut.UpdateArrowDirection(currentDirection);

            // Assert
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void Test_Arrow_Left_Is_Not_Down_From_UpdateArrowDirection()
        {
            // Arrange
            int currentDirection = 3;
            string expected = "↓";

            // Act
            string result = _sut.UpdateArrowDirection(currentDirection);

            // Assert
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void Test_CarDirection_Left_Turn()
        {
            // Arrange
            int initialDirection = 0;
            int expected = 3;

            // Act
            int result = _sut.CarDirection(Turn.Left, initialDirection);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_CarDirection_Right_Turn()
        {
            // Arrange
            int initialDirection = 0;
            int expected = 1;

            // Act
            int result = _sut.CarDirection(Turn.Right, initialDirection);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_ProcessCommand_Go_Left_UpdatesPickedCommand()
        {
            // Arrange
            char command = '1';
            string expected = "Going Left";

            // Act
            _sut.ProcessCommand(command);

            // Assert
            Assert.AreEqual(expected, _sut.PickedCommand);
        }

        [TestMethod]
        public void Test_ProcessCommand_Go_Left_UpdatesTurn()
        {
            // Arrange
            char command = '1';
            Turn expected = Turn.Left;

            // Act
            _sut.ProcessCommand(command);

            // Assert
            Assert.AreEqual(expected, _sut.Turn);
        }

        [TestMethod]
        public void Test_ProcessCommand_Go_Left_DecreasesFuel()
        {
            // Arrange
            char command = '1';
            _sut.Fuel = 10;
            int expected = 9;

            // Act
            _sut.ProcessCommand(command);

            // Assert
            Assert.AreEqual(expected, _sut.Fuel);
        }

        [TestMethod]
        public void Test_ProcessCommand_Go_Left_DecreasesTired()
        {
            // Arrange
            char command = '1';
            _sut.Tired = 18;
            int expected = 17;

            // Act
            _sut.ProcessCommand(command);

            // Assert
            Assert.AreEqual(expected, _sut.Tired);
        }

        [TestMethod]
        public void Test_ProcessCommand_Refuel_UpdatesPickedCommand()
        {
            // Arrange
            char command = '6';
            string expected = "Refueling the Car";

            // Act
            _sut.ProcessCommand(command);

            // Assert
            Assert.AreEqual(expected, _sut.PickedCommand);
        }

        [TestMethod]
        public void Test_ProcessCommand_Refuel_UpdatesStatus()
        {
            // Arrange
            char command = '6';
            StatusCode expected = StatusCode.Ok;

            // Act
            _sut.ProcessCommand(command);

            // Assert
            Assert.AreEqual(expected, _sut.Status);
        }

        [TestMethod]
        public void Test_ProcessCommand_Refuel_ResetsFuel()
        {
            // Arrange
            char command = '6';
            int expected = 10;

            // Act
            _sut.ProcessCommand(command);

            // Assert
            Assert.AreEqual(expected, _sut.Fuel);
        }

        [TestMethod]
        public void Test_ProcessCommand_Refuel_DecreasesTired()
        {
            // Arrange
            char command = '6';
            _sut.Tired = 5;
            int expected = 4;

            // Act
            _sut.ProcessCommand(command);

            // Assert
            Assert.AreEqual(expected, _sut.Tired);
        }

        [TestMethod]
        public void Test_ProcessCommand_Quit_UpdatesPickedCommand()
        {
            // Arrange
            char command = '7';
            string expected = "Quitting";

            // Act
            _sut.ProcessCommand(command);

            // Assert
            Assert.AreEqual(expected, _sut.PickedCommand);
        }

        [TestMethod]
        public void Test_ProcessCommand_Quit_UpdatesIsRunning()
        {
            // Arrange
            char command = '7';
            _sut.IsRunning = true;

            // Act
            _sut.ProcessCommand(command);

            // Assert
            Assert.IsFalse(_sut.IsRunning);
        }
    }
}
