using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TAEngine
{
    public static class GameLoader
    {
        public static Game LoadGame(string xmlPath, string playerName)
        {
            Game game = new Game(playerName);

            game.AddGameStates(GenerateGameStates(xmlPath));

            return game;
        }

        private static List<GameState> GenerateGameStates(string xmlPath)
        {
            List<GameState> gameStates = new List<GameState>();
            
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(xmlPath);

            foreach (XmlNode stateNode in xDoc.DocumentElement.ChildNodes)
            {
                if (stateNode.Name == "GameState")
                {
                    int id = 0;
                    var attribute = stateNode.Attributes["id"];
                    if (attribute != null)
                    {
                        int.TryParse(attribute.Value, out id);
                    }

                    List<string> options = new List<string>();
                    foreach (XmlNode node in stateNode)
                    {
                        if(node.Name == "Options")
                        {
                            foreach (XmlNode option in node)
                            {
                                options.Add(option.InnerText);
                            }
                        }
                    }
                    gameStates.Add(new GameState(id, options));
                }
            }


            return gameStates;

        }

    }
}
