# CarSimulation App

## Overview

The CarSimulation App is a console-based application designed to simulate car driving experiences. It features driver management, including checking and updating the driver's status such as tiredness and hunger. The application also incorporates direction updates, fuel management, and other driving actions.

## Features

- **Driver Management**: Randomly fetches driver information from an API.
- **Direction Control**: Allows the car to turn left, right, move forward, and reverse.
- **Fuel Management**: Tracks fuel levels and requires refueling.
- **Tiredness Management**: Monitors the driver's tiredness and provides warnings.

## Future Features 
- **Hunger Management**: Tracks the driver's hunger status (Full, Hungry, Starving).

## Testing
The CarSimulation App includes a suite of tests to ensure its functionality. The tests are written using MSTest, NUnit, and Moq frameworks

## Moq Usage
Moq is used to create mock implementations of the `IHungerService` interface. This allows testing of the CarSimulation App's hunger management logic without requiring an actual implementation of the service.

### Example Moq Test
```csharp
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
```
