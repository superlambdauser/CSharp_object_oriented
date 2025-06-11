using Demo_Inheritance.Models;

namespace Demo_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape s = new Shape("Blue", 2);

            Rectangle r = new Rectangle("Green", 3, 4, 5);

            Circle c = new Circle("Yellow", 2, 6);

            Square square = new Square("Green", 1, 5);

        }
    }
}
