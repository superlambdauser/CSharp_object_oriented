using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Inheritance.Models
{
    internal class Circle : Shape
    {
		private int _radius;


        public int Radius
		{
			get { return _radius; }
			set 
			{
				if (value < 0) value = -value;
				_radius = value; 
			}
		}

        public Circle(string color, int thickness, int radius) : base(color, thickness)
        {
        }
      
    }
}
