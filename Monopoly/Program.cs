
using Monopoly.Enums;
using Monopoly.Models;


namespace Monopoly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create game & boardgame (co-dependants)
            TileProperty[] board =
            {
                new TileProperty("Patio", TileColor.Brown, 20),
                new TileProperty("Accueil", TileColor.Brown, 23),
                new TileProperty("Ascenceur droit", TileColor.LightBlue, 26),
                new TileProperty("Ascenceur gauche", TileColor.LightBlue, 26),
                new TileProperty("Toilette RDC", TileColor.LightBlue, 30),
                new TileProperty("Couloir 4ième étage", TileColor.Violet, 32),
                new TileProperty("Couloir 5ième étage", TileColor.Violet, 32),
                new TileProperty("Toilette 5ième étage", TileColor.Violet, 38),
                new TileProperty("Classe des WAD", TileColor.Orange, 42),
                new TileProperty("Classe des WEB", TileColor.Orange, 42),
                new TileProperty("Classe des Games", TileColor.Orange, 48),
                new TileProperty("Bureau Sonia", TileColor.DarkBlue, 26),
                new TileProperty("Bureau Nicole", TileColor.DarkBlue, 26),
                new TileProperty("Bureau Laure", TileColor.DarkBlue, 30),
            };

            Game monopoly = new Game(board);

            int diceNumber = 2;
            int roundsNumber = 40;

            // Ask how many players will play :
            int playerNumber;

            do Console.WriteLine("How many players are you ?");
            while (!int.TryParse(Console.ReadLine(), out playerNumber) || playerNumber < 2 || playerNumber > 6);

            // For each player, ask data :
            do
            {
                string playerName;
                do
                {
                    Console.WriteLine("What's you name?");
                    playerName = Console.ReadLine();
                } while (playerName == null);

                Console.WriteLine($"What pawn do you want to choose, {playerName} ?");
                string[] pawnList = Enum.GetNames<Pawn>();

                foreach (string pawn in pawnList)
                {
                    Console.WriteLine($"\t- {pawn}");
                }

                string userInput;
                do userInput = Console.ReadLine();
                while (userInput == null);
                Pawn playerPawnChoice = Enum.Parse<Pawn>(userInput);

                monopoly.AddPlayer(userInput, playerPawnChoice);
            } while (monopoly.Players.Length < playerNumber);

            // Play, count rounds & keep tracks :
            int roundPlayer = 0;

            while (roundPlayer < roundsNumber)
            {
                Player currentPlayer = monopoly.Players[roundPlayer % monopoly.Players.Length];
                TileProperty currentTile = monopoly[currentPlayer.Position];

                // Round treatment :
                Console.WriteLine($"{currentPlayer.Name}'s turn. They are with pawn {currentPlayer.Pawn} is on the tile n°{currentTile.Name}.\n Press enter to roll the dice.");
                Console.ReadLine();

                bool playAgain = currentPlayer.Move(diceNumber);
                currentTile = monopoly[currentPlayer.Position];

                while (playAgain)
                {
                    Console.WriteLine("Great! Double!");
                    Console.WriteLine($"Player {currentPlayer.Name} with pawn {currentPlayer.Pawn} is on the tile n°{currentTile.Name}.");
                    playAgain = currentPlayer.Move(diceNumber);
                    currentTile = monopoly[currentPlayer.Position];
                }

                Console.WriteLine($"Player {currentPlayer.Name} with pawn {currentPlayer.Pawn} is on the tile n°{currentTile.Name}.");
                roundPlayer++;
            }

        }
    }
}
