
using Monopoly.Enums;
using Monopoly.Models;


namespace Monopoly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create game & boardgame (co-dependants)
            Tile[] board =
            {
                new Tile("Start"),
                new TerrainTile("Patio", TileColor.Brown, 20),
                new TerrainTile("Reception", TileColor.Brown, 23),
                new TerrainTile("Right elevator", TileColor.LightBlue, 26),
                new TerrainTile("Left elevator", TileColor.LightBlue, 26),
                new TerrainTile("Ground floor toilets", TileColor.LightBlue, 30),
                new Tile("Prison"),
                new TerrainTile("4th floor corridor", TileColor.Violet, 32),
                new TerrainTile("5th floor corridor", TileColor.Violet, 32),
                new TerrainTile("5th floor toilets", TileColor.Violet, 38),
                new TerrainTile("WAD classroom", TileColor.Orange, 42),
                new TerrainTile("WEB classroom", TileColor.Orange, 42),
                new TerrainTile("GAMES classroom", TileColor.Orange, 48),
                new Tile("Free parking"),
                new TerrainTile("Sonias's office", TileColor.DarkBlue, 26),
                new TerrainTile("Nicole's office", TileColor.DarkBlue, 26),
                new TerrainTile("Laure's office", TileColor.DarkBlue, 30),
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

                string userInput;

                foreach (string pawn in pawnList)
                {
                    Console.WriteLine($"\t- {pawn}");
                }

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
                // Get who's turn it is & where they currently are :
                Player currentPlayer = monopoly.Players[roundPlayer % monopoly.Players.Length]; // modulo result will always correspond to player's index
                Tile currentTile = monopoly[currentPlayer.Position];

                // Round treatment :
                Console.WriteLine($"{currentPlayer.Name}'s turn. They are with pawn {currentPlayer.Pawn} is on the tile {currentTile.Name}.\n Press enter to roll the dice.");

                TerrainTile terrainTile; // every instance of TerrainTile is polymorph because it can be stored in a variable of TerrainTile Type AND Tyle Type.
                if (currentTile is TerrainTile)
                {
                    terrainTile = (TerrainTile)currentTile; // here terrainTile is reassigned to a value of Tile type (currentTile is a Tile(), not a TerrainTile())
                    Console.WriteLine($"You are on the property of {((terrainTile.Owner is null) ? "no one." : $"{terrainTile.Owner.Name}")}");
                }

                currentTile.RemoveVisitor(currentPlayer); // remove player from tile BEFORE getting currentTile again
                bool playAgain = currentPlayer.Move(diceNumber); // make the player moove & keep track of an eventual double roll
                currentTile = monopoly[currentPlayer.Position]; // update current tile

                // Keep playing while player rolls doubles :
                while (playAgain)
                {
                    Console.WriteLine("Great! Double!");
                    Console.WriteLine($"Player {currentPlayer.Name} with pawn {currentPlayer.Pawn} is on the tile {currentTile.Name}.");

                    if (currentTile is TerrainTile)
                    {
                        terrainTile = (TerrainTile)currentTile;
                        Console.WriteLine($"You are on the property of {((terrainTile.Owner is null) ? "no one." : $"{terrainTile.Owner.Name}")}");
                    }

                    currentTile.RemoveVisitor(currentPlayer);
                    playAgain = currentPlayer.Move(diceNumber);
                    currentTile = monopoly[currentPlayer.Position];
                    currentTile.AddVisitor(currentPlayer);
                }

                Console.WriteLine($"Player {currentPlayer.Name} with pawn {currentPlayer.Pawn} is on the tile {currentTile.Name}.");
                
                if (currentTile is TerrainTile)
                {
                    terrainTile = (TerrainTile)currentTile;
                    Console.WriteLine($"You are on the property of {((terrainTile.Owner is null) ? "no one." : $"{terrainTile.Owner.Name}")}");
                }

                // Next round :
                roundPlayer++;
            }

        }
    }
}
