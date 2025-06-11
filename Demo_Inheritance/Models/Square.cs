using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Inheritance.Models
{
    internal sealed class Square : Rectangle //sealed = no more inheritance possible from Square() class
    {
        public Square(string rectColor, int rectThickness, int sideLenght) : base(rectColor, rectThickness, sideLenght, sideLenght)
        {
        }
    }
}
