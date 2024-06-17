namespace SimulatorLibrary.Models
{
    public class Driver
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public Driver() { }

        public Driver(string title, string name, string gender)
        {
            Title = title;
            Name = name;
            Gender = gender;
        }
    }
}
