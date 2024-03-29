﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleIO;

namespace TAEngine
{
    public class GameState
    {
        
        private int id = 0;
        private List<string> options;
        private Dictionary<int, GameState> gameStates;
        private string message;
        
        public GameState(int id, List<string> options)
        {
            this.id = id;
            this.options = options;
            this.gameStates = new Dictionary<int, GameState>();
            this.message = "GameState: " + id.ToString();
        }


        public void PrintMessage()
        {
            Console.WriteLine(message);
        }
        public int PromptForChoiceFromOptions()
        {
            int input = CIO.PromptForMenuSelection(options, false);
            int gameStateID = 0;
            if (gameStates.ElementAt(input - 1).Value != null)
            {
                gameStateID = gameStates.ElementAt(input - 1).Value.id;
            }
            return gameStateID;
        }

        public void LinkGameState(int id, ref GameState gameState)
        {
            gameStates.Add(id, gameState);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Game State " + id);
            foreach (string option in this.options)
            {
                sb.AppendLine("\t" + option);
            }
            sb.AppendLine();
            foreach(KeyValuePair<int, GameState> keyValuePair in gameStates)
            {
                sb.AppendLine("\tLinked to GameState " + keyValuePair.Key);
            }

            return sb.ToString();
        }



    }
}
