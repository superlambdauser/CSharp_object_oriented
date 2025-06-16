using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Abstract.Models
{
    internal sealed class Dog : Animal
    {
        public Dog(string name) : base(name)
        {

        }

        public override void Scream()
        {
            Console.WriteLine("Woof.");
        }
    }
}
