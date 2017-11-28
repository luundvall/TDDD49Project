using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WpfApp1.BLL;

namespace WpfApp1.DAL
{
    class WriteToXML
    {
        private GameLoop gameLoop; 

        public WriteToXML(GameLoop gameLoop)
        {
            this.gameLoop = gameLoop;
        }

        public void CreateXml()
        {
            XmlWriter xmlWriter = XmlWriter.Create(System.IO.Path.GetFullPath(@"..\..\") + "DAL\\SavedData\\test.xml");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Players");
            
            xmlWriter.WriteStartElement("Player");
            xmlWriter.WriteAttributeString("Player1", gameLoop.getPlayer1().setMarker().ToString());
            xmlWriter.WriteString(gameLoop.getPlayer1().setMarker().ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Player");
            xmlWriter.WriteAttributeString("Player2", gameLoop.getPlayer2().setMarker().ToString());
            xmlWriter.WriteString(gameLoop.getPlayer1().setMarker().ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Next");
            xmlWriter.WriteStartElement("Active");
            xmlWriter.WriteString(gameLoop.getActivePlayer().setMarker().ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("ClickedButtons");
            gameLoop.GetUltimateBoard().getListOfSub();

            foreach(SubBoard s in gameLoop.GetUltimateBoard().getListOfSub())
            {
                 
                for (int x = 0; x<3; x++)
                { 
                    if(s.getButtonBoard()[x,x].getMarker().Equals("X"))
                    {
                        int ButtonId = s.getButtonBoard()[x, x].ButtonId;
                        String marker = s.getButtonBoard()[x, x].getMarker();
                        xmlWriter.WriteEndElement();
                        
                    }
                }            
            }
            xmlWriter.WriteEndElement();





            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }
    }
}
