using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.BLL
{
    class Game
    {
        public static SubBoard[,] subBoards = new SubBoard[3, 3];
        public static Player player1;
        public static Player player2;

        static void Main(string[] args)
        {
            int boardId = 1;
            for (int col = 0; col < 3; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    subBoards[col, row] = new SubBoard(getButtonBoard(boardId), boardId);
                    boardId++;
                }
            }

            player1 = new Player("X");
            player2 = new Player("O");
            GameLoop gameLoop = new GameLoop(player1, player2, new UltimateBoard(subBoards));
            gameLoop.run();
        }

        public static Button[,] getButtonBoard(int boardId)
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
