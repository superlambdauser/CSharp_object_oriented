using Demo_Virtual_Override.Models;

namespace Demo_Virtual_Override
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Animal opossum = new WalkingAnimal("Ellie");
            //Console.WriteLine(opossum);
            //opossum.Move();

            //Animal clownFish = new SwimmingAnimal("Nemo");
            //clownFish.Move();

            //Animal snake = new Animal("Kaha");
            //snake.Move();

            List<Animal> zoo = new List<Animal>()
            {
                new WalkingAnimal("Ellie"),
                new SwimmingAnimal("Nemo"),
                new Animal("Kaha"),
            };

            foreach (Animal a in zoo)
            {
                Console.WriteLine(a);
                a.Move();
            }
        }
    }
}
