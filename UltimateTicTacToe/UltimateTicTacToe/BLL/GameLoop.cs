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
            this.winner = false;
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
            
            while (!this.winner || !player1.GetPlayerIsWinner() || !player2.GetPlayerIsWinner())
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

                Console.WriteLine("Active player is : " + activePlayer.setMarker() +  " Active board is: " + this.activeBoard.Id);
                int move = Convert.ToInt32(Console.ReadLine());
                    Button setButton = this.activeBoard.GetButton(move);
                    Console.WriteLine("Selected button: " + setButton.Id + " on board: " + setButton.getBoardId());

                if (!this.activeBoard.GetButton(setButton.Id).GetIsTaken().Equals(""))
                { 
                    Console.WriteLine("Button " + activeBoard.GetButton(move).Id + " is already taken by Player: " + ub.getBoardSelf().GetSubBoard(move).GetButton(move).GetIsTaken() + " in board: " + ub.getBoardSelf().GetSubBoard(move).GetButton(move).getBoardId());
                }
                else
                {
                        this.activeBoard.GetButton(move).SetIsTaken(activePlayer.setMarker());
                        activeBoard = ub.GetSubBoard(move);
                        this.activePlayer.PlayerIsWinner(checkWinner());
                        Console.WriteLine("any winner: " + this.activePlayer.GetPlayerIsWinner());
                }
            }
          
        }

        public bool checkWinner()
        {
            if(checkWinnerVertical())
            {
                return true;
            } else if (checkWinnerHorizontal())
            {
                return true;
            } else if(checkWinnerDiagonal())
            {
                return true;
            }
            return false;
        }

        public bool checkWinnerVertical()
        {
            Button[,] listOfButtons = activeBoard.getButtonList();

            Button b1;
            int count = 0;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    b1 = listOfButtons[y, x];
                    if (b1.GetIsTaken().Equals(activePlayer.setMarker()))
                    {
                        count++;
                        if (count == 3)
                        {
                            Console.WriteLine("Vertical winner : " + activePlayer.setMarker());
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool checkWinnerDiagonal()
        {
            Button[,] listOfButtons = activeBoard.getButtonList();
            Button b1;
            int x = 0;
            int count159 = 0;
            for (int y = 0; y <= 2; y++)
            {
                b1 = listOfButtons[x, y];
                if(b1.GetIsTaken().Equals(activePlayer.setMarker()))
                {
                    count159++;
                    if(count159 ==3 )
                    {
                        Console.WriteLine("Diagonal winner : " + activePlayer.setMarker());
                        return true;
                    }
                }
                x++;         
            }

            int xx = 2;
            int count357 = 0;
            for (int y = 0; y <= 2; y++)
            {
                b1 = listOfButtons[xx, y];
                if (b1.GetIsTaken().Equals(activePlayer.setMarker()))
                {
                    count357++;
                    if (count357 == 3)
                    {
                        Console.WriteLine("Diagonal winner : " + activePlayer.setMarker());
                        return true;
                    }
                }
                xx--;
            }
            return false;

        }

        public bool checkWinnerHorizontal()
        {
            Button[,] listOfButtons = activeBoard.getButtonList();

            Button b1;
            int count = 0;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    b1 = listOfButtons[x, y];
                    if (b1.GetIsTaken().Equals(activePlayer.setMarker()))
                    {
                        count++;
                        if (count == 3)
                        {
                            Console.WriteLine("Horizontal winner : " + activePlayer.setMarker());
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}
