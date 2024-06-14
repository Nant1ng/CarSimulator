using SimulatorLibrary.Interfaces;

namespace SimulatorLibrary.Services
{
    public class DriveSim : IDriveSim
    {
        public string Arrow { get; set; } = "↑";
        public int CurrentDirection { get; set; } = 0;
        public string PickedCommand { get; set; }
        public Turn Turn { get; set; }
        public int Fuel { get; set; } = 10;

        public void Print()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine(@"[1] Go Left
[2] Go Right
[3] Move Forward
[4] Reverse
[5] Take a Break
[6] Refuel the Car
[7] Quit
                    ");

                Console.WriteLine();
                Console.WriteLine($"What do you want to do? {PickedCommand}");
                Console.WriteLine();
                Console.WriteLine($"{Fuel}");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("    N");
                Console.WriteLine("");
                Console.WriteLine($"W   {Arrow}   E");
                Console.WriteLine();
                Console.WriteLine("    S");
                Console.ResetColor();

                char command = Console.ReadKey().KeyChar;

                switch (command)
                {
                    case '1':
                        PickedCommand = "Going Left";
                        Turn = Turn.Left;
                        Fuel = Fuel - 1;
                        break;
                    case '2':
                        PickedCommand = "Going Right";
                        Turn = Turn.Right;
                        Fuel = Fuel - 1;
                        break;
                    case '3':
                        PickedCommand = "Moving Forward";
                        Turn = Turn.None;
                        Fuel = Fuel - 1;
                        break;
                    case '4':
                        PickedCommand = "Reverse";
                        Turn = Turn.None;
                        Fuel = Fuel - 1;
                        break;
                    case '5':
                        PickedCommand = "Taking a Break";
                        Turn = Turn.None;
                        break;
                    case '6':
                        PickedCommand = "Refueling the Car";
                        Turn = Turn.None;
                        Fuel = 10;
                        break;
                    case '7':
                        isRunning = false;
                        break;
                    default:
                        PickedCommand = "Invalid input!";
                        break;
                }

                ArrowDirection(CurrentDirection);

                if (Fuel > 0 && Turn != Turn.None)
                {
                    CurrentDirection = CarDirection(Turn, CurrentDirection);
                }
                else
                {
                    Fuel = 0;
                    PickedCommand = "You need to refuel the care befor using it.";
                }

                Console.Clear();
            };
        }
        public int CarDirection(Turn turn, int currentDirection)
        {
            char[] direction = new char[] { 'N', 'E', 'S', 'W' };

            if (turn == Turn.Left)
                currentDirection = (currentDirection - 1 + direction.Length) % direction.Length;
            else if (turn == Turn.Right)
                currentDirection = (currentDirection + 1) % direction.Length;

            return currentDirection;
        }
        public string ArrowDirection(int currentDirection)
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
