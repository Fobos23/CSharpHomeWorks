namespace HW_12012021.Task_1
{
    public class User
    {
        public string Name { get; }
        public string Surname { get; }
        public int Age { get; }
        public double Height { get; }
        public double Weight { get; }

        public User(string name, string surname, int age, double height, double weight )
        {
            Name = name;
            Surname = surname;
            Age = age;
            Height = height;
            Weight = weight;
        }
    }
}