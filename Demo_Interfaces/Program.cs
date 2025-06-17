using Demo_Interfaces.Models;
using Demo_Interfaces.Enums;
using Demo_Interfaces.Structures;

namespace Demo_Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chicken lava = new Chicken("Lava");
            Position position = Lava.Move(4, DIRECTION.forward);

            Console.WriteLine($"My chicken is in x:{position.x} y:{position.y}");

            Fox goupil = new Fox("Goupil");

            goupil.OnScream += lava.Run; // Setting up the listening ability to my chicken object

            goupil.SeeChicken();
        }
    }
}
