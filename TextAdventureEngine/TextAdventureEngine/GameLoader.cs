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
            Dictionary<int, GameState> gameStates = new Dictionary<int, GameState>();
            GenerateGameStates(xmlPath, ref gameStates);
            LinkGameStates(xmlPath, ref gameStates);
            game.AddGameStates(gameStates);
            

            return game;
        }

        private static void GenerateGameStates(string xmlPath, ref Dictionary<int, GameState> gameStates)
        {
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
                    gameStates.Add(id, new GameState(id, options));
                }
            }
        }

        private static void LinkGameStates(string xmlPath, ref Dictionary<int, GameState> gameStates)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(xmlPath);

            foreach (XmlNode stateNode in xDoc.DocumentElement.ChildNodes)
            {
                if(stateNode.Name == "GameState")
                {
                    int id = 0;
                    var attribute = stateNode.Attributes["id"];
                    if(attribute != null)
                    {
                        int.TryParse(attribute.Value, out id);
                    }
                    foreach (XmlNode node in stateNode)
                    {
                        if(node.Name == "LinkedGameStates")
                        {
                            GameState gameState;
                            bool existingState = gameStates.TryGetValue(id, out gameState);
                            if(existingState)
                            {
                                foreach (XmlNode link in node)
                                {
                                    int linkID;
                                    int.TryParse(link.InnerText, out linkID);
                                    if(linkID != 0)
                                    {
                                        gameState.LinkGameState(linkID, ref gameState);
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }

    }
}
