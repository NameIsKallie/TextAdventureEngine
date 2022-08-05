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
            Game game = GameLoader.LoadGame("../../../SampleFile.xml", "Kallie");
            game.Play(1);
            Console.ReadKey();
        }
    }
}
