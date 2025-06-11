
using Demo_Class.Models;

namespace Demo_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car aFerrari = new Car()
            {
                couleur = "rouge",
                immatriculation = "2-ABC-123",
                nbRoues = 4
            };

            Car sameFerrariDifferentName = aFerrari;
            // Ici, on instancie un nouveau POINTEUR vers le MÊME OBJET "aFerrari" -> Si je modifie cette instanciation, toutes celles qui y font référence seront modifiées !!


        }
    }
}
