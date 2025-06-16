using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models
{
    internal class Tile
    {
        //props
        public string Name { get; private set; }

        private List<Player> _visitors;
        public Player[] Visitors
        {
            get
            {
                return _visitors.ToArray();
            }
        }

        //ctor
        public Tile(string name)
        {
            Name = name;
            _visitors = new List<Player>();
        }

        //methods
        public void AddVisitor(Player visitor)
        {
            if (_visitors.Contains(visitor)) return; // Exception msg
            _visitors.Add(visitor);
        }

        public void RemoveVisitor(Player visitor)
        { 
            if (!_visitors.Remove(visitor)) return; // Remove() returns a bool so we can use it for the eventual exception msg
        }
    }
}
