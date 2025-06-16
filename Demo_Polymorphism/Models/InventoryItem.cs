namespace Demo_Polymorphism.Models
{
    internal class InventoryItem
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public InventoryItem(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public void Sell(Player player)
        {
            player.Wallet += this.Price;
            player.DropItem(this);
        }
    }
}