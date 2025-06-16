using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Polymorphism.Models
{
    internal class Equipment : InventoryItem
    {
        public int BonusDefense {  get; private set; }
        public int BonusAttack { get; private set; }
        public Equipment(string name, int price, int bonusDefense, int bonusAttack) : base(name, price)
        {
            BonusDefense = bonusDefense;
            BonusAttack = bonusAttack;
        }
    }
}
