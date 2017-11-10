using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToe.BLL
{
    class UltimateBoard : InterfaceBoard<UltimateBoard>
    {
        private SubBoard[,] subBoards = new SubBoard[3, 3];
        private string TypeOfBoard;

        public UltimateBoard(SubBoard s1)
        {
            this.TypeOfBoard = "Ultimate board";
            int id = 0;
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    id++;
                    subBoards[row, column] = new SubBoard(id);
                }
            }
        }

        public UltimateBoard getBoardSelf()
        {
            return this;
        }

        public UltimateBoard[] getPostion(int id)
        {
            return null;
        }

        public SubBoard GetSubBoard(int move)
        {

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    SubBoard subBoard = subBoards[row, column];
                    if (subBoard.Id.Equals(move))
                    {
                        return subBoard;
                        break;
                    }
                }
            }

            return null;
        }

        public string getTypeOfBoard()
        {
            return this.TypeOfBoard;
        }

        public SubBoard[,] getBoardList()
        {
            return this.subBoards;    
        }
    }
}
