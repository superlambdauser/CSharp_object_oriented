using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Inheritance.Models
{
    internal class Rectangle : Shape
    {
        // shortcut for creating a property : propfull (+tab)
        private int _height;
        public int Height
        {
            get { return _height; }
            set
            {
                if (value > _width)
                {
                    _height = _width;
                    _width = value; // invert height and width if height < width
                }
                else { _height = value; }
            }
        }

        private int _width;
        public int Width
        {
            get { return _width; }
            set
            {
                if (value > _height)
                {
                    _width = _height;
                    _height = value; // invert height and width if width > height
                }
                else { _width = value; }
            }
        }

        // constructor 
        public Rectangle(string rectColor, int rectThickness, int width, int height) : base(rectColor, rectThickness)
        {

        }
    }
}
