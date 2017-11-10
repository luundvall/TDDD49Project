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
        private Player activePlayer;
        private UltimateBoard ub;
        bool turn;
        private int id;
        bool winner;
        SubBoard activeBoard;

        public GameLoop()
        {
            this.winner = true;
            this.activePlayer = player1;
            ub = new UltimateBoard(new SubBoard(id));
            this.activeBoard = ub.GetSubBoard(1);
            createComponents();
        }

        public void createComponents()
        {
            player1 = new Player("X", this);
            player2 = new Player("O", this);
        }

        public void run()
        {
            
           
           
            
            while (this.winner)
            {

                if (turn)
                {
                    activePlayer = player2;
                    turn = false;
                }
                else
                {
                    activePlayer = player1;
                    turn = true;
                }

                Console.WriteLine("Active player is : " + activePlayer.setMarker() +  " Active board is: " + activeBoard.Id);
                int move = Convert.ToInt32(Console.ReadLine());

                Button setButton = activeBoard.GetButton(move);
                ub.GetSubBoard(move).getActiveBoard();
                Console.WriteLine("Selected button: " + setButton.Id + " on board: " + setButton.getBoardId());
                
                if (!activeBoard.GetButton(move).GetIsTaken().Equals(""))
                { 
                    Console.WriteLine("Button " + activeBoard.GetButton(move).Id + " is already taken by Player: " + ub.getBoardSelf().GetSubBoard(move).GetButton(move).GetIsTaken() + " in board: " + ub.getBoardSelf().GetSubBoard(move).GetButton(move).getBoardId());
                }
                else
                {

                        activeBoard = ub.GetSubBoard(move);
                        ub.GetSubBoard(move).GetButton(move).SetIsTaken(activePlayer.setMarker());
                        //activeBoard.setActiveBoard(true);

                    
                }
            }
          
        }

    }
}
