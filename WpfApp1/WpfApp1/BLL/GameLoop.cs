using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DAL;

namespace WpfApp1.BLL
{
    [Serializable]
    public class GameLoop
    {
        private UltimateBoard ultiBoard;
        private Player activePlayer;
        private SubBoard activeBoard;
        private Player player1;
        private Player player2;
        private Button clickedButton;
        private XMLsaver xmlsaver;
        private LoadFromXML loadFromXML;
        private Initable init;

        public GameLoop(Player playerX, Player playerO, UltimateBoard ub, XMLsaver xmlsaver, LoadFromXML loadFromXML)
        {
            this.ultiBoard = ub;
            this.activeBoard = ultiBoard.GetSubBoard(1);
            this.activePlayer = playerX;
            this.player1 = playerX;
            this.player2 = playerO;
            this.xmlsaver = xmlsaver;
            this.loadFromXML = loadFromXML; 
        }

        public void SetInitable(Initable init)
        {
            this.init = init;
        }

        public SubBoard getActiveBoard()
        {
            return this.activeBoard; 
        }

        public Player getActivePlayer()
        {
            return this.activePlayer;
        }

        public void setActivePlayer(Player player)
        {
            this.activePlayer = player;
        }

        public Player getPlayer1()
        {
            return this.player1; 
        }

        public Player getPlayer2()
        {
            return this.player2;
        }

        public UltimateBoard GetUltimateBoard()
        {
            return this.ultiBoard;
        }

        public void run(int move)
        {
                Console.WriteLine("Active player is: " + this.activePlayer.setMarker() + ", Activeboard is: " + this.activeBoard.getId());
                clickedButton = this.activeBoard.getButton(move);
                Console.WriteLine("Clicked on button: " + clickedButton.ButtonId + ", on board:  " + clickedButton.BoardId + ", checkWinner: "+checkWinner());
            
                if (!this.activeBoard.getButton(clickedButton.ButtonId).getMarker().Equals(""))
                {
                    Console.WriteLine("Player " + clickedButton.getMarker() + " Clicked on button: " + clickedButton.ButtonId + ", on board:  " + clickedButton.BoardId + " already..");
                }

            if (this.activePlayer.Equals(this.player1))
            {
                this.activePlayer = this.player2;
            }
            else
            {
                this.activePlayer = this.player1;
            }
        }

        public void saveGame()
        {
            this.xmlsaver.CreateXml(this.ultiBoard, this.activePlayer);
        }

        public void deleteGame()
        {
            this.xmlsaver.deleteFile();
        }

        public Game resumeGame()
        {   
            try
            {    
            return this.loadFromXML.load();
                
            } catch (NoFileFoundException message)
            {
                
            }
            return init.Init(); 
        }

        public bool gameExists()
        {   
              return this.loadFromXML.fileExists();
        }

        public void setMove()
        { 
            activeBoard.NumberOfMoves();
            checkNumberOfMoves();
            checkWinner();

            clickedButton.setMarker(this.activePlayer.setMarker());

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
                    SubBoard board = listOfBoards[y,x];
                    
                    if (checkWinnerHorizontal(board))
                    {
                        Console.WriteLine("Horizontal winner!!");
                        board.disableBoard(true);
                        return true;
                    }
                    
                    else if (checkWinnerVertical(board))
                    {
                        Console.WriteLine("Vertical winner!!");
                        board.disableBoard(true);
                        return true;
                    }
                    
                    else if
                        (checkWinnerDiagonal(board))
                    {
                        Console.WriteLine("Diagonal 1 winner!!");
                        board.disableBoard(true);
                        
                        return true;
                    } else 
                    if (checkDiagonalWinner2(board))
                    {
                        Console.WriteLine("Diagonal 2 winner!!");
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
                countForP2 = 0;
                countForP1 = 0;
                for (int y = 0; y < 3; y++)
                {
                    b1 = buttons[y, x];
                    if (b1.getMarker().Equals("X"))
                    {
                        countForP1++;
                        if (countForP1 == 3)
                        {
                            countForP1 = 0;
                            Console.WriteLine("Vertical winner: " + player1.setMarker() + "remove board: "  + board.getId());
                            board.disableBoard(true);
                            return true;
                        }
                    }

                    if (b1.getMarker().Equals("O"))
                        countForP2++;
                        if(countForP2 == 3)
                        {
                            countForP2 = 0;
                            Console.WriteLine("Vertical winner: " + player2.setMarker() + "remove board: " + board.getId());
                            board.disableBoard(true);
                            return true;
                        }
                }
            }
            return false;
        }

        public bool checkWinnerDiagonal(SubBoard board)
        {
            int countForP1 = 0;
            int countForP2 = 0;
            Button[,] buttons = board.getButtonBoard();
            Button b1;
            int x = 0;

            for (int y = 0; y <= 2; y++)
            {
                b1 = buttons[y, y];
                
                if (b1.getMarker().Equals("X"))
                {
                    countForP1++;
                    if (countForP1 == 3)
                    {
                        countForP1 = 0;
                        Console.WriteLine("Diagonal winner: " + activePlayer.setMarker());
                        board.disableBoard(true);
                        return true;
                    }
                }

                if (b1.getMarker().Equals("O"))
                {
                    countForP2++;
                    if (countForP2 == 3)
                    {
                        countForP2 = 0;
                        Console.WriteLine("Diagonal winner: " + activePlayer.setMarker());
                        board.disableBoard(true);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool checkDiagonalWinner2(SubBoard board)
        {
            Button[,] buttons = board.getButtonBoard();
            Button b1;
            int countForP1z = 0;
            int countForP2z = 0;
            int row = 0;
            for (int y = 2; y >= 0; y--)
            {
                b1 = buttons[row, y];
                row++;
                if (b1.getMarker().Equals("X"))
                {
                    countForP1z++;
                    if (countForP1z == 3)
                    {
                        countForP1z = 0;
                        board.disableBoard(true);
                        return true;
                    }
                }

                if (b1.getMarker().Equals("O"))
                {
                    countForP2z++;
                    if (countForP2z == 3)
                    {
                        countForP2z = 0;
                        board.disableBoard(true);
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
                            countforP1 = 0;
                            board.disableBoard(true);
                            return true;
                        }
                    }
                    if (b1.getMarker().Equals("O"))
                    {
                        countforP2++;
                        if (countforP2 == 3)
                        {
                            countforP2 = 0;
                            board.disableBoard(true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
