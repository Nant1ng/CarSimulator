namespace SimulatorLibrary.Interfaces
{
    public enum StatusCode
    {
        Ok,
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
