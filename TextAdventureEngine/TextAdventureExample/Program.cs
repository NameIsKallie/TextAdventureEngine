using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAEngine;

namespace TextAdventureExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> gameState1Options = new List<string>();
            gameState1Options.Add("Take the left door");
            gameState1Options.Add("Take the right door");


            GameState gameState1 = new GameState(gameState1Options);

            int userInput = gameState1.PromptForChoiceFromOptions();

            Console.WriteLine(userInput);
        }
    }
}
