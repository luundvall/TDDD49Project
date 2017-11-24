using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.BLL
{
    public class Game
    {
        private SubBoard[,] subBoards = new SubBoard[3, 3];
        private Player player1;
        private Player player2;
        private GameLoop gameLoop;


        public Game() { 
            int boardId = 1;
            for (int col = 0; col < 3; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    subBoards[col, row] = new SubBoard(getButtonBoard(boardId), boardId);
                    boardId++;
                }
            }
            
            
            this.player1 = new Player("X");
            this.player2 = new Player("O");
            this.gameLoop = new GameLoop(player1, player2, new UltimateBoard(subBoards));
        }

        public GameLoop getGameLoop()
        {
            return this.gameLoop;
        }

        public Button[,] getButtonBoard(int boardId)
        {
            Button[,] buttonBoard = new Button[3, 3];

            int buttonId = 1;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    buttonBoard[row, col] = new Button(buttonId, boardId);
                    buttonId++;
                }
            }
            return buttonBoard;
        }
    }
}
