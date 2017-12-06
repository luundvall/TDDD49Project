using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using WpfApp1.BLL;

namespace WpfApp1.DAL
{
   public class LoadFromXML
    {
        private string path;

        public LoadFromXML()
        {
            this.path = System.IO.Path.GetFullPath(@"..\..\") + "DAL\\SavedData\\test.xml";
        }

        public Game load()
        {
            Game game = new Game();
            try
            {
                
                XDocument loadedFile = XDocument.Load(System.IO.Path.GetFullPath(@"..\..\") + "DAL\\SavedData\\test.xml");
                if (loadedFile == null)
                {
                    throw new NoFileFoundException("No file to be found in the file system");
                }
                
                var q = from b in loadedFile.Descendants("Root")
                        select new
                        {
                            ActivePlayer = (string)b.Element("ActivePlayer"),
                        };

                foreach(var Ap in q)
                {
                   String Active = Ap.ToString();
                    if(game.getGameLoop().getPlayer1().setMarker().Equals(Active))
                    {
                        game.getGameLoop().setActivePlayer(game.getGameLoop().getPlayer1());
                    } else
                    {
                        game.getGameLoop().setActivePlayer(game.getGameLoop().getPlayer2());
                    }
                }

                    var allO = from b in loadedFile.Descendants("ButtonID-O")
                           select new
                           {
                               buttonId = (string)b.Value,
                               boardId = (string)b.Attribute("BoardId").Value

                           };

                var allX = from b in loadedFile.Descendants("ButtonID-X")
                           select new
                           {
                               buttonId = (string)b.Value,
                               boardId = (string)b.Attribute("BoardId").Value
                           };

                foreach (var s in allX)
                {
                    Player playerX = new Player("X");
                    int board = int.Parse(s.boardId);
                    int button = int.Parse(s.buttonId);
                    game.getGameLoop().GetUltimateBoard().GetSubBoard(board).getButton(button).setMarker("X");
                    Console.WriteLine("setted marker X on " + board + ", on button " + button);
                }

                
                foreach (var r in allO)
                {
                    Player playerO = new Player("O");
                    int board = int.Parse(r.boardId);
                    int button = int.Parse(r.buttonId);
                    game.getGameLoop().GetUltimateBoard().GetSubBoard(board).getButton(button).setMarker("O");
                    Console.WriteLine("setted marker X on " + board + ", on button " + button);
                }

             
                return game;
            } catch (Exception ex)
            {
                if (ex is NoFileFoundException)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return game;
        }

        public bool fileExists()
        {
            if(File.Exists(this.path))
            {
                return true;
            }
            return false; 
        }
    }
}
