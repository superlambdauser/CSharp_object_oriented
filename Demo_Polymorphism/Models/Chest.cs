using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Polymorphism.Models
{
    internal class Chest
    {
        public InventoryItem Content {  get; private set; }

        public Chest(InventoryItem content)
        {
            Content = content;
        }

        public Chest(InventoryItem[] content)
        {
            Random rng = new Random();
            Content = content[rng.Next(content.Length)];
        }

        public void EmptyChest()
        {
            Content = null;
        }
    }
}
