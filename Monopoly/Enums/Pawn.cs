using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 1. Créer une énumération « Pions » qui aura pour valeurs : Voiture, Cuirasse, Chien, Chapeau, Fer, Dino, DeACoudre, Brouette, Chaussure

namespace Monopoly.Enums
{
    internal enum Pawn
    {
        Car,
        Tank,
        Dog,
        Hat,
        Horseshoe, // (fer à cheval)
        Dino,
        Thimble, // (dé à coudre)
        Wheelbarrow, // (brouette)
        Shoe
    }
}
