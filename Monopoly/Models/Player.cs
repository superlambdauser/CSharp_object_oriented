using Monopoly.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models
{
    internal class Player
    {
        #region var & properties
        private int _position = 0;
        private int _account = 0;

        public int Position
        {
            get
            {
                return _position;
            }
            private set // No access outside the class
            {
                _position = value;
            }
        }
        public int Account
        {
            get
            {
                return _account;
            }
            private set
            {
                if (value < 0) // can't be negative
                {
                    Console.WriteLine("Ceci sera remplacé plus tard par une exception");
                }
                else
                {
                    _account = value;
                }
            }
        }
        public List<TerrainTile> RealEstates
        {
            get; // autoproperty -> returns the property's value.
            // no private set here because it implies you may reset the whole array (not just its content)
        }

        // Auto properties :
        public string? Name { get; set; }
        public Pawn Pawn { get; set; }
        // -- not best practice -- 
        #endregion

        #region methods
        #region constructors
        public Player(string name, Pawn pawn)
        {
            Name = name;
            Pawn = pawn;
            Account = 1500;
            Position = 0;
            RealEstates = new List<TerrainTile>();
        }

        #endregion

        public bool Move(int diceNumber)
        {
            Dice.MinValue = 1;
            Dice.MaxValue = 6;

            int[] diceResults = Dice.Roll(diceNumber);

            for (int i = 0; i < diceResults.Length; i++)
            {
                Position += diceResults[i];
            }

            return diceResults[0] == diceResults[1];
        }

        public void GetPaid(int amount)
        {
            if (amount > 0)
            {
                Account += amount;
            }
        }

        public bool Spend(int price)
        {
            bool transactionFailed;

            if (Account > price && price > 0)
            {
                Account -= price;
                transactionFailed = false;
                return transactionFailed;
            }
            else
            {
                transactionFailed = true;
                return transactionFailed;
            }
        }

        public void AddRealEstate(TerrainTile tile)
        {
            if (tile != null && this == tile.Owner)
            {
                RealEstates.Add(tile);
            }
        }

        // Operator overloading :
        // an operator overload "Player(left) + int amount(right)" that allows you to use "+" to add amound to Player's account
        public static Player operator +(Player left, int right)
        {
            left.GetPaid(right);
            return left;
        }

        //public static List<TerrainTile> operator +(Player left, TerrainTile right)
        //{
        //    right.Buy(left);
        //    left.AddRealEstate(right);
        //    return left.RealEstates;
        //}
        #endregion
    }
}
