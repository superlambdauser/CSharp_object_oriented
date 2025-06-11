using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Indexers
{
    internal class Character
    {
        public string Name { get; set; }
        public int Size { get; set; }
        private Dictionary<string, Equipment> _inventory;

        // Create an indexer :
        public Equipment this[string key]
        {
            get
            {
                if (_inventory.ContainsKey(key)) return _inventory[key];
                else return null;
            }
            set
            {
                if (_inventory is null) _inventory = new Dictionary<string, Equipment>();
                _inventory[key] = value;
            }
        }
    }
}
