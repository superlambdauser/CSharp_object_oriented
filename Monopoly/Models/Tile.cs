using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models
{
    internal abstract  class Tile
    {
        private List<Player> _visitors;


        public string Name { get; private set; }
        public Player[] Visitors
        {
            get
            {
                return _visitors.ToArray();
            }
        }


        public Tile(string name)
        {
            Name = name;
            _visitors = new List<Player>();
        }


        public void AddVisitor(Player visitor)
        {
            if (_visitors.Contains(visitor)) return; // Exception msg
            _visitors.Add(visitor);
        }
        public void RemoveVisitor(Player visitor)
        { 
            if (!_visitors.Remove(visitor)) return; // Remove() returns a bool so we can use it for the eventual exception msg
        }
        public abstract void Activate(Player visitor);
    }
}
