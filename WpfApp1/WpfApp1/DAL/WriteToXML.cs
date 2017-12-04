using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WpfApp1.BLL;

namespace WpfApp1.DAL
{
    class WriteToXML
    {
        private GameLoop game;
        private XDocument doc = null;
        private string path;

        public WriteToXML()
        {
        }

        public WriteToXML(GameLoop game)
        {
            this.path =  System.IO.Path.GetFullPath(@"..\..\") + "DAL\\SavedData\\test.xml";
            this.game = game;
            this.doc = new XDocument(new XElement("Root"));
        }
        //skicka med object istället för hela gameloop, felhantering
        // använd inte void, returna true lr false
        public void CreateXml()
        {
            this.doc.Root.Add(new XElement("ActivePlayer", game.getActivePlayer().setMarker().ToString()));

            SubBoard[,] subs = game.GetUltimateBoard().getListOfSub();
            var query = from SubBoard item in subs.Cast<SubBoard>()
                        select item;
            
            foreach(SubBoard s in query)
            {
                var X = from Button item in s.getButtonBoard().Cast<Button>()
                          where item.getMarker().Equals("X")
                          select item;
                var O = from Button item in s.getButtonBoard().Cast<Button>()
                        where item.getMarker().Equals("O")
                        select item;

                foreach (Button b in X)
                {
                    this.doc.Root.Add(new XElement("ButtonID-X", b.ButtonId.ToString(), new XAttribute("BoardId", b.BoardId.ToString())));
                }
                foreach (Button b in O)
                {   
                    this.doc.Root.Add(new XElement("ButtonID-O", b.ButtonId.ToString(), new XAttribute("BoardId", b.BoardId.ToString())));
                }
            }
            this.doc.Save(System.IO.Path.GetFullPath(path));
            Console.WriteLine(path);
        }

        public XDocument getFile()
        {
            return this.doc; 
        }

        public void deleteFile()
        {
            if (File.Exists(this.path))
            {
                System.IO.File.Delete(System.IO.Path.GetFullPath(@"..\..\") + "DAL\\SavedData\\test.xml");
            }          
        }
    }
}
