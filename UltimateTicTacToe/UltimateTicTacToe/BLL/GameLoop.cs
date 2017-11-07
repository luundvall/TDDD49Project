using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToe.BLL
{
    class GameLoop
    {
        private Player player1;
        private Player player2;
        private UltimateBoard ultimateBoard;

        public void run()
        {
            bool winner = false;
            while(winner)
            {
                Console.WriteLine("Run loop");
            }
        }

        public void createComponents()
        {
            ultimateBoard = new UltimateBoard(this);
            player1 = new Player("X", this);
            player2 = new Player("O", this); 
        }

        public UltimateBoard GetUltimateBoard()
        {
            return this.ultimateBoard;
        }
    }
}
