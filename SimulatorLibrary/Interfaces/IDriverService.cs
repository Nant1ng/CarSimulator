using SimulatorLibrary.Models;

namespace SimulatorLibrary.Interfaces
{
    public interface IDriverService
    {
        Task<Driver> GetRandomDriver();
    }
}
