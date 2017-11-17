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
        private bool isWinner = false;


        public Player (string marker, GameLoop game)
        {
            this.game = game;
            this.marker = marker;
            this.isWinner = isWinner;
       
        }

        public bool GetPlayerIsWinner ()
        {
            return this.isWinner; 
        }

        public void PlayerIsWinner(bool winner)
        {
            this.isWinner = winner;
        }

        internal InterfaceBoard<UltimateBoard> UltimateBoard { get => ultimateBoard; set => ultimateBoard = value; }
        internal InterfaceBoard<SubBoard> SubBoard { get => subBoard; set => subBoard = value; }

        public string setMarker()
        {
            return this.marker;
        }

        

    }
}