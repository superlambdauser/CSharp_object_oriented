using Monopoly.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models
{
    internal class Game
    {

        private List<Player> _players;
        private List<Tile> _board;

        public Player[] Players
        {
            get
            {
                return _players.ToArray();
            }
        }
        public Tile[] Board
        {
            get
            {
                return _board.ToArray();
            }
            // true read only : no private set
        }

        // Indexers :
        // An indexer that returns a Tile from its "number" (place) on the board
        public Tile this[int numTile]
        {
            get
            {
                numTile %= _board.Count; // when overflowing, the max num of the board tiles : start from the beginning again
                return _board[numTile];
            }
        }

        // An indexer that returns a Player from its Pawn :
        public Player? this[Pawn pawn] // player is nullable? if no player chose the pawn
        {
            get
            {
                foreach (Player player in _players)
                {
                    if (player.Pawn == pawn) return player;
                }
                return null;
            }
        }

        public Game(Tile[] tileProp) // shortcut for quick constructor : ctor
        {
            _players = new List<Player>();
            _board = new List<Tile>(tileProp);
        }

        public void AddPlayer(string name, Pawn pawn)
        {
            foreach (Player p in _players)
            {
                if (p.Pawn == pawn)
                {
                    Console.WriteLine($"{pawn} is already taken.");
                    return;
                }

            }
            _players.Add(new Player(name, pawn));
        }
    }
}
