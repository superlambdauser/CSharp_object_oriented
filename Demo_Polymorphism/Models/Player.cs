using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Polymorphism.Models
{
    internal class Player
    {
        private List<InventoryItem> _inventory;

        public InventoryItem[] Inventory
        {
            get
            {
                return _inventory.ToArray();
            }
        }
        public int Wallet {  get; set; }
        public Equipment LeftHand { get; private set; }
        public Equipment RightHand { get; private set; }

        public Player()
        {
            Wallet = 1000;
            _inventory = new List<InventoryItem>();
        }

        public void Loot(InventoryItem item)
        {
            _inventory.Add(item);
        }
        public bool DropItem(InventoryItem item)
        {
            return _inventory.Remove(item);
        }
        public void Equip(Equipment equipment, bool leftHAnd)
        {
            if (leftHAnd)
            {
                LeftHand = equipment;
            }
            else
            {
                RightHand = equipment;
            }
        }
    }
}
