using Demo_Polymorphism.Models;

namespace Demo_Polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Demo_1
            Player player = new Player();
            //InventoryItem nugget = new InventoryItem("Pépite d'or", 5000);

            //player.Loot(nugget);

            //Console.WriteLine("Inventory :");
            //foreach (InventoryItem item in player.Inventory)
            //{
            //    Console.WriteLine($"- {item.Name}");
            //}

            //player.Inventory[0].Sell(player);

            //Console.WriteLine($"You have {player.Wallet}$ in your wallet.");

            //Console.WriteLine("Inventory :");
            //foreach (InventoryItem item in player.Inventory)
            //{
            //    Console.WriteLine($"- {item.Name}");
            //}

            //Equipment sword = new Equipment("Sword of Truth", 10000, 2, 5);

            //player.Loot(sword); // boxing (sword is a child of InventoryItem and is seen as an InventoryItem here)

            //if (player.Inventory[0] is Equipment inventoryEquipment) // = "if the variable is an Equipment, store it inventoryEquipment"
            //{
            //    player.Equip(inventoryEquipment, true);
            //} // unboxing 
            #endregion

            #region Demo_2 (with Chest)
            List<Chest> chests = new List<Chest>();
            for (int i = 0; i < 5; i++)
            {
                chests.Add(new Chest
                    (
                        [
                            new InventoryItem("Gold nugget", 5000),
                            new InventoryItem("Diamond dust", 1000),
                            new InventoryItem("Potion", 500),
                            new Equipment("Helmet", 1200, 5, 0),
                            new Equipment("Sword of Truth", 2500, 2, 5),
                            new Equipment("Mace of Punishment", 2200, 0, 8)
                        ] // using the 2nd ctor of Chest() class to make it take a list of items
                    ));
            } // adding non-fix(random loot) chests 5 times

            chests.Add(new Chest(new InventoryItem("Dungeon's key", 0)));
            chests.Add(new Chest(new Equipment("Power Ring", 0, 10, 10)));
            // adding 2 fixed chests

            foreach (Chest c in chests)
            {
                player.Loot(c.Content);
                c.EmptyChest();
            }

            while (player.Inventory.Length > 0)
            {
                Console.Clear();
                Console.WriteLine("Inventory :");
                for (int i = 0; i < player.Inventory.Length; i++)
                {
                    InventoryItem item = player.Inventory[i];
                    Console.WriteLine($"{i} : {item.Name}");
                }

                Console.WriteLine($"You have {player.Wallet}in your wallet.");

                int choice;
                do Console.WriteLine("What item do you want to interract with ?");
                while (int.TryParse(Console.ReadLine(), out choice));

                InventoryItem selectedItem = player.Inventory[choice];
                Console.WriteLine("- (S)ell");

                if (selectedItem is Equipment)
                {
                    Console.WriteLine("- (E)quip");
                }

                switch (Console.ReadKey().KeyChar)
                {
                    case 'V':
                        selectedItem.Sell(player);
                        break;
                    case 'E':
                        if (selectedItem is Equipment equipment)
                        {
                            player.Equip(equipment, true);
                        }
                        break;
                } 
            }
            #endregion
        }
    }
}
