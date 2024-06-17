using SimulatorLibrary.Models;

namespace SimulatorLibrary.Interfaces
{
    public enum StatusCode
    {
        Ok,
        Warning,
        Error
    }
    public enum Turn
    {
        None,
        Left,
        Right
    }

    public interface IDriveSim
    {
        void Print(Driver driver);
        int CarDirection(Turn turn, int currentDirection);
    }
}
