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
        public GameState(List<string> options)
        {
            this.options = options;
        }
        
        private List<string> options;
        private List<GameState> gameStates;

        public int promptForChoiceFromOptions()
        {
            return CIO.PromptForMenuSelection(options, false);
            
        }


    }
}
