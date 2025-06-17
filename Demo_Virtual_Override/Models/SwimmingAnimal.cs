using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Virtual_Override.Models
{
    internal class SwimmingAnimal : Animal
    {
        public SwimmingAnimal(string name) : base(name)
        {
        }

        public override void Move()
        {
            base.Move();
            Console.WriteLine("Inside water.");
        }
    }
}
