using Demo_Interfaces.Enums;
using Demo_Interfaces.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Interfaces.Interfaces
{
    /// <summary>
    /// Defines mandatory props and actions of a chicken
    /// </summary>
    internal interface IAnimal
    {
        string Name { get; } // props and methods of an interface are public by default

        Position Move(int distance, DIRECTION direction);
    }
}
