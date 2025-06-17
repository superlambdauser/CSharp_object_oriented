using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Virtual_Override.Models
{
    internal class WalkingAnimal : Animal
    {
        public WalkingAnimal(string name) : base(name)
        {
        }

        public virtual void Move()
        {
            base.Move();
            Console.WriteLine("On earth.");
        }
    }
}
