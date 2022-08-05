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
        private Dictionary<int, GameState> gameStates;

        public Game(string playerName)
        {
            gameStates = new Dictionary<int, GameState>();
            player = new Player(playerName);
        }

        public void AddGameState(KeyValuePair<int, GameState> gameState)
        {
            gameStates.Add(gameState.Key, gameState.Value);
        }
        public void AddGameStates(Dictionary<int, GameState> gameStates)
        {
            foreach (KeyValuePair<int, GameState> gameState in gameStates)
            {
                this.AddGameState(gameState);
            }
        }

        public void Play(int begID)
        {
            bool gameEnd = false;
            int curID = begID;

            do
            {
                GameState curGameState;
                if(gameStates.TryGetValue(curID, out curGameState))
                {
                    curGameState.PrintMessage();
                    if (Math.Abs(curID) != curID) 
                    {
                        gameEnd = true;
                    }
                    else
                    { 
                        curID = curGameState.PromptForChoiceFromOptions();
                    }
                }

            } while (!gameEnd);
        }






        public void PrintGameStates()
        {
            foreach (KeyValuePair<int, GameState> gameState in this.gameStates)
            {
                Console.WriteLine(gameState.Value);
            }
        }
    }
}
