using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleIO;

namespace TAEngine
{
    public class GameState
    {
        public GameState(int id, List<string> options)
        {
            this.id = id;
            this.options = options;
        }
        
        private int id = 0;
        private List<string> options;
        private List<GameState> gameStates;

        public int PromptForChoiceFromOptions()
        {
            return CIO.PromptForMenuSelection(options, false);
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Game State " + id);
            foreach (string option in this.options)
            {
                sb.AppendLine("\t" + option);
            }
            return sb.ToString();
        }

    }
}
