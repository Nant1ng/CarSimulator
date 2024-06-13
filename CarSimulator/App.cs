using SimulatorLibrary.Interfaces;

namespace CarSimulator
{
    public class App
    {
        private readonly IDriveSim _driveSim;
        public App(IDriveSim driveSim)
        {
            _driveSim = driveSim;
        }

        public void Run()
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

                switch (key)
                {
                    case '1':
                        _driveSim.Print();
                        break;

                    case '0':
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
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
