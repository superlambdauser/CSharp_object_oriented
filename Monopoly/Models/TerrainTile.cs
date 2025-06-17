using Monopoly.Enums;
using System;


namespace Monopoly.Models
{
    internal class TerrainTile : Tile
    {

        private TileColor _color;
        private int _price;
        private bool _isMortgaged;
        private Player? _owner;


        public TileColor Color
        {
            get
            {
                return _color;
            }
            private set
            {
                _color = value;
            }
        }
        public int Price
        {
            get
            {
                return _price;
            }
            private set
            {
                if (value > 0) _price = value;
            }
        }
        public bool IsMortgaged
        {
            get
            {
                return _isMortgaged;
            }
            private set
            {
                _isMortgaged = value;
            }
        }
        public Player? Owner
        {
            get
            {
                return _owner;
            }
            private set
            {
                _owner = value;
            }
        }


        //ctor
        public TerrainTile(string name, TileColor color, int price) : base(name)
        {
            Color = color;
            Price = price;
            // ↓ default values for bool = false & for Owner(object) = null : no need to specify them
            //IsMortgaged = false;
            //Owner = null;
        }


        //methods
        private void Buy(Player buyer)
        {
            if ((Owner == null || IsMortgaged) && buyer != null && buyer.Account >= Price)
            // !!! here i double check if buyer has the money so that i don't uselessly call a Method() (opti)
            {
                bool transactionFailed = buyer.Spend(Price); // make the player buy & take the bool that returns from it
                if (!transactionFailed)
                {
                    Owner = buyer;
                }
            }
        }
        private void Stay(Player visitor)
        {
            int stayingPrice = Price / 4;
            if (visitor != null)
            {   if (visitor.Account >= Price)
                {
                    visitor.Spend(stayingPrice);
                }
                else
                {
                    visitor.Spend(visitor.Account);
                    Console.WriteLine("Think about mortgaging your properties.");
                }
            }
        }
        public override void Activate(Player visitor)
        {
            if ((Owner == null || IsMortgaged) && visitor.Account >= Price)
            {
                Buy(visitor);
            }
            else if (!visitor.RealEstates.Contains(this)) // we try to check "deeper" tu enhance security (ideally should use DB) 
            {
                Stay(visitor);
            }
        }
    }
}
