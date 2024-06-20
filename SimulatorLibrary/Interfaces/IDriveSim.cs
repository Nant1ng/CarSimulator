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
        public string Arrow { get; set; }
        public int CurrentDirection { get; set; }
        public string PickedCommand { get; set; }
        public Turn Turn { get; set; }
        public int Tired { get; set; }
        public int Fuel { get; set; }
        public StatusCode Status { get; set; }
        public bool IsRunning { get; set; }
        void Print(Driver driver);
        void DisplayMenu();
        void DisplayStatus(StatusCode status);
        void ProcessCommand(char command);
        StatusCode EvaluateTirednessLevel(int tired);
        int CarDirection(Turn turn, int currentDirection);
        string UpdateArrowDirection(int currentDirection);

    }
}
