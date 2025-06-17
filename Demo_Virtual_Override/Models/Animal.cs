namespace Demo_Virtual_Override.Models
{
    internal class Animal
    {
        public string Name { get; set; } 
        public Animal(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"My name is {Name}";
        }

        public virtual void Move()
        {
            Console.WriteLine($"{Name} is moving.");
        }
    }
}