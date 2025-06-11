namespace Demo_Indexers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 - Create a character :
            Character CatCar = new Character()
            {
                Name = "CatCar",
                Size = 12
            };

            // 2 - Create some stuff to add to inventory :
            Equipment CatFoodDispenser = new Equipment()
            {
                Name = "Krokettor",
                Color = "Brown",
                Power = 1
            };
            Equipment Santiags = new Equipment()
            {
                Name = "Flaming Boots",
                Color = "Red",
                Power = 6
            };
            Equipment LightSword = new Equipment()
            {
                Name = "ExCatlibur",
                Color = "Silver",
                Power = 12
            };


            // 3 - Associate equipment to character :

            // Classic version :
            //if (CatCar.Inventory is null) CatCar.Inventory = new List<Equipment>();
            //CatCar.Inventory.Add(CatFoodDispenser);
            //CatCar.Inventory.Add(Santiags);
            //CatCar.Inventory.Add(LightSword);

            // Indexer version :
            CatCar["Krokettor"] = CatFoodDispenser;
            CatCar["Flaming boots"] = Santiags;
            CatCar["ExCatlibur"] = LightSword;
        }
    }
}
