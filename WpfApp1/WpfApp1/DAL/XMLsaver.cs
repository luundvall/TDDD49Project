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
    public class XMLsaver
    {
        private GameLoop game;
        private XDocument doc = null;
        private string path;

        public XMLsaver()
        {
            this.path =  System.IO.Path.GetFullPath(@"..\..\") + "DAL\\SavedData\\test.xml";
            this.doc = new XDocument(new XElement("Root"));
        }
        public bool CreateXml(UltimateBoard ultiBoard, Player activePlayer)
        {
                this.doc.Root.Add(new XElement("ActivePlayer", activePlayer.setMarker().ToString()));

                SubBoard[,] subs = ultiBoard.getListOfSub();
                var query = from SubBoard item in subs.Cast<SubBoard>()
                            select item;

                    foreach (SubBoard s in query)
                    {
                        var X = from Button item in s.getButtonBoard().Cast<Button>()
                                where item.getMarker().Equals("X")
                                select item;
                        var O = from Button item in s.getButtonBoard().Cast<Button>()
                                where item.getMarker().Equals("O")
                                select item;
                    Console.WriteLine(X.Count().Equals(0) + ", " + X.Count().Equals(0));
    
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
                return true;

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
