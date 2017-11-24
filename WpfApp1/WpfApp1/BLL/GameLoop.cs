using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace WpfApp1.BLL
{
    public class GameLoop
    {
        private UltimateBoard ultiBoard;
        private bool winner = false;
        private Player activePlayer = new Player("x");
        private SubBoard activeBoard;
        private Player player1;
        private Player player2;
        private bool turn = false;
        private Button clickedButton; 

        public GameLoop(Player playerX, Player playerO, UltimateBoard ub)
        {
            this.ultiBoard = ub;
            this.activeBoard = ultiBoard.GetSubBoard(1);
            this.activePlayer = playerX;
            this.player1 = playerX;
            this.player2 = playerO;
        }

        public Player getActivePlayer()
        {
            return this.activePlayer;
        }

        public UltimateBoard GetUltimateBoard()
        {
            return this.ultiBoard;
        }


        public void run(int move)
        {

            
            Console.WriteLine("Active player is: " + this.activePlayer.setMarker() + ", Activeboard is: " + this.activeBoard.getId());
                clickedButton = this.activeBoard.getButton(move);
                Console.WriteLine("Clicked on button: " + clickedButton.ButtonId + ", on board:  " + clickedButton.BoardId);
            
                if (!this.activeBoard.getButton(clickedButton.ButtonId).getMarker().Equals(""))
                {
                    Console.WriteLine("Player " + clickedButton.getMarker() + " Clicked on button: " + clickedButton.ButtonId + ", on board:  " + clickedButton.BoardId + " already..");
                }
            
        }

        public void setMove()
        {
            activeBoard.NumberOfMoves();
            checkNumberOfMoves();
            clickedButton.setMarker(activePlayer.setMarker());
            if (turn)
            {
                activePlayer = player1;
                turn = false;
            }
            else
            {
                activePlayer = player2;
                turn = true;
            }
            Console.WriteLine("Activeplayer is: " + activePlayer.setMarker());
            checkWinner();
            activeBoard = CheckActiveboard(ultiBoard.GetSubBoard(clickedButton.ButtonId));

   
        }

        public bool checkButton(int buttonId)
        {
            if (!this.activeBoard.getButton(buttonId).getMarker().Equals(""))
            {
                return true;
            }
            return false; 

        }
        //Check if board is possible to move to
        public SubBoard CheckActiveboard(SubBoard board)
        {
            if(board.getDisable() || board.getNumberOfMoves().Equals(9))
            {
                foreach(SubBoard s in ultiBoard.getListOfSub())
                {
                    if (!s.getDisable())
                    {
                        return s;
                    }
                }
            }
            return board;
        }

        //Removes boards that have no buttons left
        public void checkNumberOfMoves()
        {
            SubBoard[,] listOfBoards = ultiBoard.getListOfSub();

            for(int x = 0; x<3; x++)
            {
                for(int y = 0; y<3; y++)
                {
                    if(listOfBoards[x, y].getNumberOfMoves().Equals(9))
                    {
                        listOfBoards[x, y].disableBoard(true);
                    } 
                }
            }
        }

        public bool checkWinner()
        {
            SubBoard[,] listOfBoards = ultiBoard.getListOfSub();
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    SubBoard board = listOfBoards[x, y];
                    if (checkWinnerHorizontal(board))
                    {
                        board.disableBoard(true);
                        return true;
                    }
                    else if (checkWinnerVertical(board))
                    {
                        board.disableBoard(true);
                        return true;
                    }
                    else if (checkWinnerDiagonal(board))
                    {
                        board.disableBoard(true);
                        return true;
                    }

                }
            }
            return false;
        }

        public bool checkWinnerVertical(SubBoard board)
        {

            Button[,] buttons = board.getButtonBoard();
            Button b1;
            int count = 0;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    b1 = buttons[y, x];
                    if (b1.getMarker().Equals(activePlayer.setMarker()))
                    {
                        count++;
                        if (count == 3)
                        {
                            Console.WriteLine("Vertical winner: " + activePlayer.setMarker() + "remove board: "  + board.getId());
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool checkWinnerDiagonal(SubBoard board)
        {
            Button[,] buttons = board.getButtonBoard();
            Button b1;
            int x = 0;
            int count = 0;
            for (int y = 0; y <= 2; y++)
            {
                b1 = buttons[x, y];
                if (b1.getMarker().Equals(activePlayer.setMarker()))
                {
                    count++;
                    if (count == 3)
                    {
                        Console.WriteLine("Diagonal winner: " + activePlayer.setMarker());
                        return true;
                    }
                }

            }
            return false;

            int xx = 2;
            int count2 = 0;

            for (int y = 0; y <= 2; y++)
            {
                b1 = buttons[xx, y];
                if (b1.getMarker().Equals(activePlayer.setMarker()))
                {
                    count2++;
                    if (count2 == 3)
                    {
                        Console.WriteLine("Diagonal winner: " + activePlayer.setMarker());
                    }
                }
            }

        }

        public bool checkWinnerHorizontal(SubBoard board)
        {
            return false;
        }
    }
}
