using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_Interfaces.Enums
namespace Demo_Interfaces.Models
{
    internal class Chicken : Animal
    {
        public Chicken(string name) : base(name)
        {

        }

        public void Run(string foxScream)
        {
            Move(2, DIRECTION.backward);
        }
    }
}
