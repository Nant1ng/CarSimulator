using SimulatorLibrary.Models;

namespace SimulatorLibrary.Interfaces
{
    public enum HungerStatus
    {
        Full,
        Hungry,
        Starving
    }
    public interface IDriverService
    {
        Task<Driver> GetRandomDriver();
    }
    public interface IHunger
    {
        HungerStatus GetHungerStatus(int hungerLevel);
    }
}
