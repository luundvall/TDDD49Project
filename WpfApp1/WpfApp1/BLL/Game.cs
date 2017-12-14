using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DAL;
using WpfApp1.GUI;

namespace WpfApp1.BLL
{
    public class Game
    {
        private Player player1;
        private Player player2;
        private XMLsaver xmlsaver;
        private LoadFromXML loadFromXML;
        private GameLoop gameLoop;
        private UltimateBoard ub;
        private Initable init;


        public Game(UltimateBoard ub, Player player1, Player player2, XMLsaver xmlSaver, LoadFromXML loadFromXML) {
            this.ub = ub; 
            this.player1 = player1;
            this.player2 = player2;
            this.xmlsaver = xmlSaver;
            this.loadFromXML = loadFromXML;

            this.gameLoop = new GameLoop(player1, player2, ub, xmlSaver, loadFromXML);
            
        }

        public GameLoop getGameLoop()
        {
            return this.gameLoop;
        }

         void SetInitable(Initable init)
        {
            this.init = init;
        }

    }
}
