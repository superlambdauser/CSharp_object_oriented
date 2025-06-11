
using Monopoly.Enums;
using Monopoly.Models;


namespace Monopoly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create game & boardgame (co-dependants)
            TerrainTile[] board =
            {
                new TerrainTile("Patio", TileColor.Brown, 20),
                new TerrainTile("Accueil", TileColor.Brown, 23),
                new TerrainTile("Ascenceur droit", TileColor.LightBlue, 26),
                new TerrainTile("Ascenceur gauche", TileColor.LightBlue, 26),
                new TerrainTile("Toilette RDC", TileColor.LightBlue, 30),
                new TerrainTile("Couloir 4ième étage", TileColor.Violet, 32),
                new TerrainTile("Couloir 5ième étage", TileColor.Violet, 32),
                new TerrainTile("Toilette 5ième étage", TileColor.Violet, 38),
                new TerrainTile("Classe des WAD", TileColor.Orange, 42),
                new TerrainTile("Classe des WEB", TileColor.Orange, 42),
                new TerrainTile("Classe des Games", TileColor.Orange, 48),
                new TerrainTile("Bureau Sonia", TileColor.DarkBlue, 26),
                new TerrainTile("Bureau Nicole", TileColor.DarkBlue, 26),
                new TerrainTile("Bureau Laure", TileColor.DarkBlue, 30),
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
                // Get name :
                string playerName;

                do
                {
                    Console.WriteLine("What's you name?");
                    playerName = Console.ReadLine();
                } while (playerName == null);

                // Choose pawn
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

                // Add player to the game :
                monopoly.AddPlayer(userInput, playerPawnChoice);
            } while (monopoly.Players.Length < playerNumber);


            // Play, count rounds & keep tracks :
            int roundPlayer = 0;

            while (roundPlayer < roundsNumber) // while game has not exceeded max game rounds
            {
                // Get who's turn it is & where they are :
                Player currentPlayer = monopoly.Players[roundPlayer % monopoly.Players.Length]; // modulo result will always correspond to player's index
                TerrainTile currentTile = monopoly[currentPlayer.Position];

                // Round treatment :
                Console.WriteLine($"{currentPlayer.Name}'s turn. They are with pawn {currentPlayer.Pawn} is on the tile n°{currentTile.Name}.\n Press enter to roll the dice.");
                Console.ReadLine();

                bool playAgain = currentPlayer.Move(diceNumber); // make the player moove & keep track of an eventual double roll
                currentTile = monopoly[currentPlayer.Position]; // update current tile

                // Keep playing while player rolls doubles :
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
