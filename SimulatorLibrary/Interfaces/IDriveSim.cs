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
        void DisplayMenu();
        void DisplayStatus(StatusCode status);
        void ProcessCommand(char command);
        StatusCode EvaluateTirednessLevel(int tired);
        int CarDirection(Turn turn, int currentDirection);
        string UpdateArrowDirection(int currentDirection);

    }
}
