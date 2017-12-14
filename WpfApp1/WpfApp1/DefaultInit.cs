using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.BLL;
using WpfApp1.DAL;
using WpfApp1.GUI;

namespace WpfApp1
{
    class DefaultInit : GUI.Initable
    {
        public Game Init()
        {
            int boardId = 1;
            SubBoard[,] subBoards = new SubBoard[3, 3];

            for (int col = 0; col < 3; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    subBoards[col, row] = new SubBoard(getButtonBoard(boardId), boardId);
                    boardId++;
                }
            }

            UltimateBoard ub = new UltimateBoard(subBoards);
            Player player1 = new Player("X");
            Player player2 = new Player("O");
            XMLsaver xmlsaver = new XMLsaver();
            LoadFromXML loadFromXML = new LoadFromXML();

            return new Game(ub, player1, player2, xmlsaver, loadFromXML);
        }


        private BLL.Button[,] getButtonBoard(int boardId)
        {
            BLL.Button[,] buttonBoard = new BLL.Button[3, 3];

            int buttonId = 1;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    buttonBoard[row, col] = new BLL.Button(buttonId, boardId);
                    buttonId++;
                }
            }
            return buttonBoard;
        }
    }
}
