using Demo_Interfaces.Enums;
using Demo_Interfaces.Interfaces;
using Demo_Interfaces.Structures;

namespace Demo_Interfaces.Models
{
    internal abstract class Animal : IAnimal
    {
        private readonly string _name;
        private Position _placement;

        public string Name
        {
            get
            {
                return _name;
            }
        }


        public Animal(string name)
        {
            _name = name;
            _placement = new Position();
            _placement.x = 0;
            _placement.y = 0;
        }


        public Position Move(int distance, DIRECTION direction)
        {
            switch (direction)
            {
                case DIRECTION.forward:
                    _placement.x += distance;
                    break;
                case DIRECTION.backward:
                    _placement.x -= distance;
                    break;
                case DIRECTION.left:
                    _placement.y -= distance;
                    break;
                case DIRECTION.right:
                    _placement.y += distance;
                    break;
                default: // default is here because you can give an int to an enum without an error
                    throw new Exception("Direction not valid.");
                    break;
            }
            return _placement;
        }
    }
}
