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
            checkWinner();
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
            clickedButton.setMarker(activePlayer.setMarker());

            Console.WriteLine("Activeplayer is: " + activePlayer.setMarker());
           
            activeBoard = CheckActiveboard(ultiBoard.GetSubBoard(clickedButton.ButtonId));

   
        }

        public bool checkButton(int buttonId) 
        {
            if (!this.activeBoard.getButton(buttonId).getMarker().Equals(""))
            {
                throw new ButtonTakenException();
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
                    /*if (checkWinnerHorizontal(board))
                    {
                        Console.WriteLine("Horizontal winner!!");
                        board.disableBoard(true);
                        return true;
                    }
                   
                    else if (checkWinnerVertical(board))
                    {
                        board.disableBoard(true);
                        return true;
                    }*/
                    if (checkWinnerDiagonal(board))
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
            int countForP1 = 0;
            int countForP2 = 0;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    b1 = buttons[y, x];
                    if (b1.getMarker().Equals("X"))
                    {
                        countForP1++;
                        if (countForP1 == 3)
                        {
                            Console.WriteLine("Vertical winner: " + player1.setMarker() + "remove board: "  + board.getId());
                            return true;
                        }
                    } else if (b1.getMarker().Equals("O"))
                    {
                        countForP2++;
                        if(countForP2 == 3)
                        {
                            Console.WriteLine("Vertical winner: " + player2.setMarker() + "remove board: " + board.getId());
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool checkWinnerDiagonal(SubBoard board)
        {
            int countForP1z = 0;
            int countForP2z = 0;
            int countForP1 = 0;
            int countForP2 = 0;
            Button[,] buttons = board.getButtonBoard();
            Button b1;
            int x = 0;

            for (int y = 0; y <= 2; y++)
            {
                b1 = buttons[x, y];
                if (b1.getMarker().Equals("X"))
                {
                    countForP1++;
                    Console.WriteLine(countForP1);
                    if (countForP1 == 3)
                    {
                        Console.WriteLine("Diagonal winner: " + activePlayer.setMarker());
                        return true;
                    }
                } else if (b1.getMarker().Equals("O"))
                {
                    countForP2++;
                    Console.WriteLine(countForP2);
                    if (countForP2 == 3)
                    {
                        Console.WriteLine("Diagonal winner: " + activePlayer.setMarker());
                        return true;
                    }
                }

            }

            for (int y = 0; y <= 2; y++)
            {
                b1 = buttons[2, y];
                if (b1.getMarker().Equals("X"))
                {
                    countForP1z++;
                    Console.WriteLine(countForP1z);
                    if (countForP1z == 3)
                    {
                        Console.WriteLine("Diagonal winner: " + activePlayer.setMarker());
                        return true;
                    }
                }
                else if (b1.getMarker().Equals("O"))
                {
                    countForP2z++;
                    Console.WriteLine(countForP2z);
                    if (countForP2z == 3)
                    {
                        Console.WriteLine("Diagonal winner: " + activePlayer.setMarker());
                        return true;
                    }
                }
            }
            return false;

        }

        public bool checkWinnerHorizontal(SubBoard board)
        {
            Button[,] buttons = board.getButtonBoard();
            Button b1;
            int countforP1 = 0;
            int countforP2 = 0;

            for (int i = 0; i < 3; i++)
            {
                countforP1 = 0;
                countforP2 = 0;
                for (int j = 0; j < 3; j++)
                {
                    b1 = buttons[i, j];
                    if (b1.getMarker().Equals("X"))
                    {
                        countforP1++;
                        if (countforP1 == 3)
                        {
                            return true;
                        }
                    }
                    if (b1.getMarker().Equals("0"))
                    {
                        countforP2++;
                        if (countforP2 == 3)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
