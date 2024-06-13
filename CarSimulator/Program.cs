using Autofac;
using SimulatorLibrary.Interfaces;

namespace CarSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Car Simulation App";

            var serviceManger = new SimulatorLibrary.Infrastructure.Autofac();
            var container = serviceManger.ServiceManger();

            using (var scope = container.BeginLifetimeScope())
            {
                var myService = scope.Resolve<IDriveSim>();
                var app = new App(myService);

                app.Run();
            }
        }
    }
}
