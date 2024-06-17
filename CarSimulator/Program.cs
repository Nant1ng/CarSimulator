using Autofac;
using SimulatorLibrary.Interfaces;

namespace CarSimulator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Car Simulation App";

            var serviceManger = new SimulatorLibrary.Infrastructure.Autofac();
            var container = serviceManger.ServiceManger();

            using (var scope = container.BeginLifetimeScope())
            {
                var driveSimService = scope.Resolve<IDriveSim>();
                var driverService = scope.Resolve<IDriverService>();

                var app = new App(driveSimService, driverService);

                await app.Run();
            }
        }
    }
}
