using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Abstract.Models
{
    internal abstract class Animal
    {
        public string Name { get; private set; }

        protected Animal(string name)
        {
            Name = name;
        }
        public abstract void Scream();
    }
}
