using System;
using System.Windows.Controls;

namespace UltimateTicTacToe.BLL
{
    class Player
    {
        private string marker;
        private GameLoop game;

        public Player (string marker, GameLoop game)
        {
            this.game = game;
            this.marker = marker;
            
                Console.WriteLine("Creating players.. with marker - " + this.marker);
       
        }

        public int makeMove()
        {
            UltimateBoard  uB = game.GetUltimateBoard();
            Board board = uB.getBoardofBoards[1, 2];
            Button b = board.GetboardButtons[1, 2];
            return 0;

        }

        public string setMarker()
        {
            return this.marker;
        }

    }
}