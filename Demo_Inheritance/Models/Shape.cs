using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Inheritance.Models
{
    internal class Shape
    {
        // autoproperty to avoid making a public variable :
        public string Color { get; set; }
        private int _thickness;

        public int Thickness
        {
            protected get { return _thickness; }
            set 
            { 
                _thickness = (value < 0) ? -value : value; // ternary operator : if value is negative, sets it to positive. 
            }
        }

        public Shape(string color, int thickness)
        {
            Color = color;
            Thickness = thickness;
        }

    }
}
