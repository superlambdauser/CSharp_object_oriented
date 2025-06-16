using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Monopoly.Enums;


namespace Monopoly.Models
{
    internal class TerrainTile : Tile
    {

        private TileColor _color;
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

        private int _price;
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

        private bool _isMortgaged;
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
        private Player? _owner;
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
            // ↓ default values for bool = false & for Owner = null : no need to specify them
            //IsMortgaged = false;
            //Owner = null;
        }


        //methods
        public void Buy(Player buyer)
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

    }
}
