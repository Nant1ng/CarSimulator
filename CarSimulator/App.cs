using SimulatorLibrary.Interfaces;

namespace CarSimulator
{
    public class App
    {
        private readonly IDriveSim _driveSim;
        private readonly IDriverService _driverService;
        public App(IDriveSim driveSim, IDriverService driverService)
        {
            _driveSim = driveSim;
            _driverService = driverService;
        }

        public async Task Run()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(@"
             ██████╗ █████╗ ██████╗     ███████╗██╗███╗   ███╗██╗   ██╗██╗      █████╗ ████████╗ ██████╗ ██████╗ 
            ██╔════╝██╔══██╗██╔══██╗    ██╔════╝██║████╗ ████║██║   ██║██║     ██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗
            ██║     ███████║██████╔╝    ███████╗██║██╔████╔██║██║   ██║██║     ███████║   ██║   ██║   ██║██████╔╝
            ██║     ██╔══██║██╔══██╗    ╚════██║██║██║╚██╔╝██║██║   ██║██║     ██╔══██║   ██║   ██║   ██║██╔══██╗
            ╚██████╗██║  ██║██║  ██║    ███████║██║██║ ╚═╝ ██║╚██████╔╝███████╗██║  ██║   ██║   ╚██████╔╝██║  ██║
             ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝    ╚══════╝╚═╝╚═╝     ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝
                                                                                                     ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@"
                                                            [1] Start

                                                            [0] Exit
                ");
                Console.ResetColor();

                char key = Console.ReadKey().KeyChar;
                Console.Clear();

                var driver = await _driverService.GetRandomDriver();

                switch (key)
                {
                    case '1':
                        _driveSim.Print(driver);
                        break;

                    case '0':
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        Console.ResetColor();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid selection. Please choose a valid option.");
                        Console.ResetColor();
                        break;
                }
            } while (true);
        }
    }
}
