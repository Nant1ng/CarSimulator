using SimulatorLibrary.Interfaces;

namespace SimulatorLibrary.Services
{
    public class DriveSim : IDriveSim
    {
        public string Arrow { get; set; } = "↑";
        public int CurrentDirection { get; set; } = 0;
        public string PickedCommand { get; set; } = "";
        public Turn Turn { get; set; }
        public int Tired { get; set; } = 15;
        public int Fuel { get; set; } = 10;
        public StatusCode Status { get; set; }

        public void Print()
        {
            bool isRunning = true;
            while (isRunning)
            {
                DisplayMenu();
                DisplayStatus(Status);

                char command = Console.ReadKey().KeyChar;
                ProcessCommand(command);

                if (Fuel < 0)
                {
                    Fuel = 0;
                    Status = StatusCode.Error;
                    PickedCommand = "You need to refuel the care befor using it.";
                }
                else if (Fuel >= 0 & Turn != Turn.None)
                {
                    CurrentDirection = CarDirection(Turn, CurrentDirection);
                    Status = StatusCode.Ok;
                    UpdateArrowDirection(CurrentDirection);
                }

                Console.Clear();
            };
        }
        private void DisplayMenu()
        {
            Console.WriteLine(@"
[1] Go Left
[2] Go Right
[3] Move Forward
[4] Reverse
[5] Take a Break
[6] Refuel the Car
[7] Quit
            ");
        }

        private StatusCode DisplayStatus(StatusCode status)
        {
            Console.WriteLine();

            if (status == StatusCode.Ok)
                Console.WriteLine($"What do you want to do? {PickedCommand}");
            else if (status == StatusCode.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(PickedCommand);
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine($"Fuel: {Fuel}");

            if (TiredWarning(Tired) == StatusCode.Warning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Warning you need to take a brake");
                Console.ResetColor();
            };
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("    N");
            Console.WriteLine();
            Console.WriteLine($"W   {Arrow}   E");
            Console.WriteLine();
            Console.WriteLine("    S");
            Console.ResetColor();

            return status;
        }

        private void ProcessCommand(char command)
        {
            switch (command)
            {
                case '1':
                    PickedCommand = "Going Left";
                    Turn = Turn.Left;
                    Fuel--;
                    Tired--;
                    break;
                case '2':
                    PickedCommand = "Going Right";
                    Turn = Turn.Right;
                    Fuel--;
                    Tired--;
                    break;
                case '3':
                    PickedCommand = "Moving Forward";
                    Turn = Turn.None;
                    Fuel--;
                    Tired--;
                    break;
                case '4':
                    PickedCommand = "Reversing";
                    Turn = Turn.None;
                    Fuel--;
                    Tired--;
                    break;
                case '5':
                    PickedCommand = "Taking a Break";
                    Turn = Turn.None;
                    Tired = 10;
                    break;
                case '6':
                    PickedCommand = "Refueling the Car";
                    Status = StatusCode.Ok;
                    Turn = Turn.None;
                    Fuel = 10;
                    Tired--;
                    break;
                case '7':
                    PickedCommand = "Quitting";
                    Turn = Turn.None;
                    break;
                default:
                    PickedCommand = "Invalid input!";
                    Turn = Turn.None;
                    break;
            }
        }

        public StatusCode TiredWarning(int tired)
        {
            StatusCode status = StatusCode.Ok;

            if (tired <= 0)
            {
                PickedCommand = "Time to take a break";
                status = StatusCode.Warning;

                return status;
            }

            return status;
        }

        public int CarDirection(Turn turn, int currentDirection)
        {
            currentDirection = (CurrentDirection + (turn == Turn.Left ? -1 : 1) + 4) % 4;

            return currentDirection;
        }
        public string UpdateArrowDirection(int currentDirection)
        {
            switch (currentDirection)
            {
                case 0:
                    Arrow = "↑";
                    break;
                case 1:
                    Arrow = "→";
                    break;
                case 2:
                    Arrow = "↓";
                    break;
                case 3:
                    Arrow = "←";
                    break;
            }

            return Arrow;
        }
    }
}
