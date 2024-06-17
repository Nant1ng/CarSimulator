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
        void Print();
        int CarDirection(Turn turn, int currentDirection);
    }
}
