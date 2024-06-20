using SimulatorLibrary.Interfaces;
using SimulatorLibrary.Models;

namespace SimulatorLibrary.Services
{
    public class DriveSim : IDriveSim
    {
        public string Arrow { get; set; } = "↑";
        public int CurrentDirection { get; set; } = 0;
        public string PickedCommand { get; set; } = "";
        public Turn Turn { get; set; }
        public int Tired { get; set; } = 18;
        public int Fuel { get; set; } = 10;
        public StatusCode Status { get; set; }
        public bool IsRunning { get; set; } = true;

        public void Print(Driver driver)
        {
            IsRunning = true;
            while (IsRunning)
            {
                Console.WriteLine($"Driver: {driver.Title} {driver.Name}.");
                Console.WriteLine($"Gender: {driver.Gender}.");

                EvaluateTirednessLevel(Tired);
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

        public void DisplayMenu()
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

        public void DisplayStatus(StatusCode status)
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

            if (Fuel > 6)
                Console.WriteLine($"Fuel: {Fuel}");
            else if (Fuel <= 6 && Fuel > 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Fuel: {Fuel}");
                Console.ResetColor();
            }
            else if (Fuel <= 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Fuel: {Fuel}");
                Console.ResetColor();
            }

            if (EvaluateTirednessLevel(Tired) == StatusCode.Warning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Warning you need to take a break");
                Console.ResetColor();
            }
            else if (EvaluateTirednessLevel(Tired) == StatusCode.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You need to take a break now!");
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
        }

        public void ProcessCommand(char command)
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
                    Tired = 18;
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
                    IsRunning = false;
                    Turn = Turn.None;
                    break;
                default:
                    PickedCommand = "Invalid input!";
                    Turn = Turn.None;
                    break;
            }
        }

        public StatusCode EvaluateTirednessLevel(int tired)
        {
            StatusCode status = StatusCode.Ok;

            if (tired <= 12 && tired >= 6)
                status = StatusCode.Warning;
            else if (tired < 6)
                status = StatusCode.Error;

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
