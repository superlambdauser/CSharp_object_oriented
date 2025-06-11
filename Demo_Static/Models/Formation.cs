using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Static.Models
{
    internal class Formation
    {
        public static string centre = "Interface3";
        public string? name;
        public List<string>? eleves;

        public void DescribeNonStaticAttributes()
        {
            Console.WriteLine($"LA formation est dénomée {name}, et voici les noms des élèves du premier rang :");
            foreach (string eleve in eleves)
            {
                Console.WriteLine($"\t- {eleve}");
            }
        }
        public static void DescribeStaticAttributes()
        {
            Console.WriteLine($"Regroupe l'ensemble des formations de {centre}");
        }
    }
}