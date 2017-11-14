using System;
using System.Windows.Controls;

namespace UltimateTicTacToe.BLL
{
    class Player
    {
        private string marker;
        private GameLoop game;
        InterfaceBoard<UltimateBoard> ultimateBoard;
        InterfaceBoard<SubBoard> subBoard;


        public Player (string marker, GameLoop game)
        {
            this.game = game;
            this.marker = marker;
       
        }

        internal InterfaceBoard<UltimateBoard> UltimateBoard { get => ultimateBoard; set => ultimateBoard = value; }
        internal InterfaceBoard<SubBoard> SubBoard { get => subBoard; set => subBoard = value; }

        public string setMarker()
        {
            return this.marker;
        }

        

    }
}