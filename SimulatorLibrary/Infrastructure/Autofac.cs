using Autofac;
using SimulatorLibrary.Interfaces;
using SimulatorLibrary.Services;


namespace SimulatorLibrary.Infrastructure
{
    public class Autofac
    {
        public IContainer ServiceManger()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DriveSim>().As<IDriveSim>();

            return builder.Build();
        }
    }
}
