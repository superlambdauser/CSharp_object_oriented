using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models
{
    internal static class Dice
    {
        //
        private static int _minValue = 1;
        private static int _maxValue = 6;
        // !! This is a D6 -> we can reuse this to roll other dices,
        // simply change MinValue and MaxValue in the calling of the class
        // using Dice.(Min/Max)Value properties :

        public static int MinValue
        {
            get
            {
                return _minValue;
            }
            set
            {
                if (value > 0)
                {
                    _minValue = value;
                    if (value >= MaxValue)
                    {
                        MaxValue = value + 1;
                    }
                }
            }
        }

        public static int MaxValue
        {
            get
            {
                return _maxValue;
            }
            set
            {
                if (value > 1)
                {
                    _maxValue = value;
                    if (value < MinValue)
                    {
                        MinValue = value - 1;
                    }
                }
            }
        }

        public static Random rng = new Random();

        public static int[] Roll(int diceNumber) // array[]
        {
            int[] diceResults = new int[diceNumber];

            for (int i = 0; i < diceNumber; i++)
            {
                diceResults[i] = rng.Next(_minValue, MaxValue);
            }

            return diceResults;
        }
    }
}
