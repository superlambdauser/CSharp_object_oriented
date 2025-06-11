using Demo_Static.Models;

namespace Demo_Static
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Formation games = new Formation() { name = "UNITY05", eleves = new List<string>(["Manon", "Begüm", "Estelle", "Gaëlle", "Lyst"]) };

            Formation wad = new Formation() { name = "WAD25", eleves = new List<string>(["Laura", "Emilie", "Yulia", "Siham", "Tran"]) };

            games.DescribeNonStaticAttributes();
            wad.DescribeNonStaticAttributes();

            Formation.DescribeStaticAttributes();
        }

    }
}
