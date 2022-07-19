using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAEngine
{
    public class Game
    {
        private Player player;
        private List<GameState> gameStates;

        public Game(string playerName)
        {
            gameStates = new List<GameState>();
            player = new Player(playerName);
        }

        public void AddGameState(GameState gameState)
        {
            gameStates.Add(gameState);
        }
        public void AddGameStates(List<GameState> gameStates)
        {
            foreach (GameState gameState in gameStates)
            {
                this.gameStates.Add(gameState);
            }
        }

        public void PrintGameStates()
        {
            foreach (GameState gameState in this.gameStates)
            {
                Console.WriteLine(gameState);
            }
        }
    }
}
